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
    
    public partial class SPFAC_005_Result
    {
        public int IdEmpresa { get; set; }
        public int IdSucursal { get; set; }
        public decimal IdCliente { get; set; }
        public Nullable<int> IdContacto { get; set; }
        public string NomCliente { get; set; }
        public string NomContacto { get; set; }
        public string TipoDocumento { get; set; }
        public Nullable<bool> EsExportacion { get; set; }
        public string Su_Descripcion { get; set; }
        public string Su_CodigoEstablecimiento { get; set; }
        public Nullable<double> SubtotalIVA0 { get; set; }
        public Nullable<double> SubtotalIVA { get; set; }
        public Nullable<double> vt_iva { get; set; }
        public Nullable<double> Total { get; set; }
        public Nullable<double> VRetenIVA { get; set; }
        public Nullable<double> VRetenFTE { get; set; }
        public Nullable<double> ValorACobrar { get; set; }
        public double VCobrado { get; set; }
        public double Saldo { get; set; }
        public int CantFactContacto { get; set; }
    }
}
