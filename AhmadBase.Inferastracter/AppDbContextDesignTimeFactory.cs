using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AhmadBase.Inferastracter
{
    public class AppDbContextDesignTimeFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        const string SqliteDbConnection = "Data Source=EFCorePractice.db;Cache=Shared";
        const string SqlServerDbConnection = "data source =.; Initial Catalog = AhmadMessages; user id = sa; password = Aa123456;";

        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            //optionsBuilder.UseSqlite(args.Length > 0 ? args[0] : SqliteDbConnection, a => a.MigrationsAssembly(GetType().Assembly.FullName));
            optionsBuilder.UseSqlServer(args.Length > 0 ? args[0] : SqlServerDbConnection, a => a.MigrationsAssembly(GetType().Assembly.FullName));
            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
