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
    public class GetBackLoanedAmountService : IGetBackLoanedAmount
    {
        private readonly IRepository<Loan> _loanRepository;

        public GetBackLoanedAmountService(IRepository<Loan> loanRepository)
        {
            _loanRepository = loanRepository;
        }



        public async Task<bool> GetBackLoanAmount(int LoanId)
        {
            Loan loan;
            await _loanRepository.DeleteAsync(LoanId);
            try
            {
                loan = await _loanRepository.GetAsync(LoanId);

            }catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                loan = null;
            }
            if (loan == null)
            {
                return true;
            }
            return false;
        }
    }
}
