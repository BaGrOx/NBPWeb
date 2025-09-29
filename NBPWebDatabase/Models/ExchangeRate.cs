using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NBPWebDatabase.Models
{
    /// <summary>
    /// Pojedynczy kurs waluty z tabeli NBP.
    /// </summary>
    public class ExchangeRate
    {
        /// <summary>
        /// Klucz rekordu.
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Nazwa waluty.
        /// </summary>
        public string? Currency { get; set; }

        /// <summary>
        /// Trzyliterowy kod waluty.
        /// </summary>
        [MaxLength(3)]
        public string? Code { get; set; }

        /// <summary>
        /// Średni kurs w PLN.
        /// </summary>
        public decimal Mid { get; set; }

        /// <summary>
        /// Identyfikator tabeli kursów.
        /// </summary>
        [ForeignKey(nameof(ExchangeTable))]
        public Guid ExchangeTableId { get; set; }

        /// <summary>
        /// Nawigacja do tabeli kursów.
        /// </summary>
        public ExchangeTable? ExchangeTable { get; set; }
    }
}
