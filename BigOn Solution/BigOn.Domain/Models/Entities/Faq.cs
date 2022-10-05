using BigOn.Domain.AppCode.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace BigOn.Domain.Models.Entities
{
    public class Faq : BaseEntity
    {
        [Required]
        public string Question { get; set; }

        [Required]
        public string Answer { get; set; }
    }
}
