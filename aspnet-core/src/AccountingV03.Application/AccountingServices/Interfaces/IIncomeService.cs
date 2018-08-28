using Abp.Application.Services.Dto;
using AccountingV03.AccountingEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingV03.AccountingServices.Interfaces
{
    public interface IIncomeService
    {
        Task<bool> Insert(Income income);
        Task<ListResultDto<Income>> GetAll();
        Task<ListResultDto<Income>> GetIncomeFromSpecificTimePeriod(DateTime startDate, DateTime endDate);
    }
}
