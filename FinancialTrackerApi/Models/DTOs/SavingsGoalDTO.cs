namespace FinancialTrackerApi.Models.DTOs
{
    /// <summary>
    /// Savings Goal DTO
    /// </summary>
    public class SavingsGoalDTO
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// goal amount
        /// </summary>
        public float Amount { get; set; }
        /// <summary>
        /// date goal was created
        /// </summary>
        public DateTime DateCreated { get; set; }
    }
}
