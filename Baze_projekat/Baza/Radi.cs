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
    
    public partial class Radi
    {
        public int ProdavnicaIdObj { get; set; }
        public int ProdavnicaIndustrijaObuceIdIO { get; set; }
        public int ProdavacIdRad { get; set; }
    
        public virtual Prodavnica Prodavnica { get; set; }
        public virtual Prodavac Prodavac { get; set; }
    }
}
