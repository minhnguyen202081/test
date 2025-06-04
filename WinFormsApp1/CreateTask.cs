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
    public partial class CreateTask : Form
    {
        private readonly AppDbContext _context;
        private readonly TaskService _taskService;
        public CreateTask(AppDbContext context, TaskService taskService)
        {
            InitializeComponent();
            _context = context;
            _taskService = taskService;
            LoadUsers();
            comboUser.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            comboPriority.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private void LoadUsers()
        {
            var users = _context.Users.ToList();
            comboUser.DataSource = users;
            comboUser.DisplayMember = "Username";
            comboUser.ValueMember = "UserId";
        }

     

        private void btnSave_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string desc = txtDescription.Text.Trim();
            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Please fill the title");
                return;
            }
            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Please fill the title");
                return;
            }

            if (ComboStatus.SelectedItem == null)
            {
                MessageBox.Show("Please select a status");
                return;
            }

            if (comboPriority.SelectedItem == null)
            {
                MessageBox.Show("Please select a priority");
                return;
            }

            if (comboUser.SelectedItem == null)
            {
                MessageBox.Show("Please select a user");
                return;
            }
            DateTime? dueDate = dateTimePicker1.Value;
            string status = ComboStatus.SelectedItem.ToString();
            string priority = comboPriority.SelectedItem.ToString();
            int userId = (int)comboUser.SelectedValue;

          

            try
            {

                _taskService.AddTask(title, desc, dueDate, status, priority, userId);

                MessageBox.Show("Save Successfully!");
                    this.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}

