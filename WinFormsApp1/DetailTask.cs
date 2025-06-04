using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskManagerApp.Data;

namespace TaskManagerApp
{
    public partial class DetailTask : Form
    {
        private int _taskId;
        private readonly AppDbContext _context;

        public DetailTask(AppDbContext context,int taskId)
        {
            InitializeComponent();
            _taskId = taskId;
            _context = context;
            LoadReadOnly();
        }

        private void DetailTask_Load(object sender, EventArgs e)
        {
            
                var task = _context.Tasks
                    .Include(t => t.User)
                    .FirstOrDefault(t => t.TaskId == _taskId);

                if (task != null)
                {
                    txtTitle.Text = task.Title;
                    txtDescription.Text = task.Description;
                    dateTimePicker1.Value = task.DueDate ?? DateTime.Today;
                    ComboStatus.SelectedItem = task.Status;
                    comboPriority.SelectedItem = task.Priority;

                }
                else
                {
                    MessageBox.Show("Could not found the task!!!");
                    Close();
                }
           
        }
        private void LoadReadOnly()
        {

            txtTitle.ReadOnly = true;
            txtDescription.ReadOnly = true;
            dateTimePicker1.Enabled = false;
            comboPriority.Enabled = false;
            comboUser.Enabled = false;

            ComboStatus.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                var task = _context.Tasks.FirstOrDefault(t => t.TaskId == _taskId);
                if (task != null)
                {
                    task.Status = ComboStatus.SelectedItem.ToString();
                    _context.SaveChanges();
                    MessageBox.Show("Update successfully!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Could not found the task");
                }
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
