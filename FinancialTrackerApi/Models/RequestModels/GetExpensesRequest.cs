namespace FinancialTrackerApi.Models.RequestModels
{
    public class GetExpensesRequest
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
