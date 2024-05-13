using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace SystemEventLogger
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var isService = !(Environment.UserInteractive || args.Length > 0 && args[0] == "--console");

            var builder = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<EventLoggerService>();
                });

            if (isService)
            {
                await builder.UseWindowsService().Build().RunAsync();
            }
            else
            {
                await builder.RunConsoleAsync();
            }
        }
    }

    public class EventLoggerService : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                // Log system events here
                using (StreamWriter writer = new StreamWriter("C:\\SystemEventLog.txt", true))
                {
                    await writer.WriteLineAsync($"System event logged at: {DateTime.Now}");
                }

                await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken); // Log every 5 minutes
            }
        }
    }
}
