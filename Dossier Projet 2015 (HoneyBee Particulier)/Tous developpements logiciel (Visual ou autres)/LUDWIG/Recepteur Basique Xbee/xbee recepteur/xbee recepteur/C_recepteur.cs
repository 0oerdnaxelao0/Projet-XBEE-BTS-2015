using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xbee_recepteur
{
    class C_recepteur
    {
        C_Serie myserie;

        //méthodes publiques
        static public bool communication_init(string port)
        {
            try
            {
                C_Serie.Connexion(port, 9600, 8);
                return true;
            }
            catch
            {
                return false;
            }
        }
        static public void communication_close()
        {
            C_Serie.Deconnexion();
        }

        public C_recepteur()
        {
            myserie = new C_Serie();
        }
    }
}
