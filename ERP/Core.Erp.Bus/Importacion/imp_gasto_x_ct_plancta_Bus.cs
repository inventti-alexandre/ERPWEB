﻿using Core.Erp.Data.Importacion;
using Core.Erp.Info.Importacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Bus.Importacion
{
    public class imp_gasto_x_ct_plancta_Bus
    {
        imp_gasto_x_ct_plancta_Data odata = new imp_gasto_x_ct_plancta_Data();
    
        public List<imp_gasto_x_ct_plancta_Info> get_list(int IdEmpresa, int IdGasto_tipo)
        {
            try
            {
                return odata.get_list(IdEmpresa, IdGasto_tipo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool guardarDB(imp_gasto_x_ct_plancta_Info info)
        {
            try
            {
                return odata.guardarDB(info);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool eliminarDB(int IdEmpresa, int IdGasto_tipo)
        {
            try
            {
                return odata.eliminarDB(IdEmpresa, IdGasto_tipo);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
