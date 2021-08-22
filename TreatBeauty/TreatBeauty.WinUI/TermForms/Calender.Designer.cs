
namespace TreatBeauty.WinUI.TermForms
{
    partial class Calender
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
            this.cardLayout1 = new Syncfusion.Windows.Forms.Tools.CardLayout(this.components);
            this.cardLayout2 = new Syncfusion.Windows.Forms.Tools.CardLayout(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.cardLayout1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardLayout2)).BeginInit();
            this.SuspendLayout();
            // 
            // cardLayout1
            // 
            this.cardLayout1.ContainerControl = this;
            // 
            // Calender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "Calender";
            this.Text = "Calender";
            ((System.ComponentModel.ISupportInitialize)(this.cardLayout1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardLayout2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Syncfusion.Windows.Forms.Tools.CardLayout cardLayout1;
        private Syncfusion.Windows.Forms.Tools.CardLayout cardLayout2;
    }
}