using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AccountingV03.AccountingEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingV03.AccountingServices.Interfaces
{
    public interface ISummaryService : IApplicationService
    {
        Task<Summary> GetAllTimeSummary();
        Task<ListResultDto<DailySummary>> GetSummaryOnDailyBasis();
        Task<ListResultDto<WeeklySummary>> GetSummaryOnWeeklyBasis();
        Task<ListResultDto<MonthlySummary>> GetSummaryOnMonthlyBasis();
        Task<DailySummary> GetSummaryFor24Hours();
        Task<WeeklySummary> GetSummaryFor7Days();
        Task<MonthlySummary> GetSummaryFor30Days();
    }
}
