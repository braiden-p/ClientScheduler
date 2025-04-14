namespace ClientScheduler.Forms
{
    partial class AppointmentScreen
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
            dgvAppointment = new DataGridView();
            label1 = new Label();
            label3 = new Label();
            apptTypeTxt = new TextBox();
            label2 = new Label();
            apptDateTimePicker = new DateTimePicker();
            saveApptBtn = new Button();
            deleteApptBtn = new Button();
            label738 = new Label();
            rbAddAppt = new RadioButton();
            rbModifyAppt = new RadioButton();
            label4 = new Label();
            apptEndDateTimePicker = new DateTimePicker();
            customerIDcb = new ComboBox();
            userIDcb = new ComboBox();
            lblFeedback = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvAppointment).BeginInit();
            SuspendLayout();
            // 
            // dgvAppointment
            // 
            dgvAppointment.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAppointment.Location = new Point(12, 12);
            dgvAppointment.Name = "dgvAppointment";
            dgvAppointment.RowHeadersWidth = 62;
            dgvAppointment.Size = new Size(776, 238);
            dgvAppointment.TabIndex = 0;
            dgvAppointment.DataBindingComplete += dgvAppointment_DataBindingComplete;
            dgvAppointment.SelectionChanged += dgvAppointment_SelectionChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 268);
            label1.Name = "label1";
            label1.Size = new Size(79, 15);
            label1.TabIndex = 1;
            label1.Text = "Customer ID: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(52, 297);
            label3.Name = "label3";
            label3.Size = new Size(50, 15);
            label3.TabIndex = 4;
            label3.Text = "User ID: ";
            // 
            // apptTypeTxt
            // 
            apptTypeTxt.Location = new Point(120, 320);
            apptTypeTxt.Name = "apptTypeTxt";
            apptTypeTxt.Size = new Size(121, 23);
            apptTypeTxt.TabIndex = 3;
            apptTypeTxt.TextChanged += apptTypeTxt_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(35, 323);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 6;
            label2.Text = "Appt Type: ";
            // 
            // apptDateTimePicker
            // 
            apptDateTimePicker.CustomFormat = "MM/dd/yy hh:mm tt";
            apptDateTimePicker.Format = DateTimePickerFormat.Custom;
            apptDateTimePicker.Location = new Point(120, 349);
            apptDateTimePicker.Name = "apptDateTimePicker";
            apptDateTimePicker.Size = new Size(171, 23);
            apptDateTimePicker.TabIndex = 4;
            apptDateTimePicker.ValueChanged += apptDateTimePicker_ValueChanged;
            // 
            // saveApptBtn
            // 
            saveApptBtn.Location = new Point(661, 256);
            saveApptBtn.Name = "saveApptBtn";
            saveApptBtn.Size = new Size(127, 34);
            saveApptBtn.TabIndex = 7;
            saveApptBtn.Text = "Save Appointment";
            saveApptBtn.UseVisualStyleBackColor = true;
            saveApptBtn.Click += saveApptBtn_Click;
            // 
            // deleteApptBtn
            // 
            deleteApptBtn.Location = new Point(661, 314);
            deleteApptBtn.Name = "deleteApptBtn";
            deleteApptBtn.Size = new Size(127, 34);
            deleteApptBtn.TabIndex = 8;
            deleteApptBtn.Text = "Delete Appointment";
            deleteApptBtn.UseVisualStyleBackColor = true;
            deleteApptBtn.Click += deleteApptBtn_Click;
            // 
            // label738
            // 
            label738.AutoSize = true;
            label738.Location = new Point(12, 355);
            label738.Name = "label738";
            label738.Size = new Size(90, 15);
            label738.TabIndex = 12;
            label738.Text = "Start Date/Time";
            // 
            // rbAddAppt
            // 
            rbAddAppt.AutoSize = true;
            rbAddAppt.Checked = true;
            rbAddAppt.Location = new Point(391, 264);
            rbAddAppt.Name = "rbAddAppt";
            rbAddAppt.Size = new Size(121, 19);
            rbAddAppt.TabIndex = 5;
            rbAddAppt.TabStop = true;
            rbAddAppt.Text = "Add Appointment";
            rbAddAppt.UseVisualStyleBackColor = true;
            rbAddAppt.CheckedChanged += rbAddAppt_CheckedChanged;
            // 
            // rbModifyAppt
            // 
            rbModifyAppt.AutoSize = true;
            rbModifyAppt.Location = new Point(518, 264);
            rbModifyAppt.Name = "rbModifyAppt";
            rbModifyAppt.Size = new Size(137, 19);
            rbModifyAppt.TabIndex = 6;
            rbModifyAppt.Text = "Modify Appointment";
            rbModifyAppt.UseVisualStyleBackColor = true;
            rbModifyAppt.CheckedChanged += rbModifyAppt_CheckedChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 384);
            label4.Name = "label4";
            label4.Size = new Size(86, 15);
            label4.TabIndex = 14;
            label4.Text = "End Date/Time";
            // 
            // apptEndDateTimePicker
            // 
            apptEndDateTimePicker.CustomFormat = "MM/dd/yy hh:mm tt";
            apptEndDateTimePicker.Format = DateTimePickerFormat.Custom;
            apptEndDateTimePicker.Location = new Point(120, 378);
            apptEndDateTimePicker.Name = "apptEndDateTimePicker";
            apptEndDateTimePicker.Size = new Size(171, 23);
            apptEndDateTimePicker.TabIndex = 13;
            apptEndDateTimePicker.ValueChanged += apptEndDateTimePicker_ValueChanged;
            // 
            // customerIDcb
            // 
            customerIDcb.FormattingEnabled = true;
            customerIDcb.ItemHeight = 15;
            customerIDcb.Location = new Point(120, 265);
            customerIDcb.Name = "customerIDcb";
            customerIDcb.Size = new Size(121, 23);
            customerIDcb.TabIndex = 15;
            customerIDcb.SelectedIndexChanged += customerIDcb_SelectedIndexChanged;
            // 
            // userIDcb
            // 
            userIDcb.FormattingEnabled = true;
            userIDcb.Location = new Point(120, 294);
            userIDcb.Name = "userIDcb";
            userIDcb.Size = new Size(121, 23);
            userIDcb.TabIndex = 2;
            userIDcb.SelectedIndexChanged += userIDcb_SelectedIndexChanged;
            // 
            // lblFeedback
            // 
            lblFeedback.Location = new Point(363, 384);
            lblFeedback.Name = "lblFeedback";
            lblFeedback.Size = new Size(329, 23);
            lblFeedback.TabIndex = 16;
            lblFeedback.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AppointmentScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblFeedback);
            Controls.Add(userIDcb);
            Controls.Add(customerIDcb);
            Controls.Add(label4);
            Controls.Add(apptEndDateTimePicker);
            Controls.Add(rbModifyAppt);
            Controls.Add(rbAddAppt);
            Controls.Add(label738);
            Controls.Add(deleteApptBtn);
            Controls.Add(saveApptBtn);
            Controls.Add(apptDateTimePicker);
            Controls.Add(apptTypeTxt);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(dgvAppointment);
            Name = "AppointmentScreen";
            Text = "AppointmentScreen";
            ((System.ComponentModel.ISupportInitialize)dgvAppointment).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvAppointment;
        private Label label1;
        private Label label3;
        private TextBox apptTypeTxt;
        private Label label2;
        private DateTimePicker apptDateTimePicker;
        private Button saveApptBtn;
        private Button deleteApptBtn;
        private Label label738;
        private RadioButton rbAddAppt;
        private RadioButton rbModifyAppt;
        private Label label4;
        private DateTimePicker apptEndDateTimePicker;
        private ComboBox customerIDcb;
        private ComboBox userIDcb;
        private Label lblFeedback;
    }
}