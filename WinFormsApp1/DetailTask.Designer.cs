namespace TaskManagerApp
{
    partial class DetailTask
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
            button1 = new Button();
            comboUser = new ComboBox();
            label6 = new Label();
            comboPriority = new ComboBox();
            label5 = new Label();
            ComboStatus = new ComboBox();
            label4 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label3 = new Label();
            txtDescription = new TextBox();
            label2 = new Label();
            txtTitle = new TextBox();
            label1 = new Label();
            btnClose = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(238, 376);
            button1.Name = "button1";
            button1.Size = new Size(151, 29);
            button1.TabIndex = 25;
            button1.Text = "Update status";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboUser
            // 
            comboUser.FormattingEnabled = true;
            comboUser.Location = new Point(325, 313);
            comboUser.Name = "comboUser";
            comboUser.Size = new Size(295, 28);
            comboUser.TabIndex = 24;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(180, 321);
            label6.Name = "label6";
            label6.Size = new Size(102, 20);
            label6.TabIndex = 23;
            label6.Text = "Assigned User";
            // 
            // comboPriority
            // 
            comboPriority.FormattingEnabled = true;
            comboPriority.Items.AddRange(new object[] { "Low", "Medium", "High" });
            comboPriority.Location = new Point(325, 264);
            comboPriority.Name = "comboPriority";
            comboPriority.Size = new Size(295, 28);
            comboPriority.TabIndex = 22;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(180, 272);
            label5.Name = "label5";
            label5.Size = new Size(56, 20);
            label5.TabIndex = 21;
            label5.Text = "Priority";
            // 
            // ComboStatus
            // 
            ComboStatus.FormattingEnabled = true;
            ComboStatus.Items.AddRange(new object[] { "To do", "Doing", "Done" });
            ComboStatus.Location = new Point(325, 210);
            ComboStatus.Name = "ComboStatus";
            ComboStatus.Size = new Size(295, 28);
            ComboStatus.TabIndex = 20;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(180, 218);
            label4.Name = "label4";
            label4.Size = new Size(49, 20);
            label4.TabIndex = 19;
            label4.Text = "Status";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(325, 163);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(295, 27);
            dateTimePicker1.TabIndex = 18;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(180, 170);
            label3.Name = "label3";
            label3.Size = new Size(70, 20);
            label3.TabIndex = 17;
            label3.Text = "Due date";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(325, 87);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(295, 61);
            txtDescription.TabIndex = 16;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(180, 94);
            label2.Name = "label2";
            label2.Size = new Size(85, 20);
            label2.TabIndex = 15;
            label2.Text = "Description";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(325, 44);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(295, 27);
            txtTitle.TabIndex = 14;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(180, 47);
            label1.Name = "label1";
            label1.Size = new Size(38, 20);
            label1.TabIndex = 13;
            label1.Text = "Title";
            // 
            // btnClose
            // 
            btnClose.Location = new Point(435, 376);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(151, 29);
            btnClose.TabIndex = 26;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // DetailTask
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnClose);
            Controls.Add(button1);
            Controls.Add(comboUser);
            Controls.Add(label6);
            Controls.Add(comboPriority);
            Controls.Add(label5);
            Controls.Add(ComboStatus);
            Controls.Add(label4);
            Controls.Add(dateTimePicker1);
            Controls.Add(label3);
            Controls.Add(txtDescription);
            Controls.Add(label2);
            Controls.Add(txtTitle);
            Controls.Add(label1);
            Name = "DetailTask";
            Text = "DetailTask";
            Load += DetailTask_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private ComboBox comboUser;
        private Label label6;
        private ComboBox comboPriority;
        private Label label5;
        private ComboBox ComboStatus;
        private Label label4;
        private DateTimePicker dateTimePicker1;
        private Label label3;
        private TextBox txtDescription;
        private Label label2;
        private TextBox txtTitle;
        private Label label1;
        private Button btnClose;
    }
}