using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginApp.Models
{
    public class ItemModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ItemModel()
        {
            this.OrderItems = new HashSet<OrderItemsModel>();
        }

        public Int16 ItemID { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> Price { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderItemsModel> OrderItems { get; set; }
    }
}
