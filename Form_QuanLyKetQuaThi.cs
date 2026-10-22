using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HeThongThiTracNghiem
{
    public partial class Form_QuanLyKetQuaThi : Form
    {
        public string connString = "Server=100.78.158.91,1433;Database=HETHONGTHITRACNGHIEM;User Id=NhomHeThongThiTracNghiem;Password=123456;TrustServerCertificate=True;";
        public Form_QuanLyKetQuaThi()
        {
            InitializeComponent();
        }

        private void Form_QuanLyKetQuaThi_Load(object sender, EventArgs e)
        {
            LoadSoLieuThongKe();
            LoadDataGridView();
        }
        private void KiemTraKetNoi()
        {
            try
            {
                using (SqlConnection ketNoi = new SqlConnection(connString))
                {
                    ketNoi.Open();
                    lbl_KiemTraKetNoi.Text = "Ok";
                }
            }
            catch (Exception loi)
            {
                MessageBox.Show("Lỗi kết nối database: " + loi.Message);
            }
        }

        private void LoadSoLieuThongKe()
        {
            using (SqlConnection ketNoi = new SqlConnection(connString))
            {
                try
                {
                    ketNoi.Open();
                    string truyVan = @"Select 
                                        (Select count(*) From TaiKhoan Where vaiTro = 'Thi sinh') as TongSoThiSinh,
                                        (select count(*) from BaiThi where trangThai in ('DaCham','DaNop')) as TongBaiThi,
                                        (select isnull(avg(diem),0) from BaiThi where diem is not null) as DiemTrungBinh,
                                        (select isnull(max(diem),0) from BaiThi where diem is not null) as DiemCaoNhat";
                    SqlCommand lenh = new SqlCommand(truyVan, ketNoi);
                    using (SqlDataReader doc = lenh.ExecuteReader())
                    {
                        if (doc.Read())
                        {
                            lbl_TongSoThiSinh.Text = doc["TongSoThiSinh"].ToString();
                            lbl_TongSoBaiThi.Text = doc["TongBaiThi"].ToString();
                            lbl_DiemTrungBinh.Text = doc["DiemTrungBinh"].ToString();
                            lbl_DiemCaoNhat.Text = doc["DiemCaoNhat"].ToString();
                        }
                    }
                }
                catch (Exception loi)
                {
                    MessageBox.Show("Lỗi tải số liệu thống kê: " + loi.Message);
                }
            }
        }
        private void LoadDataGridView()
        {
            using (SqlConnection ketNoi = new SqlConnection(connString))
            {
                try
                {
                    ketNoi.Open();
                    string truyVan = @"SELECT 
                                        tk.hoTen,
                                        tk.tenDangNhap,
                                        mh.tenMon,
                                        bt.diem,
                                        dt.thoiGianPhut,
                                        bt.maBaiThi
                                    FROM BaiThi bt
                                    JOIN TaiKhoan tk ON bt.maTaiKhoan = tk.maTaiKhoan
                                    JOIN DeThi dt ON bt.maDeThi = dt.maDeThi
                                    JOIN MonHoc mh ON dt.maMon = mh.maMon";

                    SqlCommand cauLenh = new SqlCommand(truyVan, ketNoi);
                    using (SqlDataReader doc = cauLenh.ExecuteReader())
                    {
                        int stt = 1;
                        while (doc.Read())
                        {
                            string hoTen = doc["hoTen"].ToString();
                            string taiKhoan = doc["tenDangNhap"].ToString();
                            string monThi = doc["tenMon"].ToString();
                            string diem = doc["diem"] != DBNull.Value ? doc["diem"].ToString() : "0";
                            string thoiGianLam = doc["thoiGianPhut"].ToString() + " Phút";
                            string maBaiThi = doc["maBaiThi"].ToString();

                            dgv_DanhSachKetQuaTheoThiSinh.Rows.Add(stt, maBaiThi ,hoTen, taiKhoan, monThi, diem, thoiGianLam);
                            stt++;
                        }
                    }
                }
                catch (Exception loi)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu vào bảng: " + loi.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void tpl_ThongKeChiTiet_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void HienThiChiTietBaiThi(int maBaiThi)
        {
            using(SqlConnection ketNoi = new SqlConnection(connString))
            {
                try
                {
                    ketNoi.Open();
                    string truyVan = @"SELECT tk.hoTen, tk.tenDangNhap, mh.tenMon, dt.tenDe, dt.thoiGianPhut, bt.diem
                                        FROM BaiThi bt
                                        JOIN TaiKhoan tk ON bt.maTaiKhoan = tk.maTaiKhoan
                                        JOIN DeThi dt ON bt.maDeThi = dt.maDeThi
                                        JOIN MonHoc mh ON dt.maMon = mh.maMon
                                        WHERE bt.maBaiThi = @maBaiThi";
                    SqlCommand cauLenh = new SqlCommand(truyVan, ketNoi);
                    cauLenh.Parameters.AddWithValue("@maBaiThi", maBaiThi);

                    using(SqlDataReader doc = cauLenh.ExecuteReader())
                    {
                        if (doc.Read())
                        {
                            lbl_TenNguoiDung.Text = doc["hoTen"].ToString();
                            lbl_MonThi.Text = doc["tenMon"].ToString();
                            lbl_TaiKhoanNguoiDung.Text = doc["tenDangNhap"].ToString();
                            lbl_ThoiGianLamBai.Text = doc["thoiGianPhut"].ToString() + " phút";
                            lbl_DeThi.Text = doc["tenDe"].ToString();
                            lbl_DiemBaiThi.Text = doc["diem"].ToString();
                        }
                    }
                }
                catch (Exception loi)
                {
                    MessageBox.Show("Lỗi hiển thị chi tiết bài thi: " + loi.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgv_DanhSachKetQuaTheoThiSinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow hang = dgv_DanhSachKetQuaTheoThiSinh.Rows[e.RowIndex];
            if (hang.Cells["maBaiThi"].Value != null)
            {
                int maBaiThi = Convert.ToInt32(hang.Cells["maBaiThi"].Value);
                HienThiChiTietBaiThi(maBaiThi);
            }
        }
    }
}
