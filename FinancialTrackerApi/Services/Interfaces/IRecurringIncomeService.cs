using FinancialTrackerApi.Models.DTOs;

namespace FinancialTrackerApi.Services.Interfaces
{
    public interface IRecurringIncomeService
    {
        public List<RecurringIncomeDTO> GetRecurringIncome(int userId);
        public float GetTotalRecurringIncome(int userId);
        public bool AddRecurringIncome(int userId, RecurringIncomeDTO recurringIncome);
    }
}
