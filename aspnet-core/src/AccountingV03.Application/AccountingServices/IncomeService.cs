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
    public class IncomeService : ApplicationService, IIncomeService
    {
        private readonly IRepository<Income> _repository;

        public IncomeService(IRepository<Income> repository)
        {
            _repository = repository;
        }

        public async Task<ListResultDto<Income>> GetAll()
        {
            return new ListResultDto<Income>(ObjectMapper.Map<List<Income>>(
                await this._repository.GetAllListAsync()));
        }

        public async Task<ListResultDto<Income>> GetIncomeFromSpecificTimePeriod(DateTime startDate, DateTime endDate)
        {
            return new ListResultDto<Income>(ObjectMapper.Map<List<Income>>((
                await this._repository.GetAllListAsync()).
                Where(e=>e.CreationDate>=startDate && e.CreationDate<=endDate)));
        }

        public async Task<bool> Insert(Income income)
        {
            return await (this._repository.InsertAsync(income)) != null;
        }
        
    }
}
