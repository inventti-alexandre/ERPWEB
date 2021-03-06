﻿using Core.Erp.Bus.CuentasPorPagar;
using Core.Erp.Bus.General;
using Core.Erp.Info.General;
using Core.Erp.Info.Helps;
using Core.Erp.Web.Helps;
using Core.Erp.Web.Reportes.CuentasPorPagar;
using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Core.Erp.Web.Areas.Reportes.Controllers
{
    [SessionTimeout]
    public class CuentasPorPagarReportesController : Controller
    {
        tb_persona_Bus bus_persona = new tb_persona_Bus();
        tb_sis_reporte_x_tb_empresa_Bus bus_rep_x_emp = new tb_sis_reporte_x_tb_empresa_Bus();
        string RootReporte = System.IO.Path.GetTempPath() + "Rpt_Facturacion.repx";

        #region Metodos ComboBox bajo demanda
        public ActionResult CmbProveedor_CXP()
        {
           cl_filtros_Info model = new cl_filtros_Info();
            return PartialView("_CmbProveedor_CXP", model);
        }
        public List<tb_persona_Info> get_list_bajo_demanda(ListEditItemsRequestedByFilterConditionEventArgs args)
        {
            return bus_persona.get_list_bajo_demanda(args, Convert.ToInt32(SessionFixed.IdEmpresa), cl_enumeradores.eTipoPersona.PROVEE.ToString());
        }
        public tb_persona_Info get_info_bajo_demanda(ListEditItemRequestedByValueEventArgs args)
        {
            return bus_persona.get_info_bajo_demanda(args, Convert.ToInt32(SessionFixed.IdEmpresa), cl_enumeradores.eTipoPersona.PROVEE.ToString());
        }
        #endregion
        public ActionResult CXP_001(int IdTipoCbte_Ogiro = 0, decimal IdCbteCble_Ogiro = 0)
        {
            CXP_001_Rpt model = new CXP_001_Rpt();
            model.p_IdEmpresa.Value = Convert.ToInt32(Session["IdEmpresa"]);
            model.p_IdTipoCbte_Ogiro.Value = IdTipoCbte_Ogiro;
            model.p_IdCbteCble_Ogiro.Value = IdCbteCble_Ogiro;
            model.usuario = SessionFixed.IdUsuario;
            model.empresa = SessionFixed.NomEmpresa;
            model.RequestParameters = false;
            return View(model);
        }
        public ActionResult CXP_002(int IdEmpresa_Ogiro = 0, int IdTipoCbte_Ogiro = 0, decimal IdCbteCble_Ogiro = 0)
        {
            CXP_002_Rpt model = new CXP_002_Rpt();
            model.p_IdEmpresa_Ogiro.Value = IdEmpresa_Ogiro;
            model.p_IdTipoCbte_Ogiro.Value = IdTipoCbte_Ogiro;
            model.p_IdCbteCble_Ogiro.Value = IdCbteCble_Ogiro;
            model.RequestParameters = false;
            return View(model);
        }
        public ActionResult CXP_003( int IdTipoCbte = 0, decimal IdCbteCble = 0)
        {
            CXP_003_Rpt model = new CXP_003_Rpt();
            model.p_IdEmpresa.Value = Convert.ToInt32(Session["IdEmpresa"]);
            model.p_IdTipoCbte.Value = IdTipoCbte;
            model.p_IdCbteCble.Value = IdCbteCble;
            model.usuario = SessionFixed.IdUsuario;
            model.empresa = SessionFixed.NomEmpresa;
            model.RequestParameters = false;
            return View(model);
        }
        public ActionResult CXP_004( decimal IdOrdenPago = 0)
        {
            CXP_004_Rpt model = new CXP_004_Rpt();
            model.p_IdEmpresa.Value = Convert.ToInt32(Session["IdEmpresa"]);
            model.p_IdOrdenPago.Value = IdOrdenPago;
            model.usuario = SessionFixed.IdUsuario;
            model.empresa = SessionFixed.NomEmpresa;
            model.RequestParameters = false;
            return View(model);
        }
        public ActionResult CXP_005( decimal IdConciliacion = 0)
        {
            CXP_005_Rpt model = new CXP_005_Rpt();
            model.p_IdEmpresa.Value = Convert.ToInt32(Session["IdEmpresa"]);
            model.p_IdConciliacion.Value = IdConciliacion;
            model.usuario = SessionFixed.IdUsuario;
            model.empresa = SessionFixed.NomEmpresa;
            model.RequestParameters = false;
            return View(model);
        }
        public ActionResult CXP_006( decimal IdRetencion = 0)
        {
            CXP_006_Rpt model = new CXP_006_Rpt();
            model.p_IdEmpresa.Value = SessionFixed.IdEmpresa;
            model.p_IdRetencion.Value = IdRetencion;
            model.usuario = SessionFixed.IdUsuario;
            model.empresa = SessionFixed.NomEmpresa;
            model.RequestParameters = false;
            return View(model);
        }
        public ActionResult CXP_007()
        {
            cl_filtros_Info model = new cl_filtros_Info
            {
                IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa),
                IdSucursal = Convert.ToInt32(SessionFixed.IdSucursal)
            };
            cargar_combos();
            CXP_007_Rpt report = new CXP_007_Rpt();
            report.p_IdEmpresa.Value = model.IdEmpresa;
            report.p_IdSucursal.Value = model.IdSucursal;
            report.p_fecha_ini.Value = model.fecha_ini;
            report.p_fecha_fin.Value = model.fecha_fin;
            report.p_mostrar_agrupado.Value = model.mostrar_agrupado;
            report.usuario = SessionFixed.IdUsuario;
            report.empresa = SessionFixed.NomEmpresa;
            ViewBag.Report = report;
            return View(model);
        }
        [HttpPost]
        public ActionResult CXP_007(cl_filtros_Info model)
        {
            CXP_007_Rpt report = new CXP_007_Rpt();
            report.p_IdEmpresa.Value = model.IdEmpresa;
            report.p_IdSucursal.Value = model.IdSucursal;
            report.p_fecha_ini.Value = model.fecha_ini;
            report.p_fecha_fin.Value = model.fecha_fin;
            report.p_mostrar_agrupado.Value = model.mostrar_agrupado;
            report.usuario = SessionFixed.IdUsuario;
            report.empresa = SessionFixed.NomEmpresa;
            cargar_combos();
            ViewBag.Report = report;
            return View(model);
        }
        private void cargar_combos()
        {
            int IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
            cp_proveedor_Bus bus_proveedor = new cp_proveedor_Bus();
            var lst_proveedor = bus_proveedor.get_list(IdEmpresa, false);
            ViewBag.lst_proveedor = lst_proveedor;

            tb_sucursal_Bus bus_sucursal = new tb_sucursal_Bus();
            var lst_sucursal = bus_sucursal.get_list(IdEmpresa, false);
            ViewBag.lst_sucursal = lst_sucursal;


        }
        public ActionResult CXP_008()
        {
            cl_filtros_Info model = new cl_filtros_Info
            {
                IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa),
                IdSucursal = Convert.ToInt32(SessionFixed.IdSucursal),
                IdProveedor = 0
            };
            cargar_combos();
            CXP_008_Rpt report = new CXP_008_Rpt();
            report.p_IdEmpresa.Value = model.IdEmpresa;
            report.p_IdSucursal.Value = model.IdSucursal;
            report.p_fecha.Value = model.fecha_fin;
            report.p_IdProveedor.Value = model.IdProveedor;
            report.p_no_mostrar_en_conciliacion.Value = model.no_mostrar_en_conciliacion;
            report.p_no_mostrar_saldo_0.Value = model.no_mostrar_saldo_en_0;
            report.usuario = SessionFixed.IdUsuario;
            report.empresa = SessionFixed.NomEmpresa;
            ViewBag.Report = report;
            return View(model);
        }
        [HttpPost]
        public ActionResult CXP_008(cl_filtros_Info model)
        {
            CXP_008_Rpt report = new CXP_008_Rpt();
            report.p_IdEmpresa.Value = model.IdEmpresa;
            report.p_IdSucursal.Value = model.IdSucursal;
            report.p_fecha.Value = model.fecha_fin;
            report.p_IdProveedor.Value = model.IdProveedor;
            report.p_no_mostrar_en_conciliacion.Value = model.no_mostrar_en_conciliacion;
            report.p_no_mostrar_saldo_0.Value = model.no_mostrar_saldo_en_0;
            report.usuario = SessionFixed.IdUsuario;
            report.empresa = SessionFixed.NomEmpresa;
            cargar_combos();
            report.RequestParameters = false;
                ViewBag.Report = report;
            return View(model);
        }
        public ActionResult CXP_009()
        {
            cl_filtros_Info model = new cl_filtros_Info
            {
                IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa),
                IdSucursal = Convert.ToInt32(SessionFixed.IdSucursal)
            };
            cargar_combos();
            CXP_009_Rpt report = new CXP_009_Rpt();
            report.p_IdEmpresa.Value = model.IdEmpresa;
            report.p_IdSucursal.Value = model.IdSucursal;
            report.p_Fecha_ini.Value = model.fecha_ini;
            report.p_Fecha_fin.Value = model.fecha_fin;
            report.p_mostrar_anulados.Value = model.mostrarAnulados;
            report.usuario = SessionFixed.IdUsuario;
            report.empresa = SessionFixed.NomEmpresa;
            report.RequestParameters = false;
            ViewBag.Report = report;
            return View(model);
        }
        [HttpPost]
        public ActionResult CXP_009(cl_filtros_Info model)
        {
            CXP_009_Rpt report = new CXP_009_Rpt();
            report.p_IdEmpresa.Value = model.IdEmpresa;
            report.p_IdSucursal.Value = model.IdSucursal;
            report.p_Fecha_ini.Value = model.fecha_ini;
            report.p_Fecha_fin.Value = model.fecha_fin;
            report.p_mostrar_anulados.Value = model.mostrarAnulados;
            report.usuario = SessionFixed.IdUsuario;
            report.empresa = SessionFixed.NomEmpresa;
            cargar_combos();
            ViewBag.Report = report;
            return View(model);
        }
        public ActionResult CXP_010()
        {
            cl_filtros_Info model = new cl_filtros_Info
            {
                IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa),
                IdProveedor = 0
            };
            cargar_combos();
            CXP_010_Rpt report = new CXP_010_Rpt();
            report.p_IdEmpresa.Value = model.IdEmpresa;
            report.p_IdProveedor.Value = model.IdProveedor;
            report.p_fechaIni.Value = model.fecha_ini;
            report.p_fechaFin.Value = model.fecha_fin;
            report.p_mostrarAnulados.Value = model.mostrarAnulados;
            report.p_mostrar_observacion_completa.Value = model.mostrar_observacion_completa;
            report.usuario = SessionFixed.IdUsuario;
            report.empresa = SessionFixed.NomEmpresa;
            report.RequestParameters = false;
            ViewBag.Report = report;
            return View(model);
        }
        [HttpPost]
        public ActionResult CXP_010(cl_filtros_Info model)
        {
            CXP_010_Rpt report = new CXP_010_Rpt();
            report.p_IdEmpresa.Value = model.IdEmpresa;
            report.p_IdProveedor.Value = model.IdProveedor;
            report.p_fechaIni.Value = model.fecha_ini;
            report.p_fechaFin.Value = model.fecha_fin;
            report.p_mostrarAnulados.Value = model.mostrarAnulados;
            report.p_mostrar_observacion_completa.Value = model.mostrar_observacion_completa;
            report.usuario = SessionFixed.IdUsuario;
            report.empresa = SessionFixed.NomEmpresa;
            cargar_combos();
            report.RequestParameters = false;
            ViewBag.Report = report;
            return View(model);
        }
        public ActionResult CXP_011(decimal IdSolicitud = 0)
        {
            CXP_011_Rpt model = new CXP_011_Rpt();
            model.p_IdEmpresa.Value = SessionFixed.IdEmpresa;
            model.p_IdSolicitud.Value = IdSolicitud;
            model.RequestParameters = false;
            return View(model);
        }
        public ActionResult CXP_012(decimal IdRetencion = 0)
        {
            CXP_012_Rpt model = new CXP_012_Rpt();
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);

            #region Cargo diseño desde base
            var reporte = bus_rep_x_emp.GetInfo(IdEmpresa, "CXP_012");
            if (reporte != null)
            {
                System.IO.File.WriteAllBytes(RootReporte, reporte.ReporteDisenio);
                model.LoadLayout(RootReporte);
            }
            #endregion

            model.p_IdEmpresa.Value = SessionFixed.IdEmpresa;
            model.p_IdRetencion.Value = IdRetencion;
            model.RequestParameters = false;
            model.DefaultPrinterSettingsUsing.UsePaperKind = false;

            return View(model);
        }

        public ActionResult CXP_013(decimal IdRetencion = 0)
        {
            CXP_013_Rpt model = new CXP_013_Rpt();
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);

            #region Cargo diseño desde base
            var reporte = bus_rep_x_emp.GetInfo(IdEmpresa, "CXP_013");
            if (reporte != null)
            {
                System.IO.File.WriteAllBytes(RootReporte, reporte.ReporteDisenio);
                model.LoadLayout(RootReporte);
            }
            #endregion

            model.p_IdEmpresa.Value = SessionFixed.IdEmpresa;
            model.p_IdRetencion.Value = IdRetencion;
            model.usuario = SessionFixed.IdUsuario;
            model.empresa = SessionFixed.NomEmpresa;
            model.RequestParameters = false;
            model.DefaultPrinterSettingsUsing.UsePaperKind = false;

            return View(model);
        }
    }
}