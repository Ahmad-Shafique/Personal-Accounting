﻿using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingV03.AccountingServiceInterfaces
{
    public interface IGetBackLoanedAmount: IApplicationService
    {
        Task<bool> GetBackLoanAmount(int LoanId);
    }
}
