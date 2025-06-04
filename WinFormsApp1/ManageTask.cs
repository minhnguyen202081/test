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
using TaskManagerApp.Models;
using TaskManagerApp.Services;
using System.IO;
namespace TaskManagerApp
{
    public partial class ManageTask : Form
    {
        private readonly AppDbContext _context;
        private readonly TaskService _taskService;
        public ManageTask(AppDbContext context, TaskService taskService)
        {
            InitializeComponent();
            _context = context;
            _taskService = taskService;
            LoadUsers();

        }
        private void LoadUsers()
        {

            var users = _taskService.GetAllUsers();
            comboUser.DataSource = users;
            comboUser.DisplayMember = "Username";
            comboUser.ValueMember = "UserId";

        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            int? userId = comboUser.SelectedItem != null ? (int?)((User)comboUser.SelectedItem).UserId : null;
            string status = comboStatus.SelectedItem?.ToString();
            string priority = comboPriority.SelectedItem?.ToString();
            LoadTasks(userId, status, priority);
        }



        private void LoadTasks(int? userId = null, string status = null, string priority = null)
        {

            var result = _taskService.GetTasks(userId, status, priority);
            dataGridView1.DataSource = result;

            if (dataGridView1.Columns.Contains("TaskId"))
            {
                dataGridView1.Columns["TaskId"].Visible = false;
            }

            AddActionButtons();


        }
        private void AddActionButtons()
        {
            if (!dataGridView1.Columns.Contains("Detail"))
            {
                var btnDetail = new DataGridViewButtonColumn();
                btnDetail.Name = "Detail";
                btnDetail.HeaderText = "Detail";
                btnDetail.Text = "Detail";
                btnDetail.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(btnDetail);
            }

            if (!dataGridView1.Columns.Contains("Delete"))
            {
                var btnDelete = new DataGridViewButtonColumn();
                btnDelete.Name = "Delete";
                btnDelete.HeaderText = "Delete";
                btnDelete.Text = "Delete";
                btnDelete.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(btnDelete);
            }
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int taskId = (int)dataGridView1.Rows[e.RowIndex].Cells["TaskId"].Value;

            string columnName = dataGridView1.Columns[e.ColumnIndex].Name;

            if (columnName == "Delete")
            {
                var confirm = MessageBox.Show("Are you sure you want to delete this task?", "Confirm", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {

                    _taskService.DeleteTask(taskId);
                    int? userId = comboUser.SelectedItem != null ? (int?)((User)comboUser.SelectedItem).UserId : null;
                    string status = comboStatus.SelectedItem?.ToString();
                    string priority = comboPriority.SelectedItem?.ToString();
                    LoadTasks(userId, status, priority);

                }
            }
            else if (columnName == "Detail")
            {

                var detailForm = new DetailTask(_context,taskId, _taskService);
                detailForm.ShowDialog();

                int? userId = comboUser.SelectedItem != null ? (int?)((User)comboUser.SelectedItem).UserId : null;
                string status = comboStatus.SelectedItem?.ToString();
                string priority = comboPriority.SelectedItem?.ToString();
                LoadTasks(userId, status, priority);
            }
        }


        private void btnCreateNew_Click(object sender, EventArgs e)
        {
            CreateTask createTask = new CreateTask(_context, _taskService);
            
            createTask.ShowDialog();
            LoadTasks();
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {

            var data = _taskService.GetTaskStatusReport();

            _taskService.ExportToExcel(data, "UserTaskStatusReport.xlsx");
            
        }

        private void btnTopDone_Click(object sender, EventArgs e)
        {


            var data = _taskService.GetTopUsersDoneTasks();

            _taskService.ExportToExcel(data, "TopUsersDoneTasks.xlsx");
         
        }

        private void btnLateTask_Click(object sender, EventArgs e)
        {
            var data = _taskService.GetLateTasks();

            _taskService.ExportToExcel(data, "LateTasksReport.xlsx");
           
        }

        

    }


}
