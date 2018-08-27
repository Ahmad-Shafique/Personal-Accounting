using System.Threading.Tasks;
using Abp.Application.Services;
using AccountingV03.Authorization.Accounts.Dto;

namespace AccountingV03.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
