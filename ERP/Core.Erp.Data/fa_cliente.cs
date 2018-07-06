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
    
    public partial class fa_cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public fa_cliente()
        {
            this.fa_cliente_contactos = new HashSet<fa_cliente_contactos>();
            this.fa_cliente_x_fa_Vendedor_x_sucursal = new HashSet<fa_cliente_x_fa_Vendedor_x_sucursal>();
        }
    
        public int IdEmpresa { get; set; }
        public decimal IdCliente { get; set; }
        public string Codigo { get; set; }
        public decimal IdPersona { get; set; }
        public int Idtipo_cliente { get; set; }
        public string IdTipoCredito { get; set; }
        public int cl_plazo { get; set; }
        public string IdCtaCble_cxc { get; set; }
        public string IdCtaCble_Anti { get; set; }
        public double cl_Cupo { get; set; }
        public string IdUsuario { get; set; }
        public Nullable<System.DateTime> Fecha_Transac { get; set; }
        public string IdUsuarioUltMod { get; set; }
        public Nullable<System.DateTime> Fecha_UltMod { get; set; }
        public string IdUsuarioUltAnu { get; set; }
        public Nullable<System.DateTime> Fecha_UltAnu { get; set; }
        public string Estado { get; set; }
        public string IdCtaCble_cxc_Credito { get; set; }
        public Nullable<bool> es_empresa_relacionada { get; set; }
        public Nullable<int> NivelPrecio { get; set; }
        public string FormaPago { get; set; }
    
        public virtual fa_cliente_tipo fa_cliente_tipo { get; set; }
        public virtual fa_formaPago fa_formaPago { get; set; }
        public virtual fa_TerminoPago fa_TerminoPago { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<fa_cliente_contactos> fa_cliente_contactos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<fa_cliente_x_fa_Vendedor_x_sucursal> fa_cliente_x_fa_Vendedor_x_sucursal { get; set; }
    }
}
