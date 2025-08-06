using GESTOR_TORNEOS.src.Shared.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GESTOR_TORNEOS.src.Shared.Helpers;

public class DbContextFactory
{
    public static AppDbContext Create()
    {
        var config = new ConfigurationBuilder()
            .SetBasePath("C:\\Users\\ASUS\\Documents\\PIPEJ2\\C#\\projectsNet\\GESTOR_TORNEOSv4")
            .AddJsonFile("appsettings.json", optional: true)
            .Build();

        string? connectionString = Environment.GetEnvironmentVariable("MYSQL_CONNECTION")
                                ?? config.GetConnectionString("MySqlDb");

        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException("Connection string 'MySqlDb' not found in appsettings.json");
        }

        var detectedVersion = MySqlVersionResolver.DetectVersion(connectionString);
        var minVersion = new Version(8, 0, 0);

        if (detectedVersion < minVersion)
        {
            throw new InvalidOperationException($"MySQL version {detectedVersion} is not supported. Minimum required version is {minVersion}");
        }

        Console.WriteLine($"Using MySQL version {detectedVersion}");

        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseMySql(connectionString, new MySqlServerVersion(detectedVersion))
            .Options;

        return new AppDbContext(options);
    }
}