using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginApp.Models
{
    public class OrderItemsModel
    {
        public Int16 OrderItemID { get; set; }

        public int Quantity { get; set; }

        public virtual ItemModel Item { get; set; }
        public Int16 ItemID { get; set; }
        public virtual OrderModel Order { get; set; }
        public Int16 OrderID { get; set; }
    }
}
