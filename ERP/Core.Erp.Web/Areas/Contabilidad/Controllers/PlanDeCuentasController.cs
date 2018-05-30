﻿using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Erp.Info.Contabilidad;
using Core.Erp.Bus.Contabilidad;

namespace Core.Erp.Web.Areas.Contabilidad.Controllers
{
    public class PlanDeCuentasController : Controller
    {
        ct_plancta_Bus bus_plancta = new ct_plancta_Bus();
        public ActionResult Index()
        {
            return View();
        }
        [ValidateInput(false)]
        public ActionResult GridViewPartial_plancta()
        {
            int IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
            List<ct_plancta_Info> model = bus_plancta.get_list(IdEmpresa, true, false);
            return PartialView("_GridViewPartial_plancta", model);
        }
        private void cargar_combos()
        {
            int IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
            var lst_cuentas = bus_plancta.get_list(IdEmpresa, false, false);
            ViewBag.lst_cuentas = lst_cuentas;

            Dictionary<string, string> lst_naturaleza = new Dictionary<string, string>();
            lst_naturaleza.Add("D","Deudora");
            lst_naturaleza.Add("A", "Acreedora");
            ViewBag.lst_naturaleza = lst_naturaleza;

            ct_grupocble_Bus bus_grupo_contable = new ct_grupocble_Bus();
            var lst_grupo_contabe = bus_grupo_contable.get_list(false);
            ViewBag.lst_grupo_contabe = lst_grupo_contabe;
        }
        public ActionResult Nuevo()
        {
            ct_plancta_Info model = new ct_plancta_Info();
            cargar_combos();
            return View(model);
        }
        [HttpPost]
        public ActionResult Nuevo(ct_plancta_Info model)
        {
            model.IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
            if (bus_plancta.validar_existe_id(model.IdEmpresa,model.IdCtaCble))
            {
                ViewBag.mensaje = "El código de la cuenta ya se encuentra registrado";
                cargar_combos();
                return View(model);
            }
            if (!bus_plancta.guardarDB(model))
            {
                cargar_combos();
                return View(model);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Modificar(string IdCtaCble = "")
        {
            int IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
            ct_plancta_Info model = bus_plancta.get_info(IdEmpresa, IdCtaCble);
            if (model == null)
                return RedirectToAction("Index");
            cargar_combos();
            return View(model);
        }
        [HttpPost]
        public ActionResult Modificar(ct_plancta_Info model)
        {
            if (!bus_plancta.modificarDB(model))
            {
                cargar_combos();
                return View(model);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Anular(string IdCtaCble = "")
        {
            int IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
            ct_plancta_Info model = bus_plancta.get_info(IdEmpresa, IdCtaCble);
            if (model == null)
                return RedirectToAction("Index");
            cargar_combos();
            return View(model);
        }
        [HttpPost]
        public ActionResult Anular(ct_plancta_Info model)
        {
            if (!bus_plancta.anularDB(model))
            {
                cargar_combos();
                return View(model);
            }
            return RedirectToAction("Index");
        }

        public JsonResult get_info_nuevo(string IdCtaCble_padre = "")
        {
            int IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);

            var resultado = bus_plancta.get_info_nuevo(IdEmpresa, IdCtaCble_padre);
            
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

    }
}