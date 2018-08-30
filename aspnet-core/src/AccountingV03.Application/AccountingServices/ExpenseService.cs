using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using AccountingV03.AccountingEntities;
using AccountingV03.AccountingServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingV03.AccountingServices
{
    public class ExpenseService : ApplicationService, IExpenseService
    {
        private readonly IRepository<Expense> _repository;

        public ExpenseService(IRepository<Expense> repository)
        {
            _repository = repository;
        }

        public async Task<ListResultDto<Expense>> GetAll()
        {
            return new ListResultDto<Expense>(ObjectMapper.Map<List<Expense>>(
                await this._repository.GetAllListAsync()));
        }

        public async Task<ListResultDto<Expense>> GetExpenseFromSpecificTimePeriod(DateTime startDate, DateTime endDate)
        {
            return new ListResultDto<Expense>(ObjectMapper.Map<List<Expense>>((
                await this._repository.GetAllListAsync()).
                Where(e => e.CreationDate >= startDate && e.CreationDate <= endDate)));
        }

        public async Task<bool> Insert(Expense expense)
        {
            return await(this._repository.InsertAsync(expense)) != null;
        }
    }
}
