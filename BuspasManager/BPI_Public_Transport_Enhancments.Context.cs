﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BuspasManager
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BPI_Public_Transport_EnhancmentsEntities : DbContext
    {
        public BPI_Public_Transport_EnhancmentsEntities()
            : base("name=BPI_Public_Transport_EnhancmentsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Questionnaires> Questionnaires { get; set; }
        public virtual DbSet<Questionnaries_Items> Questionnaries_Items { get; set; }
    }
}
