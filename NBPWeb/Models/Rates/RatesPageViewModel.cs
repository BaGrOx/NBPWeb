namespace NBPWeb.Models.Rates
{
    public class RatesPageViewModel
    {
        public RatesPageViewModel(string table, string no, DateOnly effectiveDate, IReadOnlyList<RateRowViewModel> rates)
        {
            Table = table;
            No = no;
            EffectiveDate = effectiveDate;
            Rates = rates;
        }

        public string Table { get; }
        public string No { get; }
        public DateOnly EffectiveDate { get; }
        public IReadOnlyList<RateRowViewModel> Rates { get; }
    }
}
