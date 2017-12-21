using System;
using System.Text;
using System.IO.Ports;
using System.Threading;

using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

namespace PANDA_II_XBEE_E
{
    public class Program
    {
        public static void Main()
        {
            SerialPort xbee_E = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
            xbee_E.Open();

            UInt16 i = 0; // Valeur à transmettre

            // Création d'une chaîne de caractère et d'un buffer d'émission
            string counter_string;
            byte[] buffer;

            // Envoi de la valeur toutes les 2s
            while (true)
            {
                for (i = 25; i <= 35; i++) // Nombre de 30 à 40 
                {
                    if (i < 10)
                    {
                        counter_string = "0"+i.ToString() + " 0" +i.ToString() + " 0" + i.ToString(); //Création d'une chaine sous la forme : "nombre nombre nombre"
                    }
                    else
                    {
                        counter_string = i.ToString() + " " + i.ToString() + " " + i.ToString(); //Création d'une chaine sous la forme : "nombre nombre nombre"
                    }
                    buffer = Encoding.UTF8.GetBytes(counter_string);
                    xbee_E.Write(buffer, 0, buffer.Length); //Envoie de la chaîne sur le Xbee
                    Thread.Sleep(3000);
                }
            }
        }
    }
}

