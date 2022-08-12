using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using ListadoDeFirmasDSP.GauDes;
using System.Data.Sql;
using System.Data.SqlTypes;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Reporting.Map.WebForms.BingMaps;

namespace ListadoDeFirmasDSP
{
    public class UserDAO
    {
        public bool Login(string usuario, string pass)
        {
            SqlConnection conexionBD = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnFirmasDSP"].ToString());

            using(var conDB = conexionBD)
            {
                conDB.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conDB;
                    SqlCommand command = new SqlCommand("spDSP_Usuarios", conDB);
                    command.Parameters.AddWithValue("@usuario", usuario);
                    command.Parameters.AddWithValue("@pass", pass);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    if(reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            UserData.token = reader.GetInt32(0);
                            UserData.idUsuario = reader.GetInt32(1);
                            UserData.jurisdiccion_id = reader.GetInt32(2);
                            UserData.nombre = reader.GetString(3);
                            UserData.Usuario = reader.GetString(4);
                            UserData.Estatus = reader.GetString(7);
                            UserData.clave = reader.GetString(8);
                            UserData.NombreJuris = reader.GetString(9);
                            UserData.TipoUsuario = reader.GetString(10);
                          
                            
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    

                }
            }


        }
    }
}