using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Auto_parking.Business;
namespace Auto_parking
{
    public partial class Form1 : Form
    {
        quanliguixe bss = new quanliguixe();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bss.Danhsachxe_tong();
        }
    }
}
