using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace AccountingV03.Localization
{
    public static class AccountingV03LocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(AccountingV03Consts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(AccountingV03LocalizationConfigurer).GetAssembly(),
                        "AccountingV03.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
