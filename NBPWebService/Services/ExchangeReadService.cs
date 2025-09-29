using Microsoft.EntityFrameworkCore;
using NBPWebDatabase;
using NBPWebService.Interfaces;
using NBPWebService.Models.OutputDtos;

namespace NBPWebService.Services
{
    public class ExchangeReadService(NbpDbContext db) : IExchangeReadService
    {
        public async Task<ExchangeTableResultDto?> GetLatestAsync(CancellationToken ct = default) =>
            await db.Tables.AsNoTracking()
                .OrderByDescending(t => t.EffectiveDate)
                .Select(t => new ExchangeTableResultDto(
                    t.Table ?? "B",
                    t.No ?? string.Empty,
                    t.EffectiveDate,
                    t.Rates
                     .OrderBy(r => r.Currency)
                     .Select(r => new ExchangeRateResultDto(
                         r.Currency ?? string.Empty,
                         r.Code ?? string.Empty,
                         r.Mid
                     )).ToList()
                ))
                .FirstOrDefaultAsync(ct);
    }
}
