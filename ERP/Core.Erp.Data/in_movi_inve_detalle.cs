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
    
    public partial class in_movi_inve_detalle
    {
        public in_movi_inve_detalle()
        {
            this.in_Ing_Egr_Inven_det = new HashSet<in_Ing_Egr_Inven_det>();
        }
    
        public int IdEmpresa { get; set; }
        public int IdSucursal { get; set; }
        public int IdBodega { get; set; }
        public int IdMovi_inven_tipo { get; set; }
        public decimal IdNumMovi { get; set; }
        public int Secuencia { get; set; }
        public string mv_tipo_movi { get; set; }
        public decimal IdProducto { get; set; }
        public double dm_cantidad { get; set; }
        public string dm_observacion { get; set; }
        public double mv_costo { get; set; }
        public string IdCentroCosto { get; set; }
        public string IdCentroCosto_sub_centro_costo { get; set; }
        public string IdUnidadMedida { get; set; }
        public double dm_cantidad_sinConversion { get; set; }
        public string IdUnidadMedida_sinConversion { get; set; }
        public Nullable<double> mv_costo_sinConversion { get; set; }
        public Nullable<int> IdPunto_cargo { get; set; }
        public Nullable<int> IdPunto_cargo_grupo { get; set; }
        public Nullable<int> IdMotivo_Inv { get; set; }
        public Nullable<bool> Costeado { get; set; }
    
        public virtual ICollection<in_Ing_Egr_Inven_det> in_Ing_Egr_Inven_det { get; set; }
        public virtual in_movi_inve in_movi_inve { get; set; }
        public virtual in_Producto in_Producto { get; set; }
        public virtual in_UnidadMedida in_UnidadMedida { get; set; }
        public virtual in_UnidadMedida in_UnidadMedida1 { get; set; }
    }
}
