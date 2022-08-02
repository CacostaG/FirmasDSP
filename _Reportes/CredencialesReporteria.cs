using System.Security.Principal;
using System.Net;

namespace ListadoDeFirmasDSP._Reportes
{
    public class CredencialesReporteria : Microsoft.Reporting.WebForms.IReportServerCredentials
    {

        private string _UserName;
        private string _PassWord;
        private string _DomainName;

        public CredencialesReporteria(string UserName, string PassWord, string DomainName)
        {
            _UserName = UserName;
            _PassWord = PassWord;
            _DomainName = DomainName;
        }

        public CredencialesReporteria(string UserName, string PassWord)
        {
            _UserName = UserName;
            _PassWord = PassWord;

        }
        public WindowsIdentity ImpersonationUser
        {
            get
            {
                return null;
            }

        }
        public ICredentials NetworkCredentials
        {
            get
            {
                return new NetworkCredential(_UserName, _PassWord);
            }
        }


        public bool GetFormsCredentials(out Cookie authCookie, out string user, out string password, out string authority)
        {
            authCookie = null;
            user = password = authority = null;
            return false;
        }

    }
}
