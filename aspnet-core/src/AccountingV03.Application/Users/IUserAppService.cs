using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AccountingV03.Roles.Dto;
using AccountingV03.Users.Dto;

namespace AccountingV03.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
