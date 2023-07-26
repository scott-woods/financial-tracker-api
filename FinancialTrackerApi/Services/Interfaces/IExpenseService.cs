using FinancialTrackerApi.Models.DTOs;

namespace FinancialTrackerApi.Services.Interfaces
{
    public interface IExpenseService
    {
        public List<ExpenseDTO> GetExpenses(int userId, DateTime startDate, DateTime endDate);
        public bool AddExpense(int userId, ExpenseDTO expenseDTO);
    }
}
