using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;
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
            LoadComboBoxMonThi();
            LoadComboBoxMucDiem();
            KiemTraKetNoi();
        }
        private void KiemTraKetNoi()
        {
            try
            {
                using (SqlConnection ketNoi = new SqlConnection(connString))
                {
                    ketNoi.Open();
                    lbl_KiemTraKetNoi.Text = "Trạng thái kết nối cơ sở dữ liệu: Đã kết nối";
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

                            dgv_DanhSachKetQuaTheoThiSinh.Rows.Add(stt, maBaiThi, hoTen, taiKhoan, monThi, diem, thoiGianLam);
                            dgv_1.Rows.Add(stt, maBaiThi, hoTen, taiKhoan, monThi, diem, thoiGianLam);
                            
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
            using (SqlConnection ketNoi = new SqlConnection(connString))
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

                    using (SqlDataReader doc = cauLenh.ExecuteReader())
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
                LoadTongQuanCauTraLoi(maBaiThi);
            }
        }
        private void LoadTongQuanCauTraLoi(int maBaiThi)
        {
            dgv_TongQuanCauTraLoi.Rows.Clear();
            using (SqlConnection ketNoi = new SqlConnection(connString))
            {
                try
                {
                    ketNoi.Open();
                    string truyVan = @"select c.noiDung, ctbt.dapAnChon,c.dapAnDung,ctbt.laDung from ChiTietBaiThi ctbt join CauHoi c on ctbt.maCauHoi = c.maCauHoi where ctbt.maBaiThi = @maBaiThi";

                    SqlCommand cauLenh = new SqlCommand(truyVan, ketNoi);
                    cauLenh.Parameters.AddWithValue("@maBaiThi", maBaiThi);
                    using (SqlDataReader doc = cauLenh.ExecuteReader())
                    {
                        int stt = 1;
                        while (doc.Read())
                        {
                            string noiDung = doc["noiDung"].ToString();
                            string dapAnChon = doc["dapAnChon"].ToString();
                            string dapAnDung = doc["dapAnDung"].ToString();

                            bool laDung = doc["laDung"] != DBNull.Value && Convert.ToBoolean(doc["laDung"]);
                            string ketQua = laDung ? "Đúng" : "Sai";

                            dgv_TongQuanCauTraLoi.Rows.Add(stt, noiDung, dapAnChon, dapAnDung, ketQua);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải tổng quan câu trả lời: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void TimKiemTheoTenVaMucDiem(string tenThiSinh, decimal mucDiem)
        {
            dgv_DanhSachKetQuaTheoThiSinh.Rows.Clear();

            using (SqlConnection ketNoi = new SqlConnection(connString))
            {
                try
                {
                    ketNoi.Open();
                    string truyVan = @"SELECT 
                                bt.maBaiThi,
                                tk.hoTen,
                                tk.tenDangNhap,
                                mh.tenMon,
                                bt.diem,
                                dt.thoiGianPhut
                            FROM BaiThi bt
                            JOIN TaiKhoan tk ON bt.maTaiKhoan = tk.maTaiKhoan
                            JOIN DeThi dt ON bt.maDeThi = dt.maDeThi
                            JOIN MonHoc mh ON dt.maMon = mh.maMon
                            WHERE 
                                tk.hoTen LIKE '%' + @tenThiSinh + '%'
                                AND (@mucDiem = -1 OR bt.diem >= @mucDiem)";

                    SqlCommand cauLenh = new SqlCommand(truyVan, ketNoi);

                    cauLenh.Parameters.AddWithValue("@tenThiSinh", tenThiSinh.Trim());

                    cauLenh.Parameters.AddWithValue("@mucDiem", mucDiem);

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
                            int maBaiThi = Convert.ToInt32(doc["maBaiThi"]);

                            int rowIndex = dgv_DanhSachKetQuaTheoThiSinh.Rows.Add(stt, maBaiThi, hoTen, taiKhoan, monThi, diem, thoiGianLam);
                            dgv_DanhSachKetQuaTheoThiSinh.Rows[rowIndex].Tag = maBaiThi;
                            stt++;
                        }
                    }
                }
                catch (Exception loi)
                {
                    MessageBox.Show("Lỗi tìm kiếm: " + loi.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btn_TimKiemCauHoi_Click(object sender, EventArgs e)
        {
            string tenThiSinh = tbx_TenThiSinh.Text.Trim();

            decimal mucDiem = -1;
            if (!string.IsNullOrEmpty(cbo_MucDiem.Text))
            {
                decimal.TryParse(cbo_MucDiem.Text, out mucDiem);
            }

            TimKiemTheoTenVaMucDiem(tenThiSinh, mucDiem);
        }
        private void LoadComboBoxMonThi()
        {
            using (SqlConnection ketNoi = new SqlConnection(connString))
            {
                try
                {
                    ketNoi.Open();
                    string truyVan = "SELECT maMon, tenMon FROM MonHoc";

                    SqlCommand cauLenh = new SqlCommand(truyVan, ketNoi);
                    SqlDataAdapter adapter = new SqlDataAdapter(cauLenh);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);


                    DataRow row = dt.NewRow();
                    row["maMon"] = "";
                    row["tenMon"] = "-- Tất cả môn học --";
                    dt.Rows.InsertAt(row, 0);

                    cbo_MonThi.DataSource = dt;
                    cbo_MonThi.DisplayMember = "tenMon";
                    cbo_MonThi.ValueMember = "maMon";
                    cbo_MonThi.SelectedIndex = 0;


                    cbo_MonThi2.DataSource = dt;
                    cbo_MonThi2.DisplayMember = "tenMon";
                    cbo_MonThi2.ValueMember = "maMon";
                    cbo_MonThi2.SelectedIndex = 0;

                }
                catch (Exception loi)
                {
                    MessageBox.Show("Lỗi tải danh sách môn học vào ComboBox: " + loi.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void LoadComboBoxMucDiem()
        {
            cbo_MucDiem.Items.Clear();

            cbo_MucDiem.Items.Add("Tất cả mức điểm");
            cbo_MucDiem.Items.Add("5");
            cbo_MucDiem.Items.Add("7");
            cbo_MucDiem.Items.Add("8");
            cbo_MucDiem.Items.Add("9");

            cbo_MucDiem.SelectedIndex = 0;

            cbo_MucDiem2.Items.Clear();

            cbo_MucDiem2.Items.Add("Tất cả mức điểm");
            cbo_MucDiem2.Items.Add("5");
            cbo_MucDiem2.Items.Add("7");
            cbo_MucDiem2.Items.Add("8");
            cbo_MucDiem2.Items.Add("9");

            cbo_MucDiem2.SelectedIndex = 0;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            ThucHienTimKiemTongHop();
        }
        private void ThucHienTimKiemTongHop()
        {
            dgv_DanhSachKetQuaTheoThiSinh.Rows.Clear();
            dgv_1.Rows.Clear();

            string maDeThi = tbx_maDeThi.Text.Trim();

            string maMon = "";
            if (cbo_MonThi.SelectedValue != null && cbo_MonThi.SelectedIndex > 0)
            {
                maMon = cbo_MonThi.SelectedValue.ToString();
            }

            using (SqlConnection ketNoi = new SqlConnection(connString))
            {
                try
                {
                    ketNoi.Open();
                    string truyVan = @"SELECT bt.maBaiThi, tk.hoTen, tk.tenDangNhap, mh.tenMon, bt.diem, dt.thoiGianPhut 
                               FROM BaiThi bt 
                               JOIN TaiKhoan tk ON bt.maTaiKhoan = tk.maTaiKhoan
                               JOIN DeThi dt ON bt.maDeThi = dt.maDeThi
                               JOIN MonHoc mh ON dt.maMon = mh.maMon
                               WHERE (@maDeThi = '' OR dt.maDeThi LIKE '%' + @maDeThi + '%')
                                 AND (@maMon = '' OR dt.maMon = @maMon)";

                    SqlCommand lenh = new SqlCommand(truyVan, ketNoi);
                    lenh.Parameters.AddWithValue("@maDeThi", maDeThi);
                    lenh.Parameters.AddWithValue("@maMon", maMon);

                    using (SqlDataReader doc = lenh.ExecuteReader())
                    {
                        int stt = 1;
                        while (doc.Read())
                        {
                            string hoTen = doc["hoTen"].ToString();
                            string taiKhoan = doc["tenDangNhap"].ToString();
                            string monThi = doc["tenMon"].ToString();
                            string diem = doc["diem"] != DBNull.Value ? doc["diem"].ToString() : "0";
                            string thoiGianLam = doc["thoiGianPhut"].ToString() + " Phút";
                            int maBaiThi = Convert.ToInt32(doc["maBaiThi"]);

                            dgv_DanhSachKetQuaTheoThiSinh.Rows.Add(stt, maBaiThi, hoTen, taiKhoan, monThi, diem, thoiGianLam);
                            dgv_1.Rows.Add(stt, maBaiThi, hoTen, taiKhoan, monThi, diem, thoiGianLam);
                           
                            stt++;
                        }
                    }
                }
                catch (Exception loi)
                {
                    MessageBox.Show("Lỗi tìm kiếm theo môn học: " + loi.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            tbx_maDeThi.Clear();
            if (tbx_TenThiSinh != null)
            {
                tbx_TenThiSinh.Clear();
            }

            if (cbo_MonThi != null && cbo_MonThi.Items.Count > 0)
            {
                cbo_MonThi.SelectedIndex = 0;
            }
            if (cbo_MucDiem != null && cbo_MucDiem.Items.Count > 0)
            {
                cbo_MucDiem.SelectedIndex = 0;
            }

            LoadSoLieuThongKe();
            LoadDataGridView();
        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            tbx_maDeThi.Clear();
            if (tbx_TenThiSinh != null)
            {
                tbx_TenThiSinh.Clear();
            }

            if (cbo_MonThi2 != null && cbo_MonThi.Items.Count > 0)
            {
                cbo_MonThi.SelectedIndex = 0;
            }
            if (cbo_MucDiem2 != null && cbo_MucDiem.Items.Count > 0)
            {
                cbo_MucDiem.SelectedIndex = 0;
            }

            LoadSoLieuThongKe();
            LoadDataGridView();
        }

        private void dgv_1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow hang = dgv_1.Rows[e.RowIndex];
            if (hang.Cells["maBaiThi2"].Value != null)
            {
                int maBaiThi = Convert.ToInt32(hang.Cells["maBaiThi2"].Value);
                HienThiChiTietBaiThi(maBaiThi);
                LoadTongQuanCauTraLoi(maBaiThi);
            }
        }

        private void guna2HtmlLabel7_Click(object sender, EventArgs e)
        {

        }
    }
}
