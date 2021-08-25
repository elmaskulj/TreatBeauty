
namespace TreatBeauty.WinUI.TermForms
{
    partial class EmployeeTerm
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
            this.pbxPhoto = new System.Windows.Forms.PictureBox();
            this.lblFirstAndLastName = new System.Windows.Forms.Label();
            this.pnlTerms = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxPhoto
            // 
            this.pbxPhoto.Location = new System.Drawing.Point(136, 12);
            this.pbxPhoto.Name = "pbxPhoto";
            this.pbxPhoto.Size = new System.Drawing.Size(75, 63);
            this.pbxPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbxPhoto.TabIndex = 0;
            this.pbxPhoto.TabStop = false;
            // 
            // lblFirstAndLastName
            // 
            this.lblFirstAndLastName.AutoSize = true;
            this.lblFirstAndLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstAndLastName.Location = new System.Drawing.Point(123, 88);
            this.lblFirstAndLastName.Name = "lblFirstAndLastName";
            this.lblFirstAndLastName.Size = new System.Drawing.Size(103, 20);
            this.lblFirstAndLastName.TabIndex = 1;
            this.lblFirstAndLastName.Text = "Ime Prezime";
            // 
            // pnlTerms
            // 
            this.pnlTerms.Location = new System.Drawing.Point(23, 132);
            this.pnlTerms.Name = "pnlTerms";
            this.pnlTerms.Size = new System.Drawing.Size(313, 381);
            this.pnlTerms.TabIndex = 2;
            // 
            // EmployeeTerm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlTerms);
            this.Controls.Add(this.lblFirstAndLastName);
            this.Controls.Add(this.pbxPhoto);
            this.Name = "EmployeeTerm";
            this.Size = new System.Drawing.Size(357, 535);
            this.Load += new System.EventHandler(this.EmployeeTerm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxPhoto;
        private System.Windows.Forms.Label lblFirstAndLastName;
        private System.Windows.Forms.Panel pnlTerms;
    }
}
