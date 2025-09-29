namespace NBPWebService.Models.OutputDtos
{
    public class ExchangeRateResultDto
    {
        public ExchangeRateResultDto(string currency, string code, decimal mid)
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
