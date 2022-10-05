using BigOn.Domain.AppCode.Infrastructure;

namespace BigOn.Domain.Models.Entities
{
    public class ProductImages : BaseEntity

    {
        public string Name { get; set; }
        public bool IsMain { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
