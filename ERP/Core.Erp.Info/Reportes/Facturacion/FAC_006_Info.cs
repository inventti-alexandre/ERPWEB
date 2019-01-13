﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Info.Reportes.Facturacion
{
    public class FAC_006_Info
    {
        public int IdEmpresa { get; set; }
        public string Su_CodigoEstablecimiento { get; set; }
        public string Su_Descripcion { get; set; }
        public string Su_Direccion { get; set; }
        public string Su_Telefonos { get; set; }
        public int IdSucursal { get; set; }
        public decimal IdCliente { get; set; }
        public string nombre_cliente { get; set; }
        public string ced_ruc_cliente { get; set; }
        public string direccion_cliente { get; set; }
        public string celular_cliente { get; set; }
        public string telefono_cliente { get; set; }
        public decimal IdProforma { get; set; }
        public int Secuencia { get; set; }
        public string nom_TerminoPago { get; set; }
        public int pf_plazo { get; set; }
        public string pf_codigo { get; set; }
        public System.DateTime pf_fecha { get; set; }
        public bool estado { get; set; }
        public string pf_atencion_a { get; set; }
        public string Codigo { get; set; }
        public string Ve_Vendedor { get; set; }
        public double pd_cantidad { get; set; }
        public double pd_precio { get; set; }
        public double pd_por_descuento_uni { get; set; }
        public double pd_descuento_uni { get; set; }
        public double pd_precio_final { get; set; }
        public double pd_subtotal { get; set; }
        public double pd_por_iva { get; set; }
        public double pd_iva { get; set; }
        public double pd_total { get; set; }
        public string pr_observacion { get; set; }
        public decimal IdProducto { get; set; }
        public int pr_dias_entrega { get; set; }
        public string pf_observacion { get; set; }
    }
}
