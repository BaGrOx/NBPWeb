using NBPWebService.Models.OutputDtos;

namespace NBPWebService.Interfaces
{
    public interface IExchangeReadService
    {
        Task<ExchangeTableResultDto?> GetLatestAsync(CancellationToken ct = default);
    }
}
