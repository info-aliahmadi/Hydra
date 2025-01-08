using System;

namespace Hydra.Infrastructure.Data
{
    /// <summary>
    /// Represents the base class for entities
    /// </summary>
    public abstract class BaseEntity<PKType>
    {
        public PKType Id { get; set; }

    }
}