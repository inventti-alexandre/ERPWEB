﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.Erp.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;

    public partial class Entities_contabilidad : DbContext
    {
        public Entities_contabilidad()
            : base("name=Entities_contabilidad")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<ct_anio_fiscal> ct_anio_fiscal { get; set; }
        public DbSet<ct_anio_fiscal_x_cuenta_utilidad> ct_anio_fiscal_x_cuenta_utilidad { get; set; }
        public DbSet<ct_cbtecble_Reversado> ct_cbtecble_Reversado { get; set; }
        public DbSet<ct_cbtecble_tipo> ct_cbtecble_tipo { get; set; }
        public DbSet<ct_grupocble> ct_grupocble { get; set; }
        public DbSet<ct_periodo> ct_periodo { get; set; }
        public DbSet<ct_plancta_nivel> ct_plancta_nivel { get; set; }
        public DbSet<ct_punto_cargo> ct_punto_cargo { get; set; }
        public DbSet<ATS_compras> ATS_compras { get; set; }
        public DbSet<ATS_comprobantes_anulados> ATS_comprobantes_anulados { get; set; }
        public DbSet<ATS_exportaciones> ATS_exportaciones { get; set; }
        public DbSet<ATS_retenciones> ATS_retenciones { get; set; }
        public DbSet<ATS_ventas> ATS_ventas { get; set; }
        public DbSet<vwct_cbtecble_con_ctacble_acreedora> vwct_cbtecble_con_ctacble_acreedora { get; set; }
        public DbSet<ct_parametro> ct_parametro { get; set; }
        public DbSet<ct_plancta> ct_plancta { get; set; }
        public DbSet<ct_cbtecble_det> ct_cbtecble_det { get; set; }
        public DbSet<ct_cbtecble> ct_cbtecble { get; set; }
        public DbSet<vwct_cbtecble> vwct_cbtecble { get; set; }
        public DbSet<vwct_cbtecble_det> vwct_cbtecble_det { get; set; }
        public DbSet<vwct_RevisionContableFacturas> vwct_RevisionContableFacturas { get; set; }
        public DbSet<ct_CierrePorModuloPorSucursal> ct_CierrePorModuloPorSucursal { get; set; }
        public DbSet<vw_ct_CierrePorModuloPorSucursal> vw_ct_CierrePorModuloPorSucursal { get; set; }
    
        public virtual ObjectResult<generarATS_Result> generarATS(Nullable<int> idempresa, Nullable<int> idPeriodo)
        {
            var idempresaParameter = idempresa.HasValue ?
                new ObjectParameter("idempresa", idempresa) :
                new ObjectParameter("idempresa", typeof(int));
    
            var idPeriodoParameter = idPeriodo.HasValue ?
                new ObjectParameter("idPeriodo", idPeriodo) :
                new ObjectParameter("idPeriodo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<generarATS_Result>("generarATS", idempresaParameter, idPeriodoParameter);
        }
    }
}
