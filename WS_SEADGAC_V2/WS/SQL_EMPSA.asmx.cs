using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;


namespace WS_SEADGAC_V2.WS
{
    /// <summary>
    /// Summary description for SQL_List
    /// </summary>
    [WebService(Namespace = "http://www.ws.seadgacweb.aviacioncivil.gob.ec/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SQL_EMPSA : System.Web.Services.WebService
    {
        private List<SQL_List_WS> lista_IngresoEMPSA;
       
        [WebMethod]
        public List<SQL_List_WS> WebServiceDGAC(string fecha_ini, string fecha_fin, string type, string nacionality)
        {
            SQL_List_WS sql_List_WS;
            lista_IngresoEMPSA = new List<SQL_List_WS>();
            SqlConnection connection = new SqlConnection("Data Source=win-sqlserv-01;Initial Catalog=iFIS_Replica;User ID=WS_QUIAMA;Password=ws.quiama*2018;");
            SqlCommand com;
            SqlDataReader sdr;
            int i = 0;

            try
            {
                String query = " SELECT top 2500 company ,aerodrome ,aerodrome2 ,type ";
                query = query + ",nacionality ,aircraft ,ruta_oaci ,callsign ,number ,registry ";
                query = query + ",date ,capacidad_carga ,tripulacion ,asientos_ofrecidos ,fecha_arribo ";
                query = query + ",fecha_arribo_sh ,mtow ,hora_atd ,tipo_servicio ,Nombre_cia ";
                query = query + ",Servicio ,tipo_transporte ,aeropuerto_operation ,aeropuerto_destino ";
                query = query + ",id_ruta ,id_compania ,id_puntorealdes ,Pax_FF ,Pax_HF ,Pax_INF ";
                query = query + ",CG_trs ,Total_CG ,Total_pax ,CG_equ ,CG_cor ,CG_fl ,CG_pe ,CG_se ";
                query = query + ",Pax_ec ,Pax_cia ,Pax_nad,Pax_trf ,Pax_trs_24 ,Pax_trs ";
                query = query + ",Pax_gps ,Pax_3era ,Pax_pcd, id, id_detalle ";
                query = query + "FROM [iFIS_Replica].[dbo].[vista_reportes3] ";
                if (type.Equals("A")) {
                    query = query + " where aerodrome2 = 'SEQM' ";              
                }
                else if (type.Equals("D")){
                    query = query + " where aerodrome = 'SEQM' ";                
                } else{                
                 query = query + " where aerodrome = 'SEQM' ";
                };
                                
                query = query + " and date between @fecha_ini and @fecha_fin ";
                query = query + " and type = @type ";
                //query = query + "and state_descrip = 'Verificado' ";
                query = query + "and state='1' ";
                query = query + "and nacionality = @nacionality ";
                query = query + "order by company";

                com = new SqlCommand(query, connection);
                com.Parameters.AddWithValue("@fecha_ini", fecha_ini);
                com.Parameters.AddWithValue("@fecha_fin", fecha_fin);
                com.Parameters.AddWithValue("@type", type);
                com.Parameters.AddWithValue("@nacionality", nacionality);

                connection.Open();
                sdr = com.ExecuteReader();
                while (sdr.Read())
                {
                    sql_List_WS = new SQL_List_WS();
                    if (sdr.IsDBNull(0))
                    {
                        sql_List_WS.company = "";
                    }
                    else
                    {
                        sql_List_WS.company = sdr.GetString(0);

                    }
                    if (sdr.IsDBNull(1))
                    {
                        sql_List_WS.aerodrome = "";
                    }
                    else
                    {
                        sql_List_WS.aerodrome = sdr.GetString(1);

                    }
                    if (sdr.IsDBNull(2))
                    {
                        sql_List_WS.aerodrome2 = "";
                    }
                    else
                    {
                        sql_List_WS.aerodrome2 = sdr.GetString(2);

                    }
                    if (sdr.IsDBNull(3))
                    {
                        sql_List_WS.type = "";
                    }
                    else
                    {
                        sql_List_WS.type = sdr.GetString(3);

                    }
                    if (sdr.IsDBNull(4))
                    {
                        sql_List_WS.nacionality = "";
                    }
                    else
                    {
                        sql_List_WS.nacionality = sdr.GetString(4);

                    }
                    if (sdr.IsDBNull(5))
                    {
                        sql_List_WS.aircraft = "";
                    }
                    else
                    {
                        sql_List_WS.aircraft = sdr.GetString(5);

                    }
                    if (sdr.IsDBNull(6))
                    {
                        sql_List_WS.ruta_oaci = "";
                    }
                    else
                    {
                        sql_List_WS.ruta_oaci = sdr.GetString(6);

                    }
                    if (sdr.IsDBNull(7))
                    {
                        sql_List_WS.callsign = "";
                    }
                    else
                    {
                        sql_List_WS.callsign = sdr.GetString(7);

                    }
                    if (sdr.IsDBNull(8))
                    {
                        sql_List_WS.number = "";
                    }
                    else
                    {
                        sql_List_WS.number = sdr.GetString(8);

                    }
                    if (sdr.IsDBNull(9))
                    {
                        sql_List_WS.registry = "";
                    }
                    else
                    {
                        sql_List_WS.registry = sdr.GetString(9);

                    }
                    if (sdr.IsDBNull(10))
                    {
                        sql_List_WS.date = DateTime.UtcNow;
                    }
                    else
                    {
                        sql_List_WS.date =sdr.GetDateTime(10);

                    }
                    if (sdr.IsDBNull(11))
                    {
                        sql_List_WS.capacidad_carga = 0;
                    }
                    else
                    {
                        sql_List_WS.capacidad_carga = sdr.GetInt32(11);

                    }
                    if (sdr.IsDBNull(12))
                    {
                        sql_List_WS.tripulacion = 0;
                    }
                    else
                    {
                        sql_List_WS.tripulacion = sdr.GetInt32(12);

                    }
                    if (sdr.IsDBNull(13))
                    {
                        sql_List_WS.asientos_ofrecidos = 0;
                    }
                    else
                    {
                        sql_List_WS.asientos_ofrecidos = sdr.GetInt32(13);

                    }
                    if (sdr.IsDBNull(14))
                    {
                        sql_List_WS.fecha_arribo = DateTime.UtcNow;
                    }
                    else
                    {
                        sql_List_WS.fecha_arribo =sdr.GetDateTime(14);

                    }

                    if (sdr.IsDBNull(15))
                    {
                        sql_List_WS.fecha_arribo_sh = DateTime.UtcNow;
                    }
                    else
                    {
                        sql_List_WS.fecha_arribo_sh = sdr.GetDateTime(15);

                    }
                   
                    if (sdr.IsDBNull(16))
                    {
                        sql_List_WS.mtow = 0;
                    }
                    else
                    {
                        sql_List_WS.mtow = sdr.GetInt32(16);

                    }
                    if (sdr.IsDBNull(17))
                    {
                        sql_List_WS.hora_atd = "";
                    }
                    else
                    {
                        sql_List_WS.hora_atd = sdr.GetString(17);

                    }
                    if (sdr.IsDBNull(18))
                    {
                        sql_List_WS.tipo_servicio = "";
                    }
                    else
                    {
                        sql_List_WS.tipo_servicio = sdr.GetString(18);

                    }
                    if (sdr.IsDBNull(19))
                    {
                        sql_List_WS.Nombre_cia = "";
                    }
                    else
                    {
                        sql_List_WS.Nombre_cia = sdr.GetString(19);

                    }
                    if (sdr.IsDBNull(20))
                    {
                        sql_List_WS.Servicio = "";
                    }
                    else
                    {
                        sql_List_WS.Servicio = sdr.GetString(20);

                    }
                    if (sdr.IsDBNull(21))
                    {
                        sql_List_WS.tipo_transporte = "";
                    }
                    else
                    {
                        sql_List_WS.tipo_transporte = sdr.GetString(21);

                    }
                    if (sdr.IsDBNull(22))
                    {
                        sql_List_WS.aeropuerto_operation = "";
                    }
                    else
                    {
                        sql_List_WS.aeropuerto_operation = sdr.GetString(22);

                    }
                    if (sdr.IsDBNull(23))
                    {
                        sql_List_WS.aeropuerto_destino = "";
                    }
                    else
                    {
                        sql_List_WS.aeropuerto_destino = sdr.GetString(23);

                    }
                    if (sdr.IsDBNull(24))
                    {
                        sql_List_WS.id_ruta = "";
                    }
                    else
                    {
                        sql_List_WS.id_ruta = sdr.GetString(24);

                    }
                    if (sdr.IsDBNull(25))
                    {
                        sql_List_WS.id_compania = "";
                    }
                    else
                    {
                        sql_List_WS.id_compania = sdr.GetString(25);

                    }
                    if (sdr.IsDBNull(26))
                    {
                        sql_List_WS.id_puntoreales = "";
                    }
                    else
                    {
                        sql_List_WS.id_puntoreales = sdr.GetString(26);

                    }
                    if (sdr.IsDBNull(27))
                    {
                        sql_List_WS.Pax_FF = 0;
                    }
                    else
                    {
                        sql_List_WS.Pax_FF = sdr.GetInt32(27);

                    }
                    if (sdr.IsDBNull(28))
                    {
                        sql_List_WS.Pax_HF= 0;
                    }
                    else
                    {
                        sql_List_WS.Pax_HF = sdr.GetInt32(28);

                    }
                    if (sdr.IsDBNull(29))
                    {
                        sql_List_WS.Pax_INF = 0;
                    }
                    else
                    {
                        sql_List_WS.Pax_INF = sdr.GetInt32(29);

                    }
                    if (sdr.IsDBNull(30))
                    {
                        sql_List_WS.CG_trs = 0;
                    }
                    else
                    {
                        sql_List_WS.CG_trs = sdr.GetInt32(30);

                    }
                    if (sdr.IsDBNull(31))
                    {
                        sql_List_WS.Total_CG = 0;
                    }
                    else
                    {
                        sql_List_WS.Total_CG = sdr.GetInt32(31);

                    }
                    if (sdr.IsDBNull(32))
                    {
                        sql_List_WS.Total_pax = 0;
                    }
                    else
                    {
                        sql_List_WS.Total_pax = sdr.GetInt32(32);

                    }
                    if (sdr.IsDBNull(33))
                    {
                        sql_List_WS.CG_equ= 0;
                    }
                    else
                    {
                        sql_List_WS.CG_equ = sdr.GetInt32(33);

                    }
                    if (sdr.IsDBNull(34))
                    {
                        sql_List_WS.CG_cor = 0;
                    }
                    else
                    {
                        sql_List_WS.CG_cor = sdr.GetInt32(34);

                    }
                    if (sdr.IsDBNull(35))
                    {
                        sql_List_WS.CG_fl = 0;
                    }
                    else
                    {
                        sql_List_WS.CG_fl = sdr.GetInt32(35);

                    }
                    if (sdr.IsDBNull(36))
                    {
                        sql_List_WS.CG_pe = 0;
                    }
                    else
                    {
                        sql_List_WS.CG_pe= sdr.GetInt32(36);

                    }
                    if (sdr.IsDBNull(37))
                    {
                        sql_List_WS.CG_se = 0;
                    }
                    else
                    {
                        sql_List_WS.CG_se = sdr.GetInt32(37);

                    }
                    if (sdr.IsDBNull(38))
                    {
                        sql_List_WS.Pax_ec = 0;
                    }
                    else
                    {
                        sql_List_WS.Pax_ec = sdr.GetInt32(38);

                    }
                    if (sdr.IsDBNull(39))
                    {
                        sql_List_WS.Pax_cia = 0;
                    }
                    else
                    {
                        sql_List_WS.Pax_cia = sdr.GetInt32(39);

                    }
                    if (sdr.IsDBNull(40))
                    {
                        sql_List_WS.Pax_nad = 0;
                    }
                    else
                    {
                        sql_List_WS.Pax_nad = sdr.GetInt32(40);

                    }
                    if (sdr.IsDBNull(41))
                    {
                        sql_List_WS.Pax_trf = 0;
                    }
                    else
                    {
                        sql_List_WS.Pax_trf = sdr.GetInt32(41);

                    }
                   
                    if (sdr.IsDBNull(42))
                    {
                        sql_List_WS.Pax_trs_24 = 0;
                    }
                    else
                    {
                        sql_List_WS.Pax_trs_24 = sdr.GetInt32(42);

                    }
                    if (sdr.IsDBNull(43))
                    {
                        sql_List_WS.Pax_trs = 0;
                    }
                    else
                    {
                        sql_List_WS.Pax_trs = sdr.GetInt32(43);

                    }
                    if (sdr.IsDBNull(44))
                    {
                        sql_List_WS.Pax_gps = 0;
                    }
                    else
                    {
                        sql_List_WS.Pax_gps = sdr.GetInt32(44);

                    }
                    if (sdr.IsDBNull(45))
                    {
                        sql_List_WS.Pax_3era = 0;
                    }
                    else
                    {
                        sql_List_WS.Pax_3era = sdr.GetInt32(45);

                    }
                    if (sdr.IsDBNull(46))
                    {
                        sql_List_WS.Pax_pcd = 0;
                    }
                    else
                    {
                        sql_List_WS.Pax_pcd = sdr.GetInt32(46);

                    }
                    if (sdr.IsDBNull(47))
                    {
                        sql_List_WS.id = 0;
                    }
                    else
                    {
                        sql_List_WS.id = sdr.GetInt64(47);

                    }
                    if (sdr.IsDBNull(48))
                    {
                        sql_List_WS.id_detalle = 0;
                    }
                    else
                    {
                        sql_List_WS.id_detalle = sdr.GetInt64(48);

                    }

                    lista_IngresoEMPSA.Add(sql_List_WS);
                }
                connection.Close();
            }
            catch (Exception)
            {
                return null;
            }

            return lista_IngresoEMPSA;

        }
    }
}
