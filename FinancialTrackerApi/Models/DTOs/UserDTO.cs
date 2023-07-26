namespace FinancialTrackerApi.Models.DTOs
{
    /// <summary>
    /// User DTO
    /// </summary>
    public class UserDTO
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// User Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Savings goal
        /// </summary>
        public float SavingsGoal { get; set; }
        /// <summary>
        /// Savings goal last updated date
        /// </summary>
        public DateTime SavingsGoalLastUpdatedDate { get; set; }
    }
}
