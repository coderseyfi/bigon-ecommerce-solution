using BigOn.Domain.AppCode.Infrastructure;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BigOn.Domain.Models.Entities
{
    public class Product : BaseEntity
    {
        public int Name { get; set; }
        public decimal Rate { get; set; }
        public decimal Price { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public int BrandId { get; set; }

        // [ForeignKey("BId")] // BrandId yerine diger ad istifade etdikde (mes: BId) istifade olunmalidir
        public virtual Brand Brand { get; set; }
        public virtual ICollection<ProductImages> Images { get; set; }
        public virtual ICollection<ProductCatalogItem> ProductCatalog { get; set; }
        
    }
}
