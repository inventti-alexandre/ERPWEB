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
    
    public partial class in_ProductoTipo
    {
        public in_ProductoTipo()
        {
            this.in_Producto = new HashSet<in_Producto>();
            this.in_parametro = new HashSet<in_parametro>();
        }
    
        public int IdEmpresa { get; set; }
        public int IdProductoTipo { get; set; }
        public string tp_descripcion { get; set; }
        public string tp_EsCombo { get; set; }
        public string tp_ManejaInven { get; set; }
        public string Estado { get; set; }
        public string IdUsuario { get; set; }
        public Nullable<System.DateTime> Fecha_Transac { get; set; }
        public string IdUsuarioUltMod { get; set; }
        public Nullable<System.DateTime> Fecha_UltMod { get; set; }
        public string IdUsuarioUltAnu { get; set; }
        public Nullable<System.DateTime> Fecha_UltAnu { get; set; }
        public string MotivoAnulacion { get; set; }
        public bool Aparece_modu_Ventas { get; set; }
        public bool Aparece_modu_Compras { get; set; }
        public bool Aparece_modu_Inventario { get; set; }
        public bool Aparece_fabricacion { get; set; }
    
        public virtual ICollection<in_Producto> in_Producto { get; set; }
        public virtual ICollection<in_parametro> in_parametro { get; set; }
    }
}
