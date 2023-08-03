using FinancialTrackerApi.Models.DTOs;

namespace FinancialTrackerApi.Services.Interfaces
{
    public interface IRecurringExpensesService
    {
        public List<RecurringExpenseDTO> GetRecurringExpenses(int userId);
        public RecurringExpenseDTO AddRecurringExpense(int userId, RecurringExpenseDTO recurringExpenseDTO);
        public bool UpdateRecurringExpense(int userId, RecurringExpenseDTO recurringExpense);
        public bool RemoveRecurringExpense(int userId, int recurringExpenseId);
    }
}
