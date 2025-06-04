using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using TaskManagerApp.Data;
using TaskManagerApp.Models;

namespace TaskManagerApp.Services
{
    public class TaskService
    {
        private readonly AppDbContext _context;

        public TaskService(AppDbContext context)
        {
            _context = context;
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public List<dynamic> GetTasks(int? userId = null, string status = null, string priority = null)
        {
            var query = _context.Tasks.Include(t => t.User).AsQueryable();

            if (userId.HasValue)
                query = query.Where(t => t.UserId == userId.Value);

            if (!string.IsNullOrEmpty(status))
                query = query.Where(t => t.Status == status);

            if (!string.IsNullOrEmpty(priority))
                query = query.Where(t => t.Priority == priority);

            return query.Select(t => new
            {
                t.TaskId,
                t.Title,
                t.Description,
                t.DueDate,
                t.Status,
                t.Priority,
                UserName = t.User.Username
            }).ToList<dynamic>();
        }

        public void DeleteTask(int taskId)
        {
            var task = _context.Tasks.Find(taskId);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
        }

        public List<dynamic> GetTaskStatusReport()
        {
            return _context.Tasks
                .GroupBy(t => new { t.User.Username, t.Status })
                .Select(g => new
                {
                    Username = g.Key.Username,
                    Status = g.Key.Status,
                    TotalTasks = g.Count()
                }).ToList<dynamic>();
        }

        public List<dynamic> GetTopUsersDoneTasks(int top = 3)
        {
            return _context.Tasks
                .Where(t => t.Status == "done")
                .GroupBy(t => t.User.Username)
                .Select(g => new
                {
                    Username = g.Key,
                    DoneCount = g.Count()
                })
                .OrderByDescending(g => g.DoneCount)
                .Take(top)
                .ToList<dynamic>();
        }

        public List<dynamic> GetLateTasks()
        {
            var today = DateTime.Today;
            return _context.Tasks
                .Where(t => t.DueDate < today && t.Status != "done")
                .Select(t => new
                {
                    t.Title,
                    t.Description,
                    t.DueDate,
                    t.Status,
                    t.Priority,
                    Username = t.User.Username
                }).ToList<dynamic>();
        }
        public void AddTask(string title, string description, DateTime? dueDate, string status, string priority, int userId)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title is required");

            if (string.IsNullOrWhiteSpace(status))
                throw new ArgumentException("Status is required");

            if (string.IsNullOrWhiteSpace(priority))
                throw new ArgumentException("Priority is required");

            var task = new Models.Task
            {
                Title = title.Trim(),
                Description = description?.Trim(),
                DueDate = dueDate,
                Status = status,
                Priority = priority,
                UserId = userId
            };

            _context.Tasks.Add(task);
            _context.SaveChanges();
        }


        public void ExportToExcel<T>(List<T> data, string fileName)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Report");

                if (data.Any())
                {
                    var firstRow = data[0];
                    var props = firstRow.GetType().GetProperties();

                    // Header
                    for (int i = 0; i < props.Length; i++)
                    {
                        worksheet.Cells[1, i + 1].Value = props[i].Name;
                    }

                    // Data
                    for (int row = 0; row < data.Count; row++)
                    {
                        for (int col = 0; col < props.Length; col++)
                        {
                            worksheet.Cells[row + 2, col + 1].Value = props[col].GetValue(data[row]);
                        }
                    }
                }

                using (var saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel Files (*.xlsx)|*.xlsx",
                    FileName = fileName
                })
                {
                    if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        File.WriteAllBytes(saveFileDialog.FileName, package.GetAsByteArray());
                        System.Windows.Forms.MessageBox.Show("Exported successfully!");
                    }
                }
            }
        }

        public Models.Task GetTaskDetailById(int taskId)
        {
            return _context.Tasks
                .Include(t => t.User)
                .FirstOrDefault(t => t.TaskId == taskId);
        }
        public bool UpdateTaskStatus(int taskId, string newStatus)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.TaskId == taskId);
            if (task == null) return false;

            task.Status = newStatus;
            _context.SaveChanges();
            return true;
        }
    }
}
