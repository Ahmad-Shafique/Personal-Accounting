using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AccountingV03.Configuration;

namespace AccountingV03.Web.Host.Startup
{
    [DependsOn(
       typeof(AccountingV03WebCoreModule))]
    public class AccountingV03WebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public AccountingV03WebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AccountingV03WebHostModule).GetAssembly());
        }
    }
}
