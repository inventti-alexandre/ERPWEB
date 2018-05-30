﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using Core.Erp.Bus.Reportes.Contabilidad;
using Core.Erp.Info.Reportes.Contabilidad;

namespace Core.Erp.Web.Reportes.Contabilidad
{
    public partial class CONTA_001_Rpt : DevExpress.XtraReports.UI.XtraReport
    {
        public string usuario { get; set; }
        public string empresa { get; set; }
        public CONTA_001_Rpt()
        {
            InitializeComponent();
        }

        private void CONTA_001_Rpt_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            lbl_fecha.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            lbl_empresa.Text = empresa;
            lbl_usuario.Text = usuario;

            int IdEmpresa = p_IdEmpresa.Value == null ? 0 : Convert.ToInt32(p_IdEmpresa.Value);
            int IdTipoCbte = p_IdTipoCbte.Value == null ? 0 : Convert.ToInt32(p_IdTipoCbte.Value);
            decimal IdCbteCble = p_IdCbteCble.Value == null ? 0 : Convert.ToDecimal(p_IdCbteCble.Value);

            VWCONTA_001_Bus bus_rpt = new VWCONTA_001_Bus();
            List<VWCONTA_001_Info> lst_rpt = bus_rpt.get_list(IdEmpresa, IdTipoCbte, IdCbteCble);
            this.DataSource = lst_rpt;
        }
    }
}
