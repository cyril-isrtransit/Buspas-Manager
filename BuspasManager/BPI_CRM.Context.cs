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
    
    public partial class BPI_CRMEntities : DbContext
    {
        public BPI_CRMEntities()
            : base("name=BPI_CRMEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Mobile_Logins_Audit> Mobile_Logins_Audit { get; set; }
        public virtual DbSet<User_Position> User_Position { get; set; }
        public virtual DbSet<Applications_Descriptors> Applications_Descriptors { get; set; }
        public virtual DbSet<Avaliable_Agencies> Avaliable_Agencies { get; set; }
        public virtual DbSet<Mobile_Apps_Config> Mobile_Apps_Config { get; set; }
        public virtual DbSet<User_Positions> User_Positions { get; set; }
        public virtual DbSet<User_Public_Transport_Favorites> User_Public_Transport_Favorites { get; set; }
    }
}
