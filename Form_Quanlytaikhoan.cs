using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace HeThongThiTracNghiem
{
    public partial class Form_Quanlytaikhoan : Form
    {
        string connectionString = "Data Source=localhost;Initial Catalog=Hethongthitracnghiem;Integrated Security=True;Trust Server Certificate=True";
        public Form_Quanlytaikhoan()
        {
            InitializeComponent();
        }
        private void Loaddata()
        {
            string sql = @"SELECT maTaiKhoan AS MaTaiKhoan,
                          hoTen AS Hoten,
                          tenDangNhap AS Tendangnhap,
                          matKhau AS Matkhau,
                          vaiTro AS Vaitro,
                          CASE
                              WHEN trangThai = 1 THEN N'Đang hoạt động'
                              ELSE N'Đã khóa'
                          END AS Trangthai
                   FROM TaiKhoan";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();

                adapter.Fill(dt);
                dgvDanhsachtaikhoan.DataSource = dt;
            }
        }
        private void Form_Quanlytaikhoan_Load(object sender, EventArgs e)
        {
            Loaddata();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string hoTen = txtHoten.Text.Trim();
            string tenDangNhap = txtTendangnhap.Text.Trim();
            string matKhau = txtMatkhau.Text.Trim();
            string vaiTro = cboVaitro.Text;
            if (hoTen == "" || tenDangNhap == "" ||
                matKhau == "" || cboVaitro.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
            string sql = @"INSERT INTO TaiKhoan
                   (hoTen, tenDangNhap, matKhau, vaiTro, trangThai)
                   VALUES (@hoTen, @tenDangNhap, @matKhau, @vaiTro, 1)";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@hoTen", hoTen);
                    cmd.Parameters.AddWithValue("@tenDangNhap", tenDangNhap);
                    cmd.Parameters.AddWithValue("@matKhau", matKhau);
                    cmd.Parameters.AddWithValue("@vaiTro", vaiTro);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Thêm tài khoản thành công!");
                Loaddata();
                txtHoten.Clear();
                txtTendangnhap.Clear();
                txtMatkhau.Clear();
                cboVaitro.SelectedIndex = -1;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi khi thêm tài khoản: " + ex.Message);
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDanhsachtaikhoan.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần xóa!");
                return;
            }
            int maTaiKhoan = Convert.ToInt32(
                dgvDanhsachtaikhoan.CurrentRow.Cells["MaTaiKhoan"].Value
            );

            DialogResult kq = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa tài khoản này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (kq == DialogResult.No)
            {
                return;
            }
            string sql = "DELETE FROM TaiKhoan WHERE maTaiKhoan = @maTaiKhoan";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maTaiKhoan", maTaiKhoan);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Xóa tài khoản thành công!");
                Loaddata();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi khi xóa tài khoản: " + ex.Message);
            }
        }
        private void btnLammoi_Click(object sender, EventArgs e)
        {
            Loaddata();
        }
        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            if (dgvDanhsachtaikhoan.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần cập nhật!");
                return;
            }

            int maTaiKhoan = Convert.ToInt32(
                dgvDanhsachtaikhoan.CurrentRow.Cells["MaTaiKhoan"].Value
            );

            string hoTen = txtHoten.Text.Trim();
            string tenDangNhap = txtTendangnhap.Text.Trim();
            string matKhau = txtMatkhau.Text.Trim();
            string vaiTro = cboVaitro.Text.Trim();

            if (hoTen == "" || tenDangNhap == "" ||
                matKhau == "" || cboVaitro.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
            string sql = @"UPDATE TaiKhoan
                   SET hoTen = @hoTen,
                       tenDangNhap = @tenDangNhap,
                       matKhau = @matKhau,
                       vaiTro = @vaiTro
                   WHERE maTaiKhoan = @maTaiKhoan";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@hoTen", hoTen);
                    cmd.Parameters.AddWithValue("@tenDangNhap", tenDangNhap);
                    cmd.Parameters.AddWithValue("@matKhau", matKhau);
                    cmd.Parameters.AddWithValue("@vaiTro", vaiTro);
                    cmd.Parameters.AddWithValue("@maTaiKhoan", maTaiKhoan);
                    conn.Open();
                    int soDong = cmd.ExecuteNonQuery();
                    if (soDong > 0)
                    {
                        MessageBox.Show("Cập nhật tài khoản thành công!");
                        Loaddata();

                        txtHoten.Clear();
                        txtTendangnhap.Clear();
                        txtMatkhau.Clear();
                        cboVaitro.SelectedIndex = -1;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy tài khoản cần cập nhật!");
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi khi cập nhật tài khoản: " + ex.Message);
            }
        }
        private void dgvDanhsachtaikhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            DataGridViewRow row = dgvDanhsachtaikhoan.Rows[e.RowIndex];

            txtHoten.Text = row.Cells["Hoten"].Value?.ToString();
            txtTendangnhap.Text = row.Cells["Tendangnhap"].Value?.ToString();
            txtMatkhau.Text = row.Cells["Matkhau"].Value?.ToString();
            cboVaitro.Text = row.Cells["Vaitro"].Value?.ToString();
            txtTrangthai.Text = row.Cells["Trangthai"].Value?.ToString();
        }
        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string hoTen = txtTimhoten.Text.Trim();
            string maTaiKhoan = txtTimmataikhoan.Text.Trim();
            string sql = @"SELECT maTaiKhoan AS MaTaiKhoan,
                          hoTen AS Hoten,
                          tenDangNhap AS Tendangnhap,
                          matKhau AS Matkhau,
                          vaiTro AS Vaitro,
                          CASE
                              WHEN trangThai = 1 THEN N'Đang hoạt động'
                              ELSE N'Đã khóa'
                          END AS Trangthai
                   FROM TaiKhoan
                   WHERE hoTen LIKE @hoTen
                     AND CAST(maTaiKhoan AS VARCHAR(20)) LIKE @maTaiKhoan";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue(
                        "@hoTen",
                        hoTen == "" ? "%" : "%" + hoTen + "%"
                    );

                    cmd.Parameters.AddWithValue(
                        "@maTaiKhoan",
                        maTaiKhoan == "" ? "%" : "%" + maTaiKhoan + "%"
                    );
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    adapter.Fill(dt);
                    dgvDanhsachtaikhoan.DataSource = dt;
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy tài khoản phù hợp!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Chi tiết lỗi");
            }
        }
        private void btnLock_Click(object sender, EventArgs e)
        {
            if (dgvDanhsachtaikhoan.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần khóa hoặc mở khóa!");
                return;
            }
            int maTaiKhoan = Convert.ToInt32(
                dgvDanhsachtaikhoan.CurrentRow.Cells["MaTaiKhoan"].Value
            );
            string trangThai = dgvDanhsachtaikhoan.CurrentRow.Cells["Trangthai"].Value.ToString();

            int trangThaiMoi;

            if (trangThai == "Đang hoạt động")
            {
                trangThaiMoi = 0;
            }
            else
            {
                trangThaiMoi = 1;
            }
            string hanhDong = trangThaiMoi == 0 ? "khóa" : "mở khóa";

            DialogResult kq = MessageBox.Show(
                "Bạn có chắc chắn muốn " + hanhDong + " tài khoản này không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (kq == DialogResult.No)
            {
                return;
            }
            string sql = @"UPDATE TaiKhoan
                   SET trangThai = @trangThai
                   WHERE maTaiKhoan = @maTaiKhoan";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@trangThai", trangThaiMoi);
                    cmd.Parameters.AddWithValue("@maTaiKhoan", maTaiKhoan);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Đã " + hanhDong + " tài khoản thành công!");
                Loaddata();
                txtHoten.Clear();
                txtTendangnhap.Clear();
                txtMatkhau.Clear();
                txtTrangthai.Clear();
                cboVaitro.SelectedIndex = -1;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi khi khóa/mở khóa tài khoản: " + ex.Message);
            }
        }
    }
    
}

