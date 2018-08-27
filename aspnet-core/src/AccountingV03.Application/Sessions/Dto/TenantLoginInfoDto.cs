using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using AccountingV03.MultiTenancy;

namespace AccountingV03.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
