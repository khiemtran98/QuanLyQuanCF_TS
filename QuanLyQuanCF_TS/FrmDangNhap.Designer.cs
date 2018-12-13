namespace QuanLyQuanCF_TS
{
    partial class FrmDangNhap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDangNhap));
            this.mDangNhap = new MetroFramework.Controls.MetroPanel();
            this.lblPhienBan = new MetroFramework.Controls.MetroLabel();
            this.lblThongTin1 = new MetroFramework.Controls.MetroLabel();
            this.lblThongTin2 = new MetroFramework.Controls.MetroLabel();
            this.btnDangNhap = new MetroFramework.Controls.MetroButton();
            this.txtMatKhau = new MetroFramework.Controls.MetroTextBox();
            this.cmbTaiKhoan = new MetroFramework.Controls.MetroComboBox();
            this.lblMatKhau = new MetroFramework.Controls.MetroLabel();
            this.lblTaiKhoan = new MetroFramework.Controls.MetroLabel();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.mDangNhap.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mDangNhap
            // 
            this.mDangNhap.Controls.Add(this.lblThongTin1);
            this.mDangNhap.Controls.Add(this.lblThongTin2);
            this.mDangNhap.Controls.Add(this.btnDangNhap);
            this.mDangNhap.Controls.Add(this.txtMatKhau);
            this.mDangNhap.Controls.Add(this.cmbTaiKhoan);
            this.mDangNhap.Controls.Add(this.lblMatKhau);
            this.mDangNhap.Controls.Add(this.lblTaiKhoan);
            this.mDangNhap.Dock = System.Windows.Forms.DockStyle.Left;
            this.mDangNhap.HorizontalScrollbarBarColor = true;
            this.mDangNhap.HorizontalScrollbarHighlightOnWheel = false;
            this.mDangNhap.HorizontalScrollbarSize = 10;
            this.mDangNhap.Location = new System.Drawing.Point(20, 60);
            this.mDangNhap.Name = "mDangNhap";
            this.mDangNhap.Size = new System.Drawing.Size(427, 570);
            this.mDangNhap.TabIndex = 0;
            this.mDangNhap.VerticalScrollbarBarColor = true;
            this.mDangNhap.VerticalScrollbarHighlightOnWheel = false;
            this.mDangNhap.VerticalScrollbarSize = 10;
            // 
            // lblPhienBan
            // 
            this.lblPhienBan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPhienBan.AutoSize = true;
            this.lblPhienBan.Location = new System.Drawing.Point(341, 547);
            this.lblPhienBan.Name = "lblPhienBan";
            this.lblPhienBan.Size = new System.Drawing.Size(40, 19);
            this.lblPhienBan.TabIndex = 10;
            this.lblPhienBan.Text = "v2.9.1";
            // 
            // lblThongTin1
            // 
            this.lblThongTin1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblThongTin1.Location = new System.Drawing.Point(0, 524);
            this.lblThongTin1.Name = "lblThongTin1";
            this.lblThongTin1.Size = new System.Drawing.Size(427, 23);
            this.lblThongTin1.TabIndex = 9;
            this.lblThongTin1.Text = "Đồ án môn học Lập Trình Windows Nâng Cao";
            this.lblThongTin1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblThongTin2
            // 
            this.lblThongTin2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblThongTin2.Location = new System.Drawing.Point(0, 547);
            this.lblThongTin2.Name = "lblThongTin2";
            this.lblThongTin2.Size = new System.Drawing.Size(427, 23);
            this.lblThongTin2.TabIndex = 8;
            this.lblThongTin2.Text = "Lớp CĐTH 16 PMB - Nhóm 15";
            this.lblThongTin2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDangNhap.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnDangNhap.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btnDangNhap.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDangNhap.Location = new System.Drawing.Point(295, 274);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(105, 31);
            this.btnDangNhap.TabIndex = 6;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.UseSelectable = true;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Anchor = System.Windows.Forms.AnchorStyles.None;
            // 
            // 
            // 
            this.txtMatKhau.CustomButton.Image = null;
            this.txtMatKhau.CustomButton.Location = new System.Drawing.Point(279, 1);
            this.txtMatKhau.CustomButton.Name = "";
            this.txtMatKhau.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtMatKhau.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtMatKhau.CustomButton.TabIndex = 1;
            this.txtMatKhau.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtMatKhau.CustomButton.UseSelectable = true;
            this.txtMatKhau.CustomButton.Visible = false;
            this.txtMatKhau.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtMatKhau.Lines = new string[0];
            this.txtMatKhau.Location = new System.Drawing.Point(99, 245);
            this.txtMatKhau.MaxLength = 32767;
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PasswordChar = '●';
            this.txtMatKhau.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtMatKhau.SelectedText = "";
            this.txtMatKhau.SelectionLength = 0;
            this.txtMatKhau.SelectionStart = 0;
            this.txtMatKhau.ShortcutsEnabled = true;
            this.txtMatKhau.Size = new System.Drawing.Size(301, 23);
            this.txtMatKhau.TabIndex = 5;
            this.txtMatKhau.UseSelectable = true;
            this.txtMatKhau.UseSystemPasswordChar = true;
            this.txtMatKhau.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtMatKhau.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtMatKhau.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMatKhau_KeyPress);
            // 
            // cmbTaiKhoan
            // 
            this.cmbTaiKhoan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbTaiKhoan.FormattingEnabled = true;
            this.cmbTaiKhoan.ItemHeight = 23;
            this.cmbTaiKhoan.Location = new System.Drawing.Point(99, 205);
            this.cmbTaiKhoan.Name = "cmbTaiKhoan";
            this.cmbTaiKhoan.Size = new System.Drawing.Size(301, 29);
            this.cmbTaiKhoan.TabIndex = 4;
            this.cmbTaiKhoan.UseSelectable = true;
            this.cmbTaiKhoan.SelectedIndexChanged += new System.EventHandler(this.cmbTaiKhoan_SelectedIndexChanged);
            // 
            // lblMatKhau
            // 
            this.lblMatKhau.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMatKhau.AutoSize = true;
            this.lblMatKhau.Location = new System.Drawing.Point(17, 245);
            this.lblMatKhau.Name = "lblMatKhau";
            this.lblMatKhau.Size = new System.Drawing.Size(63, 19);
            this.lblMatKhau.TabIndex = 3;
            this.lblMatKhau.Text = "Mật khẩu";
            // 
            // lblTaiKhoan
            // 
            this.lblTaiKhoan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTaiKhoan.AutoSize = true;
            this.lblTaiKhoan.Location = new System.Drawing.Point(17, 211);
            this.lblTaiKhoan.Name = "lblTaiKhoan";
            this.lblTaiKhoan.Size = new System.Drawing.Size(63, 19);
            this.lblTaiKhoan.TabIndex = 2;
            this.lblTaiKhoan.Text = "Tài khoản";
            // 
            // metroPanel1
            // 
            this.metroPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("metroPanel1.BackgroundImage")));
            this.metroPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.metroPanel1.Controls.Add(this.lblPhienBan);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(447, 60);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(386, 570);
            this.metroPanel1.TabIndex = 11;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // FrmDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 650);
            this.ControlBox = false;
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.mDangNhap);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "FrmDangNhap";
            this.Resizable = false;
            this.Text = "Đăng nhập";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmDangNhap_FormClosed);
            this.Load += new System.EventHandler(this.FrmDangNhap_Load);
            this.mDangNhap.ResumeLayout(false);
            this.mDangNhap.PerformLayout();
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel mDangNhap;
        private MetroFramework.Controls.MetroLabel lblTaiKhoan;
        private MetroFramework.Controls.MetroButton btnDangNhap;
        private MetroFramework.Controls.MetroTextBox txtMatKhau;
        private MetroFramework.Controls.MetroComboBox cmbTaiKhoan;
        private MetroFramework.Controls.MetroLabel lblMatKhau;
        private MetroFramework.Controls.MetroLabel lblThongTin1;
        private MetroFramework.Controls.MetroLabel lblThongTin2;
        private MetroFramework.Controls.MetroLabel lblPhienBan;
        private MetroFramework.Controls.MetroPanel metroPanel1;
    }
}