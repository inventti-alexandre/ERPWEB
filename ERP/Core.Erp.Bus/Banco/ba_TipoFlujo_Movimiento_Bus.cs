﻿using Core.Erp.Data.Banco;
using Core.Erp.Info.Banco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Bus.Banco
{
    public class ba_TipoFlujo_Movimiento_Bus
    {
        ba_TipoFlujo_Movimiento_Data odata = new ba_TipoFlujo_Movimiento_Data();
        public List<ba_TipoFlujo_Movimiento_Info> GetList(int IdEmpresa, bool MostrarAnulado)
        {
            try
            {
                return odata.get_list(IdEmpresa, MostrarAnulado);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ba_TipoFlujo_Movimiento_Info GetInfo(int IdEmpresa, decimal IdMovimiento)
        {
            try
            {
                ba_TipoFlujo_Movimiento_Info info = new ba_TipoFlujo_Movimiento_Info();
                info = odata.get_info(IdEmpresa, IdMovimiento);

                if (info == null)
                    info = new ba_TipoFlujo_Movimiento_Info();

                return info;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool GuardarBD(ba_TipoFlujo_Movimiento_Info info)
        {
            try
            {
                return odata.GuardarBD(info);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool ModificarBD(ba_TipoFlujo_Movimiento_Info info)
        {
            try
            {
                return odata.ModificarBD(info);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool AnularBD(ba_TipoFlujo_Movimiento_Info info)
        {
            try
            {
                return odata.AnularBD(info);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
