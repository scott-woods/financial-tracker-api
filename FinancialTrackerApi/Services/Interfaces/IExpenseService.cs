using FinancialTrackerApi.Models.DTOs;

namespace FinancialTrackerApi.Services.Interfaces
{
    public interface IExpenseService
    {
        public List<ExpenseDTO> GetExpenses(int userId, DateTime? startDate = null, DateTime? endDate = null);
        public float GetTotalExpenses(int userId, DateTime? startDate = null, DateTime? endDate = null);
        public bool AddExpense(int userId, ExpenseDTO expenseDTO);
    }
}
