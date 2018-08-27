using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using AccountingV03.Configuration.Dto;

namespace AccountingV03.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : AccountingV03AppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
