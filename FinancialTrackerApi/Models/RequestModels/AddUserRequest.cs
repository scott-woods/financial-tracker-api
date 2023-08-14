namespace FinancialTrackerApi.Models.RequestModels
{
    public class AddUserRequest
    {
        public string Auth0UserId { get; set; }
        public string Email { get; set; }
    }
}
