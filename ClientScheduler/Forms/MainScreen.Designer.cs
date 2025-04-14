namespace ClientScheduler.Forms
{
    partial class MainScreen
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
            calender = new MonthCalendar();
            appointmentsdgv = new DataGridView();
            customerBtn = new Button();
            appointmentsBtn = new Button();
            rbApptMonth = new RadioButton();
            rbUserSchedule = new RadioButton();
            rbNumCustByCountry = new RadioButton();
            reportBtn = new Button();
            lblDate = new Label();
            ((System.ComponentModel.ISupportInitialize)appointmentsdgv).BeginInit();
            SuspendLayout();
            // 
            // calender
            // 
            calender.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            calender.Location = new Point(18, 33);
            calender.Name = "calender";
            calender.TabIndex = 0;
            calender.DateChanged += MonthCalendar_DataChanged;
            calender.MouseDown += MonthCalendar_DataChanged;
            // 
            // appointmentsdgv
            // 
            appointmentsdgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            appointmentsdgv.Location = new Point(251, 33);
            appointmentsdgv.Name = "appointmentsdgv";
            appointmentsdgv.RowHeadersWidth = 62;
            appointmentsdgv.Size = new Size(1075, 465);
            appointmentsdgv.TabIndex = 1;
            // 
            // customerBtn
            // 
            customerBtn.Location = new Point(18, 218);
            customerBtn.Name = "customerBtn";
            customerBtn.Size = new Size(227, 45);
            customerBtn.TabIndex = 2;
            customerBtn.Text = "View Customers";
            customerBtn.UseVisualStyleBackColor = true;
            customerBtn.Click += customerBtn_Click;
            // 
            // appointmentsBtn
            // 
            appointmentsBtn.Location = new Point(18, 286);
            appointmentsBtn.Name = "appointmentsBtn";
            appointmentsBtn.Size = new Size(227, 45);
            appointmentsBtn.TabIndex = 3;
            appointmentsBtn.Text = "View Appointments";
            appointmentsBtn.UseVisualStyleBackColor = true;
            appointmentsBtn.Click += appointmentsBtn_Click;
            // 
            // rbApptMonth
            // 
            rbApptMonth.AutoSize = true;
            rbApptMonth.Checked = true;
            rbApptMonth.Location = new Point(510, 543);
            rbApptMonth.Name = "rbApptMonth";
            rbApptMonth.Size = new Size(193, 19);
            rbApptMonth.TabIndex = 4;
            rbApptMonth.TabStop = true;
            rbApptMonth.Text = "Appointments Types Per Month";
            rbApptMonth.UseVisualStyleBackColor = true;
            // 
            // rbUserSchedule
            // 
            rbUserSchedule.AutoSize = true;
            rbUserSchedule.Location = new Point(737, 543);
            rbUserSchedule.Name = "rbUserSchedule";
            rbUserSchedule.Size = new Size(104, 19);
            rbUserSchedule.TabIndex = 5;
            rbUserSchedule.Text = "User Schedules";
            rbUserSchedule.UseVisualStyleBackColor = true;
            // 
            // rbNumCustByCountry
            // 
            rbNumCustByCountry.AutoSize = true;
            rbNumCustByCountry.Location = new Point(875, 543);
            rbNumCustByCountry.Name = "rbNumCustByCountry";
            rbNumCustByCountry.Size = new Size(205, 19);
            rbNumCustByCountry.TabIndex = 6;
            rbNumCustByCountry.Text = "Number of Customers by Country";
            rbNumCustByCountry.UseVisualStyleBackColor = true;
            // 
            // reportBtn
            // 
            reportBtn.Location = new Point(680, 568);
            reportBtn.Name = "reportBtn";
            reportBtn.Size = new Size(227, 45);
            reportBtn.TabIndex = 7;
            reportBtn.Text = "Generate Report";
            reportBtn.UseVisualStyleBackColor = true;
            reportBtn.Click += reportBtn_Click;
            // 
            // lblDate
            // 
            lblDate.Font = new Font("Segoe UI", 15F);
            lblDate.Location = new Point(528, 2);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(495, 30);
            lblDate.TabIndex = 1000;
            lblDate.Text = "All Appointments";
            lblDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MainScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1338, 625);
            Controls.Add(lblDate);
            Controls.Add(reportBtn);
            Controls.Add(rbNumCustByCountry);
            Controls.Add(rbUserSchedule);
            Controls.Add(rbApptMonth);
            Controls.Add(appointmentsBtn);
            Controls.Add(customerBtn);
            Controls.Add(appointmentsdgv);
            Controls.Add(calender);
            Name = "MainScreen";
            Text = "Appointment Scheduler";
            Load += MainScreen_Load;
            ((System.ComponentModel.ISupportInitialize)appointmentsdgv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MonthCalendar calender;
        private DataGridView appointmentsdgv;
        private Button customerBtn;
        private Button appointmentsBtn;
        private RadioButton rbApptMonth;
        private RadioButton rbUserSchedule;
        private RadioButton rbNumCustByCountry;
        private Button reportBtn;
        private Label lblDate;
    }
}