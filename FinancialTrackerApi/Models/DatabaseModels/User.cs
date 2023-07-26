namespace FinancialTrackerApi.Models.DatabaseModels
{
    /// <summary>
    /// User
    /// </summary>
    public class User
    {
        /// <summary>
        /// User Id from Auth0
        /// </summary>
        public string Auth0UserId { get; set; }
        /// <summary>
        /// User Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// User Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Savings goal
        /// </summary>
        public float? SavingsGoal { get; set; }
        /// <summary>
        /// Savings goal last updated date
        /// </summary>
        public DateTime? SavingsGoalLastUpdatedDate { get; set; }
    }
}
