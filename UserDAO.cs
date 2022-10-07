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

        public UserData Login(string usuario, string pass)
        {
            SqlConnection conexionBD = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnFirmasDSP"].ToString());

            using (var conDB = conexionBD)
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
                    UserData userData = new UserData();
                    if (reader.Read())
                    {

                        userData.token = reader.GetInt32(0);
                        userData.idUsuario = reader.GetInt32(1);
                        userData.jurisdiccion_id = reader.GetInt32(2);
                        userData.nombre = reader.GetString(3);
                        userData.Usuario = reader.GetString(4);
                        userData.Estatus = reader.GetString(7);
                        userData.clave = reader.GetString(8);
                        userData.NombreJuris = reader.GetString(9);
                        userData.TipoUsuario = reader.GetString(10);
                        userData.RFC = reader.GetString(11);
                        userData.CURP = reader.GetString(12);
                        userData.CorreoElectronico = reader.GetString(13);
                        

                        


                        return userData;
                     
                    }
                    else
                    {
                        /*userData.token = reader.GetInt32(0);*/
                        return userData;
                    }


                }
            }


        }





    }
}