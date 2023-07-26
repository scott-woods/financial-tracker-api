using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancialTrackerApi.Migrations
{
    /// <inheritdoc />
    public partial class change_table_names : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asset_User_UserId",
                table: "Asset");

            migrationBuilder.DropForeignKey(
                name: "FK_Debt_User_UserId",
                table: "Debt");

            migrationBuilder.DropForeignKey(
                name: "FK_Expense_User_UserId",
                table: "Expense");

            migrationBuilder.DropForeignKey(
                name: "FK_Income_User_UserId",
                table: "Income");

            migrationBuilder.DropForeignKey(
                name: "FK_MonthlySavings_User_UserId",
                table: "MonthlySavings");

            migrationBuilder.DropForeignKey(
                name: "FK_NetWorthReport_NetWorthReport_PreviousReportId",
                table: "NetWorthReport");

            migrationBuilder.DropForeignKey(
                name: "FK_NetWorthReport_User_UserId",
                table: "NetWorthReport");

            migrationBuilder.DropForeignKey(
                name: "FK_RecurringExpense_User_UserId",
                table: "RecurringExpense");

            migrationBuilder.DropForeignKey(
                name: "FK_RecurringIncome_User_UserId",
                table: "RecurringIncome");

            migrationBuilder.DropForeignKey(
                name: "FK_RecurringInvestment_User_UserId",
                table: "RecurringInvestment");

            migrationBuilder.DropForeignKey(
                name: "FK_SavingsGoal_User_UserId",
                table: "SavingsGoal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SavingsGoal",
                table: "SavingsGoal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecurringInvestment",
                table: "RecurringInvestment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecurringIncome",
                table: "RecurringIncome");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecurringExpense",
                table: "RecurringExpense");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NetWorthReport",
                table: "NetWorthReport");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Income",
                table: "Income");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Expense",
                table: "Expense");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Debt",
                table: "Debt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Asset",
                table: "Asset");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "SavingsGoal",
                newName: "SavingsGoals");

            migrationBuilder.RenameTable(
                name: "RecurringInvestment",
                newName: "RecurringInvestments");

            migrationBuilder.RenameTable(
                name: "RecurringIncome",
                newName: "RecurringIncomes");

            migrationBuilder.RenameTable(
                name: "RecurringExpense",
                newName: "RecurringExpenses");

            migrationBuilder.RenameTable(
                name: "NetWorthReport",
                newName: "NetWorthReports");

            migrationBuilder.RenameTable(
                name: "Income",
                newName: "Incomes");

            migrationBuilder.RenameTable(
                name: "Expense",
                newName: "Expenses");

            migrationBuilder.RenameTable(
                name: "Debt",
                newName: "Debts");

            migrationBuilder.RenameTable(
                name: "Asset",
                newName: "Assets");

            migrationBuilder.RenameIndex(
                name: "IX_SavingsGoal_UserId",
                table: "SavingsGoals",
                newName: "IX_SavingsGoals_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RecurringInvestment_UserId",
                table: "RecurringInvestments",
                newName: "IX_RecurringInvestments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RecurringIncome_UserId",
                table: "RecurringIncomes",
                newName: "IX_RecurringIncomes_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RecurringExpense_UserId",
                table: "RecurringExpenses",
                newName: "IX_RecurringExpenses_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_NetWorthReport_UserId",
                table: "NetWorthReports",
                newName: "IX_NetWorthReports_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_NetWorthReport_PreviousReportId",
                table: "NetWorthReports",
                newName: "IX_NetWorthReports_PreviousReportId");

            migrationBuilder.RenameIndex(
                name: "IX_Income_UserId",
                table: "Incomes",
                newName: "IX_Incomes_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Expense_UserId",
                table: "Expenses",
                newName: "IX_Expenses_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Debt_UserId",
                table: "Debts",
                newName: "IX_Debts_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Asset_UserId",
                table: "Assets",
                newName: "IX_Assets_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SavingsGoals",
                table: "SavingsGoals",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecurringInvestments",
                table: "RecurringInvestments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecurringIncomes",
                table: "RecurringIncomes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecurringExpenses",
                table: "RecurringExpenses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NetWorthReports",
                table: "NetWorthReports",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Incomes",
                table: "Incomes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Expenses",
                table: "Expenses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Debts",
                table: "Debts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Assets",
                table: "Assets",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Users_UserId",
                table: "Assets",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Debts_Users_UserId",
                table: "Debts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Users_UserId",
                table: "Expenses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Incomes_Users_UserId",
                table: "Incomes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MonthlySavings_Users_UserId",
                table: "MonthlySavings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NetWorthReports_NetWorthReports_PreviousReportId",
                table: "NetWorthReports",
                column: "PreviousReportId",
                principalTable: "NetWorthReports",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NetWorthReports_Users_UserId",
                table: "NetWorthReports",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecurringExpenses_Users_UserId",
                table: "RecurringExpenses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecurringIncomes_Users_UserId",
                table: "RecurringIncomes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecurringInvestments_Users_UserId",
                table: "RecurringInvestments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SavingsGoals_Users_UserId",
                table: "SavingsGoals",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Users_UserId",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_Debts_Users_UserId",
                table: "Debts");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Users_UserId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Incomes_Users_UserId",
                table: "Incomes");

            migrationBuilder.DropForeignKey(
                name: "FK_MonthlySavings_Users_UserId",
                table: "MonthlySavings");

            migrationBuilder.DropForeignKey(
                name: "FK_NetWorthReports_NetWorthReports_PreviousReportId",
                table: "NetWorthReports");

            migrationBuilder.DropForeignKey(
                name: "FK_NetWorthReports_Users_UserId",
                table: "NetWorthReports");

            migrationBuilder.DropForeignKey(
                name: "FK_RecurringExpenses_Users_UserId",
                table: "RecurringExpenses");

            migrationBuilder.DropForeignKey(
                name: "FK_RecurringIncomes_Users_UserId",
                table: "RecurringIncomes");

            migrationBuilder.DropForeignKey(
                name: "FK_RecurringInvestments_Users_UserId",
                table: "RecurringInvestments");

            migrationBuilder.DropForeignKey(
                name: "FK_SavingsGoals_Users_UserId",
                table: "SavingsGoals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SavingsGoals",
                table: "SavingsGoals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecurringInvestments",
                table: "RecurringInvestments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecurringIncomes",
                table: "RecurringIncomes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecurringExpenses",
                table: "RecurringExpenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NetWorthReports",
                table: "NetWorthReports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Incomes",
                table: "Incomes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Expenses",
                table: "Expenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Debts",
                table: "Debts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Assets",
                table: "Assets");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "SavingsGoals",
                newName: "SavingsGoal");

            migrationBuilder.RenameTable(
                name: "RecurringInvestments",
                newName: "RecurringInvestment");

            migrationBuilder.RenameTable(
                name: "RecurringIncomes",
                newName: "RecurringIncome");

            migrationBuilder.RenameTable(
                name: "RecurringExpenses",
                newName: "RecurringExpense");

            migrationBuilder.RenameTable(
                name: "NetWorthReports",
                newName: "NetWorthReport");

            migrationBuilder.RenameTable(
                name: "Incomes",
                newName: "Income");

            migrationBuilder.RenameTable(
                name: "Expenses",
                newName: "Expense");

            migrationBuilder.RenameTable(
                name: "Debts",
                newName: "Debt");

            migrationBuilder.RenameTable(
                name: "Assets",
                newName: "Asset");

            migrationBuilder.RenameIndex(
                name: "IX_SavingsGoals_UserId",
                table: "SavingsGoal",
                newName: "IX_SavingsGoal_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RecurringInvestments_UserId",
                table: "RecurringInvestment",
                newName: "IX_RecurringInvestment_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RecurringIncomes_UserId",
                table: "RecurringIncome",
                newName: "IX_RecurringIncome_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RecurringExpenses_UserId",
                table: "RecurringExpense",
                newName: "IX_RecurringExpense_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_NetWorthReports_UserId",
                table: "NetWorthReport",
                newName: "IX_NetWorthReport_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_NetWorthReports_PreviousReportId",
                table: "NetWorthReport",
                newName: "IX_NetWorthReport_PreviousReportId");

            migrationBuilder.RenameIndex(
                name: "IX_Incomes_UserId",
                table: "Income",
                newName: "IX_Income_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Expenses_UserId",
                table: "Expense",
                newName: "IX_Expense_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Debts_UserId",
                table: "Debt",
                newName: "IX_Debt_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Assets_UserId",
                table: "Asset",
                newName: "IX_Asset_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SavingsGoal",
                table: "SavingsGoal",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecurringInvestment",
                table: "RecurringInvestment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecurringIncome",
                table: "RecurringIncome",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecurringExpense",
                table: "RecurringExpense",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NetWorthReport",
                table: "NetWorthReport",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Income",
                table: "Income",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Expense",
                table: "Expense",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Debt",
                table: "Debt",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Asset",
                table: "Asset",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_User_UserId",
                table: "Asset",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Debt_User_UserId",
                table: "Debt",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_User_UserId",
                table: "Expense",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Income_User_UserId",
                table: "Income",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MonthlySavings_User_UserId",
                table: "MonthlySavings",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NetWorthReport_NetWorthReport_PreviousReportId",
                table: "NetWorthReport",
                column: "PreviousReportId",
                principalTable: "NetWorthReport",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NetWorthReport_User_UserId",
                table: "NetWorthReport",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecurringExpense_User_UserId",
                table: "RecurringExpense",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecurringIncome_User_UserId",
                table: "RecurringIncome",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecurringInvestment_User_UserId",
                table: "RecurringInvestment",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SavingsGoal_User_UserId",
                table: "SavingsGoal",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
