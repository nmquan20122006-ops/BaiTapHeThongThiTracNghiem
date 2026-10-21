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
    public partial class Form_NganHangCauHoi : Form
    {
        string connString = "Server=100.78.158.91,1433;Database=HETHONGTHITRACNGHIEM;User Id=NhomHeThongThiTracNghiem;Password=123456;TrustServerCertificate=True;";
        public Form_NganHangCauHoi()
        {
            InitializeComponent();
        }
        //
        private void Form_NganHangCauHoi_Load(object sender, EventArgs e)
        {
            LoadComboBoxMonHoc();
            LoadComboBoxLocMon();
            LoadDapAn();
            LoadDoKho();
            LoadCauHoiThuCong();
            LoadThongKeThanhTieuDe();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (cbo_MonHoc.SelectedValue == null ||
                string.IsNullOrWhiteSpace(tbx_DapAnA.Text) ||
                string.IsNullOrWhiteSpace(tbx_DapAnB.Text) ||
                string.IsNullOrWhiteSpace(tbx_DapAnC.Text) ||
                string.IsNullOrWhiteSpace(tbx_DapAnD.Text) ||
                string.IsNullOrWhiteSpace(tbx_NoiDung.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ ");
            }

            string maMon = cbo_MonHoc.SelectedValue.ToString();
            string noiDung = tbx_NoiDung.Text.Trim();
            string dapAnA = tbx_DapAnA.Text.Trim();
            string dapAnB = tbx_DapAnB.Text.Trim();
            string dapAnC = tbx_DapAnC.Text.Trim();
            string dapAnD = tbx_DapAnD.Text.Trim();
            string doKho = cbo_DoKho.SelectedItem.ToString();

            string dapAnDung = "A";

            string cauTruyVan = @"INSERT INTO CauHoi(maMon,doKho,noiDung,dapAnA,dapAnB,dapAnC,dapAnD,dapAnDung)
                                VALUES (@maMon,@doKho,@noiDung,@dapAnA,@dapAnB,@dapAnC,@dapAnD,@dapAnDung)";
            using (SqlConnection ketNoi = new SqlConnection(connString))
            {
                using (SqlCommand cauLenh = new SqlCommand(cauTruyVan, ketNoi))
                {
                    cauLenh.Parameters.AddWithValue("@maMon", maMon);
                    cauLenh.Parameters.AddWithValue("@noiDung", noiDung);
                    cauLenh.Parameters.AddWithValue("@dapAnA", dapAnA);
                    cauLenh.Parameters.AddWithValue("@dapAnB", dapAnB);
                    cauLenh.Parameters.AddWithValue("@dapAnC", dapAnC);
                    cauLenh.Parameters.AddWithValue("@dapAnD", dapAnD);
                    cauLenh.Parameters.AddWithValue("@dapAnDung", dapAnDung);
                    cauLenh.Parameters.AddWithValue("@doKho", doKho);

                    try
                    {
                        ketNoi.Open();
                        int hangAnhHuong = cauLenh.ExecuteNonQuery();
                        if (hangAnhHuong > 0)
                        {
                            MessageBox.Show("Thêm câu hỏi vào ngân hàng thành công!",
                                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadThongKeThanhTieuDe();
                        }
                    }
                    catch (Exception loi)
                    {
                        MessageBox.Show("Lỗi kết nối hoặc thêm dữ liệu: " + loi.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }
        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void LoadDapAn()
        {

            cbo_DapAnDung.Items.Clear();
            cbo_DapAnDung.Items.Add("A");
            cbo_DapAnDung.Items.Add("B");
            cbo_DapAnDung.Items.Add("C");
            cbo_DapAnDung.Items.Add("D");

            cbo_DapAnDung.SelectedIndex = 0;
        }
        private void LoadDoKho()
        {

            cbo_DoKho.Items.Clear();
            cbo_DoKho.Items.Add("1");
            cbo_DoKho.Items.Add("2");
            cbo_DoKho.Items.Add("3");

            cbo_DoKho.SelectedIndex = 0;
        }
        private void LoadCauHoiThuCong(string tuKhoa = "", string maMon = "")
        {
            dgv_DanhSachCauHoi.Rows.Clear();

            string query = @"SELECT c.maCauHoi, m.tenMon, c.doKho, c.noiDung, c.dapAnA, c.dapAnB, c.dapAnC, c.dapAnD, c.dapAnDung 
                     FROM CauHoi c 
                     JOIN MonHoc m ON c.maMon = m.maMon
                     WHERE (@tuKhoa = '' OR c.noiDung LIKE '%' + @tuKhoa + '%')
                       AND (@maMon = '' OR c.maMon = @maMon)";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tuKhoa", string.IsNullOrEmpty(tuKhoa) ? "" : tuKhoa);
                    cmd.Parameters.AddWithValue("@maMon", string.IsNullOrEmpty(maMon) ? "" : maMon);

                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string id = reader["maCauHoi"].ToString();
                                string monHoc = reader["tenMon"].ToString();
                                string noiDung = reader["noiDung"].ToString();
                                string da = reader["dapAnA"].ToString();
                                string db = reader["dapAnB"].ToString();
                                string dc = reader["dapAnC"].ToString();
                                string dd = reader["dapAnD"].ToString();
                                string dung = reader["dapAnDung"].ToString();

                                dgv_DanhSachCauHoi.Rows.Add(id, monHoc, noiDung, da, db, dc, dd, dung);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi tìm kiếm dữ liệu: " + ex.Message);
                    }
                }
            }
        }
        private void LoadComboBoxMonHoc()
        {
            string query = "SELECT maMon, tenMon FROM MonHoc";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        cbo_MonHoc.DataSource = dt;
                        cbo_MonHoc.DisplayMember = "tenMon";
                        cbo_MonHoc.ValueMember = "maMon";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi tải danh sách môn học: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void LoadComboBoxLocMon()
        {
            string query = "SELECT maMon, tenMon FROM MonHoc";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                      
                        DataRow dr = dt.NewRow();
                        dr["maMon"] = ""; 
                        dr["tenMon"] = "--- Tất cả môn học ---";
                        dt.Rows.InsertAt(dr, 0);

                        cbo_LocMon.DataSource = dt;
                        cbo_LocMon.DisplayMember = "tenMon";
                        cbo_LocMon.ValueMember = "maMon";
                        cbo_LocMon.SelectedIndex = 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi tải danh sách lọc môn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_DanhSachCauHoi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_DanhSachCauHoi.Rows[e.RowIndex];

                if (row.Cells["maCauHoi"].Value != null)
                {
                    int maCauHoi = Convert.ToInt32(row.Cells["maCauHoi"].Value);

                    string query = "SELECT * FROM CauHoi WHERE maCauHoi = @maCauHoi";

                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@maCauHoi", maCauHoi);
                            try
                            {
                                conn.Open();
                                using (SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        // 1. Môn học (Gán theo mã môn để ComboBox tự chọn đúng tên)
                                        cbo_MonHoc.SelectedValue = reader["maMon"];

                                        // 2. Độ khó
                                        cbo_DoKho.Text = reader["doKho"].ToString();

                                        // 3. Nội dung câu hỏi
                                        tbx_NoiDung.Text = reader["noiDung"].ToString();

                                        // 4. Các đáp án A, B, C, D
                                        tbx_DapAnA.Text = reader["dapAnA"].ToString();
                                        tbx_DapAnB.Text = reader["dapAnB"].ToString();
                                        tbx_DapAnC.Text = reader["dapAnC"].ToString();
                                        tbx_DapAnD.Text = reader["dapAnD"].ToString();

                                        // 5. Đáp án đúng
                                        cbo_DapAnDung.Text = reader["dapAnDung"].ToString();
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Lỗi lấy chi tiết câu hỏi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (dgv_DanhSachCauHoi.SelectedRows.Count == 0 && dgv_DanhSachCauHoi.CurrentCell == null)
            {
                MessageBox.Show("Vui lòng chọn dòng câu hỏi cần xóa trên bảng!",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int rowIndex = dgv_DanhSachCauHoi.CurrentCell.RowIndex;
                int maCauHoi = Convert.ToInt32(dgv_DanhSachCauHoi.Rows[rowIndex].Cells["maCauHoi"].Value);

                DialogResult xacNhan = MessageBox.Show("Bạn có chắc chắn muốn xóa câu hỏi này không?",
                                                       "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (xacNhan == DialogResult.No)
                {
                    return;
                }

                string cauTruyVan = "DELETE FROM CauHoi WHERE maCauHoi = @maCauHoi";

                using (SqlConnection ketNoi = new SqlConnection(connString))
                {
                    using (SqlCommand cauLenh = new SqlCommand(cauTruyVan, ketNoi))
                    {

                        cauLenh.Parameters.AddWithValue("@maCauHoi", maCauHoi);

                        ketNoi.Open();
                        int hangAnhHuong = cauLenh.ExecuteNonQuery();

                        if (hangAnhHuong > 0)
                        {
                            MessageBox.Show("Xóa câu hỏi thành công!",
                                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);


                            LoadCauHoiThuCong();
                            LoadThongKeThanhTieuDe();
                        }
                    }
                }
            }
            catch (Exception loi)
            {
                MessageBox.Show("Lỗi khi xóa dữ liệu: " + loi.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_TimKiemCauHoi_Click(object sender, EventArgs e)
        {
            string tuKhoa = tbx_TraCauHoi.Text.Trim();
            string maMon = "";
            string tenMon = "Tất cả môn";

        
            if (cbo_LocMon.SelectedValue != null)
            {
                maMon = cbo_LocMon.SelectedValue.ToString();

             
                if (string.IsNullOrEmpty(maMon))
                {
                    tenMon = "Tất cả môn";
                }
                else
                {
                    tenMon = cbo_LocMon.Text;
                }
            }
    
            LoadCauHoiThuCong(tuKhoa, maMon);
            LoadThongKeThanhTieuDe(maMon, tenMon);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (dgv_DanhSachCauHoi.SelectedRows.Count == 0 && dgv_DanhSachCauHoi.CurrentCell == null)
            {
                MessageBox.Show("Vui lòng chọn câu hỏi cần cập nhật trên bảng!",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbo_MonHoc.SelectedValue == null ||
                string.IsNullOrWhiteSpace(tbx_DapAnA.Text) ||
                string.IsNullOrWhiteSpace(tbx_DapAnB.Text) ||
                string.IsNullOrWhiteSpace(tbx_DapAnC.Text) ||
                string.IsNullOrWhiteSpace(tbx_DapAnD.Text) ||
                string.IsNullOrWhiteSpace(tbx_NoiDung.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin câu hỏi!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                int rowIndex = dgv_DanhSachCauHoi.CurrentCell.RowIndex;
                int maCauHoi = Convert.ToInt32(dgv_DanhSachCauHoi.Rows[rowIndex].Cells["maCauHoi"].Value);

                string maMon = cbo_MonHoc.SelectedValue.ToString();
                string noiDung = tbx_NoiDung.Text.Trim();
                string dapAnA = tbx_DapAnA.Text.Trim();
                string dapAnB = tbx_DapAnB.Text.Trim();
                string dapAnC = tbx_DapAnC.Text.Trim();
                string dapAnD = tbx_DapAnD.Text.Trim();
                string doKho = cbo_DoKho.SelectedItem != null ? cbo_DoKho.SelectedItem.ToString() : cbo_DoKho.Text;
                string dapAnDung = cbo_DapAnDung.SelectedItem != null ? cbo_DapAnDung.SelectedItem.ToString() : cbo_DapAnDung.Text;

                string cauTruyVan = @"UPDATE CauHoi 
                             SET maMon = @maMon, 
                                 doKho = @doKho, 
                                 noiDung = @noiDung, 
                                 dapAnA = @dapAnA, 
                                 dapAnB = @dapAnB, 
                                 dapAnC = @dapAnC, 
                                 dapAnD = @dapAnD, 
                                 dapAnDung = @dapAnDung 
                             WHERE maCauHoi = @maCauHoi";

                using (SqlConnection ketNoi = new SqlConnection(connString))
                {
                    using (SqlCommand cauLenh = new SqlCommand(cauTruyVan, ketNoi))
                    {
                        // Truyền tham số để tránh SQL Injection
                        cauLenh.Parameters.AddWithValue("@maCauHoi", maCauHoi);
                        cauLenh.Parameters.AddWithValue("@maMon", maMon);
                        cauLenh.Parameters.AddWithValue("@doKho", doKho);
                        cauLenh.Parameters.AddWithValue("@noiDung", noiDung);
                        cauLenh.Parameters.AddWithValue("@dapAnA", dapAnA);
                        cauLenh.Parameters.AddWithValue("@dapAnB", dapAnB);
                        cauLenh.Parameters.AddWithValue("@dapAnC", dapAnC);
                        cauLenh.Parameters.AddWithValue("@dapAnD", dapAnD);
                        cauLenh.Parameters.AddWithValue("@dapAnDung", dapAnDung);

                        ketNoi.Open();
                        int hangAnhHuong = cauLenh.ExecuteNonQuery();

                        if (hangAnhHuong > 0)
                        {
                            MessageBox.Show("Cập nhật câu hỏi thành công!",
                                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Làm mới lại bảng danh sách câu hỏi sau khi sửa
                            LoadCauHoiThuCong();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy câu hỏi để cập nhật!",
                                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception loi)
            {
                MessageBox.Show("Lỗi khi cập nhật dữ liệu: " + loi.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadThongKeThanhTieuDe(string maMon = "", string tenMon = "Tất cả môn")
        {

            lbl_TatCaMon.Text = string.IsNullOrEmpty(tenMon) ? "Tất cả môn" : tenMon;

            // 2. Truy vấn đếm số liệu theo maMon (nếu rỗng thì đếm tất cả)
            string query = @"
        SELECT 
            COUNT(*) AS TongCauHoi,
            SUM(CASE WHEN doKho = '1' THEN 1 ELSE 0 END) AS SoCauDe,
            SUM(CASE WHEN doKho = '2' THEN 1 ELSE 0 END) AS SoCauTB,
            SUM(CASE WHEN doKho = '3' THEN 1 ELSE 0 END) AS SoCauKho,
            (SELECT COUNT(*) FROM MonHoc) AS TongMon
        FROM CauHoi
        WHERE (@maMon = '' OR maMon = @maMon)";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maMon", string.IsNullOrEmpty(maMon) ? "" : maMon);

                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int tongCauHoi = reader["TongCauHoi"] != DBNull.Value ? Convert.ToInt32(reader["TongCauHoi"]) : 0;
                                int de = reader["SoCauDe"] != DBNull.Value ? Convert.ToInt32(reader["SoCauDe"]) : 0;
                                int tb = reader["SoCauTB"] != DBNull.Value ? Convert.ToInt32(reader["SoCauTB"]) : 0;
                                int kho = reader["SoCauKho"] != DBNull.Value ? Convert.ToInt32(reader["SoCauKho"]) : 0;
                                int tongMon = reader["TongMon"] != DBNull.Value ? Convert.ToInt32(reader["TongMon"]) : 0;

                                lbl_TongCauHoi.Text = tongCauHoi.ToString();
                                lbl_TongCauDe.Text = de.ToString();
                                lbl_TongCauTrungBinh.Text = tb.ToString();
                                lbl_TongCauKho.Text = kho.ToString();
                                lbl_TongMon.Text = tongMon.ToString();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi tải thông tin thống kê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbl_TongMon_Click(object sender, EventArgs e)
        {

        }

        private void btn_LamMoiBang_Click(object sender, EventArgs e)
        {
            tbx_NoiDung.Clear();
            tbx_DapAnA.Clear();
            tbx_DapAnB.Clear();
            tbx_DapAnC.Clear();
            tbx_DapAnD.Clear();

            if (cbo_MonHoc.Items.Count > 0) cbo_MonHoc.SelectedIndex = 0;
            if (cbo_DoKho.Items.Count > 0) cbo_DoKho.SelectedIndex = 0;
            if (cbo_DapAnDung.Items.Count > 0) cbo_DapAnDung.SelectedIndex = 0;
            if (cbo_MonHoc.Items.Count > 0) cbo_MonHoc.SelectedIndex = 0;

            LoadCauHoiThuCong();

            MessageBox.Show("Đã làm mới form và tải lại dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
