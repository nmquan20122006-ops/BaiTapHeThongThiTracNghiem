namespace HeThongThiTracNghiem
{
    partial class Form_LichSuThi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_LichSuThi));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            panel7 = new Panel();
            label10 = new Label();
            panel2 = new Panel();
            icontongbaithi = new PictureBox();
            lbl = new Label();
            lblTongBaiThi = new Label();
            panel3 = new Panel();
            icondiemtb = new PictureBox();
            lbl1 = new Label();
            lblDiemTB = new Label();
            panel4 = new Panel();
            lblDiemCaoNhat = new Label();
            icondiemcaonhat = new PictureBox();
            lbl2 = new Label();
            panel5 = new Panel();
            dtpDenNgay = new DateTimePicker();
            cboTrangThai = new ComboBox();
            dtpTuNgay = new DateTimePicker();
            cboMonHoc = new ComboBox();
            txtTimKiem = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            panel6 = new Panel();
            dgvLichSuThi = new DataGridView();
            button1 = new Button();
            bttnlammoi = new Button();
            button3 = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)icontongbaithi).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)icondiemtb).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)icondiemcaonhat).BeginInit();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLichSuThi).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(panel7);
            panel1.Controls.Add(label10);
            panel1.ForeColor = Color.MidnightBlue;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1184, 90);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(10, 8);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(70, 74);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.RoyalBlue;
            label1.Location = new Point(88, 20);
            label1.Name = "label1";
            label1.Size = new Size(288, 45);
            label1.TabIndex = 0;
            label1.Text = "Quản lý lịch sử thi";
            // 
            // panel7
            // 
            panel7.BackColor = Color.MidnightBlue;
            panel7.Location = new Point(387, 10);
            panel7.Name = "panel7";
            panel7.Size = new Size(1, 73);
            panel7.TabIndex = 9;
            panel7.Paint += panel7_Paint;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 16.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.MidnightBlue;
            label10.Location = new Point(403, 25);
            label10.Name = "label10";
            label10.Size = new Size(155, 40);
            label10.TabIndex = 8;
            label10.Text = "Lịch sử thi";
            label10.Click += label10_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(icontongbaithi);
            panel2.Controls.Add(lbl);
            panel2.Controls.Add(lblTongBaiThi);
            panel2.ForeColor = Color.MidnightBlue;
            panel2.Location = new Point(650, 10);
            panel2.Name = "panel2";
            panel2.Size = new Size(155, 65);
            panel2.TabIndex = 1;
            // 
            // icontongbaithi
            // 
            icontongbaithi.BackColor = Color.AliceBlue;
            icontongbaithi.Image = (Image)resources.GetObject("icontongbaithi.Image");
            icontongbaithi.Location = new Point(7, 7);
            icontongbaithi.Name = "icontongbaithi";
            icontongbaithi.Size = new Size(50, 50);
            icontongbaithi.SizeMode = PictureBoxSizeMode.Zoom;
            icontongbaithi.TabIndex = 11;
            icontongbaithi.TabStop = false;
            // 
            // lbl
            // 
            lbl.AutoSize = true;
            lbl.BackColor = Color.White;
            lbl.ForeColor = Color.Black;
            lbl.Location = new Point(58, 5);
            lbl.Name = "lbl";
            lbl.Size = new Size(92, 20);
            lbl.TabIndex = 0;
            lbl.Text = "Tổng bài thi:";
            // 
            // lblTongBaiThi
            // 
            lblTongBaiThi.AutoSize = true;
            lblTongBaiThi.BackColor = Color.Transparent;
            lblTongBaiThi.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblTongBaiThi.ForeColor = Color.RoyalBlue;
            lblTongBaiThi.Location = new Point(83, 28);
            lblTongBaiThi.Name = "lblTongBaiThi";
            lblTongBaiThi.Size = new Size(27, 31);
            lblTongBaiThi.TabIndex = 12;
            lblTongBaiThi.Text = "0";
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(icondiemtb);
            panel3.Controls.Add(lbl1);
            panel3.Controls.Add(lblDiemTB);
            panel3.ForeColor = Color.MidnightBlue;
            panel3.Location = new Point(815, 10);
            panel3.Name = "panel3";
            panel3.Size = new Size(155, 65);
            panel3.TabIndex = 2;
            // 
            // icondiemtb
            // 
            icondiemtb.BackColor = Color.AliceBlue;
            icondiemtb.Image = (Image)resources.GetObject("icondiemtb.Image");
            icondiemtb.Location = new Point(7, 8);
            icondiemtb.Name = "icondiemtb";
            icondiemtb.Size = new Size(50, 50);
            icondiemtb.SizeMode = PictureBoxSizeMode.Zoom;
            icondiemtb.TabIndex = 13;
            icondiemtb.TabStop = false;
            // 
            // lbl1
            // 
            lbl1.AutoSize = true;
            lbl1.BackColor = Color.White;
            lbl1.ForeColor = Color.Black;
            lbl1.Location = new Point(77, 6);
            lbl1.Name = "lbl1";
            lbl1.Size = new Size(69, 20);
            lbl1.TabIndex = 1;
            lbl1.Text = "Điểm TB:";
            // 
            // lblDiemTB
            // 
            lblDiemTB.AutoSize = true;
            lblDiemTB.BackColor = Color.Transparent;
            lblDiemTB.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblDiemTB.ForeColor = Color.RoyalBlue;
            lblDiemTB.Location = new Point(89, 28);
            lblDiemTB.Name = "lblDiemTB";
            lblDiemTB.Size = new Size(46, 31);
            lblDiemTB.TabIndex = 13;
            lblDiemTB.Text = "0.0";
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.Controls.Add(lblDiemCaoNhat);
            panel4.Controls.Add(icondiemcaonhat);
            panel4.Controls.Add(lbl2);
            panel4.ForeColor = Color.MidnightBlue;
            panel4.Location = new Point(980, 10);
            panel4.Name = "panel4";
            panel4.Size = new Size(180, 65);
            panel4.TabIndex = 3;
            // 
            // lblDiemCaoNhat
            // 
            lblDiemCaoNhat.AutoSize = true;
            lblDiemCaoNhat.BackColor = Color.Transparent;
            lblDiemCaoNhat.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblDiemCaoNhat.ForeColor = Color.RoyalBlue;
            lblDiemCaoNhat.Location = new Point(88, 29);
            lblDiemCaoNhat.Name = "lblDiemCaoNhat";
            lblDiemCaoNhat.Size = new Size(46, 31);
            lblDiemCaoNhat.TabIndex = 14;
            lblDiemCaoNhat.Text = "0.0";
            // 
            // icondiemcaonhat
            // 
            icondiemcaonhat.BackColor = Color.AliceBlue;
            icondiemcaonhat.Image = (Image)resources.GetObject("icondiemcaonhat.Image");
            icondiemcaonhat.Location = new Point(6, 7);
            icondiemcaonhat.Name = "icondiemcaonhat";
            icondiemcaonhat.Size = new Size(50, 50);
            icondiemcaonhat.SizeMode = PictureBoxSizeMode.Zoom;
            icondiemcaonhat.TabIndex = 12;
            icondiemcaonhat.TabStop = false;
            // 
            // lbl2
            // 
            lbl2.AutoSize = true;
            lbl2.BackColor = Color.White;
            lbl2.ForeColor = Color.Black;
            lbl2.Location = new Point(63, 7);
            lbl2.Name = "lbl2";
            lbl2.Size = new Size(109, 20);
            lbl2.TabIndex = 2;
            lbl2.Text = "Điểm cao nhất:";
            // 
            // panel5
            // 
            panel5.BackColor = Color.White;
            panel5.Controls.Add(dtpDenNgay);
            panel5.Controls.Add(cboTrangThai);
            panel5.Controls.Add(dtpTuNgay);
            panel5.Controls.Add(cboMonHoc);
            panel5.Controls.Add(txtTimKiem);
            panel5.Controls.Add(label6);
            panel5.Controls.Add(label5);
            panel5.Controls.Add(label4);
            panel5.Controls.Add(label3);
            panel5.Controls.Add(label2);
            panel5.ForeColor = Color.Black;
            panel5.Location = new Point(15, 105);
            panel5.Name = "panel5";
            panel5.Size = new Size(280, 510);
            panel5.TabIndex = 4;
            // 
            // dtpDenNgay
            // 
            dtpDenNgay.Location = new Point(15, 205);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(250, 27);
            dtpDenNgay.TabIndex = 9;
            dtpDenNgay.ValueChanged += dtpDenNgay_ValueChanged;
            // 
            // cboTrangThai
            // 
            cboTrangThai.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboTrangThai.FormattingEnabled = true;
            cboTrangThai.Location = new Point(15, 285);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(250, 31);
            cboTrangThai.TabIndex = 8;
            cboTrangThai.SelectedIndexChanged += cboTrangThai_SelectedIndexChanged;
            // 
            // dtpTuNgay
            // 
            dtpTuNgay.Location = new Point(15, 125);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(250, 27);
            dtpTuNgay.TabIndex = 7;
            dtpTuNgay.ValueChanged += dtpTuNgay_ValueChanged;
            // 
            // cboMonHoc
            // 
            cboMonHoc.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboMonHoc.FormattingEnabled = true;
            cboMonHoc.Location = new Point(15, 45);
            cboMonHoc.Name = "cboMonHoc";
            cboMonHoc.Size = new Size(250, 31);
            cboMonHoc.TabIndex = 6;
            cboMonHoc.SelectedIndexChanged += cboMonHoc_SelectedIndexChanged;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTimKiem.Location = new Point(15, 365);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(250, 30);
            txtTimKiem.TabIndex = 5;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(15, 335);
            label6.Name = "label6";
            label6.Size = new Size(170, 23);
            label6.TabIndex = 4;
            label6.Text = "Tìm theo tên bài thi";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(15, 255);
            label5.Name = "label5";
            label5.Size = new Size(92, 23);
            label5.TabIndex = 3;
            label5.Text = "Trạng thái";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(15, 175);
            label4.Name = "label4";
            label4.Size = new Size(86, 23);
            label4.TabIndex = 2;
            label4.Text = "Đến ngày";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(15, 95);
            label3.Name = "label3";
            label3.Size = new Size(82, 25);
            label3.TabIndex = 1;
            label3.Text = "Từ ngày";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(15, 15);
            label2.Name = "label2";
            label2.Size = new Size(79, 23);
            label2.TabIndex = 0;
            label2.Text = "Môn học";
            // 
            // panel6
            // 
            panel6.BackColor = Color.White;
            panel6.Controls.Add(dgvLichSuThi);
            panel6.ForeColor = Color.Black;
            panel6.Location = new Point(310, 105);
            panel6.Name = "panel6";
            panel6.Size = new Size(874, 510);
            panel6.TabIndex = 5;
            // 
            // dgvLichSuThi
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.RoyalBlue;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = Color.RoyalBlue;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvLichSuThi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvLichSuThi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLichSuThi.EnableHeadersVisualStyles = false;
            dgvLichSuThi.GridColor = Color.SteelBlue;
            dgvLichSuThi.Location = new Point(3, 3);
            dgvLichSuThi.Name = "dgvLichSuThi";
            dgvLichSuThi.RowHeadersVisible = false;
            dgvLichSuThi.RowHeadersWidth = 51;
            dgvLichSuThi.Size = new Size(871, 510);
            dgvLichSuThi.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackColor = Color.RoyalBlue;
            button1.ForeColor = Color.White;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(650, 635);
            button1.Name = "button1";
            button1.Size = new Size(145, 40);
            button1.TabIndex = 1;
            button1.Text = "Xem chi tiết";
            button1.TextImageRelation = TextImageRelation.ImageBeforeText;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // bttnlammoi
            // 
            bttnlammoi.BackColor = Color.Gray;
            bttnlammoi.ForeColor = Color.White;
            bttnlammoi.Image = (Image)resources.GetObject("bttnlammoi.Image");
            bttnlammoi.Location = new Point(810, 635);
            bttnlammoi.Name = "bttnlammoi";
            bttnlammoi.Size = new Size(140, 40);
            bttnlammoi.TabIndex = 6;
            bttnlammoi.Text = "   Làm mới";
            bttnlammoi.TextImageRelation = TextImageRelation.ImageBeforeText;
            bttnlammoi.UseVisualStyleBackColor = false;
            bttnlammoi.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.DarkBlue;
            button3.ForeColor = Color.White;
            button3.Image = (Image)resources.GetObject("button3.Image");
            button3.Location = new Point(965, 635);
            button3.Name = "button3";
            button3.Size = new Size(150, 40);
            button3.TabIndex = 7;
            button3.Text = "   Quay lại";
            button3.TextImageRelation = TextImageRelation.ImageBeforeText;
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // Form_LichSuThi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(1279, 700);
            Controls.Add(button3);
            Controls.Add(bttnlammoi);
            Controls.Add(button1);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form_LichSuThi";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form_LichSuThi";
            Load += Form_LichSuThi_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)icontongbaithi).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)icondiemtb).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)icondiemcaonhat).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvLichSuThi).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private DataGridView dgvLichSuThi;
        private Button button1;
        private Button bttnlammoi;
        private Button button3;
        private Label label1;
        private ComboBox cboTrangThai;
        private DateTimePicker dtpTuNgay;
        private ComboBox cboMonHoc;
        private TextBox txtTimKiem;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private DateTimePicker dtpDenNgay;
        private Label lbl;
        private Label lbl1;
        private Label lbl2;
        private Panel panel7;
        private Label label10;
        private PictureBox pictureBox1;
        private PictureBox icontongbaithi;
        private PictureBox icondiemtb;
        private PictureBox icondiemcaonhat;
        private Label lblTongBaiThi;
        private Label lblDiemTB;
        private Label lblDiemCaoNhat;
    }
}