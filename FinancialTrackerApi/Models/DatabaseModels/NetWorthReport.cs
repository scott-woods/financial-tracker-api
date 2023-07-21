namespace FinancialTrackerApi.Models.DatabaseModels
{
    /// <summary>
    /// keeps track of net worth when updating assets and debts
    /// </summary>
    public class NetWorthReport
    {
        /// <summary>
        /// id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// user id fk
        /// </summary>
        public User User { get; set; }
        /// <summary>
        /// date report was generated
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// total liquid assets
        /// </summary>
        public float LiquidAssets { get; set; }
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
