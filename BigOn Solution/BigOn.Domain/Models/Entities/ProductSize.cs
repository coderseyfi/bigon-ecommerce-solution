using BigOn.Domain.AppCode.Infrastructure;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BigOn.Domain.Models.Entities
{
    public class ProductSize : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        
        
        public string SmallName { get; set; }

        public virtual ICollection<ProductCatalogItem> ProductCatalog { get; set; }
    }
}
