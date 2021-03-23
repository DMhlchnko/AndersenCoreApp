using System;

namespace AndersenCoreApp.Models.Domain
{
    public class RelationCategory
    {
        public Guid RelationId { get; set; }
        public Guid CategoryId { get; set; }
        public virtual Relation Relation { get; set; }
        public virtual Category Category { get; set; }
    }
}
