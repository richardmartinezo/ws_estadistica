using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_SEADGAC_V2.WS
{
    public class SQL_List_WS
    {

        public Int64 id { get; set; }
        public Int64 id_detalle { get; set; }
        public string company { get; set; }
        public string aerodrome { get; set; }
        public string aerodrome2 { get; set; }
        public string type { get; set; }
        public string nacionality { get; set; }
        public string aircraft { get; set; }
        public string ruta_oaci { get; set; }
        public string callsign { get; set; }
        public string number { get; set; }

        public string registry { get; set; }
        public DateTime date { get; set; }
        public Int32 capacidad_carga { get; set; }
        public Int32 tripulacion { get; set; }
        public Int32 asientos_ofrecidos { get; set; }
        public DateTime fecha_arribo { get; set; }
        public DateTime fecha_arribo_sh { get; set; }
        public Int32 mtow { get; set; }
        public string hora_atd { get; set; }
        public string tipo_servicio { get; set; }
        public string Nombre_cia { get; set; }
        public string Servicio { get; set; }
        public string tipo_transporte { get; set; }
        public string aeropuerto_operation { get; set; }
        public string aeropuerto_destino { get; set; }
        public string id_ruta { get; set; }
        public string id_compania { get; set; }
        public string id_puntoreales { get; set; }
        public Int32 Pax_FF { get; set; }
        public Int32 Pax_HF { get; set; }
        public Int32 Pax_INF { get; set; }
        public Int32 CG_trs { get; set; }
        public Int32 Total_CG { get; set; }
        public Int32 Total_pax { get; set; }
        public Int32 CG_equ { get; set; }
        public Int32 CG_cor { get; set; }
        public Int32 CG_fl { get; set; }
        public Int32 CG_pe { get; set; }
        public Int32 CG_se { get; set; }
        public Int32 Pax_ec { get; set; }
        public Int32 Pax_cia { get; set; }
        public Int32 Pax_nad { get; set; }
        public Int32 Pax_trf { get; set; }
        public Int32 Pax_trs_24 { get; set; }
        public Int32 Pax_trs { get; set; }
        public Int32 Pax_gps { get; set; }
        public Int32 Pax_3era { get; set; }
        public Int32 Pax_pcd { get; set; }
    }
}