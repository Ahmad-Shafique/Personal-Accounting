using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using AccountingV03.Configuration;
using AccountingV03.Web;

namespace AccountingV03.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class AccountingV03DbContextFactory : IDesignTimeDbContextFactory<AccountingV03DbContext>
    {
        public AccountingV03DbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AccountingV03DbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            AccountingV03DbContextConfigurer.Configure(builder, configuration.GetConnectionString(AccountingV03Consts.ConnectionStringName));

            return new AccountingV03DbContext(builder.Options);
        }
    }
}
