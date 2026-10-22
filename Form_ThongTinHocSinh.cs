using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HeThongThiTracNghiem
{
    public partial class Form_ThongTinHocSinh : Form
    {
        string connectionString = "Data Source=DESKTOP-3U6O521\\SQLEXPRESS;Initial Catalog=Hethongthitracnghiem;Integrated Security=True;TrustServerCertificate=True;";
        public Form_ThongTinHocSinh()
        {
            InitializeComponent();
        }
        private bool dangSua = false;
        private string tenDangNhapCu = "";
        private string hoTenCu = "";

        private void Form_ThongTinHocSinh_Load(object sender, EventArgs e)
        {
            TaiDanhSachHocSinh();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void TaiDanhSachHocSinh()
        {
            try
            {
                using (SqlConnection conn =
                    new SqlConnection(connectionString))
                {
                    string sql = @"
                        SELECT maTaiKhoan, tenDangNhap,
                               hoTen, vaiTro, trangThai
                        FROM TaiKhoan
                        WHERE vaiTro = 'Thi sinh'
                        ORDER BY maTaiKhoan";

                    using (SqlDataAdapter adapter =
                        new SqlDataAdapter(sql, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvDanhSach.DataSource = dt;
                    }
                }

                // Đặt tiêu đề và độ rộng các cột
                if (dgvDanhSach.Columns.Contains("maTaiKhoan"))
                {
                    dgvDanhSach.Columns["maTaiKhoan"].HeaderText =
                        "Mã Quản Trị Viên";
                    dgvDanhSach.Columns["maTaiKhoan"].Width = 80;
                }

                if (dgvDanhSach.Columns.Contains("tenDangNhap"))
                {
                    dgvDanhSach.Columns["tenDangNhap"].HeaderText =
                        "Tên đăng nhập";
                }

                if (dgvDanhSach.Columns.Contains("hoTen"))
                {
                    dgvDanhSach.Columns["hoTen"].HeaderText =
                        "Họ và tên";
                }

                if (dgvDanhSach.Columns.Contains("vaiTro"))
                {
                    dgvDanhSach.Columns["vaiTro"].HeaderText =
                        "Vai trò";
                }

                if (dgvDanhSach.Columns.Contains("trangThai"))
                {
                    dgvDanhSach.Columns["trangThai"].HeaderText =
                        "Trạng thái";
                    dgvDanhSach.Columns["trangThai"].Width = 90;
                }
                if (dgvDanhSach.Rows.Count > 0)
                {
                    dgvDanhSach.ClearSelection();
                    dgvDanhSach.Rows[0].Selected = true;
                    HienThiThongTin(0);
                }
                else
                {
                    XoaThongTin();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không tải được danh sách học sinh.\n" +
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void XoaThongTin()
        {
            txtmhs.Clear();
            txttendangnhap.Clear();
            txthovaten.Clear();
            txtEmail.Clear();
            txtSoDienThoai.Clear();
            txtLop.Clear();
        }
        private void HienThiThongTin(int index)
        {
            if (index < 0 ||
                index >= dgvDanhSach.Rows.Count)
                return;

            DataGridViewRow row = dgvDanhSach.Rows[index];

            txtmhs.Text =
                row.Cells["maTaiKhoan"].Value?.ToString() ?? "";

            txttendangnhap.Text =
                row.Cells["tenDangNhap"].Value?.ToString() ?? "";

            txthovaten.Text =
                row.Cells["hoTen"].Value?.ToString() ?? "";
            txtEmail.Clear();
            txtSoDienThoai.Clear();
            txtLop.Clear();
        }
        private void ChonHocSinhTheoMa(string ma)
        {
            foreach (DataGridViewRow row in dgvDanhSach.Rows)
            {
                if (row.Cells["maTaiKhoan"].Value != null &&
                    row.Cells["maTaiKhoan"].Value.ToString() == ma)
                {
                    row.Selected = true;

                    dgvDanhSach.CurrentCell =
                        row.Cells["tenDangNhap"];

                    HienThiThongTin(row.Index);
                    break;
                }
            }
        }

        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dangSua)
            {
                MessageBox.Show(
                    "Vui lòng Lưu hoặc Hủy trước khi chọn học sinh khác.");

                return;
            }

            HienThiThongTin(e.RowIndex);
        }

        private void bttnsua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtmhs.Text))
            {
                MessageBox.Show("Vui lòng chọn học sinh cần sửa.");
                return;
            }
            tenDangNhapCu = txttendangnhap.Text;
            hoTenCu = txthovaten.Text;
            dangSua = true;
            txttendangnhap.ReadOnly = false;
            txthovaten.ReadOnly = false;
            bttnsua.Enabled = false;
            bttnluu.Enabled = true;
            bttnhuy.Enabled = true;
            txttendangnhap.Focus();
        }

        private void bttnluu_Click(object sender, EventArgs e)
        {
            if (!dangSua)
                return;

            if (string.IsNullOrWhiteSpace(txttendangnhap.Text))
            {
                MessageBox.Show("Tên đăng nhập không được để trống.");
                txttendangnhap.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txthovaten.Text))
            {
                MessageBox.Show("Họ tên không được để trống.");
                txthovaten.Focus();
                return;
            }

            if (txttendangnhap.Text.Trim().Length > 50)
            {
                MessageBox.Show("Tên đăng nhập tối đa 50 ký tự.");
                return;
            }

            if (txthovaten.Text.Trim().Length > 20)
            {
                MessageBox.Show("Họ tên tối đa 20 ký tự theo database.");
                return;
            }

            try
            {
                using (SqlConnection conn =
                    new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = @"
                UPDATE TaiKhoan
                SET tenDangNhap = @tenDangNhap,
                    hoTen = @hoTen
                WHERE maTaiKhoan = @maTaiKhoan
                  AND vaiTro = 'Thi sinh'";

                    using (SqlCommand cmd =
                        new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add(
                            "@tenDangNhap", SqlDbType.VarChar, 50)
                            .Value = txttendangnhap.Text.Trim();

                        cmd.Parameters.Add(
                            "@hoTen", SqlDbType.NVarChar, 20)
                            .Value = txthovaten.Text.Trim();

                        cmd.Parameters.Add(
                            "@maTaiKhoan", SqlDbType.Int)
                            .Value = int.Parse(txtmhs.Text);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show(
                                "Cập nhật thông tin thành công!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            dangSua = false;

                            txttendangnhap.ReadOnly = true;
                            txthovaten.ReadOnly = true;

                            bttnsua.Enabled = true;
                            bttnluu.Enabled = false;
                            bttnhuy.Enabled = false;

                            TaiDanhSachHocSinh();
                            ChonHocSinhTheoMa(txtmhs.Text);
                        }
                        else
                        {
                            MessageBox.Show(
                                "Không tìm thấy tài khoản thí sinh cần cập nhật.");
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2601 || ex.Number == 2627)
                {
                    MessageBox.Show(
                        "Tên đăng nhập đã tồn tại. Vui lòng chọn tên khác.");
                }
                else
                {
                    MessageBox.Show("Lỗi SQL: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void bttnhuy_Click(object sender, EventArgs e)
        {
            if (dangSua)
            {
                txttendangnhap.Text = tenDangNhapCu;
                txthovaten.Text = hoTenCu;
            }

            dangSua = false;

            txttendangnhap.ReadOnly = true;
            txthovaten.ReadOnly = true;

            bttnsua.Enabled = true;
            bttnluu.Enabled = false;
            bttnhuy.Enabled = false;
        }

        private void bttnquaylai_Click(object sender, EventArgs e)
        {
            if (dangSua)
            {
                DialogResult result = MessageBox.Show(
                    "Bạn đang chỉnh sửa thông tin. Bạn có muốn quay lại không?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                    return;
            }
            Form_LichSuThi lichsuthi = new Form_LichSuThi();
            lichsuthi.Show();
            this.Close();

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
