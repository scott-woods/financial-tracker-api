namespace FinancialTrackerApi.Models.DatabaseModels
{
    /// <summary>
    /// monthly savings
    /// </summary>
    public class MonthlySavings
    {
        /// <summary>
        /// id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// user id fk
        /// </summary>
        public virtual User User { get; set; }
        /// <summary>
        /// month
        /// </summary>
        public string Month { get; set; }
        /// <summary>
        /// year
        /// </summary>
        public string Year { get; set; }
        /// <summary>
        /// liquid savings
        /// </summary>
        public float LiquidSavings { get; set; }
        /// <summary>
        /// total savings
        /// </summary>
        public float TotalSavings { get; set; }
    }
}
