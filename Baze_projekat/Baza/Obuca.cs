//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Baza
{
    using System;
    using System.Collections.Generic;
    
    public partial class Obuca
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Obuca()
        {
            this.Pravis = new HashSet<Pravi>();
            this.Sastojis = new HashSet<Sastoji>();
        }
    
        public int IdOb { get; set; }
        public string NazOb { get; set; }
        public int BrOb { get; set; }
        public int CenaOb { get; set; }
        public int TipObuceIdTipOb { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pravi> Pravis { get; set; }
        public virtual TipObuce TipObuce { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sastoji> Sastojis { get; set; }
    }
}
