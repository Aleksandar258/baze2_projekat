﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ModelFirstDbContext : DbContext
    {
        public ModelFirstDbContext()
            : base("name=ModelFirstDbContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<IndustrijaObuce> IndustrijaObuces { get; set; }
        public virtual DbSet<Radnik> Radniks { get; set; }
        public virtual DbSet<Objekat> Objekats { get; set; }
        public virtual DbSet<Grad> Grads { get; set; }
        public virtual DbSet<Materijal> Materijals { get; set; }
        public virtual DbSet<Obuca> Obucas { get; set; }
        public virtual DbSet<Pravi> Pravis { get; set; }
        public virtual DbSet<TipObuce> TipObuces { get; set; }
        public virtual DbSet<Prodaje> Prodajes { get; set; }
        public virtual DbSet<Nalazi> Nalazis { get; set; }
        public virtual DbSet<Sastoji> Sastojis { get; set; }
        public virtual DbSet<Radi> Radis { get; set; }
    }
}
