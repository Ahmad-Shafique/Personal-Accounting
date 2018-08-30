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
    public class LoanService : ApplicationService, ILoanService
    {
        private readonly IRepository<Loan> _loanRepository;

        public LoanService(IRepository<Loan> loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task<ListResultDto<Loan>> GetUnresolvedLoans()
        {
            IEnumerable<Loan> result = await this._loanRepository.GetAllListAsync();
            result = result.Where(e => e.IsDeleted == false);

            return new ListResultDto<Loan>(ObjectMapper.Map<List<Loan>>(result));
            //return new ListResultDto<DebtDto>(ObjectMapper.Map<List<DebtDto>>(result));


        }

        public async Task<bool> Insert(Loan loan)
        {
            return await (this._loanRepository.InsertAsync(loan)) != null;
        }

        public async Task<bool> ResolveLoan(int LoanId)
        {
            Loan loan = await this._loanRepository.GetAsync(LoanId);
            loan.IsDeleted = true;
            return await (this._loanRepository.UpdateAsync(loan)) != null;
        }
    }
}
