using FinancialTrackerApi.Models.DTOs;

namespace FinancialTrackerApi.Services.Interfaces
{
    public interface IRecurringInvestmentService
    {
        public List<RecurringInvestmentDTO> GetRecurringInvestments(int userId);
        public bool AddRecurringInvestment(int userId, RecurringInvestmentDTO recurringInvestmentDTO);
    }
}
