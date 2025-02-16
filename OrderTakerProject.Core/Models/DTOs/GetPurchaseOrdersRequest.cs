﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTakerProject.Core.Models.DTOs
{
    public class GetPurchaseOrdersRequest
    {
    }
    public class GetPurchaseOrdersResponse:BaseResponse
    {
        public List<PurchaseOrderModel> PurchaseOrders { get; set; }
    }
    public class PurchaseOrderModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime DateOfDelivery { get; set; }
        public DateTime DateCreated { get; set; }
        public string Status { get; set; }
        public decimal AmountDue { get; set; }
        public bool IsActive { get; set; }
    }
}
