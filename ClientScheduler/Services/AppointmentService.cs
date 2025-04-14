using ClientScheduler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientScheduler.Services
{
    public class AppointmentService
    {
        private readonly ClientScheduleContext _context;
        TimeZoneInfo local = Program.local;
        TimeZoneInfo est = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");

        public AppointmentService(ClientScheduleContext context)
        {
            _context = context;
        }

        // Get all appointments
        public List<Object> GetAllAppointments()
        {
            
            var appointments = _context.Appointments
                .Select(a => new
                {
                    a.AppointmentId,
                    a.CustomerId,
                    a.UserId,
                    a.Type,
                    Start = TimeZoneInfo.ConvertTimeFromUtc(DateTime.SpecifyKind(a.Start, DateTimeKind.Utc), TimeZoneInfo.Local),
                    End = TimeZoneInfo.ConvertTimeFromUtc(DateTime.SpecifyKind(a.End, DateTimeKind.Utc), TimeZoneInfo.Local),
                    CreateDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.SpecifyKind(a.CreateDate, DateTimeKind.Utc), TimeZoneInfo.Local),
                    a.CreatedBy,
                    LastUpdate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.SpecifyKind(a.LastUpdate, DateTimeKind.Utc), TimeZoneInfo.Local),
                    a.LastUpdateBy
                })
                .ToList();

            return appointments.Cast<object>().ToList();

        }

        // Get appointments for a specific date
        public List<Object> GetAppointmentsByDate(DateTime startDate, DateTime endDate)
        {
            var appointments = _context.Appointments
                .Where(a => a.Start >= startDate && a.Start <= endDate)
                .ToList()
                .Select(a => new
                {
                    a.AppointmentId,
                    a.CustomerId,
                    a.UserId,
                    a.Type,
                    Start = TimeZoneInfo.ConvertTimeFromUtc(DateTime.SpecifyKind(a.Start, DateTimeKind.Utc), TimeZoneInfo.Local),
                    End = TimeZoneInfo.ConvertTimeFromUtc(DateTime.SpecifyKind(a.End, DateTimeKind.Utc), TimeZoneInfo.Local),
                    CreateDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.SpecifyKind(a.CreateDate, DateTimeKind.Utc), TimeZoneInfo.Local),
                    a.CreatedBy,
                    LastUpdate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.SpecifyKind(a.LastUpdate, DateTimeKind.Utc), TimeZoneInfo.Local),
                    a.LastUpdateBy
                })
                .ToList();

            return appointments.Cast<object>().ToList();
        }

        public List<Object> GetAppointmentsOrderedByUser()
        {
            var appointmentsByUser = _context.Appointments
                .OrderBy(a => a.UserId)
                .ThenBy(a => a.Start)
                .Select(a => new
                {
                    a.UserId,
                    a.AppointmentId,
                    a.CustomerId,
                    a.Type,
                    Start = TimeZoneInfo.ConvertTimeFromUtc(DateTime.SpecifyKind(a.Start, DateTimeKind.Utc), TimeZoneInfo.Local),
                    End = TimeZoneInfo.ConvertTimeFromUtc(DateTime.SpecifyKind(a.End, DateTimeKind.Utc), TimeZoneInfo.Local),
                })

                .ToList();
            return appointmentsByUser.Cast<object>().ToList();
        }

        public List<Object> GetAppointmentTypesByMonth()
        {
            var appointmentsByMonth = _context.Appointments
                .GroupBy(a => new { a.Start.Year, a.Start.Month, a.Type })
                .Select(g => new
                {
                    Month = g.Key.Month,
                    Year = g.Key.Year,
                    Type = g.Key.Type,
                    Count = g.Count()
                })
                .OrderBy(r => r.Month)
                .ThenBy(r => r.Type)
                .ToList();
            return appointmentsByMonth.Cast<object>().ToList();
        }

   

        public bool IsWithinBusinessHours(DateTime selectedStartTime, DateTime selectedEndTime) 
        {
            bool validTime = true;

            TimeZoneInfo est = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");

            TimeZoneInfo local = TimeZoneInfo.Local;

            DateTime now = DateTime.UtcNow;
            DateTime nowEST = TimeZoneInfo.ConvertTime(now, TimeZoneInfo.Utc, est);

            DateTime selectedStartTimeEST = TimeZoneInfo.ConvertTime(selectedStartTime, local, est);
            DateTime selectedEndTimeEST = TimeZoneInfo.ConvertTime(selectedEndTime, local, est);

            DayOfWeek startDay = selectedStartTimeEST.DayOfWeek;
            TimeSpan startTime = selectedStartTimeEST.TimeOfDay;

            DayOfWeek endDay = selectedEndTimeEST.DayOfWeek;
            TimeSpan endTime = selectedEndTimeEST.TimeOfDay;

            TimeSpan open = new TimeSpan(9, 0, 0);
            TimeSpan close = new TimeSpan(17, 0, 0);

            if (endTime < startTime || startDay != endDay) 
            {
                validTime = false;
            }

            if (selectedStartTimeEST < nowEST) 
            {
                validTime = false;
            }

            if (!(startDay >= DayOfWeek.Monday && startDay <= DayOfWeek.Friday && endDay >= DayOfWeek.Monday && endDay <= DayOfWeek.Friday))
            {
                validTime = false;
            }

            if (!(startTime >= open && startTime <= close && endTime >= open && endTime <= close))
            {
                validTime = false;
            }
            return validTime;
        }

        public void AddAppointment(int customerId, int userId, string type, DateTime start, DateTime end)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    Appointment appointment = new Appointment
                    {
                        CustomerId = customerId,
                        UserId = userId,
                        Title = "not needed???",
                        Contact = "not needed???",
                        Description = "not needed???",
                        Location = "not needed",
                        Url = "not needed",
                        Type = type,
                        Start = start.ToUniversalTime(),
                        End = end.ToUniversalTime(),
                        CreateDate = DateTime.UtcNow,
                        CreatedBy = "App",
                        LastUpdate = DateTime.UtcNow,
                        LastUpdateBy = "App"

                    };
                    _context.Appointments.Add(appointment);
                    _context.SaveChanges();

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void ModifyAppointment(int appointmentID, int customerID, int userID, string type, DateTime start, DateTime end)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var appt = _context.Appointments.FirstOrDefault(a => a.AppointmentId == appointmentID);
                    var cust = _context.Customers.FirstOrDefault(c => c.CustomerId == customerID);
                    var user = _context.Users.FirstOrDefault(u => u.UserId == userID);

                    //checks to see if the userID and custID are valid
                    if (cust == null || user == null)
                    {
                        throw new InvalidOperationException("Please use valid customer & user IDs");
                    }
    

                    //checks to see if appointmentID is valid
                    if (appt != null )
                    {
                        appt.CustomerId = customerID;
                        appt.UserId = userID;
                        appt.Type = type;
                        appt.Start = start.ToUniversalTime();
                        appt.End = end.ToUniversalTime();

                        appt.LastUpdateBy = "App";
                        appt.LastUpdate = DateTime.UtcNow;

                        //all the "not needed" values that are needed for some reason???
                        appt.Title = "not needed";
                        appt.Description = "still not needed";
                        appt.Location = "You guessed it";
                        appt.Contact = "not needed";
                        appt.Url = "needed, but not needed";

                        _context.SaveChanges();
                    }



                    transaction.Commit();
           
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public bool checkForOverlappingAppointment(DateTime start, DateTime end, int userID, int appointmentID, int customerID)
        {
            start = start.ToUniversalTime();
            end = end.ToUniversalTime();

            var overlappingAppt = _context.Appointments
                .Where(a => a.UserId == userID && a.AppointmentId != appointmentID && a.CustomerId != customerID)
                .Where(a => (start >= a.Start && start < a.End) || (end > a.Start && end <= a.End) || (start <= a.Start && end >= a.End))
                .ToList();
            return overlappingAppt.Count == 0;
        }

        public void DeleteAppointment(int apptID) 
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var appointment = _context.Appointments.FirstOrDefault(a => a.AppointmentId == apptID);
                    if (appointment != null)
                    {
                        _context.Appointments.Remove(appointment);
                        _context.SaveChanges();
                    }

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public List<int> getUserIDs() 
        {
            var userIDs = _context.Users
                .OrderBy(u => u.UserId)
                .Select(u => u.UserId)
                .ToList();


            return userIDs;
        }

        public List<int> getCustomerIDs()
        {
            var customerIDs = _context.Customers
                .OrderBy(c => c.CustomerId)
                .Select(c => c.CustomerId)
                .ToList();

            return customerIDs;
        }

        public void apptWarning() 
        {
            DateTime currentTime = DateTime.UtcNow;

            //finds appointments that are within 15 minutes of the current time
            var appointments = _context.Appointments.Where(a => a.Start >= currentTime && a.Start <= currentTime.AddMinutes(15) && a.UserId == Program.loggedInUserID)
                .Select(a => new
                {
                    a.AppointmentId,
                    a.CustomerId,
                    a.UserId,
                    a.Type,
                    a.Start,
                    a.End, 
                    a.CreateDate,
                    a.CreatedBy,
                    a.LastUpdate,
                    a.LastUpdateBy
                })
                .ToList();

            if (appointments.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("You have an appointment within the next 15 minutes:");
                foreach (var appointment in appointments)
                {
                    sb.AppendLine($"Appointment ID: {appointment.AppointmentId}");
                    sb.AppendLine($"Customer ID: {appointment.CustomerId}");
                    sb.AppendLine($"User ID: {appointment.UserId}");
                    sb.AppendLine($"Type: {appointment.Type}");
                    sb.AppendLine($"Start: {TimeZoneInfo.ConvertTimeFromUtc(DateTime.SpecifyKind(appointment.Start, DateTimeKind.Utc), TimeZoneInfo.Local)}");
                    sb.AppendLine($"End: {TimeZoneInfo.ConvertTimeFromUtc(DateTime.SpecifyKind(appointment.End, DateTimeKind.Utc), TimeZoneInfo.Local)}");
                    sb.AppendLine($"Created On: {TimeZoneInfo.ConvertTimeFromUtc(DateTime.SpecifyKind(appointment.CreateDate, DateTimeKind.Utc), TimeZoneInfo.Local)}");
                    sb.AppendLine($"Created By: {appointment.CreatedBy}");
                    sb.AppendLine($"Last Updated: {TimeZoneInfo.ConvertTimeFromUtc(DateTime.SpecifyKind(appointment.LastUpdate, DateTimeKind.Utc), TimeZoneInfo.Local)}");
                    sb.AppendLine($"Last Updated By: {appointment.LastUpdateBy}");
                    sb.AppendLine();
                }
                MessageBox.Show(sb.ToString());
            }
        }
    }
}
