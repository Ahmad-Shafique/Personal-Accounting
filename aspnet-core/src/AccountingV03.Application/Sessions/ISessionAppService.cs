using System.Threading.Tasks;
using Abp.Application.Services;
using AccountingV03.Sessions.Dto;

namespace AccountingV03.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
