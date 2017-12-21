using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO.Ports;

namespace Application_xbee_recepteur_données
{
    class C_Xbee
    {
        SerialPort my_serie = new SerialPort();
        bool EstOuvert = false;

        public C_Xbee() 
        {
        }

        public bool ConnecterPortSerie(string portCom, string baudrate)
        {
            my_serie.PortName = portCom;
            my_serie.BaudRate = Convert.ToInt16(baudrate);
            my_serie.DataBits = 8;
            my_serie.StopBits = StopBits.One;
            my_serie.Parity = Parity.None;
            my_serie.Handshake = Handshake.None;
            my_serie.Open();

            if (my_serie.IsOpen == true)
            {
                EstOuvert = true;
            }
            return EstOuvert;
        }

        public bool DeconnecterPortSerie()
        {
            if (my_serie.IsOpen)
            {
                my_serie.Close();
                my_serie.Dispose();
                if (my_serie.IsOpen == false)
                {
                    EstOuvert = false;
                }
                else { EstOuvert = true; }
            } return EstOuvert;
        }

        public string ReceptionSerie()
        {
            
                Thread.Sleep(1000);//attente pour les gros paquets de données
                string data = my_serie.ReadExisting(); //Lis les données existantes sur le périphérique du port série
                return data; //Retourne ces données
        }
    }
}

