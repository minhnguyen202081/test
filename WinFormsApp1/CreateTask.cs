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
    public partial class CreateTask : Form
    {
        public CreateTask()
        {
            InitializeComponent();
            LoadUsers();   
           
        }

        private void LoadUsers()
        {
            using (var context = new AppDbContext())
            {
                var users = context.Users.ToList();
                comboUser.DataSource = users;
                comboUser.DisplayMember = "Username";
                comboUser.ValueMember = "UserId";
            }
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
                using (var context = new AppDbContext())
                {
                    var task = new Models.Task
                    {
                        Title = title,
                        Description = desc,
                        DueDate = dueDate,
                        Status = status,
                        Priority = priority,
                        UserId = userId
                    };

                    context.Tasks.Add(task);
                    context.SaveChanges();

                    MessageBox.Show("Save Successfully!");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}

