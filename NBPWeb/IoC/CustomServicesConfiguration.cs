namespace NBPWeb.IoC
{
    public static class CustomServicesConfiguration
    {
        public static IServiceCollection AddIndividualServices(this IServiceCollection services)
        {
            services.AddHttpClient<NBPWebService.Services.NBPClient>(c =>
            {
                c.Timeout = TimeSpan.FromSeconds(30);
                c.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            services.AddScoped<NBPWebService.Interfaces.IExchangeTableImporter, NBPWebService.Services.ExchangeTableImporter>();
            services.AddScoped<NBPWebService.Interfaces.IExchangeReadService, NBPWebService.Services.ExchangeReadService>();
            services.AddHostedService<NBPWebService.Services.NbpSyncHostedService>();

            return services;
        }
    }
}
