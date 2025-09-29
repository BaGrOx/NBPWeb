using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NBPWebService.Interfaces;

namespace NBPWebService.Services
{
    public class NbpSyncHostedService : BackgroundService
    {
        private readonly ILogger<NbpSyncHostedService> _log;
        private readonly IServiceScopeFactory _scopeFactory;

        public NbpSyncHostedService(ILogger<NbpSyncHostedService> log, IServiceScopeFactory scopeFactory)
        {
            _log = log;
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await RunOnce(stoppingToken);

            using var timer = new PeriodicTimer(TimeSpan.FromHours(6));
            while (await timer.WaitForNextTickAsync(stoppingToken))
            {
                await RunOnce(stoppingToken);
            }
        }

        private async Task RunOnce(CancellationToken ct)
        {
            using var scope = _scopeFactory.CreateScope();
            var importer = scope.ServiceProvider.GetRequiredService<IExchangeTableImporter>();
            try
            {
                var added = await importer.ImportLatestTableAsync(ct);
                if (added)
                {
                    _log.LogInformation("NBP: dodano nową tabelę.");
                }
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "NBP sync failed");
            }
        }
    }
}
