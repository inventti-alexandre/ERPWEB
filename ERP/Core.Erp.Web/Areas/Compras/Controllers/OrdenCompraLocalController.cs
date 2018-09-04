﻿using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Erp.Bus.Compras;
using Core.Erp.Bus.CuentasPorPagar;
using Core.Erp.Info.Compras;
using Core.Erp.Web.Helps;
using Core.Erp.Info.Helps;
using Core.Erp.Bus.General;
using Core.Erp.Info.General;
using DevExpress.Web;
using Core.Erp.Info.Inventario;
using Core.Erp.Bus.Inventario;

namespace Core.Erp.Web.Areas.Compras.Controllers
{
    public class OrdenCompraLocalController : Controller
    {
        #region Varibales
            com_ordencompra_local_Bus bus_ordencompra = new com_ordencompra_local_Bus();
            cp_proveedor_Bus bus_proveedor = new cp_proveedor_Bus();
            com_TerminoPago_Bus bus_termino = new com_TerminoPago_Bus();
            com_catalogo_Bus bus_catalogo = new com_catalogo_Bus();
            com_estado_cierre_Bus bus_estado = new com_estado_cierre_Bus();
            com_comprador_Bus bus_comprador = new com_comprador_Bus();
            com_departamento_Bus bus_departamento = new com_departamento_Bus();
            tb_sucursal_Bus bus_sucursal = new tb_sucursal_Bus();
        in_Producto_Bus bus_producto = new in_Producto_Bus();
        com_ordencompra_local_det_List List_det = new com_ordencompra_local_det_List();
        com_ordencompra_local_det_Bus bus_det = new com_ordencompra_local_det_Bus();

        #endregion

        #region Metodos ComboBox bajo demanda proveedor
        tb_persona_Bus bus_persona = new tb_persona_Bus();
        public ActionResult CmbProveedor_COM()
        {
            com_ordencompra_local_Info model = new com_ordencompra_local_Info();
            return PartialView("_CmbProveedor_COM", model);
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

        #region Metodos ComboBox bajo demanda producto

        public ActionResult CmbProducto_Compras()
        {
            decimal model = new decimal();
            return PartialView("_CmbProducto_Compras", model);
        }
        public List<in_Producto_Info> get_list_bajo_demandaProducto(ListEditItemsRequestedByFilterConditionEventArgs args)
        {
            List<in_Producto_Info> Lista = bus_producto.get_list_bajo_demanda(args, Convert.ToInt32(SessionFixed.IdEmpresa), cl_enumeradores.eTipoBusquedaProducto.PORMODULO, cl_enumeradores.eModulo.VTA, 0);
            return Lista;
        }
        public in_Producto_Info get_info_bajo_demandaProducto(ListEditItemRequestedByValueEventArgs args)
        {
            return bus_producto.get_info_bajo_demanda(args, Convert.ToInt32(SessionFixed.IdEmpresa));
        }
        #endregion

        #region Index
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial_ordencompralocal()
        {
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            var model = bus_ordencompra.get_list(IdEmpresa, true);
            return PartialView("_GridViewPartial_ordencompralocal", model);
        }

        private void cargar_combos(int IdEmpresa)
        {
            var lst_termino = bus_termino.get_list(false);
            ViewBag.lst_termino = lst_termino;

            var lst_apro = bus_catalogo.get_list(Convert.ToString(cl_enumeradores.eTipoCatalogoCOM.EST_APRO), false);
            ViewBag.lst_apro = lst_apro;

            var lst_rec = bus_catalogo.get_list(Convert.ToString(cl_enumeradores.eTipoCatalogoCOM.EST_REC), false);
            ViewBag.lst_rec = lst_rec;

            var lst_estado = bus_estado.get_list(false);
            ViewBag.lst_estado = lst_estado;

            var lst_comprador = bus_comprador.get_list(IdEmpresa,false);
            ViewBag.lst_comprador = lst_comprador;

            var lst_sucursal = bus_sucursal.get_list(IdEmpresa, false);
            ViewBag.lst_sucursal = lst_sucursal;

            var lst_dep = bus_departamento.get_list(IdEmpresa, false);
            ViewBag.lst_dep = lst_dep;
        }

        #endregion

        #region Acciones
        public ActionResult Nuevo(int IdEmpresa = 0)
        {
            #region Validar Session
            if (string.IsNullOrEmpty(SessionFixed.IdTransaccionSession))
                return RedirectToAction("Login", new { Area = "", Controller = "Account" });
            SessionFixed.IdTransaccionSession = (Convert.ToDecimal(SessionFixed.IdTransaccionSession) + 1).ToString();
            SessionFixed.IdTransaccionSessionActual = SessionFixed.IdTransaccionSession;
            #endregion

            com_ordencompra_local_Info model = new com_ordencompra_local_Info
            {
                IdEmpresa = IdEmpresa,
                oc_fecha = DateTime.Now,
                oc_fechaVencimiento = DateTime.Now,
                co_fechaReproba = DateTime.Now,
                co_fecha_aprobacion = DateTime.Now,
                IdTransaccionSession = Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual)

            };
            List_det.set_list(model.lst_det, model.IdTransaccionSession);
            cargar_combos(IdEmpresa);
            return View(model);
        }

        [HttpPost]
        public ActionResult Nuevo(com_ordencompra_local_Info model)
        {
            model.IdUsuario = SessionFixed.IdUsuario;
            if (!bus_ordencompra.guardarDB(model))
            {
                cargar_combos(model.IdEmpresa);
                return View(model);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Modificar(int IdEmpresa = 0, int IdSucursal = 0 ,  decimal IdOrdenCompra = 0, int Secuencia = 0)
        {
            #region Validar Session
            if (string.IsNullOrEmpty(SessionFixed.IdTransaccionSession))
                return RedirectToAction("Login", new { Area = "", Controller = "Account" });
            SessionFixed.IdTransaccionSession = (Convert.ToDecimal(SessionFixed.IdTransaccionSession) + 1).ToString();
            SessionFixed.IdTransaccionSessionActual = SessionFixed.IdTransaccionSession;
            #endregion
            com_ordencompra_local_Info model = bus_ordencompra.get_info(IdEmpresa, IdSucursal, IdOrdenCompra);
            if (model == null)
                return RedirectToAction("Index");
            model.IdTransaccionSession = Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual);
            model.lst_det = bus_det.get_list(IdEmpresa, IdSucursal, IdOrdenCompra, Secuencia);
            List_det.set_list(model.lst_det, model.IdTransaccionSession);
            cargar_combos(IdEmpresa);
            return View(model);
        }
        [HttpPost]
        public ActionResult Modificar(com_ordencompra_local_Info model)
        {
            model.IdUsuarioUltMod = SessionFixed.IdUsuario;

            if (!bus_ordencompra.modificarDB(model))
            {
                cargar_combos(model.IdEmpresa);
                return View(model);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Anular(int IdEmpresa = 0, int IdSucursal = 0, decimal IdOrdenCompra = 0, int Secuencia = 0)
        {
            #region Validar Session
            if (string.IsNullOrEmpty(SessionFixed.IdTransaccionSession))
                return RedirectToAction("Login", new { Area = "", Controller = "Account" });
            SessionFixed.IdTransaccionSession = (Convert.ToDecimal(SessionFixed.IdTransaccionSession) + 1).ToString();
            SessionFixed.IdTransaccionSessionActual = SessionFixed.IdTransaccionSession;
            #endregion
            com_ordencompra_local_Info model = bus_ordencompra.get_info(IdEmpresa, IdSucursal, IdOrdenCompra);
            if (model == null)
                return RedirectToAction("Index");
            model.IdTransaccionSession = Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual);
            model.lst_det = bus_det.get_list(IdEmpresa, IdSucursal, IdOrdenCompra, Secuencia);
            List_det.set_list(model.lst_det, model.IdTransaccionSession);
            cargar_combos(IdEmpresa);
            return View(model);
        }
        [HttpPost]
        public ActionResult Anular(com_ordencompra_local_Info model)
        {
            model.IdUsuarioUltAnu = SessionFixed.IdUsuario;

            if (!bus_ordencompra.anularDB(model))
            {
                cargar_combos(model.IdEmpresa);
                return View(model);
            }
            return RedirectToAction("Index");
        }

        #endregion

        #region Grids
        [ValidateInput(false)]
        public ActionResult GridViewPartial_ordencompralocal_det()
        {
            SessionFixed.IdTransaccionSessionActual = Request.Params["TransaccionFixed"] != null ? Request.Params["TransaccionFixed"].ToString() : SessionFixed.IdTransaccionSessionActual;
            var model = List_det.get_list(Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            return PartialView("_GridViewPartial_ordencompralocal_det", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult EditingAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] com_ordencompra_local_det_Info info_det)
        {
            int IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
            List_det.AddRow(info_det, Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            var model = List_det.get_list(Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            return PartialView("_GridViewPartial_ordencompralocal_det", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult EditingUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] com_ordencompra_local_det_Info info_det)
        {
            int IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
            List_det.UpdateRow(info_det, Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            var model = List_det.get_list(Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            return PartialView("_GridViewPartial_ordencompralocal_det", model);
        }

        public ActionResult EditingDelete(int Secuencia)
        {
            List_det.DeleteRow(Secuencia, Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            var model = List_det.get_list(Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            return PartialView("_GridViewPartial_ordencompralocal_det", model);
        }
        #endregion

    }

    public class com_ordencompra_local_det_List
    {
        tb_sis_Impuesto_Bus bus_impuesto = new tb_sis_Impuesto_Bus();
        in_Producto_Bus bus_producto = new in_Producto_Bus();
        string variable = "com_ordencompra_local_det_Info";
        public List<com_ordencompra_local_det_Info> get_list(decimal IdTransaccionSession)
        {
            if (HttpContext.Current.Session[variable + IdTransaccionSession.ToString()] == null)
            {
                List<com_ordencompra_local_det_Info> list = new List<com_ordencompra_local_det_Info>();

                HttpContext.Current.Session[variable + IdTransaccionSession.ToString()] = list;
            }
            return (List<com_ordencompra_local_det_Info>)HttpContext.Current.Session[variable + IdTransaccionSession.ToString()];
        }
        public void set_list(List<com_ordencompra_local_det_Info> list, decimal IdTransaccionSession)
        {
            HttpContext.Current.Session[variable + IdTransaccionSession.ToString()] = list;
        }

        public void AddRow(com_ordencompra_local_det_Info info_det, decimal IdTransaccionSession)
        {
            List<com_ordencompra_local_det_Info> list = get_list(IdTransaccionSession);
            info_det.Secuencia = list.Count == 0 ? 1 : list.Max(q => q.Secuencia) + 1;
            info_det.IdProducto = info_det.IdProducto;
            list.Add(info_det);
        }

        public void UpdateRow(com_ordencompra_local_det_Info info_det, decimal IdTransaccionSession)
        {
            com_ordencompra_local_det_Info edited_info = get_list(IdTransaccionSession).Where(m => m.Secuencia == info_det.Secuencia).First();
            edited_info.IdProducto = info_det.IdProducto;
        }

        public void DeleteRow(int Secuencia, decimal IdTransaccionSession)
        {
            List<com_ordencompra_local_det_Info> list = get_list(IdTransaccionSession);
            list.Remove(list.Where(m => m.Secuencia == Secuencia).First());
        }
    }

}