﻿using Abp.Domain.Entities;
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
    [Table("Debts")]
    public class Debt : FullAuditedEntity, IMustHaveTenant
    {
        public int TenantId { get; set; }
        public DateTime CreationDate { get; set; }
        [Required]
        public string Lender { get; set; }
        [Required]
        public double Amount { get; set; }
        public string Description { get; set; }
    }
}
