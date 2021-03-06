﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Erp.Info.RRHH;
using Core.Erp.Bus.RRHH;
using Core.Erp.Web.Helps;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using Core.Erp.Info.Helps;

namespace Core.Erp.Web.Areas.RRHH.Controllers
{
    public class PagoBenediciosSocialesController : Controller
    {
        #region MyRegion
        int IdEmpresa = 0;
        ro_rol_Bus bus_rol = new ro_rol_Bus();
        #endregion

        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial_pago_beneficios(int IdEmpresa=0, int IdSucursal=0)
        {
            try
            {
                IdEmpresa = GetIdEmpresa();
                List<ro_rol_Info> model = bus_rol.get_list_decimos(IdEmpresa, IdSucursal);
                return PartialView("_GridViewPartial_pago_beneficios", model);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public ActionResult Nuevo(ro_rol_Info info)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    info.UsuarioIngresa = Session["IdUsuario"].ToString();
                    info.IdEmpresa = GetIdEmpresa();
                    if (!bus_rol.Decimos(info))
                        return View(info);
                    else
                        return RedirectToAction("Index");
                }
                else
                    return View(info);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult Nuevo()
        {
            try
            {
                cargar_combos(0, 0);
                ro_rol_Info info = new ro_rol_Info();
                info.Anio = DateTime.Now.Year;
                return View(info);

            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public ActionResult Modificar(ro_rol_Info info)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    info.IdEmpresa = GetIdEmpresa();
                    info.UsuarioIngresa = SessionFixed.IdUsuario;
                    if (!bus_rol.Decimos(info))
                    {
                        cargar_combos(info.IdNomina_Tipo, info.IdNomina_TipoLiqui);
                        return View(info);
                    }
                    else
                        return RedirectToAction("Index");
                }
                else
                    return View(info);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult Modificar(int IdNomina_Tipo = 0, int IdNomina_TipoLiqui = 0, int IdPeriodo = 0, decimal IdRol=0)
        {
            try
            {
                ro_rol_Info model = new ro_rol_Info();
                cargar_combos(IdNomina_Tipo, IdNomina_TipoLiqui);
                IdEmpresa = GetIdEmpresa();
                model=bus_rol.get_info(IdEmpresa, IdNomina_Tipo, IdNomina_TipoLiqui, IdPeriodo, IdRol);
                if (model.IdNomina_TipoLiqui == 3)
                    model.decimoIII = true;
                else
                    model.decimoIV = true;
                return View(model);

            }
            catch (Exception)
            {

                throw;
            }
        }

        private int GetIdEmpresa()
        {
            try
            {
                if (Session["IdEmpresa"] != null)
                    return Convert.ToInt32(Session["IdEmpresa"]);
                else
                    return 0;
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void cargar_combos(int IdNomina_Tipo, int IdNomina_Tipo_Liqui)
        {
            try
            {
                

            }
            catch (Exception)
            {

                throw;
            }
        }

        
        public FileResult GetCSV(int IdRol=0,int IdNomina_TipoLiqui = 0)
        {
            ro_archivosCSV_Bus bus_archivos = new ro_archivosCSV_Bus();
            string archivo = "";
            string NombreFile = "";

            var listado = bus_archivos.get_lis(Convert.ToInt32(SessionFixed.IdEmpresa), IdRol, 950);
            if (IdNomina_TipoLiqui == 3)
            {
                NombreFile = "Decimo III";
                archivo = bus_archivos.Get_decimoIII(listado);
            }
            else
            { 
                NombreFile = "Decimo IV";

                archivo = bus_archivos.Get_decimoIII(listado);
            }
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(archivo);
            return File(byteArray, "application/xml", NombreFile + ".csv");


        }
        

    }
}