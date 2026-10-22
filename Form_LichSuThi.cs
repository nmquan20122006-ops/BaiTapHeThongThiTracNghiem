using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Data.SqlClient;
namespace HeThongThiTracNghiem
{
    public partial class Form_LichSuThi : Form
    {
        string connectionstring = "Data Source=DESKTOP-3U6O521\\SQLEXPRESS;Initial Catalog=Hethongthitracnghiem;Integrated Security=True;TrustServerCertificate=True;";
        public Form_LichSuThi()
        {
            InitializeComponent();
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
        private void HienThiLichSuThi()
        {
            string sql = @"
        SELECT
            bt.maBaiThi AS [Mã bài thi],
            dt.tenDe AS [Tên bài thi],
            mh.tenMon AS [Môn học],
            bt.thoiGianNop AS [Ngày thi],
            DATEDIFF(MINUTE, bt.thoiGianBatDau, bt.thoiGianNop) AS [Thời gian (phút)],
            bt.diem AS [Điểm],
            CASE
                WHEN bt.diem IS NULL THEN N'Chưa chấm'
                WHEN bt.diem >= 5 THEN N'Đạt'
                ELSE N'Chưa đạt'
            END AS [Kết quả]
        FROM BaiThi bt
        INNER JOIN DeThi dt ON bt.maDeThi = dt.maDeThi
        INNER JOIN MonHoc mh ON dt.maMon = mh.maMon
        ORDER BY bt.thoiGianNop DESC";

            DataTable dt = new DataTable();

            using (SqlDataAdapter adapter = new SqlDataAdapter(sql, connectionstring))
            {
                adapter.Fill(dt);
            }

            dgvLichSuThi.DataSource = dt;
        }
        private void LocLichSuThi()
        {
            string sql = @"
        SELECT
            bt.maBaiThi AS [Mã lần thi],
            dt.tenDe AS [Tên bài thi],
            mh.tenMon AS [Môn học],
            bt.thoiGianNop AS [Ngày thi],
            DATEDIFF(MINUTE,
                bt.thoiGianBatDau,
                bt.thoiGianNop) AS [Thời gian (phút)],
            bt.diem AS [Điểm],
            CASE
                WHEN bt.diem IS NULL THEN N'Chưa chấm'
                WHEN bt.diem >= 5 THEN N'Đạt'
                ELSE N'Chưa đạt'
            END AS [Kết quả]
        FROM BaiThi bt
        JOIN DeThi dt ON bt.maDeThi = dt.maDeThi
        JOIN MonHoc mh ON dt.maMon = mh.maMon
        WHERE
            (@mon = N'Tất cả môn học' OR mh.tenMon = @mon)
            AND bt.thoiGianNop >= @tuNgay
            AND bt.thoiGianNop < @denNgay
            AND dt.tenDe LIKE @tenDe
            AND (
                @trangThai = N'Tất cả'
                OR (@trangThai = N'Đạt' AND bt.diem >= 5)
                OR (@trangThai = N'Chưa đạt'
                    AND bt.diem < 5)
                OR (@trangThai = N'Chưa chấm'
                    AND bt.diem IS NULL)
            )
        ORDER BY bt.thoiGianNop DESC";

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue(
                        "@mon", cboMonHoc.Text);

                    cmd.Parameters.AddWithValue(
                        "@tuNgay", dtpTuNgay.Value.Date);

                    cmd.Parameters.AddWithValue(
                        "@denNgay", dtpDenNgay.Value.Date.AddDays(1));

                    cmd.Parameters.AddWithValue(
                        "@tenDe", "%" + txtTimKiem.Text.Trim() + "%");

                    cmd.Parameters.AddWithValue(
                        "@trangThai", cboTrangThai.Text);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvLichSuThi.DataSource = dt;
                }
            }
        }

        private void Form_LichSuThi_Load(object sender, EventArgs e)
        {
            HienThiLichSuThi();
            cboMonHoc.Items.Clear();
            cboMonHoc.Items.Add("Tất cả môn học");
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                string sql = "SELECT tenMon FROM MonHoc ORDER BY tenMon";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cboMonHoc.Items.Add(reader["tenMon"].ToString());
                }

                reader.Close();
            }
            cboMonHoc.SelectedIndex = 0;
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.Add("Tất cả");
            cboTrangThai.Items.Add("Đạt");
            cboTrangThai.Items.Add("Chưa đạt");
            cboTrangThai.Items.Add("Chưa chấm");
            cboTrangThai.SelectedIndex = 0;
            dtpTuNgay.Value = DateTime.Today.AddYears(-1);
            dtpDenNgay.Value = DateTime.Today;
            LocLichSuThi();
            CapNhatThongKe();
        }
        private void LamMoi()
        {
            cboMonHoc.SelectedIndex = 0;
            cboTrangThai.SelectedIndex = 0;

            txtTimKiem.Clear();

            dtpTuNgay.Value = DateTime.Today.AddYears(-1);
            dtpDenNgay.Value = DateTime.Today;

            LocLichSuThi();
        }
        private void CapNhatThongKe()
        {
            string sql = @"
        SELECT
            COUNT(*) AS TongBaiThi,
            AVG(diem) AS DiemTB,
            MAX(diem) AS DiemCaoNhat
        FROM BaiThi";

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    lblTongBaiThi.Text =
                        reader["TongBaiThi"].ToString();

                    lblDiemTB.Text =
                        reader["DiemTB"] == DBNull.Value
                        ? "0.0"
                        : Convert.ToDouble(reader["DiemTB"]).ToString("0.0");

                    lblDiemCaoNhat.Text =
                        reader["DiemCaoNhat"] == DBNull.Value
                        ? "0"
                        : Convert.ToDouble(reader["DiemCaoNhat"]).ToString("0.0");
                }

                reader.Close();
            }
        }

        private void cboMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            LocLichSuThi();
        }

        private void cboTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            LocLichSuThi();
        }

        private void dtpTuNgay_ValueChanged(object sender, EventArgs e)
        {
            if (dtpTuNgay.Value.Date > dtpDenNgay.Value.Date)
            {
                dtpDenNgay.Value = dtpTuNgay.Value.Date;
            }

            LocLichSuThi();
        }

        private void dtpDenNgay_ValueChanged(object sender, EventArgs e)
        {
            if (dtpDenNgay.Value.Date < dtpTuNgay.Value.Date)
            {
                dtpTuNgay.Value = dtpDenNgay.Value.Date;
            }

            LocLichSuThi();

        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LocLichSuThi();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvLichSuThi.CurrentRow == null ||
        dgvLichSuThi.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn một bài thi!");
                return;
            }

            DataGridViewRow row = dgvLichSuThi.CurrentRow;

            string maBaiThi = row.Cells["Mã lần thi"].Value.ToString();
            string tenDe = row.Cells["Tên bài thi"].Value.ToString();
            string monHoc = row.Cells["Môn học"].Value.ToString();
            string ngayThi = Convert.ToDateTime(
                row.Cells["Ngày thi"].Value).ToString("dd/MM/yyyy HH:mm");

            string diem = row.Cells["Điểm"].Value == DBNull.Value
                ? "Chưa chấm"
                : row.Cells["Điểm"].Value.ToString();

            MessageBox.Show(
                "Mã lần thi: " + maBaiThi +
                "\nTên bài thi: " + tenDe +
                "\nMôn học: " + monHoc +
                "\nNgày thi: " + ngayThi +
                "\nĐiểm: " + diem,
                "Chi tiết bài thi"
            );
        }
    }
}
