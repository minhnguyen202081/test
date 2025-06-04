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
            ManageUser manageUserForm = new ManageUser(_context);
            manageUserForm.Show();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ManageTask manageTask= new ManageTask(_context);
            manageTask.Show();
        }
    }
}
