namespace HeThongThiTracNghiem
{
    partial class Form_ThongTinQuanLy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ThongTinQuanLy));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            bttnquaylai = new Button();
            bttnluu = new Button();
            bttnsua = new Button();
            dgvDanhSach = new DataGridView();
            pictureBox2 = new PictureBox();
            txtLop = new TextBox();
            label8 = new Label();
            label4 = new Label();
            label7 = new Label();
            txtSoDienThoai = new TextBox();
            txtmhs = new TextBox();
            label3 = new Label();
            label6 = new Label();
            pictureBox3 = new PictureBox();
            label9 = new Label();
            panel3 = new Panel();
            dtpSgaySinh = new DateTimePicker();
            txthovaten = new TextBox();
            label2 = new Label();
            txtEmail = new TextBox();
            txttendangnhap = new TextBox();
            label1 = new Label();
            bttnhuy = new Button();
            panel2 = new Panel();
            label5 = new Label();
            pictureBox1 = new PictureBox();
            label10 = new Label();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSach).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // bttnquaylai
            // 
            bttnquaylai.BackColor = Color.SteelBlue;
            bttnquaylai.ForeColor = Color.White;
            bttnquaylai.Image = (Image)resources.GetObject("bttnquaylai.Image");
            bttnquaylai.Location = new Point(785, 557);
            bttnquaylai.Name = "bttnquaylai";
            bttnquaylai.Size = new Size(130, 42);
            bttnquaylai.TabIndex = 17;
            bttnquaylai.Text = " Quay lại";
            bttnquaylai.TextImageRelation = TextImageRelation.ImageBeforeText;
            bttnquaylai.UseVisualStyleBackColor = false;
            bttnquaylai.Click += bttnquaylai_Click;
            // 
            // bttnluu
            // 
            bttnluu.BackColor = Color.Green;
            bttnluu.ForeColor = Color.White;
            bttnluu.Image = (Image)resources.GetObject("bttnluu.Image");
            bttnluu.Location = new Point(475, 557);
            bttnluu.Name = "bttnluu";
            bttnluu.Size = new Size(110, 42);
            bttnluu.TabIndex = 15;
            bttnluu.Text = "   Lưu";
            bttnluu.TextImageRelation = TextImageRelation.ImageBeforeText;
            bttnluu.UseVisualStyleBackColor = false;
            bttnluu.Click += bttnluu_Click;
            // 
            // bttnsua
            // 
            bttnsua.BackColor = SystemColors.MenuHighlight;
            bttnsua.ForeColor = Color.White;
            bttnsua.Image = (Image)resources.GetObject("bttnsua.Image");
            bttnsua.Location = new Point(295, 557);
            bttnsua.Name = "bttnsua";
            bttnsua.Size = new Size(140, 42);
            bttnsua.TabIndex = 14;
            bttnsua.Text = "Sửa thông tin";
            bttnsua.TextImageRelation = TextImageRelation.ImageBeforeText;
            bttnsua.UseVisualStyleBackColor = false;
            bttnsua.Click += bttnsua_Click;
            // 
            // dgvDanhSach
            // 
            dgvDanhSach.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDanhSach.Location = new Point(-2, 51);
            dgvDanhSach.Name = "dgvDanhSach";
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.HotTrack;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.HotTrack;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvDanhSach.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvDanhSach.RowHeadersVisible = false;
            dgvDanhSach.RowHeadersWidth = 51;
            dgvDanhSach.Size = new Size(548, 429);
            dgvDanhSach.TabIndex = 0;
            dgvDanhSach.CellContentClick += dgvDanhSach_CellContentClick;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(4, -3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(51, 48);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 16;
            pictureBox2.TabStop = false;
            // 
            // txtLop
            // 
            txtLop.Location = new Point(9, 433);
            txtLop.Name = "txtLop";
            txtLop.Size = new Size(304, 27);
            txtLop.TabIndex = 14;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = SystemColors.HotTrack;
            label8.Location = new Point(63, 1);
            label8.Name = "label8";
            label8.Size = new Size(204, 31);
            label8.TabIndex = 0;
            label8.Text = "Thông tin quản lý";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(9, 410);
            label4.Name = "label4";
            label4.Size = new Size(34, 20);
            label4.TabIndex = 13;
            label4.Text = "Lớp";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(9, 51);
            label7.Name = "label7";
            label7.Size = new Size(95, 20);
            label7.TabIndex = 1;
            label7.Text = "Mã tài khoản";
            // 
            // txtSoDienThoai
            // 
            txtSoDienThoai.Location = new Point(9, 376);
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.Size = new Size(304, 27);
            txtSoDienThoai.TabIndex = 12;
            // 
            // txtmhs
            // 
            txtmhs.Location = new Point(9, 80);
            txtmhs.Name = "txtmhs";
            txtmhs.Size = new Size(304, 27);
            txtmhs.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 353);
            label3.Name = "label3";
            label3.Size = new Size(97, 20);
            label3.TabIndex = 11;
            label3.Text = "Số điện thoại";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(9, 117);
            label6.Name = "label6";
            label6.Size = new Size(73, 20);
            label6.TabIndex = 3;
            label6.Text = "Họ và tên";
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(7, 0);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(51, 48);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 17;
            pictureBox3.TabStop = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = SystemColors.HotTrack;
            label9.Location = new Point(64, 6);
            label9.Name = "label9";
            label9.Size = new Size(209, 31);
            label9.TabIndex = 15;
            label9.Text = "Danh sách quản lý";
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(pictureBox3);
            panel3.Controls.Add(label9);
            panel3.Controls.Add(dgvDanhSach);
            panel3.Location = new Point(362, 56);
            panel3.Name = "panel3";
            panel3.Size = new Size(551, 483);
            panel3.TabIndex = 13;
            // 
            // dtpSgaySinh
            // 
            dtpSgaySinh.Location = new Point(9, 313);
            dtpSgaySinh.Name = "dtpSgaySinh";
            dtpSgaySinh.Size = new Size(304, 27);
            dtpSgaySinh.TabIndex = 10;
            // 
            // txthovaten
            // 
            txthovaten.Location = new Point(9, 140);
            txthovaten.Name = "txthovaten";
            txthovaten.Size = new Size(304, 27);
            txthovaten.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 290);
            label2.Name = "label2";
            label2.Size = new Size(74, 20);
            label2.TabIndex = 9;
            label2.Text = "Ngày sinh";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(9, 254);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(304, 27);
            txtEmail.TabIndex = 8;
            // 
            // txttendangnhap
            // 
            txttendangnhap.Location = new Point(9, 201);
            txttendangnhap.Name = "txttendangnhap";
            txttendangnhap.Size = new Size(304, 27);
            txttendangnhap.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 231);
            label1.Name = "label1";
            label1.Size = new Size(46, 20);
            label1.TabIndex = 7;
            label1.Text = "Email";
            // 
            // bttnhuy
            // 
            bttnhuy.BackColor = Color.Red;
            bttnhuy.ForeColor = Color.White;
            bttnhuy.Image = (Image)resources.GetObject("bttnhuy.Image");
            bttnhuy.Location = new Point(625, 557);
            bttnhuy.Name = "bttnhuy";
            bttnhuy.Size = new Size(110, 42);
            bttnhuy.TabIndex = 16;
            bttnhuy.Text = "   Huỷ";
            bttnhuy.TextImageRelation = TextImageRelation.ImageBeforeText;
            bttnhuy.UseVisualStyleBackColor = false;
            bttnhuy.Click += bttnhuy_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(pictureBox2);
            panel2.Controls.Add(txtLop);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(txtSoDienThoai);
            panel2.Controls.Add(txtmhs);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(dtpSgaySinh);
            panel2.Controls.Add(txthovaten);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(txtEmail);
            panel2.Controls.Add(txttendangnhap);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(15, 56);
            panel2.Name = "panel2";
            panel2.Size = new Size(335, 483);
            panel2.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(9, 178);
            label5.Name = "label5";
            label5.Size = new Size(107, 20);
            label5.TabIndex = 5;
            label5.Text = "Tên đăng nhập";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(7, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(48, 39);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.White;
            label10.Location = new Point(71, 0);
            label10.Name = "label10";
            label10.Size = new Size(221, 35);
            label10.TabIndex = 15;
            label10.Text = "Thông tin quản lý";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.HotTrack;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label10);
            panel1.Location = new Point(1, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(912, 42);
            panel1.TabIndex = 11;
            // 
            // Form_ThongTinQuanLy
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(927, 609);
            Controls.Add(bttnquaylai);
            Controls.Add(bttnluu);
            Controls.Add(bttnsua);
            Controls.Add(panel3);
            Controls.Add(bttnhuy);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form_ThongTinQuanLy";
            Text = "Form_ThongTinQuanLy";
            Load += Form_ThongTinQuanLy_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDanhSach).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button bttnquaylai;
        private Button bttnluu;
        private Button bttnsua;
        private DataGridView dgvDanhSach;
        private PictureBox pictureBox2;
        private TextBox txtLop;
        private Label label8;
        private Label label4;
        private Label label7;
        private TextBox txtSoDienThoai;
        private TextBox txtmhs;
        private Label label3;
        private Label label6;
        private PictureBox pictureBox3;
        private Label label9;
        private Panel panel3;
        private DateTimePicker dtpSgaySinh;
        private TextBox txthovaten;
        private Label label2;
        private TextBox txtEmail;
        private TextBox txttendangnhap;
        private Label label1;
        private Button bttnhuy;
        private Panel panel2;
        private Label label5;
        private PictureBox pictureBox1;
        private Label label10;
        private Panel panel1;
    }
}