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

using System.IO;
namespace TaskManagerApp
{
    public partial class ManageTask : Form
    {
        private readonly AppDbContext _context;
        public ManageTask(AppDbContext context)
        {
            InitializeComponent();
            _context = context;
            LoadUsers();

        }
        private void LoadUsers()
        {
            
                var users = _context.Users.ToList();
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
           
                var query = _context.Tasks.Include(t => t.User).AsQueryable();

                if (userId.HasValue)
                    query = query.Where(t => t.UserId == userId.Value);

                if (!string.IsNullOrEmpty(status))
                    query = query.Where(t => t.Status == status);

                if (!string.IsNullOrEmpty(priority))
                    query = query.Where(t => t.Priority == priority);

                var result = query.Select(t => new
                {
                    t.TaskId,
                    t.Title,
                    t.Description,
                    t.DueDate,
                    t.Status,
                    t.Priority,
                    UserName = t.User.Username
                }).ToList();
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
                    
                        var task = _context.Tasks.Find(taskId);
                        if (task != null)
                        {
                            _context.Tasks.Remove(task);
                            _context.SaveChanges();
                            LoadTasks();
                        }
                   
                }
            }
            else if (columnName == "Detail")
            {

                var detailForm = new DetailTask(_context,taskId);
                detailForm.ShowDialog();

                LoadTasks();
            }
        }


        private void btnCreateNew_Click(object sender, EventArgs e)
        {
            CreateTask createTask = new CreateTask(_context);
            createTask.ShowDialog();
            LoadTasks();
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
           
                var data = _context.Tasks
                    .GroupBy(t => new { t.User.Username, t.Status })
                    .Select(g => new
                    {
                        Username = g.Key.Username,
                        Status = g.Key.Status,
                        TotalTasks = g.Count()
                    }).ToList();

                ExportToExcel(data, "UserTaskStatusReport.xlsx");
            
        }

        private void btnTopDone_Click(object sender, EventArgs e)
        {
         
                var data = _context.Tasks
                    .Where(t => t.Status == "done")
                    .GroupBy(t => t.User.Username)
                    .Select(g => new
                    {
                        Username = g.Key,
                        DoneCount = g.Count()
                    })
                    .OrderByDescending(g => g.DoneCount)
                    .Take(3)
                    .ToList();

                ExportToExcel(data, "TopUsersDoneTasks.xlsx");
         
        }

        private void btnLateTask_Click(object sender, EventArgs e)
        {
            var today = DateTime.Today;

            var data = _context.Tasks
                    .Where(t => t.DueDate < today && t.Status != "done")
                    .Select(t => new
                    {
                        t.Title,
                        t.Description,
                        t.DueDate,
                        t.Status,
                        t.Priority,
                        Username = t.User.Username
                    }).ToList();

                ExportToExcel(data, "LateTasksReport.xlsx");
           
        }

        private void ExportToExcel<T>(List<T> data, string fileName)
        {
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (var package = new OfficeOpenXml.ExcelPackage())
            {

                var worksheet = package.Workbook.Worksheets.Add("Report");
                worksheet.Cells["A1"].LoadFromCollection(data, true);
                var saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel Files (*.xlsx)|*.xlsx",
                    FileName = fileName
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllBytes(saveFileDialog.FileName, package.GetAsByteArray());
                    MessageBox.Show("Exported successfully!");
                }
            }
        }

    }


}
