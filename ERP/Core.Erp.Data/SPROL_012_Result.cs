//------------------------------------------------------------------------------
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
    
    public partial class SPROL_012_Result
    {
        public int IdEmpresa { get; set; }
        public int IdTipoNomina { get; set; }
        public int IdDepartamento { get; set; }
        public decimal IdEmpleado { get; set; }
        public decimal IdPrestamo { get; set; }
        public string pe_cedulaRuc { get; set; }
        public string pe_apellido { get; set; }
        public string pe_nombre { get; set; }
        public string EstadoPago { get; set; }
        public string Descripcion { get; set; }
        public string de_descripcion { get; set; }
        public Nullable<double> Total_Prestamo { get; set; }
        public Nullable<double> Total_Cancelado { get; set; }
        public Nullable<double> Total_Pendiente_pago { get; set; }
        public string Observacion { get; set; }
    }
}
