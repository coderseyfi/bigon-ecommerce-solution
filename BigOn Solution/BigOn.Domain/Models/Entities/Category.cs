using BigOn.Domain.AppCode.Infrastructure;
using System.Collections.Generic;

namespace BigOn.Domain.Models.Entities
{
    public class Category : BaseEntity
    {
        public int? ParentId { get; set; }
        public virtual Category Parent { get; set; }

        public virtual ICollection<Category> Children { get; set; }
        public string Name { get; set; }

    }
}
