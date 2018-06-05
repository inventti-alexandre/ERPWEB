﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.Erp.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Entities_reportes : DbContext
    {
        public Entities_reportes()
            : base("name=Entities_reportes")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<VWACTF_001> VWACTF_001 { get; set; }
        public virtual DbSet<VWACTF_002> VWACTF_002 { get; set; }
        public virtual DbSet<VWACTF_003> VWACTF_003 { get; set; }
        public virtual DbSet<VWCAJ_001> VWCAJ_001 { get; set; }
        public virtual DbSet<VWCONTA_001> VWCONTA_001 { get; set; }
        public virtual DbSet<VWINV_001> VWINV_001 { get; set; }
        public virtual DbSet<VWINV_002> VWINV_002 { get; set; }
        public virtual DbSet<VWINV_004> VWINV_004 { get; set; }
    
        public virtual ObjectResult<SPINV_001_Result> SPINV_001(Nullable<int> idEmpresa, Nullable<int> idSucursal_ini, Nullable<int> idSucursal_fin, Nullable<int> idBodega_ini, Nullable<int> idBodega_fin, Nullable<decimal> idProducto_ini, Nullable<decimal> idProducto_fin, string idCategoria, Nullable<int> idLinea, Nullable<int> idGrupo, Nullable<int> idSubGrupo, Nullable<System.DateTime> fecha_corte, Nullable<bool> mostrar_stock_0)
        {
            var idEmpresaParameter = idEmpresa.HasValue ?
                new ObjectParameter("IdEmpresa", idEmpresa) :
                new ObjectParameter("IdEmpresa", typeof(int));
    
            var idSucursal_iniParameter = idSucursal_ini.HasValue ?
                new ObjectParameter("IdSucursal_ini", idSucursal_ini) :
                new ObjectParameter("IdSucursal_ini", typeof(int));
    
            var idSucursal_finParameter = idSucursal_fin.HasValue ?
                new ObjectParameter("IdSucursal_fin", idSucursal_fin) :
                new ObjectParameter("IdSucursal_fin", typeof(int));
    
            var idBodega_iniParameter = idBodega_ini.HasValue ?
                new ObjectParameter("IdBodega_ini", idBodega_ini) :
                new ObjectParameter("IdBodega_ini", typeof(int));
    
            var idBodega_finParameter = idBodega_fin.HasValue ?
                new ObjectParameter("IdBodega_fin", idBodega_fin) :
                new ObjectParameter("IdBodega_fin", typeof(int));
    
            var idProducto_iniParameter = idProducto_ini.HasValue ?
                new ObjectParameter("IdProducto_ini", idProducto_ini) :
                new ObjectParameter("IdProducto_ini", typeof(decimal));
    
            var idProducto_finParameter = idProducto_fin.HasValue ?
                new ObjectParameter("IdProducto_fin", idProducto_fin) :
                new ObjectParameter("IdProducto_fin", typeof(decimal));
    
            var idCategoriaParameter = idCategoria != null ?
                new ObjectParameter("IdCategoria", idCategoria) :
                new ObjectParameter("IdCategoria", typeof(string));
    
            var idLineaParameter = idLinea.HasValue ?
                new ObjectParameter("IdLinea", idLinea) :
                new ObjectParameter("IdLinea", typeof(int));
    
            var idGrupoParameter = idGrupo.HasValue ?
                new ObjectParameter("IdGrupo", idGrupo) :
                new ObjectParameter("IdGrupo", typeof(int));
    
            var idSubGrupoParameter = idSubGrupo.HasValue ?
                new ObjectParameter("IdSubGrupo", idSubGrupo) :
                new ObjectParameter("IdSubGrupo", typeof(int));
    
            var fecha_corteParameter = fecha_corte.HasValue ?
                new ObjectParameter("fecha_corte", fecha_corte) :
                new ObjectParameter("fecha_corte", typeof(System.DateTime));
    
            var mostrar_stock_0Parameter = mostrar_stock_0.HasValue ?
                new ObjectParameter("mostrar_stock_0", mostrar_stock_0) :
                new ObjectParameter("mostrar_stock_0", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SPINV_001_Result>("SPINV_001", idEmpresaParameter, idSucursal_iniParameter, idSucursal_finParameter, idBodega_iniParameter, idBodega_finParameter, idProducto_iniParameter, idProducto_finParameter, idCategoriaParameter, idLineaParameter, idGrupoParameter, idSubGrupoParameter, fecha_corteParameter, mostrar_stock_0Parameter);
        }
    
        public virtual int SPROL_002(Nullable<int> idempresa, Nullable<int> idnomina_tipo, Nullable<int> idnomina_Tipo_liq, Nullable<int> idperiodo)
        {
            var idempresaParameter = idempresa.HasValue ?
                new ObjectParameter("idempresa", idempresa) :
                new ObjectParameter("idempresa", typeof(int));
    
            var idnomina_tipoParameter = idnomina_tipo.HasValue ?
                new ObjectParameter("idnomina_tipo", idnomina_tipo) :
                new ObjectParameter("idnomina_tipo", typeof(int));
    
            var idnomina_Tipo_liqParameter = idnomina_Tipo_liq.HasValue ?
                new ObjectParameter("idnomina_Tipo_liq", idnomina_Tipo_liq) :
                new ObjectParameter("idnomina_Tipo_liq", typeof(int));
    
            var idperiodoParameter = idperiodo.HasValue ?
                new ObjectParameter("idperiodo", idperiodo) :
                new ObjectParameter("idperiodo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SPROL_002", idempresaParameter, idnomina_tipoParameter, idnomina_Tipo_liqParameter, idperiodoParameter);
        }
    
        public virtual ObjectResult<SPACTF_004_detalle_Result> SPACTF_004_detalle(Nullable<int> idEmpresa, Nullable<System.DateTime> fecha_corte, string idUsuario, Nullable<int> idActivoFijoTipo_ini, Nullable<int> idActivoFijoTipo_fin, Nullable<int> idCategoria_ini, Nullable<int> idCategoria_fin, string estado_Proceso)
        {
            var idEmpresaParameter = idEmpresa.HasValue ?
                new ObjectParameter("IdEmpresa", idEmpresa) :
                new ObjectParameter("IdEmpresa", typeof(int));
    
            var fecha_corteParameter = fecha_corte.HasValue ?
                new ObjectParameter("Fecha_corte", fecha_corte) :
                new ObjectParameter("Fecha_corte", typeof(System.DateTime));
    
            var idUsuarioParameter = idUsuario != null ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(string));
    
            var idActivoFijoTipo_iniParameter = idActivoFijoTipo_ini.HasValue ?
                new ObjectParameter("IdActivoFijoTipo_ini", idActivoFijoTipo_ini) :
                new ObjectParameter("IdActivoFijoTipo_ini", typeof(int));
    
            var idActivoFijoTipo_finParameter = idActivoFijoTipo_fin.HasValue ?
                new ObjectParameter("IdActivoFijoTipo_fin", idActivoFijoTipo_fin) :
                new ObjectParameter("IdActivoFijoTipo_fin", typeof(int));
    
            var idCategoria_iniParameter = idCategoria_ini.HasValue ?
                new ObjectParameter("IdCategoria_ini", idCategoria_ini) :
                new ObjectParameter("IdCategoria_ini", typeof(int));
    
            var idCategoria_finParameter = idCategoria_fin.HasValue ?
                new ObjectParameter("IdCategoria_fin", idCategoria_fin) :
                new ObjectParameter("IdCategoria_fin", typeof(int));
    
            var estado_ProcesoParameter = estado_Proceso != null ?
                new ObjectParameter("Estado_Proceso", estado_Proceso) :
                new ObjectParameter("Estado_Proceso", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SPACTF_004_detalle_Result>("SPACTF_004_detalle", idEmpresaParameter, fecha_corteParameter, idUsuarioParameter, idActivoFijoTipo_iniParameter, idActivoFijoTipo_finParameter, idCategoria_iniParameter, idCategoria_finParameter, estado_ProcesoParameter);
        }
    
        public virtual ObjectResult<SPACTF_004_resumen_Result> SPACTF_004_resumen(Nullable<int> idEmpresa, Nullable<System.DateTime> fecha_corte, string idUsuario, Nullable<int> idActivoFijoTipo_ini, Nullable<int> idActivoFijoTipo_fin, Nullable<int> idCategoria_ini, Nullable<int> idCategoria_fin, string estado_Proceso)
        {
            var idEmpresaParameter = idEmpresa.HasValue ?
                new ObjectParameter("IdEmpresa", idEmpresa) :
                new ObjectParameter("IdEmpresa", typeof(int));
    
            var fecha_corteParameter = fecha_corte.HasValue ?
                new ObjectParameter("Fecha_corte", fecha_corte) :
                new ObjectParameter("Fecha_corte", typeof(System.DateTime));
    
            var idUsuarioParameter = idUsuario != null ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(string));
    
            var idActivoFijoTipo_iniParameter = idActivoFijoTipo_ini.HasValue ?
                new ObjectParameter("IdActivoFijoTipo_ini", idActivoFijoTipo_ini) :
                new ObjectParameter("IdActivoFijoTipo_ini", typeof(int));
    
            var idActivoFijoTipo_finParameter = idActivoFijoTipo_fin.HasValue ?
                new ObjectParameter("IdActivoFijoTipo_fin", idActivoFijoTipo_fin) :
                new ObjectParameter("IdActivoFijoTipo_fin", typeof(int));
    
            var idCategoria_iniParameter = idCategoria_ini.HasValue ?
                new ObjectParameter("IdCategoria_ini", idCategoria_ini) :
                new ObjectParameter("IdCategoria_ini", typeof(int));
    
            var idCategoria_finParameter = idCategoria_fin.HasValue ?
                new ObjectParameter("IdCategoria_fin", idCategoria_fin) :
                new ObjectParameter("IdCategoria_fin", typeof(int));
    
            var estado_ProcesoParameter = estado_Proceso != null ?
                new ObjectParameter("Estado_Proceso", estado_Proceso) :
                new ObjectParameter("Estado_Proceso", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SPACTF_004_resumen_Result>("SPACTF_004_resumen", idEmpresaParameter, fecha_corteParameter, idUsuarioParameter, idActivoFijoTipo_iniParameter, idActivoFijoTipo_finParameter, idCategoria_iniParameter, idCategoria_finParameter, estado_ProcesoParameter);
        }
    
        public virtual ObjectResult<SPACTF_005_Result> SPACTF_005(Nullable<int> idEmpresa, Nullable<int> idActivoFijoTipo_ini, Nullable<int> idActivoFijoTipo_fin, Nullable<int> idCategoriaAF_ini, Nullable<int> idCategoriaAF_fin, Nullable<System.DateTime> fecha_corte, string estado_proceso)
        {
            var idEmpresaParameter = idEmpresa.HasValue ?
                new ObjectParameter("IdEmpresa", idEmpresa) :
                new ObjectParameter("IdEmpresa", typeof(int));
    
            var idActivoFijoTipo_iniParameter = idActivoFijoTipo_ini.HasValue ?
                new ObjectParameter("IdActivoFijoTipo_ini", idActivoFijoTipo_ini) :
                new ObjectParameter("IdActivoFijoTipo_ini", typeof(int));
    
            var idActivoFijoTipo_finParameter = idActivoFijoTipo_fin.HasValue ?
                new ObjectParameter("IdActivoFijoTipo_fin", idActivoFijoTipo_fin) :
                new ObjectParameter("IdActivoFijoTipo_fin", typeof(int));
    
            var idCategoriaAF_iniParameter = idCategoriaAF_ini.HasValue ?
                new ObjectParameter("IdCategoriaAF_ini", idCategoriaAF_ini) :
                new ObjectParameter("IdCategoriaAF_ini", typeof(int));
    
            var idCategoriaAF_finParameter = idCategoriaAF_fin.HasValue ?
                new ObjectParameter("IdCategoriaAF_fin", idCategoriaAF_fin) :
                new ObjectParameter("IdCategoriaAF_fin", typeof(int));
    
            var fecha_corteParameter = fecha_corte.HasValue ?
                new ObjectParameter("Fecha_corte", fecha_corte) :
                new ObjectParameter("Fecha_corte", typeof(System.DateTime));
    
            var estado_procesoParameter = estado_proceso != null ?
                new ObjectParameter("Estado_proceso", estado_proceso) :
                new ObjectParameter("Estado_proceso", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SPACTF_005_Result>("SPACTF_005", idEmpresaParameter, idActivoFijoTipo_iniParameter, idActivoFijoTipo_finParameter, idCategoriaAF_iniParameter, idCategoriaAF_finParameter, fecha_corteParameter, estado_procesoParameter);
        }
    
        public virtual ObjectResult<SPINV_003_Result> SPINV_003(Nullable<int> idEmpresa, Nullable<int> idSucursal_ini, Nullable<int> idSucursal_fin, Nullable<int> idBodega_ini, Nullable<int> idBodega_fin, Nullable<decimal> idProducto_ini, Nullable<decimal> idProducto_fin, string idCategoria, Nullable<int> idLinea, Nullable<int> idGrupo, Nullable<int> idSubGrupo, Nullable<System.DateTime> fecha_corte, Nullable<bool> mostrar_stock_0)
        {
            var idEmpresaParameter = idEmpresa.HasValue ?
                new ObjectParameter("IdEmpresa", idEmpresa) :
                new ObjectParameter("IdEmpresa", typeof(int));
    
            var idSucursal_iniParameter = idSucursal_ini.HasValue ?
                new ObjectParameter("IdSucursal_ini", idSucursal_ini) :
                new ObjectParameter("IdSucursal_ini", typeof(int));
    
            var idSucursal_finParameter = idSucursal_fin.HasValue ?
                new ObjectParameter("IdSucursal_fin", idSucursal_fin) :
                new ObjectParameter("IdSucursal_fin", typeof(int));
    
            var idBodega_iniParameter = idBodega_ini.HasValue ?
                new ObjectParameter("IdBodega_ini", idBodega_ini) :
                new ObjectParameter("IdBodega_ini", typeof(int));
    
            var idBodega_finParameter = idBodega_fin.HasValue ?
                new ObjectParameter("IdBodega_fin", idBodega_fin) :
                new ObjectParameter("IdBodega_fin", typeof(int));
    
            var idProducto_iniParameter = idProducto_ini.HasValue ?
                new ObjectParameter("IdProducto_ini", idProducto_ini) :
                new ObjectParameter("IdProducto_ini", typeof(decimal));
    
            var idProducto_finParameter = idProducto_fin.HasValue ?
                new ObjectParameter("IdProducto_fin", idProducto_fin) :
                new ObjectParameter("IdProducto_fin", typeof(decimal));
    
            var idCategoriaParameter = idCategoria != null ?
                new ObjectParameter("IdCategoria", idCategoria) :
                new ObjectParameter("IdCategoria", typeof(string));
    
            var idLineaParameter = idLinea.HasValue ?
                new ObjectParameter("IdLinea", idLinea) :
                new ObjectParameter("IdLinea", typeof(int));
    
            var idGrupoParameter = idGrupo.HasValue ?
                new ObjectParameter("IdGrupo", idGrupo) :
                new ObjectParameter("IdGrupo", typeof(int));
    
            var idSubGrupoParameter = idSubGrupo.HasValue ?
                new ObjectParameter("IdSubGrupo", idSubGrupo) :
                new ObjectParameter("IdSubGrupo", typeof(int));
    
            var fecha_corteParameter = fecha_corte.HasValue ?
                new ObjectParameter("fecha_corte", fecha_corte) :
                new ObjectParameter("fecha_corte", typeof(System.DateTime));
    
            var mostrar_stock_0Parameter = mostrar_stock_0.HasValue ?
                new ObjectParameter("mostrar_stock_0", mostrar_stock_0) :
                new ObjectParameter("mostrar_stock_0", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SPINV_003_Result>("SPINV_003", idEmpresaParameter, idSucursal_iniParameter, idSucursal_finParameter, idBodega_iniParameter, idBodega_finParameter, idProducto_iniParameter, idProducto_finParameter, idCategoriaParameter, idLineaParameter, idGrupoParameter, idSubGrupoParameter, fecha_corteParameter, mostrar_stock_0Parameter);
        }
    }
}
