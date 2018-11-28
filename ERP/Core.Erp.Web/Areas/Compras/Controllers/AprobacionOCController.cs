﻿using Core.Erp.Bus.Compras;
using Core.Erp.Bus.General;
using Core.Erp.Info.Compras;
using Core.Erp.Info.Helps;
using Core.Erp.Web.Helps;
using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Core.Erp.Web.Areas.Compras.Controllers
{
    public class AprobacionOCController : Controller
    {
        com_ordencompra_local_Bus bus_ordencompra = new com_ordencompra_local_Bus();
        tb_sucursal_Bus bus_sucursal = new tb_sucursal_Bus();
        com_orden_aprobacion_List List_apro = new com_orden_aprobacion_List();

        public ActionResult Index()
        {
            #region Validar Session
            if (string.IsNullOrEmpty(SessionFixed.IdTransaccionSession))
                return RedirectToAction("Login", new { Area = "", Controller = "Account" });
            SessionFixed.IdTransaccionSession = (Convert.ToDecimal(SessionFixed.IdTransaccionSession) + 1).ToString();
            SessionFixed.IdTransaccionSessionActual = SessionFixed.IdTransaccionSession;
            #endregion
            com_orden_aprobacion_Info model = new com_orden_aprobacion_Info
            {
                IdEmpresa = string.IsNullOrEmpty(SessionFixed.IdEmpresa) ? 0 : Convert.ToInt32(SessionFixed.IdEmpresa),
                IdSucursal = string.IsNullOrEmpty(SessionFixed.IdSucursal) ? 0 : Convert.ToInt32(SessionFixed.IdSucursal),
                IdTransaccionSession = Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual)

            };
            List_apro.set_list(new List<com_orden_aprobacion_Info>(), model.IdTransaccionSession);
            cargar_combos(model.IdEmpresa);
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(com_orden_aprobacion_Info model)
        {
            List_apro.get_list(model.IdTransaccionSession);
            cargar_combos(model.IdEmpresa);
            return View(model);
        }
        [ValidateInput(false)]
        public ActionResult GridViewPartial_aprobacion_oc(int IdSucursal, DateTime? fecha_ini, DateTime? fecha_fin)
        {

            SessionFixed.IdTransaccionSessionActual = Request.Params["TransaccionFixed"] != null ? Request.Params["TransaccionFixed"].ToString() : SessionFixed.IdTransaccionSessionActual;
            var det = List_apro.get_list(Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));

            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            ViewBag.fecha_ini = fecha_ini == null ? DateTime.Now.Date.AddMonths(-1) : Convert.ToDateTime(fecha_ini);
            ViewBag.fecha_fin = fecha_fin == null ? DateTime.Now.Date : Convert.ToDateTime(fecha_fin);
            ViewBag.IdSucursal = IdSucursal == 0 ? 0 : Convert.ToInt32(IdSucursal);

            var model = bus_ordencompra.GetListPorAprobar(IdEmpresa, IdSucursal, ViewBag.fecha_ini, ViewBag.fecha_fin);
            return PartialView("_GridViewPartial_aprobacion_oc", model);
        }

        private void cargar_combos(int IdEmpresa)
        {
            var lst_sucursal = bus_sucursal.get_list(IdEmpresa, false);
            ViewBag.lst_sucursal = lst_sucursal;
            
        }

    }
    public class com_orden_aprobacion_List
       {
           string variable = "com_orden_aprobacion_Info";
           public List<com_orden_aprobacion_Info> get_list(decimal IdTransaccionSession)
           {
               if (HttpContext.Current.Session[variable + IdTransaccionSession.ToString()] == null)
               {
                   List<com_orden_aprobacion_Info> list = new List<com_orden_aprobacion_Info>();

                   HttpContext.Current.Session[variable + IdTransaccionSession.ToString()] = list;
               }
               return (List<com_orden_aprobacion_Info>)HttpContext.Current.Session[variable + IdTransaccionSession.ToString()];
           }
           public void set_list(List<com_orden_aprobacion_Info> list, decimal IdTransaccionSession)
           {
               HttpContext.Current.Session[variable + IdTransaccionSession.ToString()] = list;
          }
       }

}