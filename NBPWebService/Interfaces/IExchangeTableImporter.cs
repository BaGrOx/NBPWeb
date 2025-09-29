namespace NBPWebService.Interfaces
{
    public interface IExchangeTableImporter
    {
        Task<bool> ImportLatestTableAsync(CancellationToken ct = default);
    }
}
