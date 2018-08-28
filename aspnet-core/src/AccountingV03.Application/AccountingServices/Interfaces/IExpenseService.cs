using Abp.Application.Services.Dto;
using AccountingV03.AccountingEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingV03.AccountingServices.Interfaces
{
    public interface IExpenseService
    {
        Task<bool> Insert(Expense expense);
        Task<ListResultDto<Expense>> GetAll();
        Task<ListResultDto<Expense>> GetExpenseFromSpecificTimePeriod(DateTime startDate, DateTime endDate);
    }
}
