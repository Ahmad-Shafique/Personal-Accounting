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
    public class DebtService: ApplicationService, IDebtService
    {
        private readonly IRepository<Debt> _debtRepository;

        public DebtService(IRepository<Debt> debtRepository)
        {
            _debtRepository = debtRepository;
        }

        public async Task<ListResultDto<Debt>> GetUnresolvedDebts()
        {
            IEnumerable<Debt> result = await _debtRepository.GetAllListAsync();
            result = result.Where(e => e.IsDeleted == false);

            return new ListResultDto<Debt>(ObjectMapper.Map<List<Debt>>(result));
            //return new ListResultDto<DebtDto>(ObjectMapper.Map<List<DebtDto>>(result));


        }

        public async Task<bool> Insert(Debt debt)
        {
            return await (this._debtRepository.InsertAsync(debt))!=null;
        }

        public async Task<bool> ResolveDebt(int DebtId)
        {
            Debt debt = await this._debtRepository.GetAsync(DebtId);
            debt.IsDeleted = true;
            return await (this._debtRepository.UpdateAsync(debt))!=null;
        }
    }
}
