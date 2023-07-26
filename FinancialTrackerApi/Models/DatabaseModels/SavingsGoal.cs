namespace FinancialTrackerApi.Models.DatabaseModels
{
    /// <summary>
    /// savings goal
    /// </summary>
    public class SavingsGoal
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
        /// goal amount
        /// </summary>
        public float Amount { get; set; }
        /// <summary>
        /// date goal was created
        /// </summary>
        public DateTime DateCreated { get; set; }
    }
}
