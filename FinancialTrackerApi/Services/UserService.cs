using AutoMapper;
using FinancialTrackerApi.Context;
using FinancialTrackerApi.Models.DatabaseModels;
using FinancialTrackerApi.Models.DTOs;
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
    }
}
