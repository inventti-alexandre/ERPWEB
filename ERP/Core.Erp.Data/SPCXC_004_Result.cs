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
    
    public partial class SPCXC_004_Result
    {
        public long IdRow { get; set; }
        public int IdEmpresa { get; set; }
        public int IdSucursal { get; set; }
        public int IdBodega { get; set; }
        public decimal IdCbteVta { get; set; }
        public string vt_tipoDoc { get; set; }
        public string vt_NumFactura { get; set; }
        public string vt_Observacion { get; set; }
        public System.DateTime vt_fecha { get; set; }
        public Nullable<double> valor_doc { get; set; }
        public Nullable<double> valor { get; set; }
        public Nullable<double> Debito { get; set; }
        public double Credito { get; set; }
        public Nullable<double> saldo { get; set; }
        public decimal IdCliente { get; set; }
        public string pe_nombreCompleto { get; set; }
        public string Estado { get; set; }
        public string Tipo_cbte { get; set; }
        public int orden { get; set; }
        public string Tipo_cobro { get; set; }
        public string num_documento_cobro { get; set; }
        public Nullable<decimal> IdCobro { get; set; }
        public string Estado_documento { get; set; }
        public string cr_observacion { get; set; }
        public Nullable<int> IdContacto { get; set; }
        public string NomContacto { get; set; }
    }
}
