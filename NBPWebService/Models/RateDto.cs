namespace NBPWebService.Models
{
    public class RateDto
    {
        public RateDto(string currency, string code, decimal mid)
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
