using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTakerProject.Repository.Models.Entity
{
    public class Customer:BaseEntity
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        public string FullName { get; set; }        
        [StringLength(10)]
        [Required]
        public string MobileNumber { get; set; }

        [Required]
        public string City { get; set; }

        public bool IsActive { get; set; } = true;
        //spublic virtual Customer Customer { get; set; }

    }
}
