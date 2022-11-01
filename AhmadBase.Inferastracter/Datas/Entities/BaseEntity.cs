using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace AhmadBase.Inferastracter.Datas.Entities
{


    public interface IAggregateRoot
    {
    }

    public interface ITxRequest
    {
    }

    public abstract class EntityBase
    {
        public Guid Id { get; protected set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; protected set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; protected set; }
        public bool IsDeleted { get; set; } = false;
    }


    public abstract class BaseEntityTypeConfiguration<TBase> : IEntityTypeConfiguration<TBase> where TBase : EntityBase
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
}
