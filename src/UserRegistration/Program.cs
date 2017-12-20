namespace UserRegistration
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Serilog;
    using System;
    using System.IO;

    public class Program
    {
        public static int Main(string[] args)
        {
            IConfiguration configuration = BuildConfiguration(args);
            Log.Logger = BuildLogger(configuration);
            
            try
            {
                IWebHost host = BuildWebHost(args, configuration);
                
                try
                {
                    DatabaseInitializer.Initialize(configuration.GetConnectionString("DefaultConnection"));
                }
                catch (Exception ex)
                {
                    Log.Fatal(ex, messageTemplate: "An error occurred initialize the DB.");
                    return 1;
                }
                
                host.Run();

                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, messageTemplate: "Host terminated unexpectedly");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IWebHost BuildWebHost(string[] args, IConfiguration configuration) =>
            WebHost.CreateDefaultBuilder(args)
                   .UseStartup<Startup>()
                   .UseConfiguration(configuration)
                   .UseSerilog()
                   .Build();

        private static ILogger BuildLogger(IConfiguration configuration) =>
            new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

        private static IConfiguration BuildConfiguration(string[] args)
        {
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";

            IConfigurationBuilder configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(path: "appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile(path: $"appsettings.{environment}.json", optional: true, reloadOnChange: true);

            if (environment.Equals(value: "development", comparisonType: StringComparison.OrdinalIgnoreCase))
            {
                configuration.AddUserSecrets<Startup>();
            }

            configuration.AddEnvironmentVariables();

            if (args != null)
            {
                configuration.AddCommandLine(args);
            }

            return configuration.Build();
        }
    }
}