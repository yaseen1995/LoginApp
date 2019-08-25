using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LoginApp.Models
{
    public class OrderModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrderModel()
        {
            this.OrderItems = new HashSet<OrderItemsModel>();
        }

        public Int16 OrderID { get; set; }
        public string OrderNo { get; set; }
        public string PMethod { get; set; }
        public decimal GTotal { get; set; }

        public CustomerModel Customer { get; set; }
        public Int16 CustomerID { get; set; }

        [NotMapped]
        public string DeletedOrderItemIDs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderItemsModel> OrderItems { get; set; }

    }
}
