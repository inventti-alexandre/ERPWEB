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
    
    public partial class tb_modulo
    {
        public tb_modulo()
        {
            this.tb_sis_formulario = new HashSet<tb_sis_formulario>();
            this.tb_sis_reporte = new HashSet<tb_sis_reporte>();
        }
    
        public string CodModulo { get; set; }
        public string Descripcion { get; set; }
        public string Nom_Carpeta { get; set; }
        public Nullable<bool> Se_Cierra { get; set; }
    
        public virtual ICollection<tb_sis_formulario> tb_sis_formulario { get; set; }
        public virtual ICollection<tb_sis_reporte> tb_sis_reporte { get; set; }
    }
}
