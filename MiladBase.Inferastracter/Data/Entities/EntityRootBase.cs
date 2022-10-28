using System;
using System.Collections.Generic;

namespace MiladBass.Core.Domain
{
    public interface IAggregateRoot
    {
    }

    public interface ITxRequest
    {
    }

    public abstract class EntityBase
    {
        public Guid Id { get; protected init; } = Guid.NewGuid();
        public DateTime CreatedAt { get; protected init; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; protected set; }
        public bool IsDeleted { get;  set; } = false;
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