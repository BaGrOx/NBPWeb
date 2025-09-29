# NBPWeb

Aplikacja **.NET 8 / ASP.NET Core MVC** do pobierania kursów walut z **NBP – Tabela B**, zapisywania ich w bazie (**EF Core 8 / SQL Server**) i wyświetlania w widoku.  
Import działa **cyklicznie w tle** (HostedService) oraz **na żądanie** przyciskiem „Sync”.

## Stack
- .NET 8, ASP.NET Core MVC  
- EF Core 8 (SQL Server)  
- Podział na projekty: `NBPWeb` (UI), `NBPWebService` (logika), `NBPWebDatabase` (DbContext + migracje)

## Uruchomienie (skrót)
1) Ustaw connection string w `NBPWeb/appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "NBPDatabase": "Server=(localdb)\\MSSQLLocalDB;Database=NbpRates;Trusted_Connection=True;TrustServerCertificate=True;"
     }
   }
