﻿using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Erp.Bus.RRHH;
using Core.Erp.Info.RRHH;
using Core.Erp.Info.General;
using Core.Erp.Bus.General;
using Core.Erp.Bus.Contabilidad;
using DevExpress.Web;
using System.IO;
using Microsoft.SqlServer.Server;
using Core.Erp.Web.Helps;

namespace Core.Erp.Web.Areas.RRHH.Controllers
{
    public class EmpleadoController : Controller
    {
        #region variables

        int IdEmpresa = 0;
        Bus.RRHH.ro_empleado_Bus bus_empleado = new Bus.RRHH.ro_empleado_Bus();
        tb_Catalogo_Bus bus_catalogo_general = new tb_Catalogo_Bus();
        ro_catalogo_Bus bus_catalogorrhh = new ro_catalogo_Bus();
        tb_banco_Bus bus_banco = new tb_banco_Bus();
        ro_cargo_Bus bus_cargo = new ro_cargo_Bus();
        ro_departamento_Bus bus_departamento = new ro_departamento_Bus();
        ro_division_Bus bus_division = new ro_division_Bus();
        ro_area_Bus bus_area = new ro_area_Bus();
        tb_pais_Bus bus_pais = new tb_pais_Bus();
        tb_provincia_Bus bus_provincia = new tb_provincia_Bus();
        tb_ciudad_Bus bus_ciudad = new tb_ciudad_Bus();
        ct_punto_cargo_Bus bus_puntocargo = new ct_punto_cargo_Bus();
        ro_horario_Bus bus_horario = new ro_horario_Bus();
        tb_sucursal_Bus bus_sucursal = new tb_sucursal_Bus();
        public static byte[] imagen { get; set; }
        public decimal IdEmpleado { get; set; }
        public static UploadedFile file { get; set; }
        public string UploadDirectory = "~/Content/imagenes/empleados";

        #endregion
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial_empleados()
        {
            try
            {
                IdEmpresa = GetIdEmpresa();
                List<ro_empleado_Info> model = bus_empleado.get_list(IdEmpresa, false);
                return PartialView("_GridViewPartial_empleados", model);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public ActionResult Nuevo(ro_empleado_Info info)
        {
            try
            {
                string mensaje = "";
                mensaje = Validar(info);
                if (mensaje != "")
                {
                    if (info.em_foto == null)
                        info.em_foto = new byte[0];
                    ViewBag.mensaje = mensaje;
                    cargar_combos();
                    return View(info);
                }
                info.IdEmpresa = GetIdEmpresa();
                if (!bus_empleado.guardarDB(info))
                {
                    if (info.em_foto == null)
                        info.em_foto = new byte[0];
                    cargar_combos();
                    return View(info);
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                if (info.em_foto == null)
                    info.em_foto = new byte[0];
                throw;
            }
        }
        public ActionResult Nuevo()
        {
            try
            {

                cargar_combos();
                ro_empleado_Info info = new ro_empleado_Info
                {
                    em_fechaIngaRol = DateTime.Now,
                    em_fechaSalida = DateTime.Now,
                    IdSucursal = 1
                };
                info.em_foto = new byte[0];

                return View(info);

            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public ActionResult Modificar(ro_empleado_Info info)
        {
            try
            {
                string mensaje = "";
                mensaje = Validar(info);
                if (mensaje != "")
                {
                    if (info.em_foto == null)
                        info.em_foto = new byte[0];
                    ViewBag.mensaje = mensaje;
                    cargar_combos();
                    return View(info);
                }
                info.IdEmpresa = GetIdEmpresa();
                if (!bus_empleado.modificarDB(info))
                {
                    if (info.em_foto == null)
                        info.em_foto = new byte[0];
                    cargar_combos();
                    return View(info);
                }
                return RedirectToAction("Index");

            }
            catch (Exception)
            {
                if (info.em_foto == null)
                    info.em_foto = new byte[0];

                throw;
            }
        }

        public ActionResult Modificar(int Idempleado = 0)
        {
            try
            {
                cargar_combos();
                ro_empleado_Info info = new ro_empleado_Info();
                info = bus_empleado.get_info(GetIdEmpresa(), Idempleado);
                if (info.em_foto == null)
                    info.em_foto = new byte[0];

                try
                {
                    ViewBag.foto = info.IdEmpresa.ToString() + info.IdEmpleado.ToString() + ".jpg";

                    info.em_foto = System.IO.File.ReadAllBytes(Server.MapPath(UploadDirectory) + info.IdEmpresa.ToString() + info.IdEmpleado.ToString() + ".jpg");
                }
                catch (Exception)
                {

                    info.em_foto = new byte[0];
                }

                return View(info);

            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]

        public ActionResult Anular(ro_empleado_Info info)
        {
            try
            {
                string mensaje = "";
                mensaje = Validar(info);
                if (mensaje != "")
                {
                    if (info.em_foto == null)
                        info.em_foto = new byte[0];
                    ViewBag.mensaje = mensaje;
                    cargar_combos();
                    return View(info);
                }
                info.IdEmpresa = GetIdEmpresa();
                if (!bus_empleado.anularDB(info))
                {
                    if (info.em_foto == null)
                        info.em_foto = new byte[0];
                    cargar_combos();
                    return View(info);
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                if (info.em_foto == null)
                    info.em_foto = new byte[0];

                throw;
            }
        }
        public ActionResult Anular(int Idempleado = 0)
        {
            try
            {
                IdEmpresa = GetIdEmpresa();
                cargar_combos();
                ro_empleado_Info info = new ro_empleado_Info();
                info = bus_empleado.get_info(GetIdEmpresa(), Idempleado);
                if (info.em_foto == null)
                    info.em_foto = new byte[0];

                try
                {

                    info.em_foto = System.IO.File.ReadAllBytes(Server.MapPath(UploadDirectory) + info.IdEmpresa.ToString() + info.IdEmpleado.ToString() + ".jpg");
                }
                catch (Exception)
                {

                    info.em_foto = new byte[0];
                }

                return View(info);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult Consulta(int Idempleado = 0)
        {
            try
            {
                cargar_combos();
                IdEmpresa = GetIdEmpresa();
                return View(bus_empleado.get_info(IdEmpresa, Idempleado));

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
        private void cargar_combos()
        {
            try
            {
                IdEmpresa = GetIdEmpresa();
                ViewBag.lst_area = bus_area.get_list(IdEmpresa, false);
                ViewBag.lst_banco = bus_banco.get_list(false);
                ViewBag.lst_cargo = bus_cargo.get_list(IdEmpresa, false);
                ViewBag.lst_division = bus_division.get_list(IdEmpresa, false);
                ViewBag.lst_departamento = bus_departamento.get_list(IdEmpresa, false);
                ViewBag.lst_documento = bus_catalogo_general.get_list(3, false);
                ViewBag.lst_sexo = bus_catalogo_general.get_list(1, false);
                ViewBag.lst_estado_civil = bus_catalogo_general.get_list(2, false);
                ViewBag.lst_tipo_docu = bus_catalogo_general.get_list(3, false);
                ViewBag.lst_estado_empleado = bus_catalogorrhh.get_list_x_tipo(25);
                ViewBag.lst_pais = bus_pais.get_list(false);
                ViewBag.lst_ciudad = bus_ciudad.get_list("", false);
                ViewBag.lst_empleado = bus_empleado.get_list_combo(IdEmpresa);
                ViewBag.lst_punto_cargo = bus_puntocargo.get_list(IdEmpresa, false);
                ViewBag.lst_horario = bus_horario.get_list(IdEmpresa, false);
                ViewBag.lst_tipo_discapacidad = bus_catalogorrhh.get_list_x_tipo(26);
                ViewBag.lst_tipo_doc_sustutuido = bus_catalogorrhh.get_list_x_tipo(29);
                ViewBag.lst_tipo_sangre = bus_catalogorrhh.get_list_x_tipo(7);
                ViewBag.lst_tipo_licencia = bus_catalogorrhh.get_list_x_tipo(10);
                ViewBag.lst_tipo_cuenta = bus_catalogorrhh.get_list_x_tipo(9);
                ViewBag.lst_tipo_empleado = bus_catalogorrhh.get_list_x_tipo(8);
                ViewBag.lst_sucursal = bus_sucursal.get_list(IdEmpresa, false);


            }
            catch (Exception)
            {
                throw;
            }
        }

        private string Validar(ro_empleado_Info info)
        {
            try
            {
                string mensaje = "";
                if (info.pe_cedulaRuc == "")
                {
                    mensaje = "El campo cédula es obligatoria";
                }
                if (info.pe_nombre == "" | info.pe_nombre == null)
                {
                    mensaje = "El campo nombres es obligatoria";
                }
                if (info.pe_apellido == "" | info.pe_apellido == null)
                {
                    mensaje = "El campo apellidos es obligatoria";
                }
                if (info.pe_correo == "" | info.pe_correo == null)
                {
                    mensaje = "El campo correo es obligatoria";
                }
                if (info.pe_fechaNacimiento == null)
                {
                    mensaje = "El campo fecha nacimiento es obligatoria";
                }
                if (info.pe_celular == "" | info.pe_celular == null)
                {
                    mensaje = "El campo fecha nacimiento es obligatoria";
                }

                return mensaje;
            }
            catch (Exception)
            {

                throw;
            }
        }
      
        public ActionResult DragAndDropImageUpload([ModelBinder(typeof(DragAndDropSupportDemoBinder))]IEnumerable<UploadedFile> ucDragAndDrop)
        {

            //Extract Image File Name.
            string fileName = System.IO.Path.GetFileName(ucDragAndDrop.FirstOrDefault().FileName);

            //Set the Image File Path.
            UploadDirectory = UploadDirectory + SessionFixed.IdEmpresa + SessionFixed.NombreImagen + ".jpg";
            imagen = ucDragAndDrop.FirstOrDefault().FileBytes;
            //Save the Image File in Folder.
            ucDragAndDrop.FirstOrDefault().SaveAs(Server.MapPath(UploadDirectory));
            SessionFixed.NombreImagen = UploadDirectory;

            file = ucDragAndDrop.FirstOrDefault();
            return Json(ucDragAndDrop.FirstOrDefault().FileBytes, JsonRequestBehavior.AllowGet);


        }

        public JsonResult nombre_imagen(decimal IdEmpleado = 0)
        {
            try
            {
                if (IdEmpleado == 0)
                    IdEmpleado = bus_empleado.get_id(Convert.ToInt32(SessionFixed.IdEmpresa));
                SessionFixed.NombreImagen = IdEmpleado.ToString();
                return Json("", JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                return Json("", JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult actualizar_div()
        {
            return Json(SessionFixed.NombreImagen, JsonRequestBehavior.AllowGet);
        }

    }


    public class DragAndDropSupportDemoBinder : DevExpressEditorsBinder
    {
        public DragAndDropSupportDemoBinder()
        {
            UploadControlBinderSettings.ValidationSettings.Assign(UploadControlDemosHelper.UploadValidationSettings);
            UploadControlBinderSettings.FileUploadCompleteHandler = UploadControlDemosHelper.FileUploadComplete;
        }
    }
    public class UploadControlDemosHelper
    {
        public static byte[] em_foto { get; set; }
        public static DevExpress.Web.UploadControlValidationSettings UploadValidationSettings = new DevExpress.Web.UploadControlValidationSettings()
        {
            AllowedFileExtensions = new string[] { ".jpg", ".jpeg", ".png" },
            MaxFileSize = 4000000
        };
        public static void FileUploadComplete(object sender, DevExpress.Web.FileUploadCompleteEventArgs e)
        {

            if (e.UploadedFile.IsValid)
            {
                em_foto = e.UploadedFile.FileBytes;
                //var filename = Path.GetFileName(e.UploadedFile.FileName);
                //e.UploadedFile.SaveAs("~/Content/imagenes/"+e.UploadedFile.FileName, true);
            }
        }







    }

    public class ro_empleado_info_list
    {
        string variable = "ro_empleado_Info";
        public List<ro_empleado_Info> get_list()
        {
            if (HttpContext.Current.Session[variable] == null)
            {
                List<ro_empleado_Info> list = new List<ro_empleado_Info>();

                HttpContext.Current.Session[variable] = list;
            }
            return (List<ro_empleado_Info>)HttpContext.Current.Session[variable];
        }

        public void set_list(List<ro_empleado_Info> list)
        {
            HttpContext.Current.Session[variable] = list;
        }


    }
}
