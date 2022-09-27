using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ListadoDeFirmasDSP
{
    public class UserModel
    {

        UserDAO UserDAO = new UserDAO();


        public UserData LoginUser(string usuario, string pass)
        {
            return UserDAO.Login(usuario, pass);
        }



    }


}