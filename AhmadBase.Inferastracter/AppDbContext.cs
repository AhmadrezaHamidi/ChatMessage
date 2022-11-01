using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhmadBase.Inferastracter.Datas.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AhmadBase.Inferastracter
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<ThreadEntity> Threads{ get; set; }
        public DbSet<ParticipantEntity> Participant { get; set; }
        public DbSet<MessageEntity> Message { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }



    }

    //public static class IdentityHelpers
    //{
    //    public static Task EnableIdentityInsert<T>(this DbContext context) =>
    //        SetIdentityInsert<T>(context, enable: true);

    //    public static Task DisableIdentityInsert<T>(this DbContext context) =>
    //        SetIdentityInsert<T>(context, enable: false);

    //    private static Task SetIdentityInsert<T>(DbContext context, bool enable)
    //    {
    //        var entityType = context.Model.FindEntityType(typeof(T));
    //        var value = enable ? "ON" : "OFF";
    //        return context.Database.ExecuteSqlRawAsync(
    //            $"SET IDENTITY_INSERT {entityType.GetSchema()}.{entityType.GetTableName()} {value}");
    //    }

    //    public static async Task SaveChangesWithIdentityInsertAsync<T>(this DbContext context)
    //    {
    //        using var transaction = context.Database.BeginTransaction();
    //        await context.EnableIdentityInsert<T>();
    //        await context.SaveChangesAsync();
    //        await context.DisableIdentityInsert<T>();
    //        await transaction.CommitAsync();
    //    }




}
