//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.Erp.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class cp_conciliacion_Caja
    {
        public cp_conciliacion_Caja()
        {
            this.cp_conciliacion_Caja_det = new HashSet<cp_conciliacion_Caja_det>();
            this.cp_conciliacion_Caja_det_Ing_Caja = new HashSet<cp_conciliacion_Caja_det_Ing_Caja>();
            this.cp_conciliacion_Caja_det_x_ValeCaja = new HashSet<cp_conciliacion_Caja_det_x_ValeCaja>();
        }
    
        public int IdEmpresa { get; set; }
        public decimal IdConciliacion_Caja { get; set; }
        public int IdPeriodo { get; set; }
        public System.DateTime Fecha_ini { get; set; }
        public System.DateTime Fecha_fin { get; set; }
        public System.DateTime Fecha { get; set; }
        public int IdCaja { get; set; }
        public string IdEstadoCierre { get; set; }
        public string Observacion { get; set; }
        public Nullable<int> IdEmpresa_op { get; set; }
        public Nullable<decimal> IdOrdenPago_op { get; set; }
        public string IdCtaCble { get; set; }
        public double Saldo_cont_al_periodo { get; set; }
        public double Ingresos { get; set; }
        public double Total_Ing { get; set; }
        public double Total_fact_vale { get; set; }
        public double Total_fondo { get; set; }
        public double Dif_x_pagar_o_cobrar { get; set; }
        public Nullable<decimal> IdTipoFlujo { get; set; }
        public Nullable<int> IdEmpresa_mov_caj { get; set; }
        public Nullable<int> IdTipoCbte_mov_caj { get; set; }
        public Nullable<decimal> IdCbteCble_mov_caj { get; set; }
        public string IdUsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string IdUsuarioModificacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
    
        public virtual caj_Caja caj_Caja { get; set; }
        public virtual caj_Caja_Movimiento caj_Caja_Movimiento { get; set; }
        public virtual ICollection<cp_conciliacion_Caja_det> cp_conciliacion_Caja_det { get; set; }
        public virtual ICollection<cp_conciliacion_Caja_det_Ing_Caja> cp_conciliacion_Caja_det_Ing_Caja { get; set; }
        public virtual ICollection<cp_conciliacion_Caja_det_x_ValeCaja> cp_conciliacion_Caja_det_x_ValeCaja { get; set; }
    }
}
