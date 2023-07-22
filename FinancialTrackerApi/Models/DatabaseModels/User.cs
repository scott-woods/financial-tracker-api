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
    }
}
