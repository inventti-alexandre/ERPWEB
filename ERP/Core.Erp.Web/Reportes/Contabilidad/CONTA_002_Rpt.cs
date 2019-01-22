﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Core.Erp.Bus.Reportes.Contabilidad;
using Core.Erp.Info.Reportes.Contabilidad;
using System.Collections.Generic;
using Core.Erp.Bus.General;

namespace Core.Erp.Web.Reportes.Contabilidad
{
    public partial class CONTA_002_Rpt : DevExpress.XtraReports.UI.XtraReport
    {
        public string usuario { get; set; }
        public string empresa { get; set; }
        public CONTA_002_Rpt()
        {
            InitializeComponent();
        }

        private void CONTA_002_Rpt_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            lbl_fecha.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            lbl_empresa.Text = empresa;
            lbl_usuario.Text = usuario;
            int IdEmpresa = p_IdEmpresa.Value == null ? 0 : Convert.ToInt32(p_IdEmpresa.Value);
            string IdCtaCble = p_IdCtaCble.Value == null ? "" : Convert.ToString(p_IdCtaCble.Value);
            DateTime fechaIni = p_fechaIni.Value == null ? DateTime.Now : Convert.ToDateTime(p_fechaIni.Value);
            DateTime fechaFin = p_fechaFin.Value == null ? DateTime.Now : Convert.ToDateTime(p_fechaFin.Value);
            int IdSucursal = string.IsNullOrEmpty(p_IdSucursal.Value.ToString()) ? 0 : Convert.ToInt32(p_IdSucursal.Value);
            CONTA_002_Bus bus_rpt = new CONTA_002_Bus();
            List<CONTA_002_Info> lst_rpt = bus_rpt.get_list(IdEmpresa, IdCtaCble, IdSucursal, fechaIni, fechaFin);
            this.DataSource = lst_rpt;

            tb_empresa_Bus bus_empresa = new tb_empresa_Bus();
            var emp = bus_empresa.get_info(IdEmpresa);

            ImageConverter obj = new ImageConverter();
            lbl_imagen.Image = (Image)obj.ConvertFrom(emp.em_logo);
        }
    }
}
