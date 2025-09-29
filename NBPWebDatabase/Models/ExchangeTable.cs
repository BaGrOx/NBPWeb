using System.ComponentModel.DataAnnotations;

namespace NBPWebDatabase.Models
{
    /// <summary>
    /// Nagłówek tabeli kursów NBP wraz z listą stawek walut.
    /// </summary>
    public class ExchangeTable
    {
        /// <summary>
        /// Klucz techniczny rekordu.
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Oznaczenie tabeli NBP: "A", "B" albo "C".
        /// Dla Twojego przypadku będzie to głównie "B".
        /// </summary>
        [MaxLength(1)]
        public string? Table { get; set; }

        /// <summary>
        /// Numer publikacji nadany przez NBP.
        /// </summary>
        [MaxLength(32)]
        public string? No { get; set; }

        /// <summary>
        /// Data, od której tabela obowiązuje.
        /// </summary>
        public DateOnly EffectiveDate { get; set; }

        /// <summary>
        /// Kursy walut należące do tej konkretnej publikacji (tabeli).
        /// </summary>
        public List<ExchangeRate> Rates { get; set; } = [];
    }
}
