using System;

namespace BoxBack.Domain.Models
{
    public abstract class EntityAudit : Entity
    {
        public DateTimeOffset CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }
}
