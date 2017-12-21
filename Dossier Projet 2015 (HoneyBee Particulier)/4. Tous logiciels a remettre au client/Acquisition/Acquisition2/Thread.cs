using System;
using Microsoft.SPOT;
using System.Threading;

namespace Acquisition
{
    public class Program
    {
        public static void Main()
        {
            //Point d'entrée du programme
            C_Traitement aquisition = new C_Traitement();
            Thread newThread = new Thread(() => aquisition.Traitement()); //Initialiser l'objet thread en passant la méthode à éxécuter  Traitement()
            newThread.Start(); //Exécution du thread
        }

    }
}
