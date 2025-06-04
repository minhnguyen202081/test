namespace TaskManagerApp
{
    partial class CreateTask
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
            label1 = new Label();
            txtTitle = new TextBox();
            label2 = new Label();
            txtDescription = new TextBox();
            label3 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label4 = new Label();
            ComboStatus = new ComboBox();
            label5 = new Label();
            comboPriority = new ComboBox();
            comboUser = new ComboBox();
            label6 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(163, 23);
            label1.Name = "label1";
            label1.Size = new Size(38, 20);
            label1.TabIndex = 0;
            label1.Text = "Title";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(308, 20);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(295, 27);
            txtTitle.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(163, 70);
            label2.Name = "label2";
            label2.Size = new Size(85, 20);
            label2.TabIndex = 2;
            label2.Text = "Description";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(308, 63);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(295, 61);
            txtDescription.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(163, 146);
            label3.Name = "label3";
            label3.Size = new Size(70, 20);
            label3.TabIndex = 4;
            label3.Text = "Due date";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(308, 147);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(295, 27);
            dateTimePicker1.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(163, 194);
            label4.Name = "label4";
            label4.Size = new Size(49, 20);
            label4.TabIndex = 6;
            label4.Text = "Status";
            // 
            // ComboStatus
            // 
            ComboStatus.FormattingEnabled = true;
            ComboStatus.Items.AddRange(new object[] { "To do", "Doing", "Done" });
            ComboStatus.Location = new Point(308, 186);
            ComboStatus.Name = "ComboStatus";
            ComboStatus.Size = new Size(295, 28);
            ComboStatus.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(163, 248);
            label5.Name = "label5";
            label5.Size = new Size(56, 20);
            label5.TabIndex = 8;
            label5.Text = "Priority";
            // 
            // comboPriority
            // 
            comboPriority.FormattingEnabled = true;
            comboPriority.Items.AddRange(new object[] { "Low", "Medium", "High" });
            comboPriority.Location = new Point(308, 240);
            comboPriority.Name = "comboPriority";
            comboPriority.Size = new Size(295, 28);
            comboPriority.TabIndex = 9;
            // 
            // comboUser
            // 
            comboUser.FormattingEnabled = true;
            comboUser.Location = new Point(308, 289);
            comboUser.Name = "comboUser";
            comboUser.Size = new Size(295, 28);
            comboUser.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(163, 297);
            label6.Name = "label6";
            label6.Size = new Size(102, 20);
            label6.TabIndex = 10;
            label6.Text = "Assigned User";
            // 
            // button1
            // 
            button1.Location = new Point(349, 354);
            button1.Name = "button1";
            button1.Size = new Size(151, 29);
            button1.TabIndex = 12;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnSave_Click;
            // 
            // CreateTask
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
            Name = "CreateTask";
            Text = "Form1";
          
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtTitle;
        private Label label2;
        private TextBox txtDescription;
        private Label label3;
        private DateTimePicker dateTimePicker1;
        private Label label4;
        private ComboBox ComboStatus;
        private Label label5;
        private ComboBox comboPriority;
        private ComboBox comboUser;
        private Label label6;
        private Button button1;
    }
}