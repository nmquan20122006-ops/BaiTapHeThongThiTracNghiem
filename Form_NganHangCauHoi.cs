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
            LoadDapAn();
            LoadDoKho();
            LoadCauHoiThuCong();
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
        private void LoadCauHoiThuCong()
        {
            // 1. Xóa sạch dữ liệu cũ trên bảng
            dgv_DanhSachCauHoi.Rows.Clear();

            string query = @"SELECT c.maCauHoi, m.tenMon, c.doKho, c.noiDung, c.dapAnA, c.dapAnB, c.dapAnC, c.dapAnD, c.dapAnDung 
                     FROM CauHoi c 
                     JOIN MonHoc m ON c.maMon = m.maMon";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // 2. Đọc từng dòng dữ liệu trả về từ SQL Server
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

                                // 3. Chèn vào từng dòng của DataGridView
                                dgv_DanhSachCauHoi.Rows.Add(id, monHoc, noiDung, da, db, dc, dd, dung);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);
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

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_DanhSachCauHoi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_DanhSachCauHoi.Rows[e.RowIndex];

                // Lấy mã câu hỏi từ cột maCauHoi
                if (row.Cells["maCauHoi"].Value != null)
                {
                    int maCauHoi = Convert.ToInt32(row.Cells["maCauHoi"].Value);

                    // Truy vấn trực tiếp từ CSDL theo mã câu hỏi để lấy chính xác tuyệt đối các thông tin
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
                                        //cbo_DapAnDung.Text = reader["dapAnDung"].ToString();
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
                // 2. Lấy giá trị cột mã câu hỏi (maCauHoi) của dòng đang chọn
                int rowIndex = dgv_DanhSachCauHoi.CurrentCell.RowIndex;
                int maCauHoi = Convert.ToInt32(dgv_DanhSachCauHoi.Rows[rowIndex].Cells["maCauHoi"].Value);

                // 3. Hiển thị hộp thoại hỏi lại để tránh bấm nhầm
                DialogResult xacNhan = MessageBox.Show("Bạn có chắc chắn muốn xóa câu hỏi này không?",
                                                       "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (xacNhan == DialogResult.No)
                {
                    return; // Nếu chọn No thì hủy lệnh xóa
                }

                // 4. Câu lệnh SQL DELETE
                string cauTruyVan = "DELETE FROM CauHoi WHERE maCauHoi = @maCauHoi";

                using (SqlConnection ketNoi = new SqlConnection(connString))
                {
                    using (SqlCommand cauLenh = new SqlCommand(cauTruyVan, ketNoi))
                    {
                        // Truyền tham số an toàn vào câu lệnh
                        cauLenh.Parameters.AddWithValue("@maCauHoi", maCauHoi);

                        ketNoi.Open();
                        int hangAnhHuong = cauLenh.ExecuteNonQuery();

                        if (hangAnhHuong > 0)
                        {
                            MessageBox.Show("Xóa câu hỏi thành công!",
                                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // 5. Gọi lại hàm load danh sách để bảng tự động cập nhật hiển thị mới nhất
                            LoadCauHoiThuCong();
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
    }
}
