using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DefaultNamespace
{
     public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            this.SavingChanges += (s, e) => UpdateUtcs();
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<AuthorBiography> AuthorBiographies { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Category> Categories { get; set; }

        // public DbSet<Contract> Contracts { get; set; }

        public DbSet<MobileContract> MobileContracts { get; set; }

        public DbSet<BroadbandContract> BroadbandContracts { get; set; }

        public DbSet<TvContract> TvContracts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }

        private void UpdateUtcs()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).UpdatedUtc = DateTimeOffset.UtcNow;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreatedUtc = DateTimeOffset.UtcNow;
                }
            }
        }

        //public override int SaveChanges(bool acceptAllChangesOnSuccess)
        //{
        //    UpdateUtcs();
        //    return base.SaveChanges(acceptAllChangesOnSuccess);
        //}

        //public async override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        //{
        //    UpdateUtcs();
        //    return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        //}
    }

    public static class IdentityHelpers
    {
        public static Task EnableIdentityInsert<T>(this DbContext context) => SetIdentityInsert<T>(context, enable: true);
        public static Task DisableIdentityInsert<T>(this DbContext context) => SetIdentityInsert<T>(context, enable: false);

        private static Task SetIdentityInsert<T>(DbContext context, bool enable)
        {
            var entityType = context.Model.FindEntityType(typeof(T));
            var value = enable ? "ON" : "OFF";
            return context.Database.ExecuteSqlRawAsync(
                $"SET IDENTITY_INSERT {entityType.GetSchema()}.{entityType.GetTableName()} {value}");
        }

        public static async Task SaveChangesWithIdentityInsertAsync<T>(this DbContext context)
        {
            using var transaction = context.Database.BeginTransaction();
            await context.EnableIdentityInsert<T>();
            await context.SaveChangesAsync();
            await context.DisableIdentityInsert<T>();
            await transaction.CommitAsync();
        }
        
        
        
        
          public abstract class BaseEntityTypeConfiguration<TBase> : IEntityTypeConfiguration<TBase> where TBase : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TBase> entityTypeBuilder)
        {
            // Optimistic concurrency control
            // SQL Server uses a rowversion column.
            // Unfortunately, SQLite has no such feature. So we implement similar functionality using a trigger.
            //CREATE TRIGGER UpdateXXXXVersion
            //AFTER UPDATE ON XXXXX
            //BEGIN
            //    UPDATE XXXXX
            //    SET Version = Version + 1
            //    WHERE rowid = NEW.rowid;
            //END;
            entityTypeBuilder.Property<byte[]>("RowVersion").IsRowVersion();
        }
    }

    public class Author : BaseEntity
    {
        public long Id { get; set; }

        // [Required]
        public string FirstName { get; set; }

        // [Required]
        public string LastName { get; set; }

        // One to One/Zero
        // a Reference navigation property having a multiplicity of zero or one
        public Address Address { get; set; }

        // One to One/Zero
        // A one to one (or more usually a one to zero or one) relationship exists
        // when only one row of data in the principal table is linked to zero or one row in a dependent table.
        // Note:
        // - One reason for implementing this kind of relationship is when you are working with inheritance.
        // For example, you may have a Vehicle entity, with sub classes such as Car, Truck, Motorcycle etc.
        // - Other reasons include database design and/or efficiency.
        // For example, you may want to apply extra database security to the dependent table because it contains confidential information (an employee's health record, for example), or you just want to move data that isn't referenced very often into a separate table to improve search and retrieval times for data that is used all the time.
        public AuthorBiography Biography { get; set; }

        // One to Many
        // a Collection navigation property having a multiplicity of many
        public ICollection<Book> Books { get; set; } = new List<Book>();

        // [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
    }

    public class AuthorTypeConfiguration : BaseEntityTypeConfiguration<Author>
    {
        public override void Configure(EntityTypeBuilder<Author> entityTypeBuilder)
        {
            entityTypeBuilder.Property(b => b.FirstName).IsRequired();
            entityTypeBuilder.Property(b => b.LastName).IsRequired();
            entityTypeBuilder.Ignore(b => b.FullName);

            // Seeding data
            //entityTypeBuilder.HasData(new Author
            //{
            //    Id = 1,
            //    FirstName = "William",
            //    LastName = "Shakespeare"
            //});
            base.Configure(entityTypeBuilder);
        }
    }
}