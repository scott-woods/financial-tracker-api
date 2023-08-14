using AutoMapper;
using FinancialTrackerApi.Context;
using FinancialTrackerApi.Models.DatabaseModels;
using FinancialTrackerApi.Models.DTOs;
using FinancialTrackerApi.Models.RequestModels;
using FinancialTrackerApi.Services.Interfaces;

namespace FinancialTrackerApi.Services
{
    /// <summary>
    /// user service
    /// </summary>
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<UserService> _log;
        private IMapper _mapper;

        public UserService(AppDbContext context, ILogger<UserService> log, IMapper mapper)
        {
            _context = context;
            _log = log;
            _mapper = mapper;
        }

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public UserDTO? GetUser(int userId)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.Id == userId);

                if (user != null)
                {
                    return _mapper.Map<User, UserDTO>(user);
                }
                else
                {
                    throw new KeyNotFoundException($"User with id {userId} was not found");
                }
            }
            catch (Exception e)
            {
                _log.LogError(e, $"Exception occurred while getting User with id {userId}");
                throw;
            }
        }

        /// <summary>
        /// Get user by auth 0 id
        /// </summary>
        /// <param name="auth0UserId"></param>
        /// <returns></returns>
        public User? GetUserByAuth0Id(string auth0UserId)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.Auth0UserId == auth0UserId);
                return user;
            }
            catch (Exception e)
            {
                _log.LogError(e, $"Exception occurred while getting User with Auth0 id {auth0UserId}");
                throw;
            }
        }

        /// <summary>
        /// add a new user
        /// </summary>
        /// <param name="userRequest"></param>
        /// <returns></returns>
        public UserDTO AddUser(AddUserRequest userRequest)
        {
            try
            {
                var user = new User()
                {
                    Auth0UserId = userRequest.Auth0UserId,
                    Email = userRequest.Email,
                    SavingsGoal = 0,
                    SavingsGoalLastUpdatedDate = DateTime.UtcNow
                };

                _context.Users.Add(user);

                _context.SaveChanges();

                return _mapper.Map<User, UserDTO>(user);
            }
            catch (Exception e)
            {
                _log.LogError(e, $"Exception occurred while adding User");
                throw;
            }
        }

        /// <summary>
        /// update a user's savings goal
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="newSavingsGoal"></param>
        /// <returns></returns>
        public bool UpdateSavingsGoal(int userId, float newSavingsGoal)
        {
            try
            {
                var user = _context.Users.Where(u => u.Id == userId).FirstOrDefault();

                if (user == null)
                {
                    if (_log.IsEnabled(LogLevel.Debug)) _log.LogDebug($"Failed to find User with id {userId}");
                    return false;
                }

                user.SavingsGoal = newSavingsGoal;
                user.SavingsGoalLastUpdatedDate = DateTime.UtcNow;

                _context.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                _log.LogError(e, $"Exception occurred while updating Savings Goal");
                throw;
            }
        }
    }
}
