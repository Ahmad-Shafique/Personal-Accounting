using System.Threading.Tasks;
using AccountingV03.Configuration.Dto;

namespace AccountingV03.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
