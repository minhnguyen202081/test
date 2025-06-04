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
    public partial class Home : Form
    {
        private readonly AppDbContext _context;
        public Home(AppDbContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var userService = new UserService(_context);
            ManageUser manageUserForm = new ManageUser(_context, userService);
            manageUserForm.Show();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var taskService = new TaskService(_context);
            ManageTask manageTask= new ManageTask(_context, taskService);
            manageTask.Show();
        }
    }
}
