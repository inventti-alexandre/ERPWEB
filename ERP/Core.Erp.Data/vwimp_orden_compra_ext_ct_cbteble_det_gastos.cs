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
    
    public partial class vwimp_orden_compra_ext_ct_cbteble_det_gastos
    {
        public long IdRow { get; set; }
        public int IdEmpresa { get; set; }
        public decimal IdOrdenCompra_ext { get; set; }
        public int IdEmpresa_ct { get; set; }
        public int IdTipoCbte { get; set; }
        public decimal IdCbteCble { get; set; }
        public int secuencia_ct { get; set; }
        public string IdCtaCble { get; set; }
        public System.DateTime cb_Fecha { get; set; }
        public double dc_Valor { get; set; }
        public string cb_Observacion { get; set; }
        public Nullable<int> IdGasto_tipo { get; set; }
        public bool seleccionado { get; set; }
    }
}
