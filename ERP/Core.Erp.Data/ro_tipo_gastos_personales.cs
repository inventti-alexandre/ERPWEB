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
    
    public partial class ro_tipo_gastos_personales
    {
        public ro_tipo_gastos_personales()
        {
            this.ro_empleado_proyeccion_gastos_det = new HashSet<ro_empleado_proyeccion_gastos_det>();
            this.ro_tipo_gastos_personales_tabla_valores_x_anio = new HashSet<ro_tipo_gastos_personales_tabla_valores_x_anio>();
        }
    
        public string IdTipoGasto { get; set; }
        public string nom_tipo_gasto { get; set; }
        public string estado { get; set; }
        public string IdUsuario { get; set; }
        public Nullable<System.DateTime> Fecha_Transac { get; set; }
        public string IdUsuarioUltMod { get; set; }
        public Nullable<System.DateTime> Fecha_UltMod { get; set; }
        public string IdUsuarioUltAnu { get; set; }
        public Nullable<System.DateTime> Fecha_UltAnu { get; set; }
        public string MotiAnula { get; set; }
    
        public virtual ICollection<ro_empleado_proyeccion_gastos_det> ro_empleado_proyeccion_gastos_det { get; set; }
        public virtual ICollection<ro_tipo_gastos_personales_tabla_valores_x_anio> ro_tipo_gastos_personales_tabla_valores_x_anio { get; set; }
    }
}
