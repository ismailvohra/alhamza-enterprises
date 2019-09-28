//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AlHamzaEnterprises.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            this.Invoices = new HashSet<Invoice>();
        }
    
        public int OrderID { get; set; }

        [DataType(DataType.Date)]
        public Nullable<System.DateTime> OrderDate { get; set; }

        [DataType(DataType.Date)]
        public System.DateTime RequiredDate { get; set; }

        [DataType(DataType.Date)]
        public Nullable<System.DateTime> ShippedDate { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<int> ProductID { get; set; }
        public int UserID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}