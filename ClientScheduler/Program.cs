using ClientScheduler.Models;
using ClientScheduler.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Drawing.Text;
using Microsoft.EntityFrameworkCore;
using ClientScheduler.Forms;



namespace ClientScheduler
{

    internal static class Program
    {
        public static int loggedInUserID = -1;
        public static TimeZoneInfo local;
        public static string selectedOption; 

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            var builder = new ServiceCollection();

            // Register DbContext
            builder.AddDbContext<ClientScheduleContext>();

            // Register services and forms
            builder.AddTransient<AuthService>();
            builder.AddTransient<LoginScreen>();
            builder.AddTransient<MainScreen>();
            builder.AddTransient<AppointmentService>();
            builder.AddTransient<CustomerService>();
            builder.AddTransient<CustomerScreen>();
            builder.AddTransient<AppointmentScreen>();
            builder.AddTransient <ReportScreen>();

            var serviceProvider = builder.BuildServiceProvider();


            ApplicationConfiguration.Initialize();

            // Start with LoginForm
            var loginForm = serviceProvider.GetRequiredService<LoginScreen>();

            local = TimeZoneInfo.Local;
            Application.Run(loginForm);

            
        }

        public static void SetUser(int userID) 
        {
            loggedInUserID = userID;
        }

   
    }
}