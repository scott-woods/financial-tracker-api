using FinancialTrackerApi.Models.DatabaseModels;

namespace FinancialTrackerApi.Services.Interfaces
{
    /// <summary>
    /// Service for interfacing with users
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        public List<User> GetUsers();
    }
}
