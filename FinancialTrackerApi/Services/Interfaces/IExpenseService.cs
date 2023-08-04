using FinancialTrackerApi.Models.DTOs;

namespace FinancialTrackerApi.Services.Interfaces
{
    public interface IExpenseService
    {
        public List<ExpenseDTO> GetExpenses(int userId, DateTime? startDate = null, DateTime? endDate = null);
        public float GetTotalExpenses(int userId, DateTime? startDate = null, DateTime? endDate = null);
        public ExpenseDTO AddExpense(int userId, ExpenseDTO expenseDTO);
        public bool UpdateExpense(int userId, ExpenseDTO expenseDTO);
        public bool RemoveExpense(int userId, int expenseId);
    }
}
