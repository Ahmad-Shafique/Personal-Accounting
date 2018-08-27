using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AccountingV03.Authorization;

namespace AccountingV03
{
    [DependsOn(
        typeof(AccountingV03CoreModule), 
        typeof(AbpAutoMapperModule))]
    public class AccountingV03ApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<AccountingV03AuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(AccountingV03ApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
