using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ListadoDeFirmasDSP
{
    public class PassGenerate
    {

        public static string MakePassword(string pwdchars, int pwdlen)
        {
            string tmpstr = "";
            int iRandNum;
            Random rnd = new Random();
            for (int i = 0; i < pwdlen; i++)
            {
                iRandNum = rnd.Next(pwdchars.Length);
                tmpstr += pwdchars[iRandNum];
            }
            return tmpstr;


         
        }
    }


}