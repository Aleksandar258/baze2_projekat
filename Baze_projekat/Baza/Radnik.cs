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
    
    public partial class Radnik
    {
        public int IdRad { get; set; }
        public string imeRad { get; set; }
        public string PrzRad { get; set; }
        public string PltRad { get; set; }
        public int IndustrijaObuceIdIO { get; set; }
    
        public virtual IndustrijaObuce IndustrijaObuce { get; set; }
    }
}