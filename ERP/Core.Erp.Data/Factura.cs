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
    
    public partial class Factura
    {
        public long cod_fact { get; set; }
        public int cod_evento { get; set; }
        public string nu_ced_ruc { get; set; }
        public string nu_ced_clte { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string direccion { get; set; }
        public string telef { get; set; }
        public Nullable<decimal> cant { get; set; }
        public Nullable<decimal> v_unit { get; set; }
        public Nullable<decimal> subtotal { get; set; }
        public Nullable<decimal> v_iva { get; set; }
        public Nullable<decimal> total { get; set; }
        public string tipo_pago { get; set; }
        public string observacion { get; set; }
        public Nullable<int> bd_est { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public string usuario { get; set; }
        public string lider { get; set; }
        public Nullable<int> co_tarjeta { get; set; }
        public Nullable<int> @ref { get; set; }
        public Nullable<int> lote { get; set; }
        public string recibos { get; set; }
        public string estado_aprobacion { get; set; }
        public Nullable<int> co_pago { get; set; }
        public Nullable<int> cod_lide { get; set; }
    }
}
