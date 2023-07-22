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
    }
}
