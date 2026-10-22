using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace HeThongThiTracNghiem
{
    public partial class Form_monthi : Form
    {
        // Chuỗi kết nối CSDL
        public string connString = "Server=100.78.158.91,1433;Database=HETHONGTHITRACNGHIEM;User Id=NhomHeThongThiTracNghiem;Password=123456;TrustServerCertificate=True;";

        // Khai báo biến lưu thông tin thí sinh
        private string tenThiSinh = "";
        private string maTaiKhoan = "";

        // Hàm khởi tạo mặc định
        public Form_monthi()
        {
            InitializeComponent();
        }

        // Hàm khởi tạo nhận tên thí sinh từ Form Đăng Nhập truyền sang
        public Form_monthi(string hoTen, string maTK)
        {
            InitializeComponent();
            this.tenThiSinh = hoTen;
            this.maTaiKhoan = maTK;
        }

        private void Form_monthi_Load(object sender, EventArgs e)
        {
            // 1. Cập nhật label xin chào khớp với tên thí sinh đăng nhập
            if (!string.IsNullOrEmpty(tenThiSinh))
            {
                // Giả sử tên label ở panel trên là lbl_XinChao hoặc guna2HtmlLabel1
                lbl_Xinchao.Text = "Xin chào, " + tenThiSinh;
            }
            else
            {
                lbl_Xinchao.Text = "Xin chào, Thí sinh";
            }

            // 2. Load danh sách đề thi khi mở form
            LoadDanhSachDeThi("");
        }

        // Hàm load danh sách đề thi lên DataGridView
        private void LoadDanhSachDeThi(string tuKhoa)
        {
            using (SqlConnection ketNoi = new SqlConnection(connString))
            {
                try
                {
                    ketNoi.Open();
                    string truyVan = @"SELECT 
                                        dt.maDeThi AS [Mã đề],
                                        dt.tenDe AS [Tên đề thi],
                                        mh.tenMon AS [Môn học],
                                        CAST(dt.thoiGianPhut AS VARCHAR) + ' phút' AS [Thời gian],
                                        dt.soLuongCau AS [Số lượng câu]
                                    FROM DeThi dt
                                    JOIN MonHoc mh ON dt.maMon = mh.maMon
                                    WHERE @tuKhoa = '' OR dt.tenDe LIKE '%' + @tuKhoa + '%' OR mh.tenMon LIKE '%' + @tuKhoa + '%'";

                    SqlCommand cmd = new SqlCommand(truyVan, ketNoi);
                    cmd.Parameters.AddWithValue("@tuKhoa", tuKhoa.Trim());

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Đổ dữ liệu lên DataGridView
                    dgv_DanhSachDeThi.DataSource = dt;
                }
                catch (Exception loi)
                {
                    MessageBox.Show("Lỗi tải danh sách đề thi: " + loi.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Nút "Tìm kiếm đề thi"
        private void btn_TimKiemDeThi_Click(object sender, EventArgs e)
        {
            string tuKhoa = btn_TimKiemDeThi.Text.Trim();
            LoadDanhSachDeThi(tuKhoa);
        }

        // Nút "Bắt đầu thi" (Chọn đề từ DataGridView và chuyển sang Form_thi)
        private void btn_BatDauThi_Click(object sender, EventArgs e)
        {
            if (dgv_DanhSachDeThi.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một đề thi trong bảng để bắt đầu làm bài!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maDeThi = Convert.ToInt32(dgv_DanhSachDeThi.SelectedRows[0].Cells["Mã đề"].Value);

            // Mở form thi và truyền mã đề cùng thông tin thí sinh sang
            //Form_thi formThi = new Form_thi(maDeThi, tenThiSinh);
            //formThi.Show();
            //this.Hide();
        }

        // Nút "Thoát"
        private void btn_Thoat_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi giao diện chọn đề thi?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Form_GiaoDienHocSinh formDN = new Form_GiaoDienHocSinh();
                formDN.Show();
                this.Close();
            }
        }

        private void dgv_DanhSachDeThi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_DanhSachDeThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}