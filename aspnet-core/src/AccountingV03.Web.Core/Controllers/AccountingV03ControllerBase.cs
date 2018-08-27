using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace AccountingV03.Controllers
{
    public abstract class AccountingV03ControllerBase: AbpController
    {
        protected AccountingV03ControllerBase()
        {
            LocalizationSourceName = AccountingV03Consts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
