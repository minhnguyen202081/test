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

namespace TaskManagerApp
{
    public partial class ManageUser : Form
    {
        private readonly AppDbContext _context;
        private readonly UserService _userService;
        public ManageUser(AppDbContext context, UserService userService)
        {
          
            InitializeComponent();
            _context = context;
            _userService = userService;
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

                _userService.AddUser(username, email);
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
