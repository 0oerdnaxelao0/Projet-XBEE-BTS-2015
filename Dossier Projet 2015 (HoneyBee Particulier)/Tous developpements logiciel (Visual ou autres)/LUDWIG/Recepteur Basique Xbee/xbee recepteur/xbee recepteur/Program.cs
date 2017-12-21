using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO.Ports;
using xbee_recepteur;


namespace xbee_recepteur
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string[] ports = SerialPort.GetPortNames();
            Console.WriteLine("Les ports suivants ont été détecté: ");

            // Display each port name to the console.
            foreach (string port in ports)
            {
                Console.WriteLine(port);
            }
            Console.WriteLine(" ");
            C_Serie.Connexion("COM20", 9600, 8);
            //C_Serie.ReceptionSerie();
            
            //do
           while(true)
            {
                //Console.WriteLine("Continuer la conversation ?");
                //choix = Console.ReadLine();
                string message = C_Serie.ReceptionSerie();
                Console.WriteLine(message);
                Thread.Sleep(1000);
            }
            //while (choix != "non");
        }
    }
}
