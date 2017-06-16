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
    
    public partial class TyresRequest
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TyresRequest()
        {
            this.FitterReviews = new HashSet<FitterReview>();
        }
    
        public int Id { get; set; }
        public int FitterProfileID { get; set; }
        public int RequestedBy { get; set; }
        public string RequestedUserName { get; set; }
        public string ModelName { get; set; }
        public string Description { get; set; }
        public bool IsView { get; set; }
        public bool IsApproved { get; set; }
        public System.DateTime CreatedDate { get; set; }
    
        public virtual FitterProfile FitterProfile { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FitterReview> FitterReviews { get; set; }
        public virtual User User { get; set; }
    }
}
