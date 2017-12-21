using System;
using System.Text;
using System.IO.Ports;
using System.Threading;

using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

using GHIElectronics.NETMF.FEZ;

namespace test
{
    public class Program
    {
        public static void Main()
        {
            // Emetteur
            // Création d'un port série pour la communication avec le module XBEE. XBEE_RX sur Di0 et XBEE_TX sur Di1.
             SerialPort xbee_E = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
             xbee_E.Open();

             UInt16 i = 0; // Valeur à transmettre

            // Création d'une chaîne de caractère et d'un buffer d'émission
            string counter_string;
            byte[] buffer;

             //Envoi de la valeur toutes les 2s
            while (true)
            {
                for (i = 30; i <= 40; i++)
                {
                    counter_string = i.ToString() + " " + i.ToString() + " " + i.ToString() + "\n"; // \n = CR (délimite la fin de la valeur
                    buffer = Encoding.UTF8.GetBytes(counter_string);
                    xbee_E.Write(buffer, 0, buffer.Length);
                    Thread.Sleep(2000);
                }
            }
        }

    }
}
