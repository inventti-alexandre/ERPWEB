//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class VWCXP_005_cancelaciones
    {
        public int IdEmpresa { get; set; }
        public decimal Idcancelacion { get; set; }
        public int Secuencia { get; set; }
        public Nullable<int> IdEmpresa_cxp { get; set; }
        public Nullable<int> IdTipoCbte_cxp { get; set; }
        public Nullable<decimal> IdCbteCble_cxp { get; set; }
        public string Referencia { get; set; }
        public string Observacion { get; set; }
        public double MontoAplicado { get; set; }
        public int IdEmpresa_conciliacion { get; set; }
        public decimal IdConciliacion { get; set; }
    }
}
