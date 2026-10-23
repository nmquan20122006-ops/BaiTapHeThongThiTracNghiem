using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace HeThongThiTracNghiem
{
    public partial class Form_monthi : Form
    {
     
        public string connString = "Server=100.78.158.91,1433;Database=HETHONGTHITRACNGHIEM;User Id=NhomHeThongThiTracNghiem;Password=123456;TrustServerCertificate=True;";

      
        private string tenThiSinh = "";
        private string maTaiKhoan = "";

     
        public Form_monthi()
        {
            InitializeComponent();
        }

        public Form_monthi(string hoTen, string maTK)
        {
            InitializeComponent();
            this.tenThiSinh = hoTen;
            this.maTaiKhoan = maTK;
        }

        private void Form_monthi_Load(object sender, EventArgs e)
        {
       
            if (!string.IsNullOrEmpty(tenThiSinh))
            {
                lbl_Xinchao.Text = "Xin chào, " + tenThiSinh;
            }
            else
            {
                lbl_Xinchao.Text = "Xin chào, Thí sinh";
            }


            LoadDanhSachDeThi("");
        
            guna2Button1.Click += guna2Button1_Click;
        }

     
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
        private void btn_TimKiemDeThi_Click(object sender, EventArgs e)
        {
            string tuKhoa = txt_TimKiemCauHoi.Text.Trim();
            LoadDanhSachDeThi(tuKhoa);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (dgv_DanhSachDeThi.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một đề thi trong bảng để bắt đầu làm bài!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maDeThi = Convert.ToInt32(dgv_DanhSachDeThi.SelectedRows[0].Cells["Mã đề"].Value);

            Form_thi formThi = new Form_thi();
            formThi.Show();
            this.Hide();
        }

   
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi giao diện chọn đề thi?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Form_GiaoDienHocSinh formHS = new Form_GiaoDienHocSinh();
                formHS.Show();
                this.Close();
            }
        }

        private void dgv_DanhSachDeThi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_DanhSachDeThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            if (dgv_DanhSachDeThi.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một đề thi trong bảng để bắt đầu làm bài!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maDeThi = Convert.ToInt32(dgv_DanhSachDeThi.SelectedRows[0].Cells["Mã đề"].Value);

         
            int tkId = !string.IsNullOrEmpty(this.maTaiKhoan) ? int.Parse(this.maTaiKhoan) : 1; 

            bool ketQuaBatDau = chamthi.batdau(maDeThi, tkId);

            if (ketQuaBatDau)
            {
                Form_thi formThi = new Form_thi();
                formThi.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(chamthi.LoiCuoi ?? "Không thể bắt đầu bài thi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}