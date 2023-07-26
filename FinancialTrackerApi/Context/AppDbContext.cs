using FinancialTrackerApi.Models.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace FinancialTrackerApi.Context
{
    /// <summary>
    /// Db context
    /// </summary>
    public class AppDbContext : DbContext
    {
        #region MODELS

        public DbSet<User> Users { get; set; }
        public DbSet<RecurringExpense> RecurringExpenses { get; set; }
        public DbSet<RecurringIncome> RecurringIncomes { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Debt> Debts { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<MonthlySavings> MonthlySavings { get; set; }
        public DbSet<NetWorthReport> NetWorthReports { get; set; }
        public DbSet<RecurringInvestment> RecurringInvestments { get; set; }

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="options"></param>
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        /// <summary>
        /// Override model creation
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //configure entities
            modelBuilder.Entity<RecurringExpense>()
                .Property(e => e.Timeframe)
                .HasConversion<string>();
            modelBuilder.Entity<RecurringIncome>()
                .Property(e => e.Timeframe)
                .HasConversion<string>();
            modelBuilder.Entity<RecurringInvestment>()
                .Property(e => e.Timeframe)
                .HasConversion<string>();
        }
    }
}
