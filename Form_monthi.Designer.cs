using System.ComponentModel;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace HeThongThiTracNghiem
{
    partial class Form_monthi
    {
        private IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2Panel4 = new Guna2Panel();
            guna2Button2 = new Guna2Button();
            guna2Button1 = new Guna2Button();
            guna2HtmlLabel1 = new Guna2HtmlLabel();
            dgv_DanhSachDeThi = new Guna2DataGridView();
            txt_TimKiemCauHoi = new Guna2TextBox();
            btn_TimKiemDeThi = new Guna2Button();
            guna2HtmlLabel3 = new Guna2HtmlLabel();
            guna2Panel1 = new Guna2Panel();
            lbl_Xinchao = new Guna2HtmlLabel();
            guna2Panel4.SuspendLayout();
            ((ISupportInitialize)dgv_DanhSachDeThi).BeginInit();
            guna2Panel1.SuspendLayout();
            SuspendLayout();
            // 
            // guna2Panel4
            // 
            guna2Panel4.Controls.Add(guna2Button2);
            guna2Panel4.Controls.Add(guna2Button1);
            guna2Panel4.Controls.Add(guna2HtmlLabel1);
            guna2Panel4.Controls.Add(dgv_DanhSachDeThi);
            guna2Panel4.Controls.Add(txt_TimKiemCauHoi);
            guna2Panel4.Controls.Add(btn_TimKiemDeThi);
            guna2Panel4.Controls.Add(guna2HtmlLabel3);
            guna2Panel4.CustomizableEdges = customizableEdges9;
            guna2Panel4.FillColor = Color.FromArgb(224, 224, 224);
            guna2Panel4.Location = new Point(12, 103);
            guna2Panel4.Name = "guna2Panel4";
            guna2Panel4.ShadowDecoration.CustomizableEdges = customizableEdges10;
            guna2Panel4.Size = new Size(967, 515);
            guna2Panel4.TabIndex = 6;
            // 
            // guna2Button2
            // 
            guna2Button2.Animated = true;
            guna2Button2.BorderRadius = 7;
            guna2Button2.CustomizableEdges = customizableEdges1;
            guna2Button2.DisabledState.BorderColor = Color.DarkGray;
            guna2Button2.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button2.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button2.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button2.FillColor = Color.FromArgb(100, 116, 139);
            guna2Button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2Button2.ForeColor = Color.White;
            guna2Button2.HoverState.FillColor = Color.FromArgb(71, 85, 105);
            guna2Button2.Location = new Point(857, 455);
            guna2Button2.Margin = new Padding(10, 20, 10, 20);
            guna2Button2.Name = "guna2Button2";
            guna2Button2.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Button2.Size = new Size(94, 36);
            guna2Button2.TabIndex = 44;
            guna2Button2.Text = "Thoát";
            guna2Button2.Click += guna2Button2_Click;
            // 
            // guna2Button1
            // 
            guna2Button1.Animated = true;
            guna2Button1.BorderRadius = 7;
            guna2Button1.CustomizableEdges = customizableEdges3;
            guna2Button1.DisabledState.BorderColor = Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button1.FillColor = Color.FromArgb(100, 116, 139);
            guna2Button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2Button1.ForeColor = Color.White;
            guna2Button1.HoverState.FillColor = Color.FromArgb(71, 85, 105);
            guna2Button1.Location = new Point(707, 455);
            guna2Button1.Margin = new Padding(10, 20, 10, 20);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Button1.Size = new Size(94, 36);
            guna2Button1.TabIndex = 43;
            guna2Button1.Text = "Bắt đầu thi";
            guna2Button1.Click += guna2Button1_Click_1;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Location = new Point(19, 474);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(53, 17);
            guna2HtmlLabel1.TabIndex = 42;
            guna2HtmlLabel1.Text = "Tìm kiếm ";
            // 
            // dgv_DanhSachDeThi
            // 
            dgv_DanhSachDeThi.AllowUserToAddRows = false;
            dgv_DanhSachDeThi.AllowUserToDeleteRows = false;
            dgv_DanhSachDeThi.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 250, 253);
            dgv_DanhSachDeThi.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgv_DanhSachDeThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(53, 106, 230);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(53, 106, 230);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgv_DanhSachDeThi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgv_DanhSachDeThi.ColumnHeadersHeight = 45;
            dgv_DanhSachDeThi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(45, 55, 72);
            dataGridViewCellStyle3.Padding = new Padding(6, 5, 6, 5);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(225, 235, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(35, 65, 125);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgv_DanhSachDeThi.DefaultCellStyle = dataGridViewCellStyle3;
            dgv_DanhSachDeThi.GridColor = Color.FromArgb(235, 239, 245);
            dgv_DanhSachDeThi.Location = new Point(19, 58);
            dgv_DanhSachDeThi.Name = "dgv_DanhSachDeThi";
            dgv_DanhSachDeThi.ReadOnly = true;
            dgv_DanhSachDeThi.RowHeadersVisible = false;
            dgv_DanhSachDeThi.RowTemplate.Height = 60;
            dgv_DanhSachDeThi.Size = new Size(932, 374);
            dgv_DanhSachDeThi.TabIndex = 41;
            dgv_DanhSachDeThi.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(248, 250, 253);
            dgv_DanhSachDeThi.ThemeStyle.GridColor = Color.FromArgb(235, 239, 245);
            dgv_DanhSachDeThi.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(53, 106, 230);
            dgv_DanhSachDeThi.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dgv_DanhSachDeThi.ThemeStyle.HeaderStyle.Height = 45;
            dgv_DanhSachDeThi.ThemeStyle.ReadOnly = true;
            dgv_DanhSachDeThi.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgv_DanhSachDeThi.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(45, 55, 72);
            dgv_DanhSachDeThi.ThemeStyle.RowsStyle.Height = 60;
            dgv_DanhSachDeThi.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(225, 235, 255);
            dgv_DanhSachDeThi.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(35, 65, 125);
            dgv_DanhSachDeThi.CellClick += dgv_DanhSachDeThi_CellClick;
            dgv_DanhSachDeThi.CellContentClick += dgv_DanhSachDeThi_CellContentClick;
            // 
            // txt_TimKiemCauHoi
            // 
            txt_TimKiemCauHoi.CustomizableEdges = customizableEdges5;
            txt_TimKiemCauHoi.DefaultText = "";
            txt_TimKiemCauHoi.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txt_TimKiemCauHoi.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txt_TimKiemCauHoi.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txt_TimKiemCauHoi.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txt_TimKiemCauHoi.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txt_TimKiemCauHoi.Font = new Font("Segoe UI", 9F);
            txt_TimKiemCauHoi.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txt_TimKiemCauHoi.Location = new Point(93, 455);
            txt_TimKiemCauHoi.Name = "txt_TimKiemCauHoi";
            txt_TimKiemCauHoi.PlaceholderText = "";
            txt_TimKiemCauHoi.SelectedText = "";
            txt_TimKiemCauHoi.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txt_TimKiemCauHoi.Size = new Size(415, 36);
            txt_TimKiemCauHoi.TabIndex = 40;
            // 
            // btn_TimKiemDeThi
            // 
            btn_TimKiemDeThi.Animated = true;
            btn_TimKiemDeThi.BorderRadius = 7;
            btn_TimKiemDeThi.CustomizableEdges = customizableEdges7;
            btn_TimKiemDeThi.DisabledState.BorderColor = Color.DarkGray;
            btn_TimKiemDeThi.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_TimKiemDeThi.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_TimKiemDeThi.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_TimKiemDeThi.FillColor = Color.FromArgb(100, 116, 139);
            btn_TimKiemDeThi.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_TimKiemDeThi.ForeColor = Color.White;
            btn_TimKiemDeThi.HoverState.FillColor = Color.FromArgb(71, 85, 105);
            btn_TimKiemDeThi.Location = new Point(560, 455);
            btn_TimKiemDeThi.Margin = new Padding(10, 20, 10, 20);
            btn_TimKiemDeThi.Name = "btn_TimKiemDeThi";
            btn_TimKiemDeThi.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btn_TimKiemDeThi.Size = new Size(99, 36);
            btn_TimKiemDeThi.TabIndex = 39;
            btn_TimKiemDeThi.Text = "Tìm kiếm dề thi";
            btn_TimKiemDeThi.Click += btn_TimKiemDeThi_Click;
            // 
            // guna2HtmlLabel3
            // 
            guna2HtmlLabel3.BackColor = Color.Transparent;
            guna2HtmlLabel3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel3.Location = new Point(19, 16);
            guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            guna2HtmlLabel3.Size = new Size(148, 27);
            guna2HtmlLabel3.TabIndex = 1;
            guna2HtmlLabel3.Text = "Danh sách đề thi";
            // 
            // guna2Panel1
            // 
            guna2Panel1.Controls.Add(lbl_Xinchao);
            guna2Panel1.CustomizableEdges = customizableEdges11;
            guna2Panel1.FillColor = SystemColors.ActiveCaption;
            guna2Panel1.Location = new Point(12, 12);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges12;
            guna2Panel1.Size = new Size(970, 75);
            guna2Panel1.TabIndex = 4;
            // 
            // lbl_Xinchao
            // 
            lbl_Xinchao.BackColor = Color.Transparent;
            lbl_Xinchao.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Xinchao.Location = new Point(19, 16);
            lbl_Xinchao.Name = "lbl_Xinchao";
            lbl_Xinchao.Size = new Size(374, 39);
            lbl_Xinchao.TabIndex = 0;
            lbl_Xinchao.Text = "Xin chào, Nguyễn Minh Quân";
            // 
            // Form_monthi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1002, 637);
            Controls.Add(guna2Panel4);
            Controls.Add(guna2Panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form_monthi";
            Text = "Form_monthi";
            Load += Form_monthi_Load;
            guna2Panel4.ResumeLayout(false);
            guna2Panel4.PerformLayout();
            ((ISupportInitialize)dgv_DanhSachDeThi).EndInit();
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            ResumeLayout(false);

        }

        private Guna2Panel guna2Panel4;
        private Guna2DataGridView dgv_DanhSachDeThi;
        private Guna2Button btn_TimKiemDeThi;
        private Guna2TextBox txt_TimKiemCauHoi;
        private Guna2HtmlLabel guna2HtmlLabel3;
        private Guna2Panel guna2Panel1;
        private Guna2HtmlLabel lbl_Xinchao;
        private Guna2HtmlLabel guna2HtmlLabel1;
        private Guna2Button guna2Button2;
        private Guna2Button guna2Button1;
    }
}