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

namespace TaskManagerApp
{
    public partial class ManageUser : Form
    {
        private readonly AppDbContext _context;
        public ManageUser(AppDbContext context)
        {
          
            InitializeComponent();
            _context = context;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please field all required fields.");
                return;
            }

            try
            {
                
                    var user = new User
                    {
                        Username = username,
                        Email = email
                    };

                    _context.Users.Add(user);
                    _context.SaveChanges();
                    MessageBox.Show("Update successfully!");
                    this.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }

}
