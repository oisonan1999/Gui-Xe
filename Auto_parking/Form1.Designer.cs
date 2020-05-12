namespace Auto_parking
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bienso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thoigian_gui = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Thoigian_lay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Bienso,
            this.thoigian_gui,
            this.Thoigian_lay});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(764, 507);
            this.dataGridView1.TabIndex = 28;
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
            // thoigian_gui
            // 
            this.thoigian_gui.DataPropertyName = "thoigian_gui";
            this.thoigian_gui.FillWeight = 145.3297F;
            this.thoigian_gui.HeaderText = "Thời Gian Gửi";
            this.thoigian_gui.Name = "thoigian_gui";
            // 
            // Thoigian_lay
            // 
            this.Thoigian_lay.DataPropertyName = "Thoigian_lay";
            this.Thoigian_lay.HeaderText = "Thời Gian Lấy";
            this.Thoigian_lay.Name = "Thoigian_lay";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 507);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Danh sách phương tiện";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bienso;
        private System.Windows.Forms.DataGridViewTextBoxColumn thoigian_gui;
        private System.Windows.Forms.DataGridViewTextBoxColumn Thoigian_lay;
    }
}