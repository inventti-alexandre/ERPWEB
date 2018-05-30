﻿using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Erp.Bus.ActivoFijo;
using Core.Erp.Info.ActivoFijo;
using Core.Erp.Bus.Contabilidad;
using Core.Erp.Web.Areas.Contabilidad.Controllers;
using Core.Erp.Info.Contabilidad;

namespace Core.Erp.Web.Areas.ActivoFijo.Controllers
{
    public class VentaActivoController : Controller
    {
        Af_Venta_Activo_Bus bus_venta = new Af_Venta_Activo_Bus();
        ct_cbtecble_det_List list_ct_cbtecble_det = new ct_cbtecble_det_List();
        ct_cbtecble_det_Bus bus_comprobante_detalle = new ct_cbtecble_det_Bus();
        string mensaje = string.Empty;
        public ActionResult Index()
        {
            return View();
        }
        private bool validar(Af_Venta_Activo_Info i_validar, ref string msg)
        {
            if (i_validar.lst_ct_cbtecble_det.Count == 0)
            {
                mensaje = "Debe ingresar registros en el detalle, por favor verifique";
                return false;
            }
            if (i_validar.lst_ct_cbtecble_det.Sum(q => q.dc_Valor) != 0)
            {
                mensaje = "La suma de los detalles debe ser 0, por favor verifique";
                return false;
            }
            foreach (var item in i_validar.lst_ct_cbtecble_det)
            {
                if (string.IsNullOrEmpty(item.IdCtaCble))
                {
                    mensaje = "Faltan cuentas contables, por favor verifique";
                    return false;
                }
            }
            if (i_validar.lst_ct_cbtecble_det.Where(q => q.dc_Valor == 0).Count() > 0)
            {
                mensaje = "Existen detalles con valor 0 en el debe o haber, por favor verifique";
                return false;
            }
            return true;
        }
        [ValidateInput(false)]
        public ActionResult GridViewPartial_venta_activo()
        {
            int IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
            List<Af_Venta_Activo_Info> model = new List<Af_Venta_Activo_Info>();
            model = bus_venta.get_list(IdEmpresa, true);
            return PartialView("_GridViewPartial_venta_activo", model);
        }
        private void cargar_combos()
        {

            int IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
            Af_Activo_fijo_Bus bus_fijo = new Af_Activo_fijo_Bus();
            var lst_fijo = bus_fijo.get_list(IdEmpresa, false);
            ViewBag.lst_fijo = lst_fijo;            

            ct_cbtecble_tipo_Bus bus_tipo = new ct_cbtecble_tipo_Bus();
            var lst_tipo = bus_tipo.get_list(IdEmpresa, false);
            ViewBag.lst_tipo = lst_tipo;

        }
        private void cargar_combos_detalle()
        {
            int IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
            ct_plancta_Bus bus_cuenta = new ct_plancta_Bus();
            var lst_cuentas = bus_cuenta.get_list(IdEmpresa, false, true);
            ViewBag.lst_cuentas = lst_cuentas;
        }
        public ActionResult Nuevo()
        {
            Af_Venta_Activo_Info model = new Af_Venta_Activo_Info
            {
                IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]),
                Fecha_Venta = DateTime.Now
            };
            model.lst_ct_cbtecble_det = new List<ct_cbtecble_det_Info>();
            list_ct_cbtecble_det.set_list(model.lst_ct_cbtecble_det);
            cargar_combos_detalle();
            cargar_combos();
            return View(model);
        }

        [HttpPost]
        public ActionResult Nuevo(Af_Venta_Activo_Info model)
        {
            model.lst_ct_cbtecble_det = list_ct_cbtecble_det.get_list();
            if (!validar(model, ref mensaje))
            {
                cargar_combos();
                ViewBag.mensaje = mensaje;
                return View(model);
            }
            model.IdUsuario = Session["IdUsuario"].ToString();
            model.IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
            if (!bus_venta.guardarDB(model))
            {
                cargar_combos();
                return View(model);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Modificar(decimal IdVtaActivo = 0)
        {
            int IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
            Af_Venta_Activo_Info model = bus_venta.get_info(IdEmpresa, IdVtaActivo);
            if (model == null)
                return RedirectToAction("Index");
            model.lst_ct_cbtecble_det = bus_comprobante_detalle.get_list(IdEmpresa, model.IdTipoCbte == null ? 0 : Convert.ToInt32(model.IdTipoCbte), model.IdCbteCble == null ? 0 : Convert.ToDecimal(model.IdCbteCble));
            list_ct_cbtecble_det.set_list(model.lst_ct_cbtecble_det);
            cargar_combos();
            return View(model);
        }
        [HttpPost]
        public ActionResult Modificar(Af_Venta_Activo_Info model)
        {
            model.lst_ct_cbtecble_det = list_ct_cbtecble_det.get_list();
            if (!validar(model, ref mensaje))
            {
                cargar_combos();
                ViewBag.mensaje = mensaje;
                return View(model);
            }
            model.IdUsuarioUltMod = Session["IdUsuario"].ToString();
            if (!bus_venta.modificarDB(model))
            {
                cargar_combos();
                return View(model);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Anular(decimal IdVtaActivo = 0)
        {
            int IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
            Af_Venta_Activo_Info model = bus_venta.get_info(IdEmpresa, IdVtaActivo);
            if (model == null)
                return RedirectToAction("Index");
            model.lst_ct_cbtecble_det = bus_comprobante_detalle.get_list(IdEmpresa, model.IdTipoCbte == null ? 0 : Convert.ToInt32(model.IdTipoCbte), model.IdCbteCble == null ? 0 : Convert.ToDecimal(model.IdCbteCble));
            list_ct_cbtecble_det.set_list(model.lst_ct_cbtecble_det);
            cargar_combos();
            return View(model);
        }
        [HttpPost]
        public ActionResult Anular(Af_Venta_Activo_Info model)
        {
            model.IdUsuarioUltAnu = Session["IdUsuario"].ToString();
            if (!bus_venta.anularDB(model))
            {
                cargar_combos();
                return View(model);
            }
            return RedirectToAction("Index");
        }

        #region

        public JsonResult get_valores(int IdActivoFijo = 0)
        {
            int IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
            Af_Activo_fijo_Bus bus_activo = new Af_Activo_fijo_Bus();
            var resultado = bus_activo.get_valores(IdEmpresa, IdActivoFijo);

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}