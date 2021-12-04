using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace QualificationTask.Models
{
    [Table("Address")]
    public partial class Address
    {
        public Address()
        {
            Users = new HashSet<User>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Country { get; set; }
        [Required]
        [StringLength(100)]
        public string City { get; set; }
        [Required]
        [StringLength(10)]
        public string PostCode { get; set; }
        [Required]
        [StringLength(100)]
        public string Street { get; set; }
        [Required]
        [StringLength(10)]
        public string HouseNumber { get; set; }
        [StringLength(10)]
        public string LocalNumber { get; set; }

        [InverseProperty(nameof(User.Address))]
        public virtual ICollection<User> Users { get; set; }
    }
}
