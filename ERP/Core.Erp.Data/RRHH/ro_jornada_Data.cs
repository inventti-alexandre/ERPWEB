﻿using Core.Erp.Info.RRHH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Data.RRHH
{
    public class ro_jornada_Data
    {
        public List<ro_jornada_Info> get_list(int IdEmpresa, bool mostrar_anulados)
        {
            try
            {
                List<ro_jornada_Info> Lista;

                using (Entities_rrhh Context = new Entities_rrhh())
                {
                    if (mostrar_anulados)
                        Lista = (from q in Context.ro_jornada
                                 where q.IdEmpresa == IdEmpresa
                                 select new ro_jornada_Info
                                 {
                                     IdEmpresa = q.IdEmpresa,
                                     IdJornada = q.IdJornada,
                                     codigo = q.codigo,
                                     Descripcion = q.Descripcion,
                                     estado = q.estado
                                 }).ToList();
                    else
                        Lista = (from q in Context.ro_jornada
                                 where q.IdEmpresa == IdEmpresa
                                 && q.estado == true
                                 select new ro_jornada_Info
                                 {
                                     IdEmpresa = q.IdEmpresa,
                                     IdJornada = q.IdJornada,
                                     codigo = q.codigo,
                                     Descripcion = q.Descripcion,
                                     estado = q.estado
                                 }).ToList();
                }

                return Lista;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ro_jornada_Info get_info(int IdEmpresa, int IdJornada)
        {
            try
            {
                ro_jornada_Info info = new ro_jornada_Info();

                using (Entities_rrhh Context = new Entities_rrhh())
                {
                    ro_jornada Entity = Context.ro_jornada.FirstOrDefault(q => q.IdEmpresa == IdEmpresa && q.IdJornada == IdJornada);
                    if (Entity == null) return null;

                    info = new ro_jornada_Info
                    {
                        IdEmpresa = Entity.IdEmpresa,
                        IdJornada = Entity.IdJornada,
                        codigo = Entity.codigo,
                        Descripcion = Entity.Descripcion,
                        estado = Entity.estado
                    };
                }

                return info;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int get_id(int IdEmpresa)
        {
            try
            {
                int ID = 1;

                using (Entities_rrhh Context = new Entities_rrhh())
                {
                    var lst = from q in Context.ro_jornada
                              where q.IdEmpresa == IdEmpresa
                              select q;

                    if (lst.Count() > 0)
                        ID = lst.Max(q => q.IdJornada) + 1;
                }

                return ID;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool guardarDB(ro_jornada_Info info)
        {
            try
            {
                using (Entities_rrhh Context = new Entities_rrhh())
                {
                    ro_jornada Entity = new ro_jornada
                    {
                        IdEmpresa = info.IdEmpresa,
                        IdJornada = info.IdJornada = get_id(info.IdEmpresa),
                        codigo = info.codigo,
                        Descripcion = info.Descripcion,
                        estado = info.estado = true,
                        IdUsuario = info.IdUsuario,
                        Fecha_Transac = info.Fecha_Transac = DateTime.Now
                    };
                    Context.ro_jornada.Add(Entity);
                    Context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool modificarDB(ro_jornada_Info info)
        {
            try
            {
                using (Entities_rrhh Context = new Entities_rrhh())
                {
                    ro_jornada Entity = Context.ro_jornada.FirstOrDefault(q => q.IdEmpresa == info.IdEmpresa && q.IdJornada == info.IdJornada);
                    if (Entity == null)
                        return false;
                    Entity.codigo = info.codigo;
                    Entity.Descripcion = info.Descripcion;
                    Entity.IdUsuarioUltMod = info.IdUsuarioUltMod;
                    Entity.Fecha_UltMod = info.Fecha_UltMod = DateTime.Now;
                    Context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool anularDB(ro_jornada_Info info)
        {
            try
            {
                using (Entities_rrhh Context = new Entities_rrhh())
                {
                    ro_jornada Entity = Context.ro_jornada.FirstOrDefault(q => q.IdEmpresa == info.IdEmpresa && q.IdJornada == info.IdJornada);
                    if (Entity == null)
                        return false;
                    Entity.estado = info.estado = false;

                    Entity.IdUsuarioUltAnu = info.IdUsuarioUltAnu;
                    Entity.Fecha_UltAnu = info.Fecha_UltAnu = DateTime.Now;
                    Context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
