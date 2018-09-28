namespace QuanLyQuanCF_TS
{
    partial class FrmQuanLyHoaDon
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
            this.lsvHoaDon = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lsvHoaDon
            // 
            this.lsvHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvHoaDon.Location = new System.Drawing.Point(0, 0);
            this.lsvHoaDon.Name = "lsvHoaDon";
            this.lsvHoaDon.Size = new System.Drawing.Size(800, 450);
            this.lsvHoaDon.TabIndex = 0;
            this.lsvHoaDon.UseCompatibleStateImageBehavior = false;
            // 
            // FrmQuanLyHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lsvHoaDon);
            this.Name = "FrmQuanLyHoaDon";
            this.Text = "Quản lý hoá đơn";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmQuanLyHoaDon_FormClosed);
            this.Load += new System.EventHandler(this.FrmQuanLyHoaDon_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmQuanLyHoaDon_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lsvHoaDon;
    }
}