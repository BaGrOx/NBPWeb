using NBPWebService.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace NBPWebService.Services
{
    public class NBPClient(HttpClient http)
    {
        private static readonly JsonSerializerOptions JsonOpts = new(JsonSerializerDefaults.Web);

        public async Task<TableDto?> GetLatestTableAsync(CancellationToken ct = default)
        {
            var url = "https://api.nbp.pl/api/exchangerates/tables/B?format=json";
            var list = await http.GetFromJsonAsync<List<TableDto>>(url, JsonOpts, ct);
            return list?.FirstOrDefault();
        }
    }
}
