namespace QuanLyQuanCF_TS
{
    partial class FrmBanHang
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panelMenu = new MetroFramework.Controls.MetroPanel();
            this.lsvMon = new System.Windows.Forms.ListView();
            this.colMenuTenMon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMenuGiaTien = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.btnQuayLai = new System.Windows.Forms.Button();
            this.txtTimKiem = new MetroFramework.Controls.MetroTextBox();
            this.panelHoaDon = new MetroFramework.Controls.MetroPanel();
            this.panelThanhToan = new MetroFramework.Controls.MetroPanel();
            this.lblThanhTien = new MetroFramework.Controls.MetroLabel();
            this.lblTong = new MetroFramework.Controls.MetroLabel();
            this.btnHoaDon = new System.Windows.Forms.Button();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.colTenMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelLayout = new MetroFramework.Controls.MetroPanel();
            this.panelLoaiMon = new MetroFramework.Controls.MetroPanel();
            this.imlMon = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.panelHoaDon.SuspendLayout();
            this.panelThanhToan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.panelLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panelMenu);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelHoaDon);
            this.splitContainer1.Panel2MinSize = 350;
            this.splitContainer1.Size = new System.Drawing.Size(754, 341);
            this.splitContainer1.SplitterDistance = 321;
            this.splitContainer1.TabIndex = 0;
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.lsvMon);
            this.panelMenu.Controls.Add(this.metroLabel1);
            this.panelMenu.Controls.Add(this.btnQuayLai);
            this.panelMenu.Controls.Add(this.txtTimKiem);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMenu.HorizontalScrollbarBarColor = true;
            this.panelMenu.HorizontalScrollbarHighlightOnWheel = false;
            this.panelMenu.HorizontalScrollbarSize = 10;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(321, 341);
            this.panelMenu.TabIndex = 1;
            this.panelMenu.VerticalScrollbarBarColor = true;
            this.panelMenu.VerticalScrollbarHighlightOnWheel = false;
            this.panelMenu.VerticalScrollbarSize = 10;
            // 
            // lsvMon
            // 
            this.lsvMon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvMon.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colMenuTenMon,
            this.colMenuGiaTien});
            this.lsvMon.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvMon.FullRowSelect = true;
            this.lsvMon.GridLines = true;
            this.lsvMon.LargeImageList = this.imlMon;
            this.lsvMon.Location = new System.Drawing.Point(3, 37);
            this.lsvMon.MultiSelect = false;
            this.lsvMon.Name = "lsvMon";
            this.lsvMon.Size = new System.Drawing.Size(315, 301);
            this.lsvMon.TabIndex = 5;
            this.lsvMon.TileSize = new System.Drawing.Size(270, 100);
            this.lsvMon.UseCompatibleStateImageBehavior = false;
            this.lsvMon.View = System.Windows.Forms.View.Tile;
            // 
            // colMenuTenMon
            // 
            this.colMenuTenMon.Text = "Tên món";
            // 
            // colMenuGiaTien
            // 
            this.colMenuGiaTien.Text = "Giá tiền";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(27, 9);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(63, 19);
            this.metroLabel1.TabIndex = 4;
            this.metroLabel1.Text = "Tìm kiếm";
            // 
            // btnQuayLai
            // 
            this.btnQuayLai.BackgroundImage = global::QuanLyQuanCF_TS.Properties.Resources.back;
            this.btnQuayLai.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnQuayLai.FlatAppearance.BorderSize = 0;
            this.btnQuayLai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuayLai.Location = new System.Drawing.Point(3, 8);
            this.btnQuayLai.Name = "btnQuayLai";
            this.btnQuayLai.Size = new System.Drawing.Size(20, 20);
            this.btnQuayLai.TabIndex = 3;
            this.btnQuayLai.UseVisualStyleBackColor = true;
            this.btnQuayLai.Click += new System.EventHandler(this.btnQuayLai_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtTimKiem.CustomButton.Image = null;
            this.txtTimKiem.CustomButton.Location = new System.Drawing.Point(200, 1);
            this.txtTimKiem.CustomButton.Name = "";
            this.txtTimKiem.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtTimKiem.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtTimKiem.CustomButton.TabIndex = 1;
            this.txtTimKiem.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtTimKiem.CustomButton.UseSelectable = true;
            this.txtTimKiem.CustomButton.Visible = false;
            this.txtTimKiem.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtTimKiem.Lines = new string[0];
            this.txtTimKiem.Location = new System.Drawing.Point(96, 8);
            this.txtTimKiem.MaxLength = 32767;
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.PasswordChar = '\0';
            this.txtTimKiem.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtTimKiem.SelectedText = "";
            this.txtTimKiem.SelectionLength = 0;
            this.txtTimKiem.SelectionStart = 0;
            this.txtTimKiem.ShortcutsEnabled = true;
            this.txtTimKiem.Size = new System.Drawing.Size(222, 23);
            this.txtTimKiem.TabIndex = 2;
            this.txtTimKiem.UseSelectable = true;
            this.txtTimKiem.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtTimKiem.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtTimKiem.Enter += new System.EventHandler(this.txtTimKiem_Enter);
            this.txtTimKiem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTimKiem_KeyPress);
            this.txtTimKiem.Leave += new System.EventHandler(this.txtTimKiem_Leave);
            // 
            // panelHoaDon
            // 
            this.panelHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelHoaDon.Controls.Add(this.panelThanhToan);
            this.panelHoaDon.Controls.Add(this.dgvHoaDon);
            this.panelHoaDon.HorizontalScrollbarBarColor = true;
            this.panelHoaDon.HorizontalScrollbarHighlightOnWheel = false;
            this.panelHoaDon.HorizontalScrollbarSize = 10;
            this.panelHoaDon.Location = new System.Drawing.Point(13, 0);
            this.panelHoaDon.Name = "panelHoaDon";
            this.panelHoaDon.Size = new System.Drawing.Size(416, 338);
            this.panelHoaDon.TabIndex = 0;
            this.panelHoaDon.VerticalScrollbarBarColor = true;
            this.panelHoaDon.VerticalScrollbarHighlightOnWheel = false;
            this.panelHoaDon.VerticalScrollbarSize = 10;
            // 
            // panelThanhToan
            // 
            this.panelThanhToan.Controls.Add(this.lblThanhTien);
            this.panelThanhToan.Controls.Add(this.lblTong);
            this.panelThanhToan.Controls.Add(this.btnHoaDon);
            this.panelThanhToan.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelThanhToan.HorizontalScrollbarBarColor = true;
            this.panelThanhToan.HorizontalScrollbarHighlightOnWheel = false;
            this.panelThanhToan.HorizontalScrollbarSize = 10;
            this.panelThanhToan.Location = new System.Drawing.Point(0, 226);
            this.panelThanhToan.Name = "panelThanhToan";
            this.panelThanhToan.Size = new System.Drawing.Size(416, 112);
            this.panelThanhToan.TabIndex = 8;
            this.panelThanhToan.VerticalScrollbarBarColor = true;
            this.panelThanhToan.VerticalScrollbarHighlightOnWheel = false;
            this.panelThanhToan.VerticalScrollbarSize = 10;
            // 
            // lblThanhTien
            // 
            this.lblThanhTien.AutoSize = true;
            this.lblThanhTien.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblThanhTien.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblThanhTien.Location = new System.Drawing.Point(3, 19);
            this.lblThanhTien.Name = "lblThanhTien";
            this.lblThanhTien.Size = new System.Drawing.Size(33, 25);
            this.lblThanhTien.TabIndex = 6;
            this.lblThanhTien.Text = "0d";
            // 
            // lblTong
            // 
            this.lblTong.AutoSize = true;
            this.lblTong.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblTong.Location = new System.Drawing.Point(3, 4);
            this.lblTong.Name = "lblTong";
            this.lblTong.Size = new System.Drawing.Size(33, 15);
            this.lblTong.TabIndex = 5;
            this.lblTong.Text = "Tổng";
            // 
            // btnHoaDon
            // 
            this.btnHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHoaDon.BackColor = System.Drawing.Color.LimeGreen;
            this.btnHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHoaDon.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHoaDon.ForeColor = System.Drawing.SystemColors.Window;
            this.btnHoaDon.Location = new System.Drawing.Point(3, 53);
            this.btnHoaDon.Name = "btnHoaDon";
            this.btnHoaDon.Size = new System.Drawing.Size(410, 56);
            this.btnHoaDon.TabIndex = 7;
            this.btnHoaDon.Text = "HOÁ ĐƠN";
            this.btnHoaDon.UseVisualStyleBackColor = false;
            this.btnHoaDon.Click += new System.EventHandler(this.btnHoaDon_Click);
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.AllowUserToAddRows = false;
            this.dgvHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHoaDon.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHoaDon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvHoaDon.ColumnHeadersHeight = 50;
            this.dgvHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTenMon,
            this.colDonGia});
            this.dgvHoaDon.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvHoaDon.Location = new System.Drawing.Point(3, 8);
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.RowHeadersVisible = false;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvHoaDon.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvHoaDon.RowTemplate.Height = 50;
            this.dgvHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaDon.Size = new System.Drawing.Size(410, 212);
            this.dgvHoaDon.TabIndex = 4;
            this.dgvHoaDon.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHoaDon_CellValueChanged);
            this.dgvHoaDon.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvHoaDon_RowsRemoved);
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
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colDonGia.DefaultCellStyle = dataGridViewCellStyle11;
            this.colDonGia.HeaderText = "Đơn giá";
            this.colDonGia.Name = "colDonGia";
            this.colDonGia.ReadOnly = true;
            // 
            // panelLayout
            // 
            this.panelLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelLayout.Controls.Add(this.splitContainer1);
            this.panelLayout.HorizontalScrollbarBarColor = true;
            this.panelLayout.HorizontalScrollbarHighlightOnWheel = false;
            this.panelLayout.HorizontalScrollbarSize = 10;
            this.panelLayout.Location = new System.Drawing.Point(23, 20);
            this.panelLayout.Name = "panelLayout";
            this.panelLayout.Size = new System.Drawing.Size(754, 341);
            this.panelLayout.TabIndex = 0;
            this.panelLayout.VerticalScrollbarBarColor = true;
            this.panelLayout.VerticalScrollbarHighlightOnWheel = false;
            this.panelLayout.VerticalScrollbarSize = 10;
            // 
            // panelLoaiMon
            // 
            this.panelLoaiMon.BackColor = System.Drawing.SystemColors.Control;
            this.panelLoaiMon.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelLoaiMon.HorizontalScrollbar = true;
            this.panelLoaiMon.HorizontalScrollbarBarColor = false;
            this.panelLoaiMon.HorizontalScrollbarHighlightOnWheel = false;
            this.panelLoaiMon.HorizontalScrollbarSize = 10;
            this.panelLoaiMon.Location = new System.Drawing.Point(20, 370);
            this.panelLoaiMon.Name = "panelLoaiMon";
            this.panelLoaiMon.Size = new System.Drawing.Size(760, 60);
            this.panelLoaiMon.TabIndex = 1;
            this.panelLoaiMon.VerticalScrollbarBarColor = true;
            this.panelLoaiMon.VerticalScrollbarHighlightOnWheel = false;
            this.panelLoaiMon.VerticalScrollbarSize = 10;
            // 
            // imlMon
            // 
            this.imlMon.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imlMon.ImageSize = new System.Drawing.Size(64, 64);
            this.imlMon.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // FrmBanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.panelLoaiMon);
            this.Controls.Add(this.panelLayout);
            this.DisplayHeader = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBanHang";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Resizable = false;
            this.ShowIcon = false;
            this.Text = "Bán hàng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmBanHang_FormClosed);
            this.Load += new System.EventHandler(this.FrmBanHang_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.panelHoaDon.ResumeLayout(false);
            this.panelThanhToan.ResumeLayout(false);
            this.panelThanhToan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.panelLayout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private MetroFramework.Controls.MetroPanel panelMenu;
        private MetroFramework.Controls.MetroTextBox txtTimKiem;
        private System.Windows.Forms.Button btnQuayLai;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.ListView lsvMon;
        private MetroFramework.Controls.MetroPanel panelHoaDon;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.Button btnHoaDon;
        private MetroFramework.Controls.MetroLabel lblThanhTien;
        private MetroFramework.Controls.MetroLabel lblTong;
        private MetroFramework.Controls.MetroPanel panelThanhToan;
        private System.Windows.Forms.ColumnHeader colMenuTenMon;
        private System.Windows.Forms.ColumnHeader colMenuGiaTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonGia;
        private MetroFramework.Controls.MetroPanel panelLayout;
        private MetroFramework.Controls.MetroPanel panelLoaiMon;
        private System.Windows.Forms.ImageList imlMon;
    }
}