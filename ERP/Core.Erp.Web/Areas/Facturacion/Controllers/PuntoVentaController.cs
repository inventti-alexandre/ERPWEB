﻿using Core.Erp.Info.Facturacion;
using Core.Erp.Bus.Facturacion;
using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Erp.Bus.General;

namespace Core.Erp.Web.Areas.Facturacion.Controllers
{
    public class PuntoVentaController : Controller
    {
        fa_PuntoVta_Bus bus_punto = new fa_PuntoVta_Bus();
        public ActionResult Index(int IdSucursal = 0, int IdBodega = 0)
        {
            ViewBag.IdSucursal = IdSucursal;
            ViewBag.IdBodega = IdBodega;
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial_puntoventa(int IdSucursal = 0, int IdBodega = 0)
        {
            int IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
            List<fa_PuntoVta_Info> model = bus_punto.get_list(IdEmpresa, IdSucursal, IdBodega);
            ViewBag.IdSucursal = IdSucursal;
            ViewBag.Idbodega = IdBodega;
            return PartialView("_GridViewPartial_puntoventa", model);
        }
        private void cargar_combos( fa_PuntoVta_Info model)
        {
            int IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
            tb_sucursal_Bus bus_sucursal = new tb_sucursal_Bus();
            var lst_sucursal = bus_sucursal.get_list(IdEmpresa, false);
            ViewBag.lst_sucursal = lst_sucursal;

            tb_bodega_Bus bus_bodega = new tb_bodega_Bus();
            var lst_bodega = bus_bodega.get_list(model.IdEmpresa, model.IdSucursal, false);
            ViewBag.lst_bodega = lst_bodega;

            Dictionary<string, string> lst_signos = new Dictionary<string, string>();
            lst_signos.Add("-", "-");
            lst_signos.Add("+", "+");
            ViewBag.lst_signos = lst_signos;
        }
        public ActionResult Nuevo(int IdSucursal = 0, int IdBodega = 0)
        {
            fa_PuntoVta_Info model = new fa_PuntoVta_Info
            {
                IdSucursal = IdSucursal,
                IdBodega = IdBodega
            };
            ViewBag.IdSucursal = IdSucursal;
            ViewBag.IdBodega = IdBodega;
            cargar_combos(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Nuevo(fa_PuntoVta_Info model)
        {
            model.IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
            if (!bus_punto.guardarDB(model))
            {
                ViewBag.IdSucursal = model.IdSucursal;
                ViewBag.IdBodega = model.IdBodega;
                cargar_combos(model);
                return View(model);
            }
            return RedirectToAction("Index", new { IdSucursal = model.IdSucursal, IdBodega = model.IdBodega });
        }
        public ActionResult Modificar(int IdSucursal = 0, int IdBodega = 0,int IdPuntoVta = 0)
        {
            int IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
            fa_PuntoVta_Info model = bus_punto.get_info(IdEmpresa,IdSucursal, IdPuntoVta);
            if (model == null)
            return RedirectToAction("Index", new { IdSucursal = IdSucursal, IdBodega = IdBodega });
                ViewBag.IdSucursal = IdSucursal;
                ViewBag.IdBodega = IdBodega;
                cargar_combos(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Modificar(fa_PuntoVta_Info model)
        {
            model.IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
            if (!bus_punto.modificarDB(model))
            {
                ViewBag.IdSucursal = model.IdSucursal;
                ViewBag.IdBodega = model.IdBodega;
                cargar_combos(model);
                return View(model);
            }
            return RedirectToAction("Index", new { IdSucursal = model.IdSucursal, IdBodega = model.IdBodega });
        }
        public ActionResult Anular(int IdSucursal = 0, int IdBodega = 0, int IdPuntoVta = 0)
        {
            int IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
            fa_PuntoVta_Info model = bus_punto.get_info(IdEmpresa, IdSucursal, IdPuntoVta);
            if (model == null)
            {
                ViewBag.IdSucursal = IdSucursal;
                ViewBag.IdBodega = IdBodega;
                return RedirectToAction("Index", new { IdSucursal = IdSucursal, IdBodega = IdBodega});
            }
                cargar_combos(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Anular(fa_PuntoVta_Info model)
        {
            model.IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
            if (!bus_punto.anularDB(model))
            {
                ViewBag.IdSucursal = model.IdSucursal;
                ViewBag.IdBodega = model.IdBodega;
                cargar_combos(model);
                return View(model);
            }
            return RedirectToAction("Index", new { IdSucursal = model.IdSucursal, IdBodega = model.IdBodega });
        }

        #region Json
        public JsonResult cargar_bodega(int IdSucursal = 0)
        {
            int IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
            tb_bodega_Bus bus_bodega = new tb_bodega_Bus();
            var resultado = bus_bodega.get_list(IdEmpresa, IdSucursal, false);

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}