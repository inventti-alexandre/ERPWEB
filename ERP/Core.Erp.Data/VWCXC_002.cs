//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class VWCXC_002
    {
        public int IdEmpresa { get; set; }
        public int IdSucursal { get; set; }
        public decimal IdCobro { get; set; }
        public int secuencial { get; set; }
        public string dc_TipoDocumento { get; set; }
        public Nullable<int> IdBodega_Cbte { get; set; }
        public decimal IdCbte_vta_nota { get; set; }
        public string tc_descripcion { get; set; }
        public double dc_ValorPago { get; set; }
        public string Su_Descripcion { get; set; }
        public string pe_nombreCompleto { get; set; }
        public System.DateTime cr_fecha { get; set; }
        public double cr_TotalCobro { get; set; }
        public string cr_observacion { get; set; }
        public string cr_NumDocumento { get; set; }
        public string vt_NumFactura { get; set; }
        public Nullable<System.DateTime> vt_fecha { get; set; }
        public Nullable<double> vt_Subtotal { get; set; }
        public Nullable<double> vt_iva { get; set; }
        public Nullable<double> vt_total { get; set; }
        public double PorcentajeRet { get; set; }
    }
}
