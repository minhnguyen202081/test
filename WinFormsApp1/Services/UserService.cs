using System;
using TaskManagerApp.Data;
using TaskManagerApp.Models;

namespace TaskManagerApp.Services
{
    public class UserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public void AddUser(string username, string email)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Username and Email are required.");
            }

            var user = new User
            {
                Username = username,
                Email = email
            };

            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
