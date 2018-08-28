using Abp.Application.Services.Dto;
using AccountingV03.AccountingEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingV03.AccountingServices.Interfaces
{
    public interface IDebtService
    {
        Task<bool> Insert(Debt debt);
        Task<ListResultDto<Debt>> GetUnresolvedDebts();
        Task<bool> ResolveDebt(int DebtId);
    }
}
