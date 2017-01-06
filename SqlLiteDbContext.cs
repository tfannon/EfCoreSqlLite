using Microsoft.EntityFrameworkCore;

namespace DatabaseApplication {
    public class SqliteDbContext :  DbContext {
        public DbSet<Reminder> Reminders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite("Filename=./Reminders.sqlite");
        }
    }
}