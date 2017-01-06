using System;
using System.Linq;
using DatabaseApplication;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
           using (var context = new SqliteDbContext()) {

                // Start with a clean database
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                // Add reminders.
                context.Reminders.Add(new Reminder {
                    Title = "Meditate"
                });
                context.Reminders.Add(new Reminder {
                    Title = "Eat a nutritious breakfast"
                });
                context.SaveChanges();

                // Fetch Reminders
                var reminders = context.Reminders.ToArray();
                foreach(var reminder in reminders) {
                    Console.WriteLine($"{reminder.Title}");
                }

                // Remove a reminder
                context.Database.ExecuteSqlCommand(
                    "DELETE FROM Reminders WHERE Title = {0}", "Meditate");

                // Fetch Reminders
                var reminderz = context.Reminders.ToArray();
                foreach(var reminder in reminderz) {
                    Console.WriteLine($"{reminder.Title}");
                }
            }
        }
    }
}
