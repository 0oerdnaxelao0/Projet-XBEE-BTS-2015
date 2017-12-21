using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Xml;
using System.IO.Ports;

namespace xbee_recepteur
{
    class C_Serie
    {
        static private SerialPort portcom;

        static public bool Connexion(string port, int speed, int taille)
        {
            try
            {
                portcom = new SerialPort(port, speed);
                portcom.Open();
                Console.WriteLine("Connecté au port " + port);
                return true;
            }
            catch
            {
                Console.WriteLine("Echec de la connexion");
                return false;

            }
        }

        static public bool Deconnexion()
        {
            try
            {
                portcom.Close();
                Console.WriteLine("Déconnecté");
                return true;
            }
            catch 
            {
                Console.WriteLine("Echec de la déconnexion");
                return false; 
            }
        }
        static public string ReceptionSerie()
{

        
            //Thread.Sleep(83);//attente pour les gros paquets de données
            string data = portcom.ReadExisting();
            int taille = portcom.ReadBufferSize;         
            return data;
            //données de type texte
            //OnSerieReceive(this, new MessageEventArgs(Seriemes));// événement avec message
        
      
    }

}
        }