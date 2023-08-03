using FinancialTrackerApi.Models.DTOs;

namespace FinancialTrackerApi.Services.Interfaces
{
    public interface IRecurringInvestmentService
    {
        public List<RecurringInvestmentDTO> GetRecurringInvestments(int userId);
        public RecurringInvestmentDTO AddRecurringInvestment(int userId, RecurringInvestmentDTO recurringInvestmentDTO);
        public bool UpdateRecurringInvestment(int userId, RecurringInvestmentDTO recurringInvestment);
        public bool RemoveRecurringInvestment(int userId, int recurringInvestmentId);
    }
}
