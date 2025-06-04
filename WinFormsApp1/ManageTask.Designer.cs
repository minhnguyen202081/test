namespace TaskManagerApp
{
    partial class ManageTask
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
            comboUser = new ComboBox();
            comboStatus = new ComboBox();
            label2 = new Label();
            comboPriority = new ComboBox();
            label3 = new Label();
            btnSearch = new Button();
            dataGridView1 = new DataGridView();
            btnCreateNew = new Button();
            btnStatus = new Button();
            btnTopDone = new Button();
            btnLateTask = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(58, 37);
            label1.Name = "label1";
            label1.Size = new Size(79, 20);
            label1.TabIndex = 0;
            label1.Text = "User name";
            // 
            // comboUser
            // 
            comboUser.FormattingEnabled = true;
            comboUser.Location = new Point(157, 37);
            comboUser.Name = "comboUser";
            comboUser.Size = new Size(177, 28);
            comboUser.TabIndex = 1;
            // 
            // comboStatus
            // 
            comboStatus.FormattingEnabled = true;
            comboStatus.Items.AddRange(new object[] { "To do", "Doing", "Done" });
            comboStatus.Location = new Point(157, 85);
            comboStatus.Name = "comboStatus";
            comboStatus.Size = new Size(177, 28);
            comboStatus.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(58, 93);
            label2.Name = "label2";
            label2.Size = new Size(49, 20);
            label2.TabIndex = 2;
            label2.Text = "Status";
            // 
            // comboPriority
            // 
            comboPriority.FormattingEnabled = true;
            comboPriority.Items.AddRange(new object[] { "Low", "Medium", "High" });
            comboPriority.Location = new Point(464, 37);
            comboPriority.Name = "comboPriority";
            comboPriority.Size = new Size(151, 28);
            comboPriority.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(365, 45);
            label3.Name = "label3";
            label3.Size = new Size(56, 20);
            label3.TabIndex = 4;
            label3.Text = "Priority";
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(464, 89);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(141, 29);
            btnSearch.TabIndex = 6;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 163);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1100, 275);
            dataGridView1.TabIndex = 7;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // btnCreateNew
            // 
            btnCreateNew.Location = new Point(47, 128);
            btnCreateNew.Name = "btnCreateNew";
            btnCreateNew.Size = new Size(141, 29);
            btnCreateNew.TabIndex = 8;
            btnCreateNew.Text = "Create new task";
            btnCreateNew.UseVisualStyleBackColor = true;
            btnCreateNew.Click += btnCreateNew_Click;
            // 
            // btnStatus
            // 
            btnStatus.Location = new Point(636, 128);
            btnStatus.Name = "btnStatus";
            btnStatus.Size = new Size(141, 29);
            btnStatus.TabIndex = 9;
            btnStatus.Text = "Export status";
            btnStatus.UseVisualStyleBackColor = true;
            btnStatus.Click += btnStatus_Click;
            // 
            // btnTopDone
            // 
            btnTopDone.Location = new Point(805, 128);
            btnTopDone.Name = "btnTopDone";
            btnTopDone.Size = new Size(141, 29);
            btnTopDone.TabIndex = 10;
            btnTopDone.Text = "Export Top Done";
            btnTopDone.UseVisualStyleBackColor = true;
            btnTopDone.Click += btnTopDone_Click;
            // 
            // btnLateTask
            // 
            btnLateTask.BackColor = SystemColors.ControlLight;
            btnLateTask.Location = new Point(971, 128);
            btnLateTask.Name = "btnLateTask";
            btnLateTask.Size = new Size(141, 29);
            btnLateTask.TabIndex = 11;
            btnLateTask.Text = "Export Late Task";
            btnLateTask.UseVisualStyleBackColor = false;
            btnLateTask.Click += btnLateTask_Click;
            // 
            // ManageTask
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1124, 462);
            Controls.Add(btnLateTask);
            Controls.Add(btnTopDone);
            Controls.Add(btnStatus);
            Controls.Add(btnCreateNew);
            Controls.Add(dataGridView1);
            Controls.Add(btnSearch);
            Controls.Add(comboPriority);
            Controls.Add(label3);
            Controls.Add(comboStatus);
            Controls.Add(label2);
            Controls.Add(comboUser);
            Controls.Add(label1);
            Name = "ManageTask";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox comboUser;
        private ComboBox comboStatus;
        private Label label2;
        private ComboBox comboPriority;
        private Label label3;
        private Button btnSearch;
        private DataGridView dataGridView1;
        private Button btnCreateNew;
        private Button btnStatus;
        private Button btnTopDone;
        private Button btnLateTask;
    }
}