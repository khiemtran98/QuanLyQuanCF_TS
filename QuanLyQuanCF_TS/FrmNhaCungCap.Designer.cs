namespace QuanLyQuanCF_TS
{
    partial class FrmNhaCungCap
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.metroPanel3 = new MetroFramework.Controls.MetroPanel();
            this.dgvNhaCungCap = new System.Windows.Forms.DataGridView();
            this.colMaNhaCungCap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenNhaCungCap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.metroPanel27 = new MetroFramework.Controls.MetroPanel();
            this.lnkDSNhaCungCap = new MetroFramework.Controls.MetroLink();
            this.panelDSChucNangNhaCungCap = new MetroFramework.Controls.MetroPanel();
            this.panelDSChucNangNhaCungCapDaXoa = new MetroFramework.Controls.MetroPanel();
            this.btnKhoiPhuc = new MetroFramework.Controls.MetroButton();
            this.btnLamMoi = new MetroFramework.Controls.MetroButton();
            this.btnSua = new MetroFramework.Controls.MetroButton();
            this.btnXoa = new MetroFramework.Controls.MetroButton();
            this.btnThem = new MetroFramework.Controls.MetroButton();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.txtTenNhaCungCap = new MetroFramework.Controls.MetroTextBox();
            this.txtMaNhaCungCap = new MetroFramework.Controls.MetroTextBox();
            this.metroPanel1.SuspendLayout();
            this.metroPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhaCungCap)).BeginInit();
            this.metroPanel27.SuspendLayout();
            this.panelDSChucNangNhaCungCap.SuspendLayout();
            this.panelDSChucNangNhaCungCapDaXoa.SuspendLayout();
            this.metroPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.metroPanel3);
            this.metroPanel1.Controls.Add(this.metroPanel27);
            this.metroPanel1.Controls.Add(this.panelDSChucNangNhaCungCap);
            this.metroPanel1.Controls.Add(this.metroPanel2);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(20, 60);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(760, 570);
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // metroPanel3
            // 
            this.metroPanel3.Controls.Add(this.dgvNhaCungCap);
            this.metroPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel3.HorizontalScrollbarBarColor = true;
            this.metroPanel3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel3.HorizontalScrollbarSize = 10;
            this.metroPanel3.Location = new System.Drawing.Point(0, 215);
            this.metroPanel3.Name = "metroPanel3";
            this.metroPanel3.Size = new System.Drawing.Size(760, 355);
            this.metroPanel3.TabIndex = 46;
            this.metroPanel3.VerticalScrollbarBarColor = true;
            this.metroPanel3.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel3.VerticalScrollbarSize = 10;
            // 
            // dgvNhaCungCap
            // 
            this.dgvNhaCungCap.AllowUserToAddRows = false;
            this.dgvNhaCungCap.AllowUserToDeleteRows = false;
            this.dgvNhaCungCap.AllowUserToResizeRows = false;
            this.dgvNhaCungCap.BackgroundColor = System.Drawing.Color.PapayaWhip;
            this.dgvNhaCungCap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNhaCungCap.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvNhaCungCap.ColumnHeadersHeight = 70;
            this.dgvNhaCungCap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvNhaCungCap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaNhaCungCap,
            this.colTenNhaCungCap});
            this.dgvNhaCungCap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNhaCungCap.EnableHeadersVisualStyles = false;
            this.dgvNhaCungCap.Location = new System.Drawing.Point(0, 0);
            this.dgvNhaCungCap.MultiSelect = false;
            this.dgvNhaCungCap.Name = "dgvNhaCungCap";
            this.dgvNhaCungCap.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkCyan;
            this.dgvNhaCungCap.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvNhaCungCap.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvNhaCungCap.RowTemplate.Height = 35;
            this.dgvNhaCungCap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNhaCungCap.Size = new System.Drawing.Size(760, 355);
            this.dgvNhaCungCap.TabIndex = 41;
            this.dgvNhaCungCap.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNhaCungCap_CellClick);
            // 
            // colMaNhaCungCap
            // 
            this.colMaNhaCungCap.DataPropertyName = "MaNhaCungCap";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "#,###";
            this.colMaNhaCungCap.DefaultCellStyle = dataGridViewCellStyle2;
            this.colMaNhaCungCap.HeaderText = "Mã nhà cung cấp";
            this.colMaNhaCungCap.Name = "colMaNhaCungCap";
            this.colMaNhaCungCap.ReadOnly = true;
            // 
            // colTenNhaCungCap
            // 
            this.colTenNhaCungCap.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTenNhaCungCap.DataPropertyName = "TenNhaCungCap";
            this.colTenNhaCungCap.HeaderText = "Tên nhà cung cấp";
            this.colTenNhaCungCap.Name = "colTenNhaCungCap";
            this.colTenNhaCungCap.ReadOnly = true;
            // 
            // metroPanel27
            // 
            this.metroPanel27.Controls.Add(this.lnkDSNhaCungCap);
            this.metroPanel27.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroPanel27.HorizontalScrollbarBarColor = true;
            this.metroPanel27.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel27.HorizontalScrollbarSize = 10;
            this.metroPanel27.Location = new System.Drawing.Point(0, 176);
            this.metroPanel27.Name = "metroPanel27";
            this.metroPanel27.Size = new System.Drawing.Size(760, 39);
            this.metroPanel27.TabIndex = 43;
            this.metroPanel27.VerticalScrollbarBarColor = true;
            this.metroPanel27.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel27.VerticalScrollbarSize = 10;
            // 
            // lnkDSNhaCungCap
            // 
            this.lnkDSNhaCungCap.AccessibleName = "DSNhaCungCap";
            this.lnkDSNhaCungCap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkDSNhaCungCap.Location = new System.Drawing.Point(3, 7);
            this.lnkDSNhaCungCap.Name = "lnkDSNhaCungCap";
            this.lnkDSNhaCungCap.Size = new System.Drawing.Size(754, 23);
            this.lnkDSNhaCungCap.TabIndex = 2;
            this.lnkDSNhaCungCap.Text = "Hiện danh sách nhà cung cấp đã xoá";
            this.lnkDSNhaCungCap.UseSelectable = true;
            this.lnkDSNhaCungCap.Click += new System.EventHandler(this.lnkDSNhaCungCap_Click);
            // 
            // panelDSChucNangNhaCungCap
            // 
            this.panelDSChucNangNhaCungCap.Controls.Add(this.panelDSChucNangNhaCungCapDaXoa);
            this.panelDSChucNangNhaCungCap.Controls.Add(this.btnLamMoi);
            this.panelDSChucNangNhaCungCap.Controls.Add(this.btnSua);
            this.panelDSChucNangNhaCungCap.Controls.Add(this.btnXoa);
            this.panelDSChucNangNhaCungCap.Controls.Add(this.btnThem);
            this.panelDSChucNangNhaCungCap.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDSChucNangNhaCungCap.HorizontalScrollbarBarColor = true;
            this.panelDSChucNangNhaCungCap.HorizontalScrollbarHighlightOnWheel = false;
            this.panelDSChucNangNhaCungCap.HorizontalScrollbarSize = 10;
            this.panelDSChucNangNhaCungCap.Location = new System.Drawing.Point(0, 99);
            this.panelDSChucNangNhaCungCap.Name = "panelDSChucNangNhaCungCap";
            this.panelDSChucNangNhaCungCap.Size = new System.Drawing.Size(760, 77);
            this.panelDSChucNangNhaCungCap.TabIndex = 42;
            this.panelDSChucNangNhaCungCap.VerticalScrollbarBarColor = true;
            this.panelDSChucNangNhaCungCap.VerticalScrollbarHighlightOnWheel = false;
            this.panelDSChucNangNhaCungCap.VerticalScrollbarSize = 10;
            // 
            // panelDSChucNangNhaCungCapDaXoa
            // 
            this.panelDSChucNangNhaCungCapDaXoa.Controls.Add(this.btnKhoiPhuc);
            this.panelDSChucNangNhaCungCapDaXoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDSChucNangNhaCungCapDaXoa.HorizontalScrollbarBarColor = true;
            this.panelDSChucNangNhaCungCapDaXoa.HorizontalScrollbarHighlightOnWheel = false;
            this.panelDSChucNangNhaCungCapDaXoa.HorizontalScrollbarSize = 10;
            this.panelDSChucNangNhaCungCapDaXoa.Location = new System.Drawing.Point(0, 0);
            this.panelDSChucNangNhaCungCapDaXoa.Name = "panelDSChucNangNhaCungCapDaXoa";
            this.panelDSChucNangNhaCungCapDaXoa.Size = new System.Drawing.Size(760, 77);
            this.panelDSChucNangNhaCungCapDaXoa.TabIndex = 44;
            this.panelDSChucNangNhaCungCapDaXoa.VerticalScrollbarBarColor = true;
            this.panelDSChucNangNhaCungCapDaXoa.VerticalScrollbarHighlightOnWheel = false;
            this.panelDSChucNangNhaCungCapDaXoa.VerticalScrollbarSize = 10;
            this.panelDSChucNangNhaCungCapDaXoa.Visible = false;
            // 
            // btnKhoiPhuc
            // 
            this.btnKhoiPhuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnKhoiPhuc.BackColor = System.Drawing.Color.OliveDrab;
            this.btnKhoiPhuc.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnKhoiPhuc.ForeColor = System.Drawing.Color.White;
            this.btnKhoiPhuc.Location = new System.Drawing.Point(326, 18);
            this.btnKhoiPhuc.Name = "btnKhoiPhuc";
            this.btnKhoiPhuc.Size = new System.Drawing.Size(105, 40);
            this.btnKhoiPhuc.TabIndex = 18;
            this.btnKhoiPhuc.Text = "Khôi phục";
            this.btnKhoiPhuc.UseCustomBackColor = true;
            this.btnKhoiPhuc.UseCustomForeColor = true;
            this.btnKhoiPhuc.UseSelectable = true;
            this.btnKhoiPhuc.Click += new System.EventHandler(this.btnKhoiPhuc_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnLamMoi.BackColor = System.Drawing.Color.OliveDrab;
            this.btnLamMoi.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(588, 18);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(105, 40);
            this.btnLamMoi.TabIndex = 18;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseCustomBackColor = true;
            this.btnLamMoi.UseCustomForeColor = true;
            this.btnLamMoi.UseSelectable = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnSua
            // 
            this.btnSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnSua.BackColor = System.Drawing.Color.DimGray;
            this.btnSua.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(244, 18);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(105, 40);
            this.btnSua.TabIndex = 4;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseCustomBackColor = true;
            this.btnSua.UseCustomForeColor = true;
            this.btnSua.UseSelectable = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnXoa.BackColor = System.Drawing.Color.Firebrick;
            this.btnXoa.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(416, 18);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(105, 40);
            this.btnXoa.TabIndex = 3;
            this.btnXoa.Text = "Xoá";
            this.btnXoa.UseCustomBackColor = true;
            this.btnXoa.UseCustomForeColor = true;
            this.btnXoa.UseSelectable = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnThem.BackColor = System.Drawing.Color.SteelBlue;
            this.btnThem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnThem.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(72, 18);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(105, 40);
            this.btnThem.TabIndex = 2;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseCustomBackColor = true;
            this.btnThem.UseCustomForeColor = true;
            this.btnThem.UseSelectable = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // metroPanel2
            // 
            this.metroPanel2.Controls.Add(this.metroLabel2);
            this.metroPanel2.Controls.Add(this.metroLabel3);
            this.metroPanel2.Controls.Add(this.txtTenNhaCungCap);
            this.metroPanel2.Controls.Add(this.txtMaNhaCungCap);
            this.metroPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(0, 0);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(760, 99);
            this.metroPanel2.TabIndex = 45;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.Location = new System.Drawing.Point(25, 22);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(145, 25);
            this.metroLabel2.TabIndex = 37;
            this.metroLabel2.Text = "Mã nhà cung cấp";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.Location = new System.Drawing.Point(25, 63);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(146, 25);
            this.metroLabel3.TabIndex = 38;
            this.metroLabel3.Text = "Tên nhà cung cấp";
            // 
            // txtTenNhaCungCap
            // 
            this.txtTenNhaCungCap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtTenNhaCungCap.CustomButton.Image = null;
            this.txtTenNhaCungCap.CustomButton.Location = new System.Drawing.Point(537, 1);
            this.txtTenNhaCungCap.CustomButton.Name = "";
            this.txtTenNhaCungCap.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtTenNhaCungCap.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtTenNhaCungCap.CustomButton.TabIndex = 1;
            this.txtTenNhaCungCap.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtTenNhaCungCap.CustomButton.UseSelectable = true;
            this.txtTenNhaCungCap.CustomButton.Visible = false;
            this.txtTenNhaCungCap.Lines = new string[0];
            this.txtTenNhaCungCap.Location = new System.Drawing.Point(177, 65);
            this.txtTenNhaCungCap.MaxLength = 32767;
            this.txtTenNhaCungCap.Name = "txtTenNhaCungCap";
            this.txtTenNhaCungCap.PasswordChar = '\0';
            this.txtTenNhaCungCap.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtTenNhaCungCap.SelectedText = "";
            this.txtTenNhaCungCap.SelectionLength = 0;
            this.txtTenNhaCungCap.SelectionStart = 0;
            this.txtTenNhaCungCap.ShortcutsEnabled = true;
            this.txtTenNhaCungCap.Size = new System.Drawing.Size(559, 23);
            this.txtTenNhaCungCap.TabIndex = 39;
            this.txtTenNhaCungCap.UseSelectable = true;
            this.txtTenNhaCungCap.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtTenNhaCungCap.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtMaNhaCungCap
            // 
            this.txtMaNhaCungCap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtMaNhaCungCap.CustomButton.Image = null;
            this.txtMaNhaCungCap.CustomButton.Location = new System.Drawing.Point(537, 1);
            this.txtMaNhaCungCap.CustomButton.Name = "";
            this.txtMaNhaCungCap.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtMaNhaCungCap.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtMaNhaCungCap.CustomButton.TabIndex = 1;
            this.txtMaNhaCungCap.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtMaNhaCungCap.CustomButton.UseSelectable = true;
            this.txtMaNhaCungCap.CustomButton.Visible = false;
            this.txtMaNhaCungCap.Enabled = false;
            this.txtMaNhaCungCap.Lines = new string[0];
            this.txtMaNhaCungCap.Location = new System.Drawing.Point(177, 24);
            this.txtMaNhaCungCap.MaxLength = 32767;
            this.txtMaNhaCungCap.Name = "txtMaNhaCungCap";
            this.txtMaNhaCungCap.PasswordChar = '\0';
            this.txtMaNhaCungCap.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtMaNhaCungCap.SelectedText = "";
            this.txtMaNhaCungCap.SelectionLength = 0;
            this.txtMaNhaCungCap.SelectionStart = 0;
            this.txtMaNhaCungCap.ShortcutsEnabled = true;
            this.txtMaNhaCungCap.Size = new System.Drawing.Size(559, 23);
            this.txtMaNhaCungCap.TabIndex = 40;
            this.txtMaNhaCungCap.UseSelectable = true;
            this.txtMaNhaCungCap.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtMaNhaCungCap.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // FrmNhaCungCap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 650);
            this.Controls.Add(this.metroPanel1);
            this.Name = "FrmNhaCungCap";
            this.Text = "Nhà cung cấp";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmNhaCungCap_FormClosed);
            this.Load += new System.EventHandler(this.FrmNhaCungCap_Load);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhaCungCap)).EndInit();
            this.metroPanel27.ResumeLayout(false);
            this.panelDSChucNangNhaCungCap.ResumeLayout(false);
            this.panelDSChucNangNhaCungCapDaXoa.ResumeLayout(false);
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroPanel panelDSChucNangNhaCungCap;
        private MetroFramework.Controls.MetroButton btnLamMoi;
        private MetroFramework.Controls.MetroButton btnSua;
        private MetroFramework.Controls.MetroButton btnXoa;
        private MetroFramework.Controls.MetroButton btnThem;
        private System.Windows.Forms.DataGridView dgvNhaCungCap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaNhaCungCap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenNhaCungCap;
        private MetroFramework.Controls.MetroTextBox txtMaNhaCungCap;
        private MetroFramework.Controls.MetroTextBox txtTenNhaCungCap;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroPanel metroPanel27;
        private MetroFramework.Controls.MetroLink lnkDSNhaCungCap;
        private MetroFramework.Controls.MetroPanel panelDSChucNangNhaCungCapDaXoa;
        private MetroFramework.Controls.MetroButton btnKhoiPhuc;
        private MetroFramework.Controls.MetroPanel metroPanel3;
        private MetroFramework.Controls.MetroPanel metroPanel2;
    }
}