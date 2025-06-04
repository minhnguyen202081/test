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
using TaskManagerApp.Services;
namespace TaskManagerApp
{
    public partial class DetailTask : Form
    {
        private int _taskId;
        private readonly AppDbContext _context;
        private readonly TaskService _taskService;
        public DetailTask(AppDbContext context,int taskId, TaskService taskService)
        {
            InitializeComponent();
            _taskId = taskId;
            _taskService = taskService;
            _context = context;
            LoadReadOnly();
        }

        private void DetailTask_Load(object sender, EventArgs e)
        {
            var task = _taskService.GetTaskDetailById(_taskId);

            if (task != null)
            {
                txtTitle.Text = task.Title;
                txtDescription.Text = task.Description;
                dateTimePicker1.Value = task.DueDate ?? DateTime.Today;
                ComboStatus.SelectedItem = task.Status;
                comboPriority.SelectedItem = task.Priority;
                comboUser.Text = task.User?.Username; 
            }
            else
            {
                MessageBox.Show("Could not find the task!!!");
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

            string status = ComboStatus.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(status))
            {
                MessageBox.Show("Please select a status");
                return;
            }

            bool success = _taskService.UpdateTaskStatus(_taskId, status);
            if (success)
            {
                MessageBox.Show("Update successfully!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Could not find the task");
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
