using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PlatformDemo.DAL.Data.Services;

public static class Dependencies
{
    public static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
    {
        // Requires LocalDB which can be installed with SQL Server Express 2016
        // https://www.microsoft.com/en-us/download/details.aspx?id=54284
        services.AddDbContext<PlatformDbContext>(c =>
            c.UseSqlServer(configuration.GetConnectionString("CatalogConnection")));
    }
}