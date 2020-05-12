using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.ML;
using Emgu.CV.ML.Structure;
using Emgu.CV.UI;
using Emgu.Util;
using System.Diagnostics;
using Emgu.CV.CvEnum;
using System.IO;
using System.IO.Ports;
using tesseract;
using System.Collections;
using System.Threading;
using Auto_parking.DataAccess;
using Auto_parking.Business;
using ZXing;
using ZXing.Common;
using System.Drawing.Imaging;

namespace Auto_parking
{
    public partial class MainForm : Form
    {
        quanliguixe bss = new quanliguixe();
        public static string giatribienso;
        public static string time;
        DataTable dt = new DataTable();
        private readonly IBarcodeReader barcodeReader;
        public MainForm()
        {
            InitializeComponent();
            barcodeReader = new BarcodeReader();
        }

        List<Image<Bgr, byte>> PlateImagesList = new List<Image<Bgr, byte>>();
        Image Plate_Draw;
        List<string> PlateTextList = new List<string>();
        List<Rectangle> listRect = new List<Rectangle>();
        PictureBox[] box = new PictureBox[12];
        
        public TesseractProcessor full_tesseract = null;
        public TesseractProcessor ch_tesseract = null;
        public TesseractProcessor num_tesseract = null;
        private string m_path = Application.StartupPath + @"\data\";
        private List<string> lstimages = new List<string>();
        private const string m_lang = "eng";

        Capture capture = null;

        private void MainForm_Load(object sender, EventArgs e)
        {
            int soluong;
            int tong;
            tong = int.Parse(txt_tong.Text);
            soluong = int.Parse(bss.so_luong_xe());
            txt_conlai.Text = (tong - soluong).ToString();
            dataGridView1.DataSource = bss.Danhsachxe();
            capture = new Emgu.CV.Capture();
            timer1.Enabled = true;
            full_tesseract = new TesseractProcessor();
            bool succeed = full_tesseract.Init(m_path, m_lang, 3);
            if (!succeed)
            {
                MessageBox.Show("Tesseract initialization failed. The application will exit.");
                Application.Exit();
            }
            full_tesseract.SetVariable("tessedit_char_whitelist", "ABCDEFHKLMNPRSTVXY1234567890").ToString();

            ch_tesseract = new TesseractProcessor();
            succeed = ch_tesseract.Init(m_path, m_lang, 3);
            if (!succeed)
            {
                MessageBox.Show("Tesseract initialization failed. The application will exit.");
                Application.Exit();
            }
            ch_tesseract.SetVariable("tessedit_char_whitelist", "ABCDEFHKLMNPRSTUVXY").ToString();

            num_tesseract = new TesseractProcessor();
            succeed = num_tesseract.Init(m_path, m_lang, 3);
            if (!succeed)
            {
                MessageBox.Show("Tesseract initialization failed. The application will exit.");
                Application.Exit();
            }
            num_tesseract.SetVariable("tessedit_char_whitelist", "1234567890").ToString();


            m_path = System.Environment.CurrentDirectory + "\\";
            string[] ports = SerialPort.GetPortNames();
            for (int i = 0; i < box.Length; i++)
            {
                box[i] = new PictureBox();
            }
        }

        bool success = true;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (success == true)
            {
                success = false;
                new Thread(() =>
                {
                    try
                    {
                        capture.SetCaptureProperty(CAP_PROP.CV_CAP_PROP_FRAME_WIDTH, 640);
                        capture.SetCaptureProperty(CAP_PROP.CV_CAP_PROP_FRAME_HEIGHT, 480);
                        Image<Bgr, byte> cap = capture.QueryFrame();
                        if (cap != null)
                        {
                            MethodInvoker mi = delegate
                            {
                                try
                                {
                                    Bitmap bmp = cap.ToBitmap();
                                    pictureBox_WC.Image = bmp;
                                    pictureBox_WC.Update();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.ToString()); }
                            };
                            if (InvokeRequired)
                                Invoke(mi);
                        }
                    }
                    catch (Exception) { }
                    success = true;
                }).Start();
            
            }
        }

        public void ProcessImage(string urlImage)
        {
            PlateImagesList.Clear();
            PlateTextList.Clear();
            FileStream fs = new FileStream(urlImage, FileMode.Open, FileAccess.Read);
            Image img = Image.FromStream(fs);
            Bitmap image = new Bitmap(img);
            fs.Close();
            FindLicensePlate(image, out Plate_Draw);

        }
        public static Bitmap RotateImage(Image image, float angle)
        {
            if (image == null)
                throw new ArgumentNullException("image");

            PointF offset = new PointF((float)image.Width / 2, (float)image.Height / 2);

            //tao mot bitmap de giu hinh anh sau khi xoay
            Bitmap rotatedBmp = new Bitmap(image.Width, image.Height);
            rotatedBmp.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            //tao mot doi tuong graphic tu bitmap rong
            Graphics g = Graphics.FromImage(rotatedBmp);

            //Dat diem xoay o giua hinh anh
            g.TranslateTransform(offset.X, offset.Y);

            //quay hinh theo goc
            g.RotateTransform(angle);
            g.TranslateTransform(-offset.X, -offset.Y);
            g.DrawImage(image, new PointF(0, 0));

            return rotatedBmp;
        }

        public static string Ocr(Bitmap image_s, bool isFull, TesseractProcessor full_tesseract, TesseractProcessor num_tesseract, TesseractProcessor ch_tesseract, bool isNum = false)
        {
            Image<Gray, byte> image = new Image<Gray, byte>(image_s);
            while (true)
            {
                if ((double)CvInvoke.cvCountNonZero((IntPtr)((UnmanagedObject)image)) / (double)(image.Width * image.Height) <= 0.5)
                    image = image.Dilate(2);
                else
                    break;
            }
            Bitmap bitmap = image.ToBitmap();
            TesseractProcessor tesseractProcessor = !isFull ? (!isNum ? ch_tesseract : num_tesseract) : full_tesseract;
            int num = 0;
            tesseractProcessor.Clear();
            tesseractProcessor.ClearAdaptiveClassifier();
            string str = tesseractProcessor.Apply((Image)bitmap);
            while (str.Length > 3)
            {
                bitmap = new Image<Gray, byte>(bitmap).Erode(2).ToBitmap();
                tesseractProcessor.Clear();
                tesseractProcessor.ClearAdaptiveClassifier();
                str = tesseractProcessor.Apply((Image)bitmap);
                ++num;
                if (num > 10)
                {
                    str = "";
                    break;
                }
            }
            return str;
        }
        public void FindLicensePlate(Bitmap image, out Image plateDraw)
        {
            plateDraw = null;
            Image<Bgr, byte> frame;
            bool isface = false;
            Bitmap src;
            //pictureBox2.Image = new Image<Gray, byte>(image).ToBitmap();
            Image dst = image;
            HaarCascade haar = new HaarCascade(Application.StartupPath + "\\output-hv-33-x25.xml");
            for (float i = 0; i <= 20; i = i + 3)
            {
                for (float s = -1; s <= 1 && s + i != 1; s += 2)
                {
                    src = RotateImage(dst, i * s);
                    PlateImagesList.Clear();
                    frame = new Image<Bgr, byte>(src);
                    using (Image<Gray, byte> grayframe = new Image<Gray, byte>(src))
                    {
                        var faces =
                       grayframe.DetectHaarCascade(haar, 1.1, 8, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(0, 0))[0];
                        foreach (var face in faces)
                        {
                            Image<Bgr, byte> tmp = frame.Copy();
                            tmp.ROI = face.rect;

                            frame.Draw(face.rect, new Bgr(Color.Blue), 2);

                            PlateImagesList.Add(tmp);

                            isface = true;
                        }
                        if (isface)
                        {
                            Image<Bgr, byte> showimg = frame.Clone();
                            plateDraw = (Image)showimg.ToBitmap();
                            if (PlateImagesList.Count > 1)
                            {
                                for (int k = 1; k < PlateImagesList.Count; k++)
                                {
                                    if (PlateImagesList[0].Width < PlateImagesList[k].Width)
                                    {
                                        PlateImagesList[0] = PlateImagesList[k];
                                    }
                                }
                            }
                            PlateImagesList[0] = PlateImagesList[0].Resize(400, 400, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR);
                            return;
                        }
                    }
                }
            }

            
        }
        private void Reconize(string link, out Image hinhbienso, out string bienso, out string bienso_text)
        {
            for (int i = 0; i < box.Length; i++)
            {
                this.Controls.Remove(box[i]);
            }

            hinhbienso = null;
            bienso = "";
            bienso_text = "";
            ProcessImage(link);
            if (PlateImagesList.Count != 0)
            {
                Image<Bgr, byte> src = new Image<Bgr, byte>(PlateImagesList[0].ToBitmap());
                Bitmap grayframe;
                FindContours con = new FindContours();
                Bitmap color;
                int c = con.IdentifyContours(src.ToBitmap(), 50, false, out grayframe, out color, out listRect);
                pictureBox_BiensoVAO.Image = color;
                hinhbienso = Plate_Draw;
                pictureBox_BiensoVAO.Image = grayframe;
                Image<Gray, byte> dst = new Image<Gray, byte>(grayframe);
                grayframe = dst.ToBitmap();
                string zz = "";
                // lọc và sắp xếp số
                List<Bitmap> bmp = new List<Bitmap>();
                List<int> erode = new List<int>();
                List<Rectangle> up = new List<Rectangle>();
                List<Rectangle> dow = new List<Rectangle>();
                int up_y = 0, dow_y = 0;
                bool flag_up = false;

                int di = 0;

                if (listRect == null) return;

                for (int i = 0; i < listRect.Count; i++)
                {
                    Bitmap ch = grayframe.Clone(listRect[i], grayframe.PixelFormat);                    
                    int cou = 0;
                    full_tesseract.Clear();
                    full_tesseract.ClearAdaptiveClassifier();
                    string temp = full_tesseract.Apply(ch);
                    while (temp.Length > 3)
                    {
                        Image<Gray, byte> temp2 = new Image<Gray, byte>(ch);
                        temp2 = temp2.Erode(2);
                        ch = temp2.ToBitmap();
                        full_tesseract.Clear();
                        full_tesseract.ClearAdaptiveClassifier();
                        temp = full_tesseract.Apply(ch);
                        cou++;
                        if (cou > 10)
                        {
                            listRect.RemoveAt(i);
                            i--;
                            di = 0;
                            break;
                        }
                        di = cou;
                    }
                }

                for (int i = 0; i < listRect.Count; i++)
                {
                    for (int j = i; j < listRect.Count; j++)
                    {
                        if (listRect[i].Y > listRect[j].Y + 100)
                        {
                            flag_up = true;
                            up_y = listRect[j].Y;
                            dow_y = listRect[i].Y;
                            break;
                        }
                        else if (listRect[j].Y > listRect[i].Y + 100)
                        {
                            flag_up = true;
                            up_y = listRect[i].Y;
                            dow_y = listRect[j].Y;
                            break;
                        }
                        if (flag_up == true) break;
                    }
                }

                for (int i = 0; i < listRect.Count; i++)
                {
                    if (listRect[i].Y < up_y + 50 && listRect[i].Y > up_y - 50)
                    {
                        up.Add(listRect[i]);
                    }
                    else if (listRect[i].Y < dow_y + 50 && listRect[i].Y > dow_y - 50)
                    {
                        dow.Add(listRect[i]);
                    }
                }

                if (flag_up == false) dow = listRect;

                for (int i = 0; i < up.Count; i++)
                {
                    for (int j = i; j < up.Count; j++)
                    {
                        if (up[i].X > up[j].X)
                        {
                            Rectangle w = up[i];
                            up[i] = up[j];
                            up[j] = w;
                        }
                    }
                }
                for (int i = 0; i < dow.Count; i++)
                {
                    for (int j = i; j < dow.Count; j++)
                    {
                        if (dow[i].X > dow[j].X)
                        {
                            Rectangle w = dow[i];
                            dow[i] = dow[j];
                            dow[j] = w;
                        }
                    }
                }

                int x = 12;
                int c_x = 0;

                for (int i = 0; i < up.Count; i++)
                {
                    Bitmap ch = grayframe.Clone(up[i], grayframe.PixelFormat);
                    Bitmap o = ch;
                    string temp;
                    if (i < 2)
                    {
                        temp = Ocr(ch, false, full_tesseract, num_tesseract, ch_tesseract, true); // nhan dien so
                    }
                    else
                    {
                        temp = Ocr(ch, false, full_tesseract, num_tesseract, ch_tesseract, false); // nhan dien chu
                    }

                    zz += temp;
                    box[i].Location = new Point(x + i * 50, 290);
                    box[i].Size = new Size(50, 100);
                    box[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    box[i].Image = ch;
                    box[i].Update();
                    //this.Controls.Add(box[i]);
                    c_x++;
                }
                zz += "\r\n";
                for (int i = 0; i < dow.Count; i++)
                {
                    Bitmap ch = grayframe.Clone(dow[i], grayframe.PixelFormat);
                    //ch = con.Erodetion(ch);
                    string temp = Ocr(ch, false, full_tesseract, num_tesseract, ch_tesseract, true); // nhan dien so
                    zz += temp;
                    box[i + c_x].Location = new Point(x + i * 50, 390);
                    box[i + c_x].Size = new Size(50, 100);
                    box[i + c_x].SizeMode = PictureBoxSizeMode.StretchImage;
                    box[i + c_x].Image = ch;
                    box[i + c_x].Update();
                }
                bienso = zz.Replace("\n", "");
                bienso = bienso.Replace("\r", "");
                bienso_text = zz;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image (*.bmp; *.jpg; *.jpeg; *.png) |*.bmp; *.jpg; *.jpeg; *.png|All files (*.*)|*.*||";
            dlg.InitialDirectory = Application.StartupPath + "\\HinhBienSo";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }
            string startupPath = dlg.FileName;

            Image temp1;
            string temp2, temp3;
            Reconize(startupPath, out temp1, out temp2, out temp3);
            pictureBox_XeVAO.Image = temp1;
            if (temp3 == "")
                text_BiensoVAO.Text = "Không nhận dạng được biển số.";
            else

            {
                text_BiensoVAO.Text = temp3;
                txt_bienso.Text = text_BiensoVAO.Text.Trim();
                giatribienso = txt_bienso.Text;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (capture != null)
            {
                timer1.Enabled = false;
                pictureBox_XeVAO.Image = null;
                capture.QueryFrame().Save("aa.bmp");
                FileStream fs = new FileStream(m_path + "aa.bmp", FileMode.Open, FileAccess.Read);
                Image temp = Image.FromStream(fs);
                fs.Close();
                pictureBox_XeVAO.Image = temp;
                pictureBox_XeVAO.Update();
                Image temp1;
                string temp2, temp3;
                Reconize(m_path + "aa.bmp", out temp1, out temp2, out temp3);
                pictureBox_XeVAO.Image = temp1;
                if (temp3 == "")
                    text_BiensoVAO.Text = "Không nhận dạng được biển số.";
                else
                {
                    text_BiensoVAO.Text = temp3;
                    txt_bienso.Text = text_BiensoVAO.Text.Trim();
                    giatribienso = txt_bienso.Text;
                
                }

                timer1.Enabled = true;
            }
            
        }

        WEBCAM[] cam = new WEBCAM[3];
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PictureBox p = (PictureBox)sender;
                for (int i = 0; i < cam.Length; i++)
                {
                    if (cam[i] != null && cam[i].status == "run" && cam[i].pb == p.Name)
                    {
                        cam[i].Stop();
                        cam[i] = null;
                    }
                }
                ContextMenu m = new ContextMenu();
                List<string> ls = WEBCAM.get_all_cam();
                for(int i = 0; i<=2 & i < ls.Count; i++)
                {
                    m.MenuItems.Add(ls[i], (s, e2) => {
                        MenuItem menuItem = s as MenuItem;
                        ContextMenu owner = menuItem.Parent as ContextMenu;
                        PictureBox pb = (PictureBox)owner.SourceControl;
                        if (cam[menuItem.Index] != null && cam[menuItem.Index].status == "run")
                        {
                            cam[menuItem.Index].Stop();
                            //cam[menuItem.Index] = null;
                        }
                        cam[menuItem.Index] = new WEBCAM();
                        cam[menuItem.Index].Start(menuItem.Index);
                        cam[menuItem.Index].put_picturebox(pb.Name);
                    });
                }
                m.Show(p, new Point(e.X, e.Y));
            }
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < cam.Length; i++)
                {
                    if (cam[i] != null && cam[i].status == "run" && cam[i].image != null)
                    {
                        MethodInvoker mi = delegate
                        {
                            PictureBox pb = this.Controls.Find(cam[i].pb, true).FirstOrDefault() as PictureBox;
                            pb.Image = cam[i].image;
                            pb.Update();
                            pb.Invalidate();
                        };
                        if (InvokeRequired)
                        {
                            Invoke(mi);
                            return;
                        }
                            
                        PictureBox pb2 = this.Controls.Find(cam[i].pb, true).FirstOrDefault() as PictureBox;
                        pb2.Image = cam[i].image;
                        pb2.Update();
                        pb2.Invalidate();
                    }
                }
            }
            catch (Exception) { }
        }
        private void button4_Click(object sender, EventArgs e)
        {
      
            string a;
            string s = txt_bienso.Text;
            string[] str = s.Split('\n');
            string str2 = null;

            for (int i = 0; i < str.Length - 1; i++)
            {
                str[i] = str[i].Trim();
                str2 += str[i] + "";
            }
            str2 += str[str.Length - 1];
            a = str2.Trim();

            dt = bss.TimKiem(a);
            if(text_BiensoVAO.Text=="" || txt_bienso.Text=="")
            {
                MessageBox.Show("Không được để biển số trống.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Xe đã có trong bãi đỗ xe.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult dlr = MessageBox.Show("Bạn có chắc chắn thông tin xe là: " + a.Trim(), "Thông báo.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    bss.Them(a, time.Trim());
                    string id;
                    id = bss.ktbienso(a.Trim());
                    string vexe;
                    vexe = id + " " + a;
                    bss.Them2(id,a, time.Trim());
                    var barcodeWriter = new BarcodeWriter
                    {
                        Format = BarcodeFormat.QR_CODE,
                        Options = new EncodingOptions
                        {
                            Height = 150,
                            Width = 150,
                            Margin = 0
                        }
                    };

                    string content = vexe;

                    using (var bitmap = barcodeWriter.Write(content))
                    {
                        using (var stream = new MemoryStream())
                        {
                            bitmap.Save(stream, ImageFormat.Png);
                            var image = Image.FromStream(stream);
                            pictureBox1.Image = image;
                        }
                    }
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Title = " Save file...";
                    saveFileDialog1.InitialDirectory = Application.StartupPath + "\\VeXe";
                    saveFileDialog1.DefaultExt = "jpg";
                    saveFileDialog1.FileName = "ve xe " + id;
                    saveFileDialog1.Filter = " Image file (*.PNG)|*.png ";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        pictureBox1.Image.Save(saveFileDialog1.FileName);
                        MessageBox.Show("Đã tiến hành gửi xe có biển kiểm soát: " + a.ToString() + " mã số là: " + id.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        dataGridView1.DataSource = bss.Danhsachxe();
                        text_BiensoVAO.Text = null;
                        txt_bienso.Text = null;
                        int soluong;
                        int tong;
                        tong = int.Parse(txt_tong.Text);
                        soluong = int.Parse(bss.so_luong_xe());
                        txt_conlai.Text = (tong - soluong).ToString();
                        dataGridView1.DataSource = bss.Danhsachxe();
                       
                    }
                    else
                    {
                        MessageBox.Show("Gửi xe chưa thành công. ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            string b;
            string s = txt_bienso.Text;
            string[] str = s.Split('\n');
            string str2 = null;

            for (int i = 0; i < str.Length - 1; i++)
            {
                str[i] = str[i].Trim();
                str2 += str[i] + "";
            }
            str2 += str[str.Length - 1];
            b = str2.Trim();

            string kqqr;
            string[] kq;
            string a;
            string id;
            using (var openDlg = new OpenFileDialog())
            {
                openDlg.Multiselect = false;
                openDlg.InitialDirectory = Application.StartupPath + "\\VeXe";
                if (openDlg.ShowDialog(this) == DialogResult.OK)
                {
                    string fileName = openDlg.FileName;
                    if (!File.Exists(fileName))
                    {
                        return;
                    }

                    var image = (Bitmap)Bitmap.FromFile(fileName);
                    pictureBox1.Image = image;

                    var result = barcodeReader.Decode(image);
                    if (result == null)
                    {
                        result = barcodeReader.Decode(image);
                    }

                    if (result == null)
                    {
                        MessageBox.Show("Không nhận diện được mã QR Code",
                        "QR Code Generator");
                    }
                    else
                    {
                        kqqr= result.Text;
                        kq = kqqr.Split(' ');
                        id = kq[0];
                        a = kq[1];

                        if ((bss.check_bienso(id, a) == true)&&(a==b))
                        {
                            string store_id;
                            string store_bienso;
                            string store_thoigian_gui;
                            string store_thoigian_lay;
                            string tien;                        
                            store_id = id;
                            store_bienso = a;
                            store_thoigian_gui = bss.getThoiGian(id).ToString();
                            store_thoigian_lay = time.Trim();
                            bss.Them_tg_lay(store_thoigian_lay, store_id);
                            tien = bss.kiemtratien(int.Parse(id));
                            MessageBox.Show("Đúng biển kiểm soát: " + a.ToString()+", Mã gửi xe là: "+id.ToString()+", Tiền gửi xe là: "+tien+".", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            bss.xoa(id.Trim());
                            dataGridView1.DataSource = bss.Danhsachxe();
                            text_BiensoVAO.Text = null;
                            txt_bienso.Text = null;
                            int soluong;
                            int tong;
                            tong = int.Parse(txt_tong.Text);
                            soluong = int.Parse(bss.so_luong_xe());
                            txt_conlai.Text = (tong - soluong).ToString();
                            dataGridView1.DataSource = bss.Danhsachxe();
                        }
                        else
                        {
                            MessageBox.Show("Không đúng xe, vui lòng thử lại.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                }
            }


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            txt_tong.Enabled = true;
            button6.Visible = true;
            button1.Visible = false;
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            txt_tong.Enabled = false;
            button6.Visible = false;
            button1.Visible = true;
            int soluong;
            int tong;
            tong = int.Parse(txt_tong.Text);
            soluong = int.Parse(bss.so_luong_xe());
            txt_conlai.Text = (tong - soluong).ToString();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
        }

        private void timer2_Tick_1(object sender, EventArgs e)
        {
            textBox2.Text = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString() + " " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
            time=DateTime.Now.Month.ToString()+"/"+DateTime.Now.Day.ToString()  + "/" + DateTime.Now.Year.ToString() + " " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            Form1 fm = new Form1();
            fm.Show();
        }
    }
}
