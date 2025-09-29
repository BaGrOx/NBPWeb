using Microsoft.AspNetCore.Mvc;
using NBPWeb.Mappers;
using NBPWebService.Interfaces;

namespace NBPWeb.Controllers
{
    [Route("")]
    public class RatesController : Controller
    {
        private readonly IExchangeReadService _readService;
        private readonly IExchangeTableImporter _importer;
        private readonly ILogger<RatesController> _log;

        public RatesController(
            IExchangeReadService readService,
            IExchangeTableImporter importer,
            ILogger<RatesController> log)
        {
            _readService = readService;
            _importer = importer;
            _log = log;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index(CancellationToken ct)
        {
            var dto = await _readService.GetLatestAsync(ct);
            if (dto is null)
            {
                return View("Index", model: null);
            }

            var vm = dto.ToVM();
            return View("Index", vm);
        }

        [HttpPost("sync")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Sync(CancellationToken ct)
        {
            try
            {
                var added = await _importer.ImportLatestTableAsync(ct);
                TempData["SyncMsg"] = added
                    ? "✅ Dodano nową tabelę."
                    : "ℹ️ Brak nowych danych.";
            }
            catch (OperationCanceledException)
            {
                TempData["SyncMsg"] = "⏹ Operacja przerwana.";
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "Błąd podczas ręcznej synchronizacji NBP.");
                TempData["SyncMsg"] = "❗ Wystąpił błąd podczas synchronizacji.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
