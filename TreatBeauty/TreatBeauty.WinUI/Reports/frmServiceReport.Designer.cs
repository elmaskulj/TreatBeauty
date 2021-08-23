
namespace TreatBeauty.WinUI.Reports
{
    partial class frmServiceReport
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
            this.lblSalon = new System.Windows.Forms.Label();
            this.cmbSalon = new System.Windows.Forms.ComboBox();
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSalon
            // 
            this.lblSalon.AutoSize = true;
            this.lblSalon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalon.Location = new System.Drawing.Point(25, 34);
            this.lblSalon.Name = "lblSalon";
            this.lblSalon.Size = new System.Drawing.Size(127, 20);
            this.lblSalon.TabIndex = 33;
            this.lblSalon.Text = "Odaberite salon";
            // 
            // cmbSalon
            // 
            this.cmbSalon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSalon.FormattingEnabled = true;
            this.cmbSalon.Location = new System.Drawing.Point(29, 61);
            this.cmbSalon.Name = "cmbSalon";
            this.cmbSalon.Size = new System.Drawing.Size(273, 28);
            this.cmbSalon.TabIndex = 32;
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(49)))), ((int)(((byte)(102)))));
            this.btnAddCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCategory.ForeColor = System.Drawing.Color.White;
            this.btnAddCategory.Location = new System.Drawing.Point(369, 47);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(179, 42);
            this.btnAddCategory.TabIndex = 34;
            this.btnAddCategory.Text = "Generiši izvještaj";
            this.btnAddCategory.UseVisualStyleBackColor = false;
            this.btnAddCategory.UseWaitCursor = true;
            this.btnAddCategory.Click += new System.EventHandler(this.btnAddCategory_Click);
            // 
            // frmServiceReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(843, 597);
            this.Controls.Add(this.btnAddCategory);
            this.Controls.Add(this.lblSalon);
            this.Controls.Add(this.cmbSalon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmServiceReport";
            this.Text = "frmServiceReport";
            this.Load += new System.EventHandler(this.frmServiceReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSalon;
        private System.Windows.Forms.ComboBox cmbSalon;
        private System.Windows.Forms.Button btnAddCategory;
    }
}