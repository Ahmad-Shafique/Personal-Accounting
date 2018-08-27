using Abp.Domain.Repositories;
using AccountingV03.AccountingEntities;
using AccountingV03.AccountingServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingV03.AccountingServices
{
    public class PayOffDebtService : IPayOffDebt
    {
        private readonly IRepository<Debt> _debtRepository;

        public PayOffDebtService(IRepository<Debt> debtRepository)
        {
            _debtRepository = debtRepository;
        }



        public async Task<bool> PayOffDebt(int DebtId)
        {
            Debt debt;
            await _debtRepository.DeleteAsync(DebtId);
            try
            {
                debt = await _debtRepository.GetAsync(DebtId);

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                debt = null;
            }
            if (debt == null)
            {
                return true;
            }
            return false;
        }

    }
}
