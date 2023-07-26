using FinancialTrackerApi.Models.DatabaseModels;

namespace FinancialTrackerApi.Models.DTOs
{
    /// <summary>
    /// Debt DTO
    /// </summary>
    public class DebtDTO
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// amount
        /// </summary>
        public float Amount { get; set; }
        /// <summary>
        /// date created
        /// </summary>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// date last updated
        /// </summary>
        public DateTime DateLastUpdated { get; set; }
    }
}
