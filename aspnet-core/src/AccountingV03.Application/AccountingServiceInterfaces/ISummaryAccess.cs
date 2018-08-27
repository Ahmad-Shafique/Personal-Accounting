using Abp.Application.Services.Dto;
using AccountingV03.ApplicationServiceDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingV03.AccountingServiceInterfaces
{
    public interface ISummaryAccess
    {
        Task<SummaryDTO> GetAllTimeSummary();
        Task<SummaryDTO> Get365DaysSummary();
        Task<SummaryDTO> Get30DaysSummary();
        Task<SummaryDTO> Get7DaysSummary();
        Task<ListResultDto<SummaryDTO>> GetWeeklySummary();
        Task<ListResultDto<SummaryDTO>> GetMonthlySummary();
        Task<ListResultDto<SummaryDTO>> GetYearlySummary();
    }
}
