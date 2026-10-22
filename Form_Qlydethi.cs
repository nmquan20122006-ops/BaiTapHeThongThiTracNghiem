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
    public partial class Form_Qlydethi : Form
    {
        public string connectionString = "Server=100.78.158.91,1433;Database=HETHONGTHITRACNGHIEM;User Id=NhomHeThongThiTracNghiem;Password=123456;TrustServerCertificate=True;";
        public Form_Qlydethi()
        {
            InitializeComponent();
        }
        private void Loaddata()
        {
            string Sql = @"SELECT d.maDeThi AS MaDe,
                          d.tenDe AS TenDe,
                          d.maMon AS maMon,
                          m.tenMon AS TenMon,
                          d.thoiGianPhut AS ThoiGian,
                          d.soLuongCau AS SoLuongCau,
                          d.ngayCapNhat AS NgayCapNhat
                   FROM DeThi d
                   INNER JOIN MonHoc m ON d.maMon = m.maMon";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(Sql, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvDanhsachdethi.DataSource = dt;
                dgvDanhsachdethi.Columns["maMon"].Visible = false;
            }
        }
        private void LoadMonHoc()
        {
            string sql = "SELECT maMon, tenMon FROM MonHoc";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                cboMonhoc.DataSource = dt;
                cboMonhoc.DisplayMember = "tenMon";
                cboMonhoc.ValueMember = "maMon";
                cboMonhoc.SelectedIndex = -1;
            }
        }
        private void Form_Qlydethi_Load(object sender, EventArgs e)
        {
            Loaddata();
            LoadMonHoc();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string tenDe = txtTendethi.Text.Trim();
            string soCau = txtSocau.Text.Trim();
            string thoiGian = txtThoigian.Text.Trim();
            if (tenDe == "" || soCau == "" ||
                thoiGian == "" || cboMonhoc.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
            int sc, tg;
            if (!int.TryParse(soCau, out sc) ||
                !int.TryParse(thoiGian, out tg))
            {
                MessageBox.Show("Số câu và thời gian phải là số nguyên!");
                return;
            }
            string sql = @"INSERT INTO DeThi
                   (maMon, tenDe, thoiGianPhut, soLuongCau)
                   VALUES (@maMon, @tenDe, @thoiGianPhut, @soLuongCau)";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@maMon", cboMonhoc.SelectedValue);
                    cmd.Parameters.AddWithValue("@tenDe", tenDe);
                    cmd.Parameters.AddWithValue("@thoiGianPhut", tg);
                    cmd.Parameters.AddWithValue("@soLuongCau", sc);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Thêm đề thi thành công!");
                Loaddata();
                txtTendethi.Clear();
                txtSocau.Clear();
                txtThoigian.Clear();
                cboMonhoc.SelectedIndex = -1;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi khi thêm đề thi: " + ex.Message);
            }
        }
        private void dgvDanhsachdethi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            DataGridViewRow row = dgvDanhsachdethi.Rows[e.RowIndex];
            txtTendethi.Text = row.Cells["Tendethi"].Value.ToString();
            txtSocau.Text = row.Cells["SoCau"].Value.ToString();
            txtThoigian.Text = row.Cells["ThoiGian"].Value.ToString();
            cboMonhoc.SelectedValue = row.Cells["maMon"].Value;
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvDanhsachdethi.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn đề thi cần sửa!");
                return;
            }
            int maDeThi = Convert.ToInt32(
                dgvDanhsachdethi.CurrentRow.Cells[0].Value
            );
            string tenDe = txtTendethi.Text.Trim();
            string soCau = txtSocau.Text.Trim();
            string thoiGian = txtThoigian.Text.Trim();
            if (tenDe == "" || soCau == "" || thoiGian == "" ||
                cboMonhoc.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
            int sc, tg;
            if (!int.TryParse(soCau, out sc) ||
                !int.TryParse(thoiGian, out tg) || sc <= 0 || tg <= 0)
            {
                MessageBox.Show("Số câu và thời gian phải là số nguyên dương!");
                return;
            }
            string sql = @"UPDATE DeThi
                   SET maMon = @maMon,
                       tenDe = @tenDe,
                       thoiGianPhut = @thoiGianPhut,
                       soLuongCau = @soLuongCau,
                       ngayCapNhat = GETDATE()
                   WHERE maDeThi = @maDeThi";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@maMon", cboMonhoc.SelectedValue);
                    cmd.Parameters.AddWithValue("@tenDe", tenDe);
                    cmd.Parameters.AddWithValue("@thoiGianPhut", tg);
                    cmd.Parameters.AddWithValue("@soLuongCau", sc);
                    cmd.Parameters.AddWithValue("@maDeThi", maDeThi);

                    conn.Open();
                    int kq = cmd.ExecuteNonQuery();
                    if (kq > 0)
                    {
                        MessageBox.Show("Sửa đề thi thành công!");
                        Loaddata();

                        txtTendethi.Clear();
                        txtSocau.Clear();
                        txtThoigian.Clear();
                        cboMonhoc.SelectedIndex = -1;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy đề thi cần sửa!");
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi khi sửa đề thi: " + ex.Message);
            }
        }
        private void btnLammoi_Click(object sender, EventArgs e)
        {
            Loaddata();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDanhsachdethi.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn đề thi cần xóa!");
                return;
            }
            int maDeThi = Convert.ToInt32(
                dgvDanhsachdethi.CurrentRow.Cells[0].Value
            );

            DialogResult kq = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa đề thi này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (kq == DialogResult.No)
            {
                return;
            }
            string sql = "DELETE FROM DeThi WHERE maDeThi = @maDeThi";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maDeThi", maDeThi);

                    conn.Open();
                    int soDong = cmd.ExecuteNonQuery();

                    if (soDong > 0)
                    {
                        MessageBox.Show("Xóa đề thi thành công!");
                        Loaddata();

                        txtTendethi.Clear();
                        txtSocau.Clear();
                        txtThoigian.Clear();
                        cboMonhoc.SelectedIndex = -1;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy đề thi cần xóa!");
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Không thể xóa đề thi. Có thể đề thi đang được sử dụng trong bảng khác.\n"
                    + ex.Message
                );
            }
        }
        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string tenMon = txtTimtenmon.Text.Trim();
            string maDe = txtTimmadethi.Text.Trim();
            string sql = @"SELECT d.maDeThi AS MaDe,
                          d.tenDe AS TenDe,
                          d.maMon AS maMon,
                          m.tenMon AS TenMon,
                          d.thoiGianPhut AS ThoiGian,
                          d.soLuongCau AS SoLuongCau,
                          d.ngayCapNhat AS NgayCapNhat
                   FROM DeThi d
                   INNER JOIN MonHoc m ON d.maMon = m.maMon
                   WHERE 1 = 1";

            if (tenMon != "")
            {
                sql += " AND m.tenMon LIKE @tenMon";
            }
            if (maDe != "")
            {
                sql += " AND d.maDeThi = @maDe";
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                if (tenMon != "")
                {
                    cmd.Parameters.AddWithValue("@tenMon", "%" + tenMon + "%");
                }
                if (maDe != "")
                {
                    int ma;
                    if (!int.TryParse(maDe, out ma))
                    {
                        MessageBox.Show("Mã đề thi phải là số nguyên!");
                        return;
                    }
                    cmd.Parameters.AddWithValue("@maDe", ma);
                }
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvDanhsachdethi.DataSource = dt;
                dgvDanhsachdethi.Columns["maMon"].Visible = false;
            }
        }
        private void btnThemmon_Click(object sender, EventArgs e)
        {
            string tenMon = txtThemmon.Text.Trim();
            if (tenMon == "")
            {
                MessageBox.Show("Vui lòng nhập tên môn học!");
                return;
            }
            string sql = "INSERT INTO MonHoc (maMon, tenMon) VALUES (@maMon, @tenMon)";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@maMon", tenMon);
                    cmd.Parameters.AddWithValue("@tenMon", tenMon);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Thêm môn học thành công!");
                LoadMonHoc();
                txtThemmon.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi khi thêm môn học: " + ex.Message);
            }
        }
    }
}



