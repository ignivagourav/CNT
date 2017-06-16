//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CNT.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class FitterProfile
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FitterProfile()
        {
            this.Tyres = new HashSet<Tyre>();
            this.TyresRequests = new HashSet<TyresRequest>();
        }
    
        public int Id { get; set; }
        public int FitterID { get; set; }
        public string ProfileImage { get; set; }
        public string BusinessName { get; set; }
        public string Description { get; set; }
        public string PostCode { get; set; }
        public int Region_ID { get; set; }
        public string AverageRating { get; set; }
        public System.DateTime OpenFrom { get; set; }
        public System.DateTime OpenTo { get; set; }
        public Nullable<bool> IsCretedbyAdmin { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModiFiedDate { get; set; }
    
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tyre> Tyres { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TyresRequest> TyresRequests { get; set; }
    }
}
