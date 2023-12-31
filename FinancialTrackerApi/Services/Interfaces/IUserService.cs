﻿using FinancialTrackerApi.Models.DatabaseModels;
using FinancialTrackerApi.Models.DTOs;
using FinancialTrackerApi.Models.RequestModels;

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
        /// <summary>
        /// Add a new user
        /// </summary>
        /// <param name="userRequest"></param>
        /// <returns></returns>
        public UserDTO AddUser(AddUserRequest userRequest);
        /// <summary>
        /// Update a user's savings goal
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="newSavingsGoal"></param>
        /// <returns></returns>
        public bool UpdateSavingsGoal(int userId, float newSavingsGoal);
    }
}
