using ChatMesssage.Domain.Core.AggregatesModel.FeatureAggregate;
using ChatMesssage.Domain.Core.AggregatesModel.ProductAggregate;
using ChatMesssage.Domain.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatMesssage.Domain.Core.SeedWork;

namespace ChatMesssage.Infrastructure.Database.Context
{
    public class ChatMesssageContext : DbContext, IUnitOfWork
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Product> Products { get; set; }

        public ChatMesssageContext(DbContextOptions<ChatMesssageContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ChatMesssageContext).Assembly);
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            var result = await base.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
