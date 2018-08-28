using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingV03.AccountingEntities
{
    [Table("MonthlySummaries")]
    public class MonthlySummary : FullAuditedEntity, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public double Income { get; set; }
        public double Expense { get; set; }
        public double Debt { get; set; }
        public double Loan { get; set; }
        public double Balance { get; set; }

    }
}
