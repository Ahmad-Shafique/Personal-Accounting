using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace AccountingV03.EntityFrameworkCore
{
    public static class AccountingV03DbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<AccountingV03DbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<AccountingV03DbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
