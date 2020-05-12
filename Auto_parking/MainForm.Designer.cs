namespace Auto_parking
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel_WC = new System.Windows.Forms.Panel();
            this.pictureBox_WC = new System.Windows.Forms.PictureBox();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button7 = new System.Windows.Forms.Button();
            this.panel_VAO = new System.Windows.Forms.Panel();
            this.pictureBox_XeVAO = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_bienso = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.text_BiensoVAO = new System.Windows.Forms.TextBox();
            this.pictureBox_BiensoVAO = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bienso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thoigian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_tong = new System.Windows.Forms.TextBox();
            this.txt_conlai = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.button8 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel_WC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_WC)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel_VAO.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_XeVAO)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_BiensoVAO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 80;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.textBox2.Location = new System.Drawing.Point(309, 104);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(142, 18);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "12/28/2015 12:19:28";
            // 
            // panel_WC
            // 
            this.panel_WC.BackColor = System.Drawing.SystemColors.Control;
            this.panel_WC.Controls.Add(this.pictureBox_WC);
            this.panel_WC.Location = new System.Drawing.Point(457, 272);
            this.panel_WC.Name = "panel_WC";
            this.panel_WC.Size = new System.Drawing.Size(294, 260);
            this.panel_WC.TabIndex = 22;
            // 
            // pictureBox_WC
            // 
            this.pictureBox_WC.BackColor = System.Drawing.Color.Snow;
            this.pictureBox_WC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_WC.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_WC.Name = "pictureBox_WC";
            this.pictureBox_WC.Size = new System.Drawing.Size(294, 260);
            this.pictureBox_WC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_WC.TabIndex = 6;
            this.pictureBox_WC.TabStop = false;
            // 
            // splitter2
            // 
            this.splitter2.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter2.Location = new System.Drawing.Point(0, 533);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(1067, 3);
            this.splitter2.TabIndex = 23;
            this.splitter2.TabStop = false;
            // 
            // splitter1
            // 
            this.splitter1.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(1064, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 533);
            this.splitter1.TabIndex = 24;
            this.splitter1.TabStop = false;
            // 
            // timer3
            // 
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(457, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(288, 125);
            this.tabControl1.TabIndex = 26;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(280, 99);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Gửi Xe";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button4.FlatAppearance.BorderSize = 2;
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(78, 23);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(119, 50);
            this.button4.TabIndex = 23;
            this.button4.Text = "GỬI XE";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button7);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(280, 99);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Lấy Xe";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Transparent;
            this.button7.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button7.FlatAppearance.BorderSize = 2;
            this.button7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.button7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(78, 23);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(119, 50);
            this.button7.TabIndex = 24;
            this.button7.Text = "LẤY XE";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // panel_VAO
            // 
            this.panel_VAO.BackColor = System.Drawing.SystemColors.Control;
            this.panel_VAO.Controls.Add(this.pictureBox_XeVAO);
            this.panel_VAO.Location = new System.Drawing.Point(39, 128);
            this.panel_VAO.Name = "panel_VAO";
            this.panel_VAO.Size = new System.Drawing.Size(412, 402);
            this.panel_VAO.TabIndex = 20;
            // 
            // pictureBox_XeVAO
            // 
            this.pictureBox_XeVAO.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pictureBox_XeVAO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_XeVAO.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_XeVAO.Name = "pictureBox_XeVAO";
            this.pictureBox_XeVAO.Size = new System.Drawing.Size(412, 402);
            this.pictureBox_XeVAO.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_XeVAO.TabIndex = 1;
            this.pictureBox_XeVAO.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_bienso);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.text_BiensoVAO);
            this.groupBox1.Controls.Add(this.pictureBox_BiensoVAO);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(457, 127);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(294, 139);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // txt_bienso
            // 
            this.txt_bienso.Location = new System.Drawing.Point(8, 99);
            this.txt_bienso.Name = "txt_bienso";
            this.txt_bienso.Size = new System.Drawing.Size(121, 24);
            this.txt_bienso.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(8, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Biển số:";
            // 
            // text_BiensoVAO
            // 
            this.text_BiensoVAO.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.text_BiensoVAO.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_BiensoVAO.Location = new System.Drawing.Point(8, 19);
            this.text_BiensoVAO.Multiline = true;
            this.text_BiensoVAO.Name = "text_BiensoVAO";
            this.text_BiensoVAO.ReadOnly = true;
            this.text_BiensoVAO.Size = new System.Drawing.Size(121, 57);
            this.text_BiensoVAO.TabIndex = 0;
            this.text_BiensoVAO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox_BiensoVAO
            // 
            this.pictureBox_BiensoVAO.BackColor = System.Drawing.Color.Gainsboro;
            this.pictureBox_BiensoVAO.Location = new System.Drawing.Point(151, 19);
            this.pictureBox_BiensoVAO.Name = "pictureBox_BiensoVAO";
            this.pictureBox_BiensoVAO.Size = new System.Drawing.Size(137, 104);
            this.pictureBox_BiensoVAO.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_BiensoVAO.TabIndex = 4;
            this.pictureBox_BiensoVAO.TabStop = false;
            this.pictureBox_BiensoVAO.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button3.FlatAppearance.BorderSize = 2;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(39, 39);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(137, 62);
            this.button3.TabIndex = 8;
            this.button3.Text = "CHỤP ẢNH";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.BorderSize = 2;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ImageKey = "(none)";
            this.button2.Location = new System.Drawing.Point(188, 39);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(137, 62);
            this.button2.TabIndex = 7;
            this.button2.Text = "LẤY TỪ ẢNH..";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Bienso,
            this.thoigian});
            this.dataGridView1.Location = new System.Drawing.Point(757, 162);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(307, 323);
            this.dataGridView1.TabIndex = 27;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.FillWeight = 32.84287F;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // Bienso
            // 
            this.Bienso.DataPropertyName = "Bienso";
            this.Bienso.FillWeight = 121.8274F;
            this.Bienso.HeaderText = "Biển Số";
            this.Bienso.Name = "Bienso";
            // 
            // thoigian
            // 
            this.thoigian.DataPropertyName = "thoigian";
            this.thoigian.FillWeight = 145.3297F;
            this.thoigian.HeaderText = "Thời Gian";
            this.thoigian.Name = "thoigian";
            // 
            // txt_tong
            // 
            this.txt_tong.Enabled = false;
            this.txt_tong.Location = new System.Drawing.Point(784, 55);
            this.txt_tong.Name = "txt_tong";
            this.txt_tong.Size = new System.Drawing.Size(40, 22);
            this.txt_tong.TabIndex = 29;
            this.txt_tong.Text = "50";
            // 
            // txt_conlai
            // 
            this.txt_conlai.Enabled = false;
            this.txt_conlai.Location = new System.Drawing.Point(784, 104);
            this.txt_conlai.Name = "txt_conlai";
            this.txt_conlai.Size = new System.Drawing.Size(40, 22);
            this.txt_conlai.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(747, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Tổng số vị trí trong bãi:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(747, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Số vị trí còn lại:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(838, 55);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 23);
            this.button1.TabIndex = 34;
            this.button1.Text = "Sửa";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(838, 54);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(46, 23);
            this.button6.TabIndex = 35;
            this.button6.Text = "Xong";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Visible = false;
            this.button6.Click += new System.EventHandler(this.button6_Click_1);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick_1);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(796, 491);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(231, 33);
            this.button8.TabIndex = 36;
            this.button8.Text = "Danh sách phương tiện đã gửi";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(890, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(162, 156);
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1067, 536);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_conlai);
            this.Controls.Add(this.txt_tong);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.panel_VAO);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel_WC);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Demo";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel_WC.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_WC)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel_VAO.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_XeVAO)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_BiensoVAO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox_WC;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Panel panel_WC;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox text_BiensoVAO;
        private System.Windows.Forms.PictureBox pictureBox_BiensoVAO;
        private System.Windows.Forms.PictureBox pictureBox_XeVAO;
        private System.Windows.Forms.Panel panel_VAO;
        private System.Windows.Forms.TextBox txt_bienso;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bienso;
        private System.Windows.Forms.DataGridViewTextBoxColumn thoigian;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txt_tong;
        private System.Windows.Forms.TextBox txt_conlai;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button button8;
    }
}

