using FinancialTrackerApi.Models.DTOs;

namespace FinancialTrackerApi.Services.Interfaces
{
    public interface IRecurringIncomeService
    {
        public List<RecurringIncomeDTO> GetRecurringIncome(int userId);
        public float GetTotalRecurringIncome(int userId);
        public RecurringIncomeDTO AddRecurringIncome(int userId, RecurringIncomeDTO recurringIncome);
        public bool UpdateRecurringIncome(int userId, RecurringIncomeDTO recurringIncome);
        public bool RemoveRecurringIncome(int userId, int recurringIncomeId);
    }
}
