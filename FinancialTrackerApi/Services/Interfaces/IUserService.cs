using FinancialTrackerApi.Models.DatabaseModels;
using FinancialTrackerApi.Models.DTOs;

namespace FinancialTrackerApi.Services.Interfaces
{
    /// <summary>
    /// Service for interfacing with users
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public UserDTO? GetUser(int userId);

        /// <summary>
        /// Get user ef object by auth0 id
        /// </summary>
        /// <param name="auth0UserId"></param>
        /// <returns></returns>
        public User GetUserByAuth0Id(string auth0UserId);
    }
}
