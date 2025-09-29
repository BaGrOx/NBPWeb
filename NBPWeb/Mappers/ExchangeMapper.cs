using NBPWeb.Models.Rates;
using NBPWebService.Models.OutputDtos;

namespace NBPWeb.Mappers
{
    public static class ExchangeMapper
    {
        public static RatesPageViewModel ToVM(this ExchangeTableResultDto dto) =>
            new(dto.Table, dto.No, dto.EffectiveDate, dto.Rates.Select(x => x.ToVM()).ToList());


        private static RateRowViewModel ToVM(this ExchangeRateResultDto dto) =>
            new(dto.Currency, dto.Code, dto.Mid);
    }
}
