using System;
using Microsoft.SPOT;
using System.Threading;
using System.Text;
using System.IO;
using System.IO.Ports;
using Microsoft.SPOT.Hardware;


namespace Acquisition
{
    class C_Traitement
    {

        //Emetteur
        //Création d'un port série pour la communication avec le module XBEE. 
        SerialPort xbee_E = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One); 

        
        public void Traitement()
        {

            C_Panda_I2C I2C = new C_Panda_I2C();
  
            double temp;
            double masse;           
            double tensionAlim;

            string temp_s;
            string masse_s;
            string tensionAlim_s;

            string data;
            byte[] wdata = new byte[1];

            bool i = true;
           
  
            xbee_E.Open();  
            if (xbee_E.IsOpen == true) 
            { 
                Debug.Print("Module sans fil connecté !"); 
            }
  
            while (i == true)
            {

                Debug.Print("En cours d'acquisition ...");
                
                temp = I2C.AcquisitionTemperature();
                // poids = I2C.correction();
                //masse = 0.0;
                masse = I2C.AquisitionPoids();
                tensionAlim = I2C.AquisitionTensionAlim();
                
                masse_s = masse.ToString();
                if (masse < 10) { masse_s = "0" + masse_s; }
                if (masse_s.Length == 2) { masse_s = masse_s + ".0"; }
                masse_s = masse_s.Substring(0, 4);                
                Debug.Print("Le poids est de " + masse_s + "Kg.");
                
                temp_s = temp.ToString();
                if (temp < 10) { temp_s = "0" + temp_s; }
                if (temp_s.Length == 2) { temp_s = temp_s + ".0"; }
                temp_s = temp_s.Substring(0, 4);
                Debug.Print("La temperature est de " + temp_s + " C.");
                
                tensionAlim_s = tensionAlim.ToString();
                if (tensionAlim < 10) { tensionAlim_s = "0" + tensionAlim_s; }
                if (tensionAlim_s.Length == 2) { tensionAlim_s = tensionAlim_s + ".0"; }
                tensionAlim_s = tensionAlim_s.Substring(0, 4);
                Debug.Print("La tension d'alim est de " + tensionAlim_s + "V.");
                
                data = masse_s + " " + temp_s + " " + tensionAlim_s;//des données sous forme de chaine
                wdata = Encoding.UTF8.GetBytes(data);//encodage des données en byte
                xbee_E.Write(wdata, 0, wdata.Length);

                Thread.Sleep(3000); // Toutes les 3sec une acquisition se fait.

            }
        }
    }
}
