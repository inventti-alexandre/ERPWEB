﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Info.Reportes.RRHH
{
   public class ROL_002_Info
    {
        public string NombreCompleto { get; set; }
        public string Ruc { get; set; }
        public string RubroDescripcion { get; set; }
        public int IdEmpresa { get; set; }
        public int IdNominaTipo { get; set; }
        public int IdNominaTipoLiqui { get; set; }
        public int IdPeriodo { get; set; }
        public decimal IdEmpleado { get; set; }
        public double Valor { get; set; }
        public string Cargo { get; set; }
        public string pe_apellido { get; set; }
        public string pe_nombre { get; set; }
        public System.DateTime pe_FechaIni { get; set; }
        public System.DateTime pe_FechaFin { get; set; }
        public string ru_tipo { get; set; }
        public string em_status { get; set; }
        public int ru_orden { get; set; }
        public string em_ruc { get; set; }
        public int IdSucursal { get; set; }
        public string Grupo { get; set; }
        public string em_codigo { get; set; }
        public string de_descripcion { get; set; }
        public string Area { get; set; }

        public double Ingresos { get; set; }
        public double Egreso { get; set; }
        public string IdRubro { get; set; }

        public string mes_nom { get; set; }
        public double TotalPagar { get; set; }


        public string NomNomina { get; set; }
        public string NomNominaTipo { get; set; }

        #region DetallePrestamo
        public decimal IdPrestamo { get; set; }
        public string ru_descripcion { get; set; }
        public int NumCuota { get; set; }
        public int NumCuotas { get; set; }
        public double TotalCuota { get; set; }
        

        #endregion

    }
}
