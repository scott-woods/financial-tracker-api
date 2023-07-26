using FinancialTrackerApi.Models.DTOs;

namespace FinancialTrackerApi.Services.Interfaces
{
    public interface IRecurringExpensesService
    {
        public List<RecurringExpenseDTO> GetRecurringExpenses(int userId);
        public bool AddRecurringExpense(int userId, RecurringExpenseDTO recurringExpenseDTO);
    }
}
