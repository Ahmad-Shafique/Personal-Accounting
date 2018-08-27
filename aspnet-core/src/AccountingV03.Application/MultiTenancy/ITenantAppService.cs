using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AccountingV03.MultiTenancy.Dto;

namespace AccountingV03.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
