namespace QuanLyQuanCF_TS
{
    partial class ucXemLaiHoaDon
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.lblTenNhanVien = new MetroFramework.Controls.MetroLabel();
            this.lblNgayLap = new MetroFramework.Controls.MetroLabel();
            this.lblTongLy = new MetroFramework.Controls.MetroLabel();
            this.lblTongTien = new MetroFramework.Controls.MetroLabel();
            this.lblTongPhaiTra = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.txtTienMat = new MetroFramework.Controls.MetroTextBox();
            this.txtTienThoi = new MetroFramework.Controls.MetroTextBox();
            this.btnXuatHoaDon = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnQuayLai = new System.Windows.Forms.Button();
            this.colTenMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.AllowUserToAddRows = false;
            this.dgvHoaDon.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHoaDon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHoaDon.ColumnHeadersHeight = 50;
            this.dgvHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTenMon,
            this.colDonGia});
            this.dgvHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHoaDon.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvHoaDon.Location = new System.Drawing.Point(0, 0);
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvHoaDon.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHoaDon.RowTemplate.Height = 50;
            this.dgvHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaDon.Size = new System.Drawing.Size(310, 331);
            this.dgvHoaDon.TabIndex = 5;
            // 
            // lblTenNhanVien
            // 
            this.lblTenNhanVien.AutoSize = true;
            this.lblTenNhanVien.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblTenNhanVien.Location = new System.Drawing.Point(13, 10);
            this.lblTenNhanVien.Name = "lblTenNhanVien";
            this.lblTenNhanVien.Size = new System.Drawing.Size(90, 25);
            this.lblTenNhanVien.TabIndex = 6;
            this.lblTenNhanVien.Text = "Nhân viên";
            // 
            // lblNgayLap
            // 
            this.lblNgayLap.AutoSize = true;
            this.lblNgayLap.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblNgayLap.Location = new System.Drawing.Point(13, 35);
            this.lblNgayLap.Name = "lblNgayLap";
            this.lblNgayLap.Size = new System.Drawing.Size(89, 25);
            this.lblNgayLap.TabIndex = 7;
            this.lblNgayLap.Text = "01/01/2018";
            // 
            // lblTongLy
            // 
            this.lblTongLy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTongLy.AutoSize = true;
            this.lblTongLy.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblTongLy.Location = new System.Drawing.Point(13, 67);
            this.lblTongLy.Name = "lblTongLy";
            this.lblTongLy.Size = new System.Drawing.Size(72, 25);
            this.lblTongLy.TabIndex = 9;
            this.lblTongLy.Text = "Tổng ly:";
            // 
            // lblTongTien
            // 
            this.lblTongTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblTongTien.Location = new System.Drawing.Point(13, 101);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(84, 25);
            this.lblTongTien.TabIndex = 10;
            this.lblTongTien.Text = "Tổng tiền";
            // 
            // lblTongPhaiTra
            // 
            this.lblTongPhaiTra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTongPhaiTra.AutoSize = true;
            this.lblTongPhaiTra.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblTongPhaiTra.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblTongPhaiTra.Location = new System.Drawing.Point(13, 143);
            this.lblTongPhaiTra.Name = "lblTongPhaiTra";
            this.lblTongPhaiTra.Size = new System.Drawing.Size(122, 25);
            this.lblTongPhaiTra.TabIndex = 11;
            this.lblTongPhaiTra.Text = "Tổng phải trả:";
            // 
            // metroLabel6
            // 
            this.metroLabel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel6.Location = new System.Drawing.Point(13, 189);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(82, 25);
            this.metroLabel6.TabIndex = 12;
            this.metroLabel6.Text = "Tiền mặt:";
            // 
            // metroLabel7
            // 
            this.metroLabel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel7.Location = new System.Drawing.Point(13, 225);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(82, 25);
            this.metroLabel7.TabIndex = 13;
            this.metroLabel7.Text = "Tiền thối:";
            // 
            // txtTienMat
            // 
            this.txtTienMat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtTienMat.CustomButton.Image = null;
            this.txtTienMat.CustomButton.Location = new System.Drawing.Point(262, 1);
            this.txtTienMat.CustomButton.Name = "";
            this.txtTienMat.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtTienMat.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtTienMat.CustomButton.TabIndex = 1;
            this.txtTienMat.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtTienMat.CustomButton.UseSelectable = true;
            this.txtTienMat.CustomButton.Visible = false;
            this.txtTienMat.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtTienMat.Lines = new string[0];
            this.txtTienMat.Location = new System.Drawing.Point(101, 191);
            this.txtTienMat.MaxLength = 32767;
            this.txtTienMat.Name = "txtTienMat";
            this.txtTienMat.PasswordChar = '\0';
            this.txtTienMat.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtTienMat.SelectedText = "";
            this.txtTienMat.SelectionLength = 0;
            this.txtTienMat.SelectionStart = 0;
            this.txtTienMat.ShortcutsEnabled = true;
            this.txtTienMat.Size = new System.Drawing.Size(284, 23);
            this.txtTienMat.TabIndex = 14;
            this.txtTienMat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTienMat.UseSelectable = true;
            this.txtTienMat.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtTienMat.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtTienThoi
            // 
            this.txtTienThoi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtTienThoi.CustomButton.Image = null;
            this.txtTienThoi.CustomButton.Location = new System.Drawing.Point(262, 1);
            this.txtTienThoi.CustomButton.Name = "";
            this.txtTienThoi.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtTienThoi.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtTienThoi.CustomButton.TabIndex = 1;
            this.txtTienThoi.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtTienThoi.CustomButton.UseSelectable = true;
            this.txtTienThoi.CustomButton.Visible = false;
            this.txtTienThoi.Enabled = false;
            this.txtTienThoi.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtTienThoi.Lines = new string[0];
            this.txtTienThoi.Location = new System.Drawing.Point(101, 227);
            this.txtTienThoi.MaxLength = 32767;
            this.txtTienThoi.Name = "txtTienThoi";
            this.txtTienThoi.PasswordChar = '\0';
            this.txtTienThoi.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtTienThoi.SelectedText = "";
            this.txtTienThoi.SelectionLength = 0;
            this.txtTienThoi.SelectionStart = 0;
            this.txtTienThoi.ShortcutsEnabled = true;
            this.txtTienThoi.Size = new System.Drawing.Size(284, 23);
            this.txtTienThoi.TabIndex = 15;
            this.txtTienThoi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTienThoi.UseSelectable = true;
            this.txtTienThoi.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtTienThoi.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnXuatHoaDon
            // 
            this.btnXuatHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXuatHoaDon.BackColor = System.Drawing.Color.LimeGreen;
            this.btnXuatHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatHoaDon.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatHoaDon.ForeColor = System.Drawing.SystemColors.Window;
            this.btnXuatHoaDon.Location = new System.Drawing.Point(13, 269);
            this.btnXuatHoaDon.Name = "btnXuatHoaDon";
            this.btnXuatHoaDon.Size = new System.Drawing.Size(372, 56);
            this.btnXuatHoaDon.TabIndex = 18;
            this.btnXuatHoaDon.Text = "XUẤT HOÁ ĐƠN";
            this.btnXuatHoaDon.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dgvHoaDon);
            this.panel1.Location = new System.Drawing.Point(13, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(310, 331);
            this.panel1.TabIndex = 19;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.lblTenNhanVien);
            this.panel2.Controls.Add(this.lblNgayLap);
            this.panel2.Controls.Add(this.btnXuatHoaDon);
            this.panel2.Controls.Add(this.lblTongLy);
            this.panel2.Controls.Add(this.txtTienThoi);
            this.panel2.Controls.Add(this.lblTongTien);
            this.panel2.Controls.Add(this.txtTienMat);
            this.panel2.Controls.Add(this.lblTongPhaiTra);
            this.panel2.Controls.Add(this.metroLabel7);
            this.panel2.Controls.Add(this.metroLabel6);
            this.panel2.Location = new System.Drawing.Point(329, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(399, 328);
            this.panel2.TabIndex = 20;
            // 
            // btnQuayLai
            // 
            this.btnQuayLai.BackgroundImage = global::QuanLyQuanCF_TS.Properties.Resources.back;
            this.btnQuayLai.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnQuayLai.FlatAppearance.BorderSize = 0;
            this.btnQuayLai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuayLai.Location = new System.Drawing.Point(13, 10);
            this.btnQuayLai.Name = "btnQuayLai";
            this.btnQuayLai.Size = new System.Drawing.Size(20, 20);
            this.btnQuayLai.TabIndex = 6;
            this.btnQuayLai.UseVisualStyleBackColor = true;
            this.btnQuayLai.Click += new System.EventHandler(this.btnQuayLai_Click);
            // 
            // colTenMon
            // 
            this.colTenMon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTenMon.HeaderText = "Tên món";
            this.colTenMon.Name = "colTenMon";
            this.colTenMon.ReadOnly = true;
            // 
            // colDonGia
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colDonGia.DefaultCellStyle = dataGridViewCellStyle2;
            this.colDonGia.HeaderText = "Đơn giá";
            this.colDonGia.Name = "colDonGia";
            this.colDonGia.ReadOnly = true;
            this.colDonGia.Width = 150;
            // 
            // ucXemLaiHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnQuayLai);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ucXemLaiHoaDon";
            this.Size = new System.Drawing.Size(728, 376);
            this.Load += new System.EventHandler(this.ucXemLaiHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHoaDon;
        private MetroFramework.Controls.MetroLabel lblTenNhanVien;
        private MetroFramework.Controls.MetroLabel lblNgayLap;
        private MetroFramework.Controls.MetroLabel lblTongLy;
        private MetroFramework.Controls.MetroLabel lblTongTien;
        private MetroFramework.Controls.MetroLabel lblTongPhaiTra;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroTextBox txtTienMat;
        private MetroFramework.Controls.MetroTextBox txtTienThoi;
        private System.Windows.Forms.Button btnXuatHoaDon;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnQuayLai;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonGia;
    }
}
