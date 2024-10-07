using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PlatformDemo.DAL.Model;

namespace PlatformDemo.DAL.Data.Seed;

public class PlatformDbContextSeed
{
    // Method to seed data into the database
    public static async Task SeedAsync(PlatformDbContext context,
        ILogger logger,
        int retry = 0)
    {
        var retryForAvailability = retry;
        try
        {
            if (context.Database.IsSqlServer())
            {
                context.Database.Migrate();
            }

            if (!await context.ServicePlans.AnyAsync())
            {
                await context.ServicePlans.AddRangeAsync(
                    GetPreconfiguredServicePlans(context));

                await context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            if (retryForAvailability >= 10) throw;

            retryForAvailability++;

            logger.LogError(ex.Message);
            await SeedAsync(context, logger, retryForAvailability);
            throw;
        }
    }


    private static IEnumerable<ServicePlan> GetPreconfiguredServicePlans(PlatformDbContext context)
    {
        var servicePlans = new List<ServicePlan>();
        for (int i = 1; i <= 10; i++)
        {
            var servicePlan = new ServicePlan
            {
                DateOfPurchase = DateTime.Now.AddDays(-i)
            };

            for (int j = 0; j < new Random().Next(0, 5); j++)
            {
                servicePlan.TimeSheets ??= [];

                servicePlan.TimeSheets?.Add(new TimeSheet
                {
                    StartTime = DateTime.Now.AddHours(-j),
                    EndTime = DateTime.Now,
                    Description = $"Task {j} for Service Plan {i}"
                });
            }

            servicePlans.Add(servicePlan);
        }

        context.ServicePlans.AddRange(servicePlans);
        context.SaveChanges();

        return servicePlans;
    }
}
