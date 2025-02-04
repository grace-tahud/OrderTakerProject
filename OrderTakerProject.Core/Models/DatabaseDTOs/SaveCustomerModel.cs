using OrderTakerProject.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTakerProject.Core.Models.DatabaseDTOs
{
    public class SaveCustomerModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string City { get; set; }
    }
    public class GetCustomerModel
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string MobileNumber { get; set; } = string.Empty;
        public string City { get; set; }
        public bool IsActive { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class UpdateCustomerModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string City { get; set; }
        public bool IsActive { get; set; }
    }
}
