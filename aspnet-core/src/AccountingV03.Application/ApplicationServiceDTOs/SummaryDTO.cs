using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using AccountingV03.AccountingEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingV03.ApplicationServiceDTOs
{
    [AutoMapFrom(typeof(Summary))]
    public class SummaryDTO: FullAuditedEntityDto
    {
        public int TimePeriod { get; set; }
        public double Income { get; set; }
        public double Expense { get; set; }
        public double Loan { get; set; }
        public double Debt { get; set; }
        public double Balance { get; set; }
    }
}
