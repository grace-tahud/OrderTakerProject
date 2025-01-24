using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OrderTakerProject.Repository.Models.Entity
{
    public class BaseEntity:BaseModel
    {
       

        [IgnoreDataMember]
        public DateTime? DateCreated { get; set; } = DateTime.Now;

        [IgnoreDataMember]
        public string? CreatedBy { get; set; } = "OrderTakerUser";

        
    }
    public class BaseModel
    {
        public int Id { get; set; }
        public string UserId { get; set; } = "OrderTakerUser";

        [Timestamp]
        [IgnoreDataMember]
        public byte[] Timestamp { get; set; }
    }
}
