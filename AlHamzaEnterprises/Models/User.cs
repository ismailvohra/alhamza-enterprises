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
    
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.Attendances = new HashSet<Attendance>();
            this.EmployeeLeaves = new HashSet<EmployeeLeave>();
            this.Orders = new HashSet<Order>();
            this.Overtimes = new HashSet<Overtime>();
        }
    
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserType { get; set; }
        public string MobileNo { get; set; }
        public string Landline { get; set; }
        public string CompanyName { get; set; }
        public string SalesTax_ { get; set; }
        public string NTN_ { get; set; }
        public string Designation { get; set; }
        public Nullable<int> BasicSalary { get; set; }
        public Nullable<System.DateTime> HireDate { get; set; }
        public Nullable<bool> CurrentEmployee { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Attendance> Attendances { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeLeave> EmployeeLeaves { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Overtime> Overtimes { get; set; }
    }
}