using AutoMapper;
using FinancialTrackerApi.Models.DatabaseModels;
using FinancialTrackerApi.Models.DTOs;

namespace FinancialTrackerApi.Mapping
{
    /// <summary>
    /// Mapping profile
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>()
                .ForMember(u => u.Auth0UserId, opt => opt.Ignore());

            CreateMap<Asset, AssetDTO>();
            CreateMap<AssetDTO, Asset>()
                .ForMember(a => a.User, opt => opt.Ignore());

            CreateMap<Debt, DebtDTO>();
            CreateMap<DebtDTO, Debt>()
                .ForMember(d => d.User, opt => opt.Ignore());

            CreateMap<Expense, ExpenseDTO>();
            CreateMap<ExpenseDTO, Expense>()
                .ForMember(e => e.User, opt => opt.Ignore());

            CreateMap<Income, IncomeDTO>();
            CreateMap<IncomeDTO, Income>()
                .ForMember(x => x.User, opt => opt.Ignore());

            CreateMap<MonthlySavings, MonthlySavingsDTO>();
            CreateMap<MonthlySavingsDTO, MonthlySavings>()
                .ForMember(x => x.User, opt => opt.Ignore());

            CreateMap<NetWorthReport, NetWorthReportDTO>();
            CreateMap<NetWorthReportDTO, NetWorthReport>()
                .ForMember(x => x.User, opt => opt.Ignore());

            CreateMap<RecurringExpense, RecurringExpenseDTO>();
            CreateMap<RecurringExpenseDTO, RecurringExpense>()
                .ForMember(x => x.User, opt => opt.Ignore());

            CreateMap<RecurringIncome, RecurringIncomeDTO>();
            CreateMap<RecurringIncomeDTO, RecurringIncome>()
                .ForMember(x => x.User, opt => opt.Ignore());

            CreateMap<RecurringInvestment, RecurringInvestmentDTO>();
            CreateMap<RecurringInvestmentDTO, RecurringInvestment>()
                .ForMember(x => x.User, opt => opt.Ignore());

            CreateMap<SavingsGoal, SavingsGoalDTO>();
            CreateMap<SavingsGoalDTO, SavingsGoal>()
                .ForMember(x => x.User, opt => opt.Ignore());
        }
    }
}
