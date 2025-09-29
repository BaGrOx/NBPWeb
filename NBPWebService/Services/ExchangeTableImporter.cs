using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NBPWebDatabase;
using NBPWebDatabase.Models;
using NBPWebService.Interfaces;

namespace NBPWebService.Services
{
    public class ExchangeTableImporter(NbpDbContext db, NBPClient client, ILogger<ExchangeTableImporter> log) : IExchangeTableImporter
    {
        public async Task<bool> ImportLatestTableAsync(CancellationToken ct)
        {
            var dto = await client.GetLatestTableAsync(ct);
            if (dto is null)
            {
                return false;
            }

            var exists = await db.Set<ExchangeTable>().AnyAsync(t => t.No == dto.No, ct);
            if (exists)
            {
                return false;
            }

            var table = new ExchangeTable
            {
                Id = Guid.NewGuid(),
                Table = dto.Table,
                No = dto.No,
                EffectiveDate = dto.EffectiveDate,
                Rates = dto.Rates.Select(r => new ExchangeRate
                {
                    Id = Guid.NewGuid(),
                    Currency = r.Currency,
                    Code = r.Code,
                    Mid = r.Mid,
                }).ToList()
            };

            await db.AddAsync(table, ct);
            var saved = await db.SaveChangesAsync(ct);
            log.LogInformation("Imported NBP table {No} ({Date}), {Count} rates", table.No, table.EffectiveDate, table.Rates.Count);
            return saved > 0;
        }
    }
}
