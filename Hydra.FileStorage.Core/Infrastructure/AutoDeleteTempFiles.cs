using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Hydra.FileStorage.Core.Infrastructure
{
    public class AutoDeleteService : IHostedService, IDisposable
    {
        private int _executionCount = 0;
        private readonly ILogger<AutoDeleteService> _logger;
        private Timer _timer;

        public AutoDeleteService(ILogger<AutoDeleteService> logger)
        {
            _logger = logger;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");

            _timer = new Timer(DeleteFiles, null, TimeSpan.Zero,
                TimeSpan.FromHours(6));  // every 6 hours run the method

            return Task.CompletedTask;
        }

        private void DeleteFiles(object state)
        {
            var count = Interlocked.Increment(ref _executionCount);
            var specDateTime = DateTime.Now.AddHours(-6);  // each file that was created before 6 hours ago
            string folderPath = Directory.GetCurrentDirectory() + "\\Temp\\";

            if (Directory.Exists(folderPath))
            {

                DirectoryInfo di = new DirectoryInfo(folderPath);

                var getAllFiles = di.GetFiles("*")
                    .Where(file => file.CreationTime < specDateTime).ToList();
                foreach (var fileFullPath in getAllFiles.Select(fileInfo => fileInfo.DirectoryName + @"\" + fileInfo.Name))
                {
                    File.Delete(fileFullPath);
                }
                _logger.LogInformation(
                    "Timed Hosted Service is working. Count: {Count}", count);
            }
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
