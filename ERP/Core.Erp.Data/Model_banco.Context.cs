﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.Erp.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities_banco : DbContext
    {
        public Entities_banco()
            : base("name=Entities_banco")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ba_CatalogoTipo> ba_CatalogoTipo { get; set; }
        public virtual DbSet<ba_parametros> ba_parametros { get; set; }
        public virtual DbSet<ba_Banco_Cuenta> ba_Banco_Cuenta { get; set; }
        public virtual DbSet<ba_Catalogo> ba_Catalogo { get; set; }
        public virtual DbSet<ba_Caja_Movimiento_x_Cbte_Ban_x_Deposito> ba_Caja_Movimiento_x_Cbte_Ban_x_Deposito { get; set; }
        public virtual DbSet<ba_Cbte_Ban_tipo_x_ct_CbteCble_tipo> ba_Cbte_Ban_tipo_x_ct_CbteCble_tipo { get; set; }
        public virtual DbSet<ba_Talonario_cheques_x_banco> ba_Talonario_cheques_x_banco { get; set; }
        public virtual DbSet<ba_tipo_nota> ba_tipo_nota { get; set; }
        public virtual DbSet<ba_Cbte_Ban> ba_Cbte_Ban { get; set; }
        public virtual DbSet<vwba_Talonario_cheques_x_banco_ID> vwba_Talonario_cheques_x_banco_ID { get; set; }
    }
}
