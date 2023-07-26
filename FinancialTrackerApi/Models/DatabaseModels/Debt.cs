namespace FinancialTrackerApi.Models.DatabaseModels
{
    /// <summary>
    /// debt
    /// </summary>
    public class Debt
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
