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
    
    public partial class Pravi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pravi()
        {
            this.Prodajes = new HashSet<Prodaje>();
        }
    
        public int ObucarIdRad { get; set; }
        public int ObucaIdOb { get; set; }
    
        public virtual Obucar Obucar { get; set; }
        public virtual Obuca Obuca { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prodaje> Prodajes { get; set; }
    }
}
