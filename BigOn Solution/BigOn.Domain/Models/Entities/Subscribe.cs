using BigOn.Domain.AppCode.Infrastructure;
using System;
using System.ComponentModel.DataAnnotations;

namespace BigOn.Domain.Models.Entities
{
    public class Subscribe : BaseEntity
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public DateTime? ApprovedDate { get; set; }
        public bool IsApproved { get; set; } = false;

    }
}
