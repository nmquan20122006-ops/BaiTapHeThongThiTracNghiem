using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HeThongThiTracNghiem
{
    public partial class Form_ThemCauHoiVaoDeThi : Form
    {
        public string connString = "Server=100.78.158.91,1433;Database=HETHONGTHITRACNGHIEM;User Id=NhomHeThongThiTracNghiem;Password=123456;TrustServerCertificate=True;";

        public Form_ThemCauHoiVaoDeThi()
        {
            InitializeComponent();
        }

        private void Form_ThemCauHoiVaoDeThi_Load(object sender, EventArgs e)
        {
            LoadComboBoxDeThi();
        }

        // 1. Load danh sách đề thi vào ComboBox
        private void LoadComboBoxDeThi()
        {
            using (SqlConnection ketNoi = new SqlConnection(connString))
            {
                try
                {
                    ketNoi.Open();
                    string truyVan = "SELECT maDeThi, tenDe FROM DeThi";
                    SqlDataAdapter adapter = new SqlDataAdapter(truyVan, ketNoi);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cb_ChonDeThi.DataSource = dt;
                    cb_ChonDeThi.DisplayMember = "tenDe";
                    cb_ChonDeThi.ValueMember = "maDeThi";
                    cb_ChonDeThi.SelectedIndex = -1; // Mặc định chưa chọn
                }
                catch (Exception loi)
                {
                    MessageBox.Show("Lỗi tải danh sách đề thi: " + loi.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 2. Khi chọn đề thi -> Lấy tên môn học và push danh sách câu hỏi của môn đó lên DataGridView
        private void cb_ChonDeThi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_ChonDeThi.SelectedValue != null && int.TryParse(cb_ChonDeThi.SelectedValue.ToString(), out int maDeThi))
            {
                HienThiThongTinMonHoc(maDeThi);
                LoadNganHangCauHoiTheoDe(maDeThi);
            }
        }

        // Hiển thị tên môn học vào label (lbl_MonHoc)
        private void HienThiThongTinMonHoc(int maDeThi)
        {
            using (SqlConnection ketNoi = new SqlConnection(connString))
            {
                try
                {
                    ketNoi.Open();
                    string truyVan = @"SELECT mh.tenMon 
                                    FROM DeThi dt 
                                    JOIN MonHoc mh ON dt.maMon = mh.maMon 
                                    WHERE dt.maDeThi = @maDeThi";
                    SqlCommand cmd = new SqlCommand(truyVan, ketNoi);
                    cmd.Parameters.AddWithValue("@maDeThi", maDeThi);

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        lbl_MonHoc.Text = result.ToString();
                    }
                }
                catch (Exception loi)
                {
                    MessageBox.Show("Lỗi lấy thông tin môn học: " + loi.Message);
                }
            }
        }

        // 3. Lấy toàn bộ câu hỏi trong ngân hàng thuộc môn của đề thi đó push lên DataGridView
        private void LoadNganHangCauHoiTheoDe(int maDeThi)
        {
            using (SqlConnection ketNoi = new SqlConnection(connString))
            {
                try
                {
                    ketNoi.Open();
                    // Lấy các câu hỏi thuộc đúng môn của đề thi
                    string truyVan = @"SELECT 
                                        ch.maCauHoi AS [Mã câu],
                                        ch.doKho AS [Độ khó],
                                        ch.noiDung AS [Nội dung câu hỏi],
                                        ch.dapAnA AS [Đáp án A],
                                        ch.dapAnB AS [Đáp án B],
                                        ch.dapAnC AS [Đáp án C],
                                        ch.dapAnD AS [Đáp án D],
                                        ch.dapAnDung AS [Đáp án Đúng],
                                        CASE 
                                            WHEN ctdt.maCauHoi IS NOT NULL THEN N'Đã có trong đề' 
                                            ELSE N'Chưa có' 
                                        END AS [Trạng thái]
                                    FROM CauHoi ch
                                    JOIN DeThi dt ON ch.maMon = dt.maMon
                                    LEFT JOIN ChiTietDeThi ctdt ON ch.maCauHoi = ctdt.maCauHoi AND ctdt.maDeThi = dt.maDeThi
                                    WHERE dt.maDeThi = @maDeThi";

                    SqlCommand cmd = new SqlCommand(truyVan, ketNoi);
                    cmd.Parameters.AddWithValue("@maDeThi", maDeThi);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgv_DanhSachCauHoi.DataSource = dt;
                }
                catch (Exception loi)
                {
                    MessageBox.Show("Lỗi tải ngân hàng câu hỏi: " + loi.Message);
                }
            }
        }

        // 4. Nút THÊM: Thêm câu hỏi được chọn trên DataGridView vào đề thi
        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (cb_ChonDeThi.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn đề thi trước!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgv_DanhSachCauHoi.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một câu hỏi từ bảng bên phải để thêm vào đề!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maDeThi = Convert.ToInt32(cb_ChonDeThi.SelectedValue);
            int maCauHoi = Convert.ToInt32(dgv_DanhSachCauHoi.SelectedRows[0].Cells["Mã câu"].Value);
            string trangThai = dgv_DanhSachCauHoi.SelectedRows[0].Cells["Trạng thái"].Value.ToString();

            if (trangThai == "Đã có trong đề")
            {
                MessageBox.Show("Câu hỏi này đã có sẵn trong đề thi rồi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SqlConnection ketNoi = new SqlConnection(connString))
            {
                try
                {
                    ketNoi.Open();
                    string truyVan = "INSERT INTO ChiTietDeThi (maDeThi, maCauHoi) VALUES (@maDeThi, @maCauHoi)";
                    SqlCommand cmd = new SqlCommand(truyVan, ketNoi);
                    cmd.Parameters.AddWithValue("@maDeThi", maDeThi);
                    cmd.Parameters.AddWithValue("@maCauHoi", maCauHoi);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm câu hỏi vào đề thi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Load lại bảng để cập nhật cột trạng thái
                    LoadNganHangCauHoiTheoDe(maDeThi);
                }
                catch (Exception loi)
                {
                    MessageBox.Show("Lỗi khi thêm câu hỏi: " + loi.Message);
                }
            }
        }

        // 5. Nút XÓA: Xóa câu hỏi khỏi đề thi (hoặc gỡ câu hỏi khỏi ChiTietDeThi)
        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (cb_ChonDeThi.SelectedValue == null) return;
            if (dgv_DanhSachCauHoi.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn câu hỏi cần xóa khỏi đề!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maDeThi = Convert.ToInt32(cb_ChonDeThi.SelectedValue);
            int maCauHoi = Convert.ToInt32(dgv_DanhSachCauHoi.SelectedRows[0].Cells["Mã câu"].Value);

            using (SqlConnection ketNoi = new SqlConnection(connString))
            {
                try
                {
                    ketNoi.Open();
                    string truyVan = "DELETE FROM ChiTietDeThi WHERE maDeThi = @maDeThi AND maCauHoi = @maCauHoi";
                    SqlCommand cmd = new SqlCommand(truyVan, ketNoi);
                    cmd.Parameters.AddWithValue("@maDeThi", maDeThi);
                    cmd.Parameters.AddWithValue("@maCauHoi", maCauHoi);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Đã gỡ câu hỏi khỏi đề thi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadNganHangCauHoiTheoDe(maDeThi);
                    }
                    else
                    {
                        MessageBox.Show("Câu hỏi này chưa có trong đề thi để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception loi)
                {
                    MessageBox.Show("Lỗi khi xóa câu hỏi: " + loi.Message);
                }
            }
        }

        // 6. Nút LÀM MỚI
        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            cb_ChonDeThi.SelectedIndex = -1;
            lbl_MonHoc.Text = "";
            dgv_DanhSachCauHoi.DataSource = null;
            txt_TimKiemCauHoi.Clear();
        }

        // 7. Nút TÌM KIẾM CÂU HỎI trong ngân hàng của môn
        private void btn_TimKiemCauHoi_Click(object sender, EventArgs e)
        {
            if (cb_ChonDeThi.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn đề thi trước khi tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maDeThi = Convert.ToInt32(cb_ChonDeThi.SelectedValue);
            string tuKhoa = txt_TimKiemCauHoi.Text.Trim();

            using (SqlConnection ketNoi = new SqlConnection(connString))
            {
                try
                {
                    ketNoi.Open();
                    string truyVan = @"SELECT 
                                        ch.maCauHoi AS [Mã câu],
                                        ch.doKho AS [Độ khó],
                                        ch.noiDung AS [Nội dung câu hỏi],
                                        ch.dapAnA AS [Đáp án A],
                                        ch.dapAnB AS [Đáp án B],
                                        ch.dapAnC AS [Đáp án C],
                                        ch.dapAnD AS [Đáp án D],
                                        ch.dapAnDung AS [Đáp án Đúng],
                                        CASE 
                                            WHEN ctdt.maCauHoi IS NOT NULL THEN N'Đã có trong đề' 
                                            ELSE N'Chưa có' 
                                        END AS [Trạng thái]
                                    FROM CauHoi ch
                                    JOIN DeThi dt ON ch.maMon = dt.maMon
                                    LEFT JOIN ChiTietDeThi ctdt ON ch.maCauHoi = ctdt.maCauHoi AND ctdt.maDeThi = dt.maDeThi
                                    WHERE dt.maDeThi = @maDeThi AND ch.noiDung LIKE '%' + @tuKhoa + '%'";

                    SqlCommand cmd = new SqlCommand(truyVan, ketNoi);
                    cmd.Parameters.AddWithValue("@maDeThi", maDeThi);
                    cmd.Parameters.AddWithValue("@tuKhoa", tuKhoa);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgv_DanhSachCauHoi.DataSource = dt;
                }
                catch (Exception loi)
                {
                    MessageBox.Show("Lỗi tìm kiếm: " + loi.Message);
                }
            }
        }
    }
}