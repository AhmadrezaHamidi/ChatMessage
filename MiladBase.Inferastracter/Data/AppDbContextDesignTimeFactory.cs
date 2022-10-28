namespace DefaultNamespace
{
    public class AppDbContextDesignTimeFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        const string SqliteDbConnection = "Data Source=EFCorePractice.db;Cache=Shared";
        const string SqlServerDbConnection = "Server=(localdb)\\MSSQLLocalDB;Database=EFCorePractice;Trusted_Connection=True;MultipleActiveResultSets=true;ConnectRetryCount=0";

        /// <summary>
        /// Supply the connection string as the first arg:
        ///  
        /// A basic connection string with a shared cache for improved concurrency.
        /// - Data Source=Application.db;Cache=Shared
        /// 
        /// An encrypted database.
        /// - Data Source=Application.db;Password=MyEncryptionKey
        /// 
        /// A read-only database that cannot be modified by the app.
        /// - Data Source=Reference.db;Mode=ReadOnly
        /// 
        /// A private, in-memory database.
        /// - Data Source=:memory:
        /// 
        /// A sharable, in-memory database identified by the name Sharable.
        /// - Data Source=Sharable;Mode=Memory;Cache=Shared
        /// 
        /// The -- token directs dotnet ef to treat everything that follows as an argument and not try to parse them as options. 
        /// Any extra arguments not used by dotnet ef are forwarded to the app.
        /// 
        ///  PM> dotnet ef migrations add InitialCreate -- "Data Source=Application.db;Cache=Shared"
        ///  PM> dotnet ef database update -- "Data Source=Application.db;Cache=Shared"
        ///  
        /// </summary>
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            //optionsBuilder.UseSqlite(args.Length > 0 ? args[0] : SqliteDbConnection, a => a.MigrationsAssembly(GetType().Assembly.FullName));
            optionsBuilder.UseSqlServer(args.Length > 0 ? args[0] : SqlServerDbConnection, a => a.MigrationsAssembly(GetType().Assembly.FullName));
            return new AppDbContext(optionsBuilder.Options);
        }
    }

}