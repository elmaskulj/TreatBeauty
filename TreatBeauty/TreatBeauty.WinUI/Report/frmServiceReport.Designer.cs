
namespace TreatBeauty.WinUI.Report
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
            this.components = new System.ComponentModel.Container();
            this.tblBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.serviceDataSet = new TreatBeauty.WinUI.Report.serviceDataSet();
            this.lblSalon = new System.Windows.Forms.Label();
            this.cmbSalon = new System.Windows.Forms.ComboBox();
            this.btnAddEmployee = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.serviceDataSet = new TreatBeauty.WinUI.Report.serviceDataSet();
            this.tblBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.serviceDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // tblBindingSource
            // 
            this.tblBindingSource.DataMember = "tbl";
            this.tblBindingSource.DataSource = this.serviceDataSet;
            // 
            // serviceDataSet
            // 
            this.serviceDataSet.DataSetName = "serviceDataSet";
            this.serviceDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblSalon
            // 
            this.lblSalon.AutoSize = true;
            this.lblSalon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalon.Location = new System.Drawing.Point(69, 27);
            this.lblSalon.Name = "lblSalon";
            this.lblSalon.Size = new System.Drawing.Size(51, 20);
            this.lblSalon.TabIndex = 33;
            this.lblSalon.Text = "Salon";
            // 
            // cmbSalon
            // 
            this.cmbSalon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSalon.FormattingEnabled = true;
            this.cmbSalon.Location = new System.Drawing.Point(73, 54);
            this.cmbSalon.Name = "cmbSalon";
            this.cmbSalon.Size = new System.Drawing.Size(273, 28);
            this.cmbSalon.TabIndex = 32;
            // 
            // btnAddEmployee
            // 
            this.btnAddEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(49)))), ((int)(((byte)(102)))));
            this.btnAddEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddEmployee.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAddEmployee.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddEmployee.Location = new System.Drawing.Point(371, 42);
            this.btnAddEmployee.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddEmployee.Name = "btnAddEmployee";
            this.btnAddEmployee.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnAddEmployee.Size = new System.Drawing.Size(216, 40);
            this.btnAddEmployee.TabIndex = 34;
            this.btnAddEmployee.Text = "Generiši izvještaj";
            this.btnAddEmployee.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddEmployee.UseVisualStyleBackColor = false;
            this.btnAddEmployee.Click += new System.EventHandler(this.btnAddEmployee_Click);
            // 
            //reportDataSource1.Name = "dataSet";
            //reportDataSource1.Value = this.tblBindingSource;
            //this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "TreatBeauty.WinUI.Report.serviceReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(35, 115);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(740, 396);
            this.reportViewer1.TabIndex = 35;
            // 
            // serviceDataSet
            // 
            this.serviceDataSet.DataSetName = "serviceDataSet";
            this.serviceDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblBindingSource
            // 
            this.tblBindingSource.DataMember = "tbl";
            this.tblBindingSource.DataSource = this.serviceDataSet;
            // 
            // 
            // frmServiceReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(825, 550);
            this.Controls.Add(this.reportViewer1);

            this.Controls.Add(this.btnAddEmployee);
            this.Controls.Add(this.lblSalon);
            this.Controls.Add(this.cmbSalon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmServiceReport";
            this.Text = "frmServiceReport";
            this.Load += new System.EventHandler(this.frmServiceReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSalon;
        private System.Windows.Forms.ComboBox cmbSalon;
        private System.Windows.Forms.Button btnAddEmployee;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tblBindingSource;
        private serviceDataSet serviceDataSet;
    }
}