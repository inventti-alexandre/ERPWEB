﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Info.General
{
   public class tb_banco_procesos_bancarios_x_empresa_Info
    {
        public int IdEmpresa { get; set; }
        public int IdProceso { get; set; }
        public string IdProceso_bancario_tipo { get; set; }
        public int IdBanco { get; set; }
        public string Codigo_Empresa { get; set; }
        public Nullable<int> IdTipoNota { get; set; }
        public Nullable<bool> Se_contabiliza { get; set; }
        public string estado { get; set; }
        public Nullable<System.DateTime> Fecha_Transaccion { get; set; }
        public string IdUsuarioUltModi { get; set; }
        public Nullable<System.DateTime> Fecha_UltMod { get; set; }
        public string IdUsuarioUltAnu { get; set; }
        public Nullable<System.DateTime> Fecha_UltAnu { get; set; }
        public string MotivoAnulacion { get; set; }




        public bool EstadoBool { get; set; }
    }
}
