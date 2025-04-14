namespace ClientScheduler.Forms
{
    partial class ReportScreen
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
            dgvReport = new DataGridView();
            reportBackBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvReport).BeginInit();
            SuspendLayout();
            // 
            // dgvReport
            // 
            dgvReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReport.Location = new Point(12, 12);
            dgvReport.Name = "dgvReport";
            dgvReport.Size = new Size(776, 362);
            dgvReport.TabIndex = 0;
            dgvReport.DataBindingComplete += dgvReport_DataBindingComplete;
            // 
            // reportBackBtn
            // 
            reportBackBtn.Location = new Point(692, 399);
            reportBackBtn.Name = "reportBackBtn";
            reportBackBtn.Size = new Size(96, 39);
            reportBackBtn.TabIndex = 1;
            reportBackBtn.Text = "Back";
            reportBackBtn.UseVisualStyleBackColor = true;
            reportBackBtn.Click += reportBackBtn_Click;
            // 
            // ReportScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(reportBackBtn);
            Controls.Add(dgvReport);
            Name = "ReportScreen";
            Text = "ReportScreen";
            Load += ReportScreen_Load;
            ((System.ComponentModel.ISupportInitialize)dgvReport).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvReport;
        private Button reportBackBtn;
    }
}