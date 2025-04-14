namespace ClientScheduler.Forms
{
    partial class CustomerScreen
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
            customerDgv = new DataGridView();
            label1 = new Label();
            fullnameTxt = new TextBox();
            addressTxt = new TextBox();
            label2 = new Label();
            phoneTxt = new TextBox();
            label3 = new Label();
            cityTxt = new TextBox();
            label4 = new Label();
            zipCodeTxt = new TextBox();
            label5 = new Label();
            countryTxt = new TextBox();
            label6 = new Label();
            saveCustBtn = new Button();
            custDeleteBtn = new Button();
            addCustRb = new RadioButton();
            modifyCustRb = new RadioButton();
            clearCustBtn = new Button();
            lblFeedback = new Label();
            ((System.ComponentModel.ISupportInitialize)customerDgv).BeginInit();
            SuspendLayout();
            // 
            // customerDgv
            // 
            customerDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            customerDgv.Location = new Point(12, 12);
            customerDgv.Name = "customerDgv";
            customerDgv.Size = new Size(776, 219);
            customerDgv.TabIndex = 0;
            customerDgv.DataBindingComplete += customerDgv_DataBindingComplete;
            customerDgv.SelectionChanged += customerDgv_SelectionChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 255);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 1;
            label1.Text = "Full Name:";
            label1.TextAlign = ContentAlignment.TopRight;
            // 
            // fullnameTxt
            // 
            fullnameTxt.Location = new Point(109, 252);
            fullnameTxt.Name = "fullnameTxt";
            fullnameTxt.Size = new Size(185, 23);
            fullnameTxt.TabIndex = 1;
            fullnameTxt.TextChanged += fullNameChange;
            // 
            // addressTxt
            // 
            addressTxt.Location = new Point(109, 281);
            addressTxt.Name = "addressTxt";
            addressTxt.Size = new Size(185, 23);
            addressTxt.TabIndex = 2;
            addressTxt.TextChanged += addressChange;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(51, 284);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 3;
            label2.Text = "Address:";
            label2.TextAlign = ContentAlignment.TopRight;
            // 
            // phoneTxt
            // 
            phoneTxt.Location = new Point(109, 397);
            phoneTxt.Name = "phoneTxt";
            phoneTxt.Size = new Size(185, 23);
            phoneTxt.TabIndex = 6;
            phoneTxt.TextChanged += phoneChange;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 400);
            label3.Name = "label3";
            label3.Size = new Size(91, 15);
            label3.TabIndex = 5;
            label3.Text = "Phone Number:";
            // 
            // cityTxt
            // 
            cityTxt.Location = new Point(109, 310);
            cityTxt.Name = "cityTxt";
            cityTxt.Size = new Size(185, 23);
            cityTxt.TabIndex = 3;
            cityTxt.TextChanged += cityChange;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(72, 313);
            label4.Name = "label4";
            label4.Size = new Size(31, 15);
            label4.TabIndex = 7;
            label4.Text = "City:";
            label4.TextAlign = ContentAlignment.TopRight;
            // 
            // zipCodeTxt
            // 
            zipCodeTxt.Location = new Point(109, 339);
            zipCodeTxt.Name = "zipCodeTxt";
            zipCodeTxt.Size = new Size(185, 23);
            zipCodeTxt.TabIndex = 4;
            zipCodeTxt.TextChanged += zipChange;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(45, 342);
            label5.Name = "label5";
            label5.Size = new Size(58, 15);
            label5.TabIndex = 9;
            label5.Text = "Zip Code:";
            label5.TextAlign = ContentAlignment.TopRight;
            // 
            // countryTxt
            // 
            countryTxt.Location = new Point(109, 368);
            countryTxt.Name = "countryTxt";
            countryTxt.Size = new Size(185, 23);
            countryTxt.TabIndex = 5;
            countryTxt.TextChanged += countryChange;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(45, 371);
            label6.Name = "label6";
            label6.Size = new Size(53, 15);
            label6.TabIndex = 11;
            label6.Text = "Country:";
            label6.TextAlign = ContentAlignment.TopRight;
            // 
            // saveCustBtn
            // 
            saveCustBtn.Location = new Point(437, 268);
            saveCustBtn.Name = "saveCustBtn";
            saveCustBtn.Size = new Size(101, 36);
            saveCustBtn.TabIndex = 9;
            saveCustBtn.Text = "Save Changes";
            saveCustBtn.UseVisualStyleBackColor = true;
            saveCustBtn.Click += saveCustBtn_Click;
            // 
            // custDeleteBtn
            // 
            custDeleteBtn.Location = new Point(657, 237);
            custDeleteBtn.Name = "custDeleteBtn";
            custDeleteBtn.Size = new Size(116, 36);
            custDeleteBtn.TabIndex = 10;
            custDeleteBtn.Text = "Delete Customer";
            custDeleteBtn.UseVisualStyleBackColor = true;
            custDeleteBtn.Click += custDeleteBtn_Click;
            // 
            // addCustRb
            // 
            addCustRb.AutoSize = true;
            addCustRb.Checked = true;
            addCustRb.Location = new Point(384, 246);
            addCustRb.Name = "addCustRb";
            addCustRb.Size = new Size(102, 19);
            addCustRb.TabIndex = 7;
            addCustRb.TabStop = true;
            addCustRb.Text = "Add Customer";
            addCustRb.UseVisualStyleBackColor = true;
            addCustRb.CheckedChanged += addCustRb_CheckedChanged;
            // 
            // modifyCustRb
            // 
            modifyCustRb.AutoSize = true;
            modifyCustRb.Location = new Point(492, 246);
            modifyCustRb.Name = "modifyCustRb";
            modifyCustRb.Size = new Size(118, 19);
            modifyCustRb.TabIndex = 8;
            modifyCustRb.Text = "Modify Customer";
            modifyCustRb.UseVisualStyleBackColor = true;
            modifyCustRb.CheckedChanged += modifyCustRb_CheckedChanged;
            // 
            // clearCustBtn
            // 
            clearCustBtn.Location = new Point(437, 389);
            clearCustBtn.Name = "clearCustBtn";
            clearCustBtn.Size = new Size(101, 36);
            clearCustBtn.TabIndex = 11;
            clearCustBtn.Text = "Clear Form";
            clearCustBtn.UseVisualStyleBackColor = true;
            clearCustBtn.Click += clearCustBtn_Click;
            // 
            // lblFeedback
            // 
            lblFeedback.Location = new Point(379, 315);
            lblFeedback.Name = "lblFeedback";
            lblFeedback.Size = new Size(231, 42);
            lblFeedback.TabIndex = 12;
            lblFeedback.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // CustomerScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblFeedback);
            Controls.Add(clearCustBtn);
            Controls.Add(modifyCustRb);
            Controls.Add(addCustRb);
            Controls.Add(custDeleteBtn);
            Controls.Add(saveCustBtn);
            Controls.Add(countryTxt);
            Controls.Add(label6);
            Controls.Add(zipCodeTxt);
            Controls.Add(label5);
            Controls.Add(cityTxt);
            Controls.Add(label4);
            Controls.Add(phoneTxt);
            Controls.Add(label3);
            Controls.Add(addressTxt);
            Controls.Add(label2);
            Controls.Add(fullnameTxt);
            Controls.Add(label1);
            Controls.Add(customerDgv);
            Name = "CustomerScreen";
            Text = "Customer";
            ((System.ComponentModel.ISupportInitialize)customerDgv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView customerDgv;
        private Label label1;
        private TextBox fullnameTxt;
        private TextBox addressTxt;
        private Label label2;
        private TextBox phoneTxt;
        private Label label3;
        private TextBox cityTxt;
        private Label label4;
        private TextBox zipCodeTxt;
        private Label label5;
        private TextBox countryTxt;
        private Label label6;
        private Button saveCustBtn;
        private Button custDeleteBtn;
        private RadioButton addCustRb;
        private RadioButton modifyCustRb;
        private Button clearCustBtn;
        private Label lblFeedback;
    }
}