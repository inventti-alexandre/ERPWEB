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
    
    public partial class ro_archivos_bancos_generacion_x_empleado
    {
        public int IdEmpresa { get; set; }
        public decimal IdArchivo { get; set; }
        public int Secuencia { get; set; }
        public int IdSucursal { get; set; }
        public decimal IdEmpleado { get; set; }
        public double Valor { get; set; }
        public bool pagacheque { get; set; }
    
        public virtual ro_archivos_bancos_generacion ro_archivos_bancos_generacion { get; set; }
        public virtual ro_empleado ro_empleado { get; set; }
    }
}
