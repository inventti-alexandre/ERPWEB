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
    
    public partial class vwba_Conciliacion
    {
        public int IdEmpresa { get; set; }
        public decimal IdConciliacion { get; set; }
        public int IdBanco { get; set; }
        public int IdPeriodo { get; set; }
        public System.DateTime co_Fecha { get; set; }
        public double co_SaldoContable_MesAnt { get; set; }
        public double co_totalIng { get; set; }
        public double co_totalEgr { get; set; }
        public double co_SaldoContable_MesAct { get; set; }
        public string Estado { get; set; }
        public string co_Observacion { get; set; }
        public string ba_descripcion { get; set; }
        public string IdCtaCble { get; set; }
        public string Periodo { get; set; }
        public double co_SaldoBanco_anterior { get; set; }
        public string IdEstado_Concil_Cat { get; set; }
        public double co_SaldoBanco_EstCta { get; set; }
    }
}
