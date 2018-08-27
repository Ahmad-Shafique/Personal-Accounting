using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using AccountingV03.AccountingEntities;
using AccountingV03.AccountingServiceInterfaces;
using AccountingV03.ApplicationServiceDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingV03.AccountingServices
{
    public class SummaryAccessService : ISummaryAccess
    {
        private readonly IQueryable<Income> incomes;
        private readonly IQueryable<Expense> expenses;
        private readonly IQueryable<Loan> loans;
        private readonly IQueryable<Debt> debts;


        public SummaryAccessService(IRepository<Income> incomeRepository, IRepository<Expense> expenseRepository,
                                    IRepository<Loan> loanRepository, IRepository<Debt> debtRepository)
        {
            incomes = incomeRepository.GetAll();
            expenses = expenseRepository.GetAll();
            loans = loanRepository.GetAll();
            debts = debtRepository.GetAll();
        }

        public async Task<SummaryDTO> GetSummaryForANumberOfDays(int numberOfDays)
        {
            IQueryable<Income> tincomes;
            IQueryable<Expense> texpenses;
            IQueryable<Loan> tloans;
            IQueryable<Debt> tdebts;
            double inc = 0, exp = 0, ln = 0, dt = 0;
            SummaryDTO summaryDTO;
            DateTime current = DateTime.Now;
            tincomes = incomes.Where(e => (e.LastModificationTime.Value - current).TotalDays <= numberOfDays);
            texpenses = expenses.Where(e => (e.LastModificationTime.Value - current).TotalDays <= numberOfDays);
            tloans = loans.Where(e => (e.LastModificationTime.Value - current).TotalDays <= numberOfDays);
            tdebts = debts.Where(e => (e.LastModificationTime.Value - current).TotalDays <= numberOfDays);
            inc = tincomes.Sum(e => e.Amount);
            exp = texpenses.Sum(e => e.Amount);
            ln = tloans.Sum(e => e.Amount);
            dt = tdebts.Sum(e => e.Amount);

            summaryDTO = new SummaryDTO();
            summaryDTO.Income = inc;
            summaryDTO.Expense = exp;
            summaryDTO.Loan = ln;
            summaryDTO.Debt = dt;

            summaryDTO.Balance = (inc - exp - dt);
            return summaryDTO;

        }

        public async Task<SummaryDTO> GetSummaryForACertainInterval(int interval)
        {
            IQueryable<Income> tincomes;
            IQueryable<Expense> texpenses;
            IQueryable<Loan> tloans;
            IQueryable<Debt> tdebts;
            double inc = 0, exp = 0, ln = 0, dt = 0;
            SummaryDTO summaryDTO;
            DateTime current = DateTime.Now;
            tincomes = incomes.Where(e => (e.LastModificationTime.Value - current).TotalDays <= numberOfDays);
            texpenses = expenses.Where(e => (e.LastModificationTime.Value - current).TotalDays <= numberOfDays);
            tloans = loans.Where(e => (e.LastModificationTime.Value - current).TotalDays <= numberOfDays);
            tdebts = debts.Where(e => (e.LastModificationTime.Value - current).TotalDays <= numberOfDays);
            inc = tincomes.Sum(e => e.Amount);
            exp = texpenses.Sum(e => e.Amount);
            ln = tloans.Sum(e => e.Amount);
            dt = tdebts.Sum(e => e.Amount);

            summaryDTO = new SummaryDTO();
            summaryDTO.Income = inc;
            summaryDTO.Expense = exp;
            summaryDTO.Loan = ln;
            summaryDTO.Debt = dt;

            summaryDTO.Balance = (inc - exp - dt);
            return summaryDTO;

        }


        public async Task<SummaryDTO> Get30DaysSummary()
        {
            return await GetSummaryForANumberOfDays(30);
        }

        public async Task<SummaryDTO> Get365DaysSummary()
        {
            return await GetSummaryForANumberOfDays(365);
        }

        public async Task<SummaryDTO> Get7DaysSummary()
        {
            return await GetSummaryForANumberOfDays(7);
        }

        public async Task<SummaryDTO> GetAllTimeSummary()
        {
            return await GetSummaryForANumberOfDays(999999);
        }

        public Task<ListResultDto<SummaryDTO>> GetMonthlySummary()
        {
            throw new NotImplementedException();
        }

        public Task<ListResultDto<SummaryDTO>> GetWeeklySummary()
        {
            throw new NotImplementedException();
        }

        public Task<ListResultDto<SummaryDTO>> GetYearlySummary()
        {
            throw new NotImplementedException();
        }
    }
}
