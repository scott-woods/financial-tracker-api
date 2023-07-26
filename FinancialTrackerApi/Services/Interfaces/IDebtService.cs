using FinancialTrackerApi.Models.DTOs;

namespace FinancialTrackerApi.Services.Interfaces
{
    public interface IDebtService
    {
        public List<DebtDTO> GetDebts(int userId);
        public bool UpdateDebtList(int userId, List<DebtDTO> debtDtos);
    }
}
