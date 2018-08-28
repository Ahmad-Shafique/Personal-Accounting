using Abp.Application.Services.Dto;
using AccountingV03.AccountingEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingV03.AccountingServices.Interfaces
{
    public interface ILoanService
    {
        Task<bool> Insert(Loan loan);
        Task<ListResultDto<Loan>> GetUnresolvedLoans();
        Task<bool> ResolveLoan(int LoanId);
    }
}
