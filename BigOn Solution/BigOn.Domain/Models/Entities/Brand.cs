using BigOn.Domain.AppCode.Infrastructure;
using System.Collections;
using System.Collections.Generic;

namespace BigOn.Domain.Models.Entities
{
    public class Brand : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
