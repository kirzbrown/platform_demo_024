using Microsoft.EntityFrameworkCore;
using PlatformDemo.DAL.Model;
using System.Reflection;

namespace PlatformDemo.DAL.Data
{
    public class PlatformDbContext : DbContext
    {
        public DbSet<ServicePlan> ServicePlans { get; set; }
        public DbSet<TimeSheet> TimeSheets { get; set; }

        public PlatformDbContext(DbContextOptions<PlatformDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ServicePlan>()
                .HasMany(sp => sp.TimeSheets)
                .WithOne(ts => ts.ServicePlan)
                .HasForeignKey(ts => ts.ServicePlanId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
