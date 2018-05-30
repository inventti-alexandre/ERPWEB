﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Erp.Info.RRHH;
using Core.Erp.Bus.RRHH;
using DevExpress.Web.Mvc;

namespace Core.Erp.Web.Areas.RRHH.Controllers
{
    public class EmpleadoNovedadController : Controller
    {
        #region Variables
        ro_empleado_novedad_Bus bus_novedad = new ro_empleado_novedad_Bus();
        ro_nomina_tipo_Bus bus_nomina = new ro_nomina_tipo_Bus();
        ro_Nomina_Tipoliquiliqui_Bus bus_nomina_tipo = new ro_Nomina_Tipoliquiliqui_Bus();
        ro_empleado_novedad_det_Bus bus_novedad_detalle_bus = new ro_empleado_novedad_det_Bus();
        ro_empleado_novedad_det_lst lst_novedad_det = new ro_empleado_novedad_det_lst();
        ro_rubro_tipo_Bus bus_rubro = new ro_rubro_tipo_Bus();
        ro_empleado_Bus bus_empleado = new ro_empleado_Bus();
        int IdEmpresa = 0;
        #endregion
        public ActionResult Index()
        {
            return View();
        }       


        [ValidateInput(false)]
        public ActionResult GridViewPartial_empleado_novedad()
        {
            int IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
            List<ro_empleado_novedad_Info> model = bus_novedad.get_list(IdEmpresa);
            return PartialView("_GridViewPartial_empleado_novedad", model);
        }
        private void cargar_combos(int IdNomina)
        {
            IdEmpresa =Convert.ToInt32( Session["IdEmpresa"]);
            ViewBag.lst_nomina = bus_nomina.get_list(IdEmpresa, false);
            ViewBag.lst_nomina_tipo = bus_nomina_tipo.get_list(IdEmpresa, IdNomina);
            ViewBag.lst_empleado = bus_empleado.get_list_combo(IdEmpresa);

        }

        public ActionResult Nuevo()
        {
             ro_empleado_novedad_Info model = new  ro_empleado_novedad_Info
            {
                IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]),
                Fecha = DateTime.Now,
                IdEmpleado = 1
            };
            model.lst_novedad_det = new List<ro_empleado_novedad_det_Info>();
            lst_novedad_det.set_list(model.lst_novedad_det);
            cargar_combos(0);
            cargar_combos_detalle();
            return View(model);
        }

        [HttpPost]
        public ActionResult Nuevo( ro_empleado_novedad_Info model)
        {
            model.lst_novedad_det =lst_novedad_det.get_list();
            if (model.lst_novedad_det==null || model.lst_novedad_det.Count()==0)
            {
                ViewBag.mensaje = "No existe detalle para la novedad";
                cargar_combos(model.IdNomina_Tipo);
                return View(model);
            }
            model.IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
            model.IdUsuario = Session["IdUsuario"].ToString();
            if (!bus_novedad.guardarDB(model))
            {
                cargar_combos(model.IdNomina_Tipo);
                return View(model);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Modificar(int IdEmpleado, decimal IdNovedad)
        {
            int IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
             ro_empleado_novedad_Info model = bus_novedad.get_info(IdEmpresa, IdEmpleado, IdNovedad);
            if (model == null)
                return RedirectToAction("Index");
            model.lst_novedad_det = bus_novedad_detalle_bus.get_list(IdEmpresa, IdEmpleado, IdNovedad);
            lst_novedad_det.set_list(model.lst_novedad_det);
            cargar_combos_detalle();
            cargar_combos(model.IdNomina_Tipo);
            return View(model);
        }

        [HttpPost]
        public ActionResult Modificar( ro_empleado_novedad_Info model)
        {
            model.lst_novedad_det = lst_novedad_det.get_list();
            if (model.lst_novedad_det == null || model.lst_novedad_det.Count() == 0)
            {
                ViewBag.mensaje = "No existe detalle para la planificación";
                cargar_combos(model.IdNomina_Tipo);
                return View(model);
            }
            model.IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
            model.IdUsuario = Session["IdUsuario"].ToString();
            if (!bus_novedad.modificarDB(model))
            {
                cargar_combos(model.IdNomina_Tipo);
                return View(model);
            }
            return RedirectToAction("Index");

        }

        public ActionResult Anular(int IdEmpleado, decimal IdNovedad)
        {
            int IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
             ro_empleado_novedad_Info model = bus_novedad.get_info(IdEmpresa, IdEmpleado, IdNovedad);
            if (model == null)
                return RedirectToAction("Index");
            model.lst_novedad_det = bus_novedad_detalle_bus.get_list(IdEmpresa, IdEmpleado, IdNovedad);
            lst_novedad_det.set_list(model.lst_novedad_det);
            cargar_combos(model.IdNomina_Tipo);
            return View(model);
        }
        [HttpPost]
        public ActionResult Anular( ro_empleado_novedad_Info model)
        {
            model.lst_novedad_det = lst_novedad_det.get_list();
            
            model.IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
            model.IdUsuario = Session["IdUsuario"].ToString();
            if (!bus_novedad.anularDB(model))
            {
                cargar_combos(model.IdNomina_Tipo);
                return View(model);
            }
            return RedirectToAction("Index");
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial_empleado_novedad_det(int IdEmpleado = 0, decimal IdNovedad = 0)
        {
            int IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
             ro_empleado_novedad_Info model = new  ro_empleado_novedad_Info();
            model.lst_novedad_det = bus_novedad_detalle_bus.get_list(IdEmpresa, IdEmpleado, IdNovedad);
            if (model.lst_novedad_det.Count == 0)
                model.lst_novedad_det = lst_novedad_det.get_list();
            cargar_combos_detalle();
            return PartialView("_GridViewPartial_empleado_novedad_det", model);
        }

        private void cargar_combos_detalle()
        {
            int IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
            ViewBag.lst_rubro = bus_rubro.get_list_rub_concepto(IdEmpresa);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult EditingAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] ro_empleado_novedad_det_Info info_det)
        {
            if (ModelState.IsValid)
                lst_novedad_det.AddRow(info_det);
             ro_empleado_novedad_Info model = new  ro_empleado_novedad_Info();
            model.lst_novedad_det = lst_novedad_det.get_list();
            cargar_combos_detalle();
            return PartialView("_GridViewPartial_empleado_novedad_det", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult EditingUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] ro_empleado_novedad_det_Info info_det)
        {
            if (ModelState.IsValid)
                lst_novedad_det.UpdateRow(info_det);
             ro_empleado_novedad_Info model = new  ro_empleado_novedad_Info();
            model.lst_novedad_det = lst_novedad_det.get_list();
            cargar_combos_detalle();
            return PartialView("_GridViewPartial_empleado_novedad_det", model);
        }

        public ActionResult EditingDelete([ModelBinder(typeof(DevExpressEditorsBinder))] ro_empleado_novedad_det_Info info_det)
        {
            lst_novedad_det.DeleteRow(info_det.Secuencia);
             ro_empleado_novedad_Info model = new  ro_empleado_novedad_Info();
            model.lst_novedad_det = lst_novedad_det.get_list();
            cargar_combos_detalle();
            return PartialView("_GridViewPartial_empleado_novedad_det", model);
        }
    }

    public class ro_empleado_novedad_det_lst
    {
        public List<ro_empleado_novedad_det_Info> get_list()
        {
            if (HttpContext.Current.Session["ro_novedad_detalle_info"] == null)
            {
                List<ro_empleado_novedad_det_Info> list = new List<ro_empleado_novedad_det_Info>();

                HttpContext.Current.Session["ro_novedad_detalle_info"] = list;
            }
            return (List<ro_empleado_novedad_det_Info>)HttpContext.Current.Session["ro_novedad_detalle_info"];
        }

        public void set_list(List<ro_empleado_novedad_det_Info> list)
        {
            HttpContext.Current.Session["ro_novedad_detalle_info"] = list;
        }

        public void AddRow(ro_empleado_novedad_det_Info info_det)
        {
            List<ro_empleado_novedad_det_Info> list = get_list();
            info_det.Secuencia = list.Count == 0 ? 1 : list.Max(q => q.Secuencia) + 1;
            list.Add(info_det);
        }

        public void UpdateRow(ro_empleado_novedad_det_Info info_det)
        {
            ro_empleado_novedad_det_Info edited_info = get_list().Where(m => m.Secuencia == info_det.Secuencia).First();
            edited_info.IdNovedad = info_det.IdNovedad;
            edited_info.IdRubro = info_det.IdRubro;
            edited_info.Valor = info_det.Valor;
        }

        public void DeleteRow(int Secuencia)
        {
            List<ro_empleado_novedad_det_Info> list = get_list();
            list.Remove(list.Where(m => m.Secuencia == Secuencia).First());
        }
    }
}
