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
    
    public partial class cxc_MotivoLiquidacionTarjeta
    {
        public cxc_MotivoLiquidacionTarjeta()
        {
            this.cxc_MotivoLiquidacionTarjeta_x_tb_sucursal = new HashSet<cxc_MotivoLiquidacionTarjeta_x_tb_sucursal>();
            this.cxc_LiquidacionTarjetaDet = new HashSet<cxc_LiquidacionTarjetaDet>();
        }
    
        public int IdEmpresa { get; set; }
        public decimal IdMotivo { get; set; }
        public string Descripcion { get; set; }
        public bool ESRetenIVA { get; set; }
        public bool ESRetenFTE { get; set; }
        public double Porcentaje { get; set; }
        public bool Estado { get; set; }
        public string IdUsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string IdUsuarioModificacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public string IdUsuarioAnulacion { get; set; }
        public Nullable<System.DateTime> FechaAnulacion { get; set; }
        public string MotivoAnulacion { get; set; }
    
        public virtual ICollection<cxc_MotivoLiquidacionTarjeta_x_tb_sucursal> cxc_MotivoLiquidacionTarjeta_x_tb_sucursal { get; set; }
        public virtual ICollection<cxc_LiquidacionTarjetaDet> cxc_LiquidacionTarjetaDet { get; set; }
    }
}
