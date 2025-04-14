using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using ClientScheduler.Models;
using Microsoft.VisualBasic.ApplicationServices;
using Org.BouncyCastle.Bcpg;

namespace ClientScheduler.Services
{
    public class AuthService
    {
        private readonly ClientScheduleContext _context;
        private readonly string _logFilePath;
        public AuthService(ClientScheduleContext context)
        {
            _context = context;

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            _logFilePath = Path.Combine(desktopPath, "Login_History.txt");

            checkFileExists();
        }

        public void checkFileExists() 
        {
            if (!File.Exists(_logFilePath)) 
            {
                File.Create(_logFilePath).Dispose();
            }
        }
        public async Task logUserLogin(string message) 
        {
            
           

            await File.AppendAllTextAsync(_logFilePath, message) ;
        }

        public async Task<bool> ValidateUser(string username, string password)
        {
            // Look for a user with the given username
            var user = _context.Users.FirstOrDefault(u => u.UserName == username);
            string message = "";
            if (user == null)
            {
                Program.SetUser(-1);
                message = $"{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} - Unsuccessful Login - username: {username} \n";
                await logUserLogin(message);
                return false; // User not found
            }

            if (user.Password == password) 
            {
                Program.SetUser(user.UserId);
                message = $"{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} - Successful Login - user ID: {user.UserId} Name: {user.UserName}\n";
                await logUserLogin(message);
            }
            return user.Password == password;

        }
    }

}    

