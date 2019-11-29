using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OrdersDisplay.Domain
{
    public class Order
    {
        [Key]
        public string PurchaseOrderId { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [MaxLength(100)]
        public string Sequence { get; set; }
        public int Quantity { get; set; }
        [MaxLength(100)]
        public string TapeType { get; set; }
        [MaxLength(100)]
        public string InternalOrderId { get; set; }
        [MaxLength(150)]
        public string Location { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }
        [MaxLength(100)]
        public string Tracking { get; set; }
        [MaxLength(150)]
        public string PointOfContact { get; set; }

        //public IEnumerable<Order> Orders { get; set; }

    }
}
