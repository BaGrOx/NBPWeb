namespace NBPWeb.Models.Rates
{
    public class RateRowViewModel
    {
        public RateRowViewModel(string currency, string code, decimal mid)
        {
            Currency = currency;
            Code = code;
            Mid = mid;
        }

        public string Currency { get; }
        public string Code { get; }
        public decimal Mid { get; }
    }
}
