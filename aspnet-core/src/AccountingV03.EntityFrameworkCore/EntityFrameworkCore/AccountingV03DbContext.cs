using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using AccountingV03.Authorization.Roles;
using AccountingV03.Authorization.Users;
using AccountingV03.MultiTenancy;
using AccountingV03.AccountingEntities;

namespace AccountingV03.EntityFrameworkCore
{
    public class AccountingV03DbContext : AbpZeroDbContext<Tenant, Role, User, AccountingV03DbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Debt> Debts { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Summary> Summaries { get; set; }
        public DbSet<DailySummary> DailySummaries { get; set; }
        public DbSet<WeeklySummary> WeeklySummaries { get; set; }
        public DbSet<MonthlySummary> MonthlySummaries { get; set; }

        public AccountingV03DbContext(DbContextOptions<AccountingV03DbContext> options)
            : base(options)
        {
        }
    }
}
