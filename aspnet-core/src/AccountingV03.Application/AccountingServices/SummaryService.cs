using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using AccountingV03.AccountingEntities;
using AccountingV03.AccountingServices.Daemon;
using AccountingV03.AccountingServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingV03.AccountingServices
{
    public class SummaryService : ApplicationService, ISummaryService
    {
        private readonly IRepository<DailySummary> _dailyRepository;
        private readonly IRepository<WeeklySummary> _weeklyRepository;
        private readonly IRepository<MonthlySummary> _monthlyRepository;
        private readonly IRepository<Income> _incomeRepository;
        private readonly IRepository<Expense> _expenseRepository;
        private readonly IRepository<Loan> _loanRepository;
        private readonly IRepository<Debt> _debtRepository;

        public SummaryService(IRepository<DailySummary> drepository, IRepository<WeeklySummary> wrepository,
            IRepository<MonthlySummary> mrepository, IRepository<Income> irepository,
            IRepository<Expense> erepository, IRepository<Loan> lrepository,
            IRepository<Debt> dbtrepository)
        {
            this._dailyRepository = drepository;
            this._weeklyRepository = wrepository;
            this._monthlyRepository = mrepository;
        }

        public async Task<Summary> GetAllTimeSummary()
        {
            Summary summary = new Summary();
            IEnumerable<MonthlySummary> monthlySummaries = await _monthlyRepository.GetAllListAsync();
            summary.Income = monthlySummaries.Sum(e => e.Income);
            summary.Expense = monthlySummaries.Sum(e => e.Expense);
            summary.Debt = monthlySummaries.Sum(e => e.Debt);
            summary.Loan = monthlySummaries.Sum(e => e.Loan);
            return summary;
        }

        public async Task<DailySummary> GetSummaryFor24Hours()
        {
            new GenerateDailyReport().GenerateOrUpdateTodaysReport();
            return await this._dailyRepository.FirstOrDefaultAsync(e => e.Date == DateTime.Now);
        }

        public async Task<MonthlySummary> GetSummaryFor30Days()
        {
            new GenerateMonthlyReport().GenerateOrUpdateThisMonthsReport();
            return await this._monthlyRepository.FirstOrDefaultAsync(e => e.StartDate.Month == DateTime.Now.Month && e.StartDate.Year==DateTime.Now.Year);
        }

        public async Task<WeeklySummary> GetSummaryFor7Days()
        {
            new GenerateWeeklyReport().GenerateOrUpdateThisWeeksReport();
            return await this._weeklyRepository.FirstOrDefaultAsync(e => (e.StartDate-DateTime.Now).TotalDays <= 7);
        }

        public async Task<ListResultDto<DailySummary>> GetSummaryOnDailyBasis()
        {
            return new ListResultDto<DailySummary>(ObjectMapper.Map<List<DailySummary>>(
                await this._dailyRepository.GetAllListAsync()));
        }

        public async Task<ListResultDto<MonthlySummary>> GetSummaryOnMonthlyBasis()
        {
            return new ListResultDto<MonthlySummary>(ObjectMapper.Map<List<MonthlySummary>>(
                await this._monthlyRepository.GetAllListAsync()));
        }

        public async Task<ListResultDto<WeeklySummary>> GetSummaryOnWeeklyBasis()
        {
            return new ListResultDto<WeeklySummary>(ObjectMapper.Map<List<WeeklySummary>>(
                await this._weeklyRepository.GetAllListAsync()));
        }
    }
}
