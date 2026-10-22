using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
namespace HeThongThiTracNghiem
{
    public partial class Form_DangNhap : Form
    {
        private const string connectionString = "Server=100.78.158.91,1433;Database=HETHONGTHITRACNGHIEM;User Id=NhomHeThongThiTracNghiem;Password=123456;TrustServerCertificate=True;";
        public Form_DangNhap()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void Form_DangNhap_Load(object sender, EventArgs e)
        {

        }
        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            string tk = guna2TextBox1.Text.Trim();
            string mk = guna2TextBox2.Text.Trim();

            if (tk == "" || mk == "")
            {
                MessageBox.Show("Nhập đầy đủ thông tin để đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT maTaiKhoan, tenDangNhap, matKhau, vaiTro 
                         FROM TaiKhoan 
                         WHERE tenDangNhap = @tendangnhap AND trangThai = 1";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@tendangnhap", tk);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int maTK = Convert.ToInt32(reader["maTaiKhoan"]);
                            string matKhauDb = reader["matKhau"].ToString().Trim();
                            string vaiTro = reader["vaiTro"].ToString().Trim();

                            if (mk == matKhauDb)
                            {
                                MessageBox.Show("Đăng nhập thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                chamthi.MaTaiKhoan = maTK;

                                if (vaiTro == "Thi sinh")
                                {
                                    Form_GiaoDienHocSinh f = new Form_GiaoDienHocSinh();
                                    f.Show();
                                    this.Hide();
                                }
                                else if (vaiTro == "Admin")
                                {
                                    Form_GiaoDienAdmin f = new Form_GiaoDienAdmin();
                                    f.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    MessageBox.Show("Vai trò không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {

                                MessageBox.Show("Sai mật khẩu! Vui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Tài khoản không tồn tại hoặc đã bị khóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}
