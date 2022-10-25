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
}