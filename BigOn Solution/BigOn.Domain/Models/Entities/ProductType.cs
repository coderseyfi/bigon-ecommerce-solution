using BigOn.Domain.AppCode.Infrastructure;
using System.Collections.Generic;

namespace BigOn.Domain.Models.Entities
{
    public class ProductType : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<ProductCatalogItem> ProductCatalog { get; set; }
    }
}
