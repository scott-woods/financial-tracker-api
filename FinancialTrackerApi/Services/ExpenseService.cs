using AutoMapper;
using FinancialTrackerApi.Context;
using FinancialTrackerApi.Models.DatabaseModels;
using FinancialTrackerApi.Models.DTOs;
using FinancialTrackerApi.Services.Interfaces;

namespace FinancialTrackerApi.Services
{
    /// <summary>
    /// Expense service
    /// </summary>
    public class ExpenseService : IExpenseService
    {
        private readonly ILogger<ExpenseService> _log;
        private readonly AppDbContext _context;
        private IMapper _mapper;

        public ExpenseService(ILogger<ExpenseService> log, AppDbContext context, IMapper mapper)
        {
            _log = log;
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Get expenses by date range
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public List<ExpenseDTO> GetExpenses(int userId, DateTime? startDate = null, DateTime? endDate = null)
        {
            try
            {
                var expenseDtos = new List<ExpenseDTO>();

                var expenses = _context.Expenses
                    .Where(e => e.User.Id == userId)
                    .OrderByDescending(e => e.Date)
                    .ToList();

                if (startDate != null)
                {
                    expenses = expenses.Where(e => e.Date >= startDate).ToList();
                }
                if (endDate != null)
                {
                    expenses = expenses.Where(e => e.Date <= endDate).ToList();
                }

                if (expenses.Any())
                {
                    expenseDtos = expenses.Select(_mapper.Map<Expense, ExpenseDTO>).ToList();
                }

                return expenseDtos;
            }
            catch (Exception e)
            {
                _log.LogError(e, "Exception occurred while getting expenses");
                throw;
            }
        }

        public float GetTotalExpenses(int userId, DateTime? startDate = null, DateTime? endDate = null)
        {
            try
            {
                var totalExpenses = 0f;

                var expenses = _context.Expenses
                    .Where(e => e.User.Id == userId)
                    .OrderByDescending(e => e.Date)
                    .ToList();

                if (startDate != null)
                {
                    expenses = expenses.Where(e => e.Date >= startDate).ToList();
                }
                if (endDate != null)
                {
                    expenses = expenses.Where(e => e.Date <= endDate).ToList();
                }

                foreach (var expense in expenses)
                {
                    totalExpenses += expense.Amount;
                }

                return totalExpenses;
            }
            catch (Exception e)
            {
                _log.LogError(e, "Exception occurred while getting total expenses");
                throw;
            }
        }

        /// <summary>
        /// Add a single expense
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="expenseDTO"></param>
        /// <returns></returns>
        public ExpenseDTO AddExpense(int userId, ExpenseDTO expenseDTO)
        {
            try
            {
                var user = _context.Users.Where(u => u.Id == userId).FirstOrDefault();

                if (user == null)
                {
                    if (_log.IsEnabled(LogLevel.Debug)) _log.LogDebug($"Failed to find User with id {userId}");
                    throw new KeyNotFoundException();
                }

                var expense = _mapper.Map<ExpenseDTO, Expense>(expenseDTO, opts =>
                {
                    opts.AfterMap((src, dest) =>
                    {
                        dest.User = user;
                        dest.Date = DateTime.UtcNow;
                    });
                });

                _context.Expenses.Add(expense);

                _context.SaveChanges();

                return _mapper.Map<Expense, ExpenseDTO>(expense);
            }
            catch (Exception e)
            {
                _log.LogError(e, "Exception occurred while adding expense");
                throw;
            }
        }

        public bool UpdateExpense(int userId, ExpenseDTO expense)
        {
            try
            {
                var user = _context.Users.Where(u => u.Id == userId).FirstOrDefault();

                if (user == null)
                {
                    if (_log.IsEnabled(LogLevel.Debug)) _log.LogDebug($"Failed to find User with id {userId}");
                    return false;
                }

                var currentExpense = _context.Expenses.Find(expense.Id);

                if (currentExpense == null)
                {
                    if (_log.IsEnabled(LogLevel.Debug)) _log.LogDebug($"Expense with id {expense.Id} not found");
                    return false;
                }

                _context.Entry(currentExpense).CurrentValues.SetValues(expense);
                _context.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                _log.LogError(e, "Exception occurred while updating Expense");
                throw;
            }
        }

        public bool RemoveExpense(int userId, int expenseId)
        {
            try
            {
                var user = _context.Users.Where(u => u.Id == userId).FirstOrDefault();

                if (user == null)
                {
                    if (_log.IsEnabled(LogLevel.Debug)) _log.LogDebug($"Failed to find User with id {userId}");
                    return false;
                }

                var expense = _context.Expenses.Find(expenseId);

                if (expense == null)
                {
                    if (_log.IsEnabled(LogLevel.Debug)) _log.LogDebug($"Expense with id {expenseId} not found");
                    return false;
                }

                _context.Expenses.Remove(expense);
                return _context.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                _log.LogError(e, "Exception occurred while deleting Expense");
                throw;
            }
        }
    }
}
