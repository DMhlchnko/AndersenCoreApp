using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndersenCoreApp.Models.Domain
{
    [Table("RelationCategory")]
    public class RelationCategory
    {
        public Guid RelationId { get; set; }
        public Guid CategoryId { get; set; }
        public virtual Relation Relation { get; set; }
        public virtual Category Category { get; set; }
    }
}
