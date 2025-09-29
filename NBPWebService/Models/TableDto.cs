namespace NBPWebService.Models
{
    public class TableDto
    {
        public TableDto(string table, string no, DateOnly effectiveDate, List<RateDto> rates)
        {
            Table = table;
            No = no;
            EffectiveDate = effectiveDate;
            Rates = rates;
        }

        public string Table { get; }
        public string No { get; }
        public DateOnly EffectiveDate { get; }
        public List<RateDto> Rates { get; }
    }
}
