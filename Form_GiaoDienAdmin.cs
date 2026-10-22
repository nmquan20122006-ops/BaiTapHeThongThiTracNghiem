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
            Form_Qlydethi form = new Form_Qlydethi();
            form.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form_NganHangCauHoi form = new Form_NganHangCauHoi();
            form.Show();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form_QuanLyKetQuaThi form = new Form_QuanLyKetQuaThi();
            form.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form_ThongTinQuanLy form = new Form_ThongTinQuanLy();
            form.Show();
            this.Close();
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
    }
}
