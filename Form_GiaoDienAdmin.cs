using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HeThongThiTracNghiem
{
    public partial class Form_GiaoDienAdmin : Form
    {
        public Form_GiaoDienAdmin()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Form_GiaoDienAdmin));
            label6 = new Label();
            label5 = new Label();
            panel4 = new Panel();
            pictureBox3 = new PictureBox();
            panel6 = new Panel();
            pictureBox4 = new PictureBox();
            panel5 = new Panel();
            button6 = new Button();
            button5 = new Button();
            button3 = new Button();
            button2 = new Button();
            button4 = new Button();
            button1 = new Button();
            pictureBox5 = new PictureBox();
            label8 = new Label();
            label7 = new Label();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            label3 = new Label();
            pictureBox2 = new PictureBox();
            label4 = new Label();
            panel3 = new Panel();
            panel1 = new Panel();
            panel4.SuspendLayout();
            ((ISupportInitialize)pictureBox3).BeginInit();
            ((ISupportInitialize)pictureBox4).BeginInit();
            ((ISupportInitialize)pictureBox5).BeginInit();
            ((ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            ((ISupportInitialize)pictureBox2).BeginInit();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.SteelBlue;
            label6.Location = new Point(574, 22);
            label6.Name = "label6";
            label6.Size = new Size(49, 19);
            label6.TabIndex = 5;
            label6.Text = "Admin";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.SteelBlue;
            label5.Location = new Point(40, 26);
            label5.Name = "label5";
            label5.Size = new Size(211, 25);
            label5.TabIndex = 4;
            label5.Text = "TRANG CHỦ HỌC SINH";
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.Controls.Add(label6);
            panel4.Controls.Add(pictureBox3);
            panel4.Controls.Add(label5);
            panel4.Location = new Point(248, 31);
            panel4.Margin = new Padding(3, 2, 3, 2);
            panel4.Name = "panel4";
            panel4.Size = new Size(643, 58);
            panel4.TabIndex = 7;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(498, 1);
            pictureBox3.Margin = new Padding(3, 2, 3, 2);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(98, 56);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 3;
            pictureBox3.TabStop = false;
            // 
            // panel6
            // 
            panel6.BackColor = Color.RoyalBlue;
            panel6.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            panel6.Location = new Point(183, 34);
            panel6.Margin = new Padding(3, 2, 3, 2);
            panel6.Name = "panel6";
            panel6.Size = new Size(1, 74);
            panel6.TabIndex = 4;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(62, 29);
            pictureBox4.Margin = new Padding(3, 2, 3, 2);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(116, 86);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 11;
            pictureBox4.TabStop = false;
            // 
            // panel5
            // 
            panel5.BackColor = Color.RoyalBlue;
            panel5.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            panel5.Location = new Point(26, 456);
            panel5.Margin = new Padding(3, 2, 3, 2);
            panel5.Name = "panel5";
            panel5.Size = new Size(290, 1);
            panel5.TabIndex = 3;
            // 
            // button6
            // 
            button6.BackColor = Color.MidnightBlue;
            button6.FlatAppearance.BorderColor = Color.MidnightBlue;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            button6.Image = (Image)resources.GetObject("button6.Image");
            button6.Location = new Point(50, 479);
            button6.Margin = new Padding(3, 2, 3, 2);
            button6.Name = "button6";
            button6.Size = new Size(214, 46);
            button6.TabIndex = 10;
            button6.Text = "     Đăng Xuất";
            button6.TextImageRelation = TextImageRelation.ImageBeforeText;
            button6.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            button5.BackColor = Color.MidnightBlue;
            button5.FlatAppearance.BorderColor = Color.MidnightBlue;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            button5.Image = (Image)resources.GetObject("button5.Image");
            button5.Location = new Point(50, 150);
            button5.Margin = new Padding(3, 2, 3, 2);
            button5.Name = "button5";
            button5.Size = new Size(213, 46);
            button5.TabIndex = 9;
            button5.Text = "Quản lý đề thi";
            button5.TextImageRelation = TextImageRelation.ImageBeforeText;
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click_1;
            // 
            // button3
            // 
            button3.BackColor = Color.MidnightBlue;
            button3.FlatAppearance.BorderColor = Color.MidnightBlue;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            button3.Image = (Image)resources.GetObject("button3.Image");
            button3.Location = new Point(56, 281);
            button3.Margin = new Padding(3, 2, 3, 2);
            button3.Name = "button3";
            button3.Size = new Size(201, 46);
            button3.TabIndex = 8;
            button3.Text = "Quản lý tài khoản";
            button3.TextImageRelation = TextImageRelation.ImageBeforeText;
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click_1;
            // 
            // button2
            // 
            button2.BackColor = Color.MidnightBlue;
            button2.FlatAppearance.BorderColor = Color.MidnightBlue;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.Location = new Point(50, 214);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(213, 46);
            button2.TabIndex = 7;
            button2.Text = "Quản lý kết quả";
            button2.TextImageRelation = TextImageRelation.ImageBeforeText;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click_1;
            // 
            // button4
            // 
            button4.BackColor = Color.RoyalBlue;
            button4.Location = new Point(42, 166);
            button4.Margin = new Padding(3, 2, 3, 2);
            button4.Name = "button4";
            button4.Size = new Size(0, 0);
            button4.TabIndex = 6;
            button4.Text = "Tổng Quan";
            button4.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.MidnightBlue;
            button1.FlatAppearance.BorderColor = Color.MidnightBlue;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(49, 87);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(214, 46);
            button1.TabIndex = 3;
            button1.Text = "Ngân hàng câu hỏi";
            button1.TextImageRelation = TextImageRelation.ImageBeforeText;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(80, 112);
            pictureBox5.Margin = new Padding(3, 2, 3, 2);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(533, 364);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 13;
            pictureBox5.TabStop = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.SteelBlue;
            label8.Location = new Point(201, 76);
            label8.Name = "label8";
            label8.Size = new Size(241, 19);
            label8.TabIndex = 12;
            label8.Text = "Sẵn sàng chinh phục bài thi hôm nay?";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.SteelBlue;
            label7.Location = new Point(201, 39);
            label7.Name = "label7";
            label7.Size = new Size(168, 25);
            label7.TabIndex = 6;
            label7.Text = "Xin chào,học sinh!";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(26, 5);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(86, 61);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(120, 38);
            label2.Name = "label2";
            label2.Size = new Size(150, 28);
            label2.TabIndex = 1;
            label2.Text = "TRẮC NGHIỆM";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(118, 12);
            label1.Name = "label1";
            label1.Size = new Size(161, 28);
            label1.TabIndex = 0;
            label1.Text = "HỆ THỐNG THI ";
            // 
            // panel2
            // 
            panel2.BackColor = Color.MidnightBlue;
            panel2.Controls.Add(panel5);
            panel2.Controls.Add(button6);
            panel2.Controls.Add(button5);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(button4);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.ForeColor = Color.White;
            panel2.Location = new Point(-35, 33);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(278, 539);
            panel2.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(69, 11);
            label3.Name = "label3";
            label3.Size = new Size(274, 25);
            label3.TabIndex = 3;
            label3.Text = "HỆ THỐNG THI TRẮC NGHIỆM";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(34, 7);
            pictureBox2.Margin = new Padding(3, 2, 3, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(30, 31);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(50, 24);
            label4.Name = "label4";
            label4.Size = new Size(0, 28);
            label4.TabIndex = 3;
            // 
            // panel3
            // 
            panel3.Controls.Add(pictureBox5);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(panel6);
            panel3.Controls.Add(pictureBox4);
            panel3.Location = new Point(248, 90);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(643, 482);
            panel3.TabIndex = 6;
            // 
            // panel1
            // 
            panel1.BackColor = Color.DodgerBlue;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(label4);
            panel1.ForeColor = Color.White;
            panel1.Location = new Point(-35, -2);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(927, 29);
            panel1.TabIndex = 4;
            // 
            // Form_GiaoDienAdmin
            // 
            ClientSize = new Size(895, 578);
            Controls.Add(panel4);
            Controls.Add(panel2);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Name = "Form_GiaoDienAdmin";
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((ISupportInitialize)pictureBox3).EndInit();
            ((ISupportInitialize)pictureBox4).EndInit();
            ((ISupportInitialize)pictureBox5).EndInit();
            ((ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((ISupportInitialize)pictureBox2).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);

        }

        private void Form_GiaoDienAdmin_Load(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show(
        "Bạn có chắc chắn muốn đăng xuất không?",
        "Xác nhận",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Form_DangNhap form = new Form_DangNhap();
                form.Show();
                this.Close();
            }
        }

        private Label label6;
        private Label label5;
        private Panel panel4;
        private PictureBox pictureBox3;
        private Panel panel6;
        private PictureBox pictureBox4;
        private Panel panel5;
        private Button button6;
        private Button button5;
        private Button button3;
        private Button button2;
        private Button button4;
        private Button button1;
        private PictureBox pictureBox5;
        private Label label8;
        private Label label7;
        private PictureBox pictureBox1;
        private Label label2;
        private Label label1;
        private Panel panel2;
        private Label label3;
        private PictureBox pictureBox2;
        private Label label4;
        private Panel panel3;
        private Panel panel1;

        private void button5_Click_1(object sender, EventArgs e)
        {
            Form_Qlydethi form = new Form_Qlydethi();
            form.Show();
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form_QuanLyKetQuaThi form = new Form_QuanLyKetQuaThi();
            form.Show();
            this.Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Form_Quanlytaikhoan form = new Form_Quanlytaikhoan();
            form.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_NganHangCauHoi form = new Form_NganHangCauHoi();
            form.Show();
            this.Close();
        }
    }
}
