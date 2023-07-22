using FinancialTrackerApi.Models.DatabaseModels;

namespace FinancialTrackerApi.Models.DTOs
{
    /// <summary>
    /// Net Worth Report DTO
    /// </summary>
    public class NetWorthReportDTO
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// date report was generated
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// total liquid assets
        /// </summary>
        public float LiquidAssets { get; set; }
        /// <summary>
        /// Non liquid assets
        /// </summary>
        public float NonLiquidAssets { get; set; }
        /// <summary>
        /// total assets (including non liquid)
        /// </summary>
        public float TotalAssets { get; set; }
        /// <summary>
        /// total debts
        /// </summary>
        public float TotalDebts { get; set; }
        /// <summary>
        /// fk to previous report
        /// </summary>
        public NetWorthReport? PreviousReport { get; set; }
    }
}
