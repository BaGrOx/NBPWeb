namespace NBPWebService.Models.OutputDtos
{
    public class ExchangeTableResultDto
    {
        public ExchangeTableResultDto(string table, string no, DateOnly effectiveDate, IReadOnlyList<ExchangeRateResultDto> rates)
        {
            Table = table;
            No = no;
            EffectiveDate = effectiveDate;
            Rates = rates;
        }

        public string Table { get; }
        public string No { get; }
        public DateOnly EffectiveDate { get; }
        public IReadOnlyList<ExchangeRateResultDto> Rates { get; }
    }
}
