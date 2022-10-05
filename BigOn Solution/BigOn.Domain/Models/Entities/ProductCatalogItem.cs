using BigOn.Domain.AppCode.Infrastructure;

namespace BigOn.Domain.Models.Entities
{
    public class ProductCatalogItem : BaseEntity
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int ProductTypeId { get; set; }
        public virtual ProductType ProductType { get; set; }

        public int ProductColorId { get; set; }
        public virtual ProductColor ProductColor { get; set; }

        public int ProductSizeId { get; set; }
        public virtual ProductSize ProductSize { get; set; }

        public int ProductMaterialId { get; set; }
        public virtual ProductMaterial ProductMaterial { get; set; }

    }
}
