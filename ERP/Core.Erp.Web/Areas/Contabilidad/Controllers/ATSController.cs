﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Erp.Info.Contabilidad.ATS.ATS_Info;
using Core.Erp.Bus.Contabilidad;
using Core.Erp.Info.Helps;
using Core.Erp.Web.Helps;
using Core.Erp.Info.Contabilidad.ATS;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Text;
using DevExpress.Web.Mvc;
using DevExpress.Web;
using DevExpress.Utils;
using Core.Erp.Bus.Helps;

namespace Core.Erp.Web.Areas.Contabilidad.Controllers
{
    [SessionTimeout]
    public class ATSController : Controller
    {
        #region Acciones
        ats_Bus bus_ats = new ats_Bus();
        FilesHelper_Bus FilesHelper_B = new FilesHelper_Bus();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Nuevo()
        {
            ats_Info model = new ats_Info();
            cargar_combos();
            return View(model);
        }
        [HttpPost]
        public FileResult Nuevo(ats_Info model)
        {

            model.info_periodo.IdPeriodo =Convert.ToInt32( Session["IdPeriodo"]) ;
            bus_ats = new ats_Bus();
            string nombre_file = model.info_periodo.IdPeriodo.ToString();
            if (model.info_periodo.IdPeriodo.ToString().Length == 6)
            {
                nombre_file = "AT-" + model.info_periodo.IdPeriodo.ToString().Substring(4, 2) + model.info_periodo.IdPeriodo.ToString().Substring(0, 4);
            }
            string xml = "";
            iva ats = new iva();
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            int IdSucursal = Convert.ToInt32(SessionFixed.IdSucursal);
            ats = bus_ats.get_ats(IdEmpresa, model.info_periodo.IdPeriodo, IdSucursal);
            var ms = new MemoryStream();
            var xw = XmlWriter.Create(ms);


            var serializer = new XmlSerializer(ats.GetType());
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            serializer.Serialize(xw, ats, ns);
            xw.Flush();
            ms.Seek(0, SeekOrigin.Begin);
            using (var sr = new StreamReader(ms, Encoding.UTF8))
            {
                xml = sr.ReadToEnd();
            }
            byte[] fileBytes = ms.ToArray();         
            return File(fileBytes, "application/xml", nombre_file+".xml");


        }

        #endregion

        #region Grids

        public ActionResult GridViewPartial_ventas()
        {
            List<ventas_Info> model = new List<ventas_Info>();
            model=Session["lst_ventas"] as List<ventas_Info>;
            return PartialView("_GridViewPartial_ventas", model);
        }
        public ActionResult GridViewPartial_compras()
        {
            List<compras_Info> model = new List<compras_Info>();
            model = Session["lst_compras"] as List<compras_Info>;

            return PartialView("_GridViewPartial_compras", model);
        }
        public ActionResult GridViewPartial_retenciones()
        {
            List<retenciones_Info> model = new List<retenciones_Info>();
          model=  Session["lst_retenciones"] as List<retenciones_Info>;

            return PartialView("_GridViewPartial_retenciones", model);
        }
        public ActionResult GridViewPartial_exportaciones()
        {
            List<exportaciones_Info> model = new List<exportaciones_Info>();
            model = Session["lst_exportaciones"] as List<exportaciones_Info>;

            return PartialView("_GridViewPartial_exportaciones", model);
        }
        public ActionResult GridViewPartial_anulados()
        {
            List<comprobantesAnulados_info> model = new List<comprobantesAnulados_info>();
            model = Session["lst_anulados"] as List<comprobantesAnulados_info>;

            return PartialView("_GridViewPartial_anulados", model);
        }

        #endregion

        #region Metodos
        private void cargar_combos()
        {
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            ct_periodo_Bus bus_periodo = new ct_periodo_Bus();
            var lst_periodos = bus_periodo.get_list(IdEmpresa, false);


            ViewBag.lst_periodos = lst_periodos;

        }

        #endregion

        #region json
        public JsonResult get_ats(int IdPeriodo)
        {
            bus_ats = new ats_Bus();
            ats_Info model = new ats_Info();
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            model = bus_ats.get_info(IdEmpresa, IdPeriodo);
            Session["lst_compras"] = model.lst_compras;
            Session["lst_ventas"] = model.lst_ventas;
            Session["lst_retenciones"] = model.lst_retenciones;
            Session["lst_exportaciones"] = model.lst_exportaciones;
            Session["lst_anulados"] = model.lst_anulados;
            Session["IdPeriodo"] = IdPeriodo;

            return Json("", JsonRequestBehavior.AllowGet);
        }
        #endregion

        public class HomeControllerControllerUploadControlSettings
        {
            public static DevExpress.Web.UploadControlValidationSettings UploadControlValidationSettings = new DevExpress.Web.UploadControlValidationSettings()
            {
                MaxFileSize = 4194304
            };
        }
    
    }
}