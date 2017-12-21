using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;



namespace Xbee_emetteur_graphique
{
    public class C_Serie
    {

        SerialPort my_serie = new SerialPort();
        bool IS_OK = false;
        //MessageEventArgs.SerieMessage Seriemes = new MessageEventArgs.SerieMessage();//les données
        //public event MessageEventHandler OnSerieReceive; //gestionnaire d'événements



        public bool ConnecterPortSerie(string portCom, string baudrate)
        {
            bool EstOuvert = false;
            my_serie.PortName = portCom;
            my_serie.BaudRate = Convert.ToInt32(baudrate);
            my_serie.DataBits = 8;
            my_serie.StopBits = StopBits.One;
            my_serie.Parity = Parity.None;
            my_serie.Handshake = Handshake.None;
            my_serie.Open();
            
            if (my_serie.IsOpen == true)
            {
                EstOuvert = true;
                my_serie.WriteLine("+++");
                my_serie.DataReceived += new SerialDataReceivedEventHandler(ReceptionSerie);
            }
            return EstOuvert;//données de type texte
            //OnSerieReceive(this, new MessageEventArgs(Seriemes));// événement avec message
        }

        public void DeconnecterPortSerie()
        {
            if (my_serie.IsOpen)
            {
                my_serie.Close();
                my_serie.Dispose();
                //données de type texte
                //OnSerieReceive(this, new MessageEventArgs(Seriemes));// événement avec message
            }
        }

        public void TransmissionSerie(string data)
        {
            my_serie.WriteLine(data);
                        //données de type texte
            //OnSerieReceive(this, new MessageEventArgs(Seriemes));// événement avec message
        }
        public void ReceptionSerie(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                Thread.Sleep(83);//attente pour les gros paquets de données
                string data = my_serie.ReadExisting();
                int taille = my_serie.ReadBufferSize;
                //OnSerieReceive(this, new MessageEventArgs(Seriemes));// événement avec message
               
                if(data.Contains("OK")) IS_OK = true;
            }
            catch
            {
                IS_OK = false;//données de type texte
            }
        }
        public delegate void MessageEventHandler(object sender, MessageEventArgs e); //délégué
        public class MessageEventArgs : EventArgs// une classe pour traiter les événements de réception
        {
            public struct SerieMessage
            {
                public int type;//indique le type de données
                public string s_data;//données texte
                public byte[] b_data;//données brute en octets
                public int taille;
            }
            private SerieMessage _Seriepm;//la donnée à echanger lors des événements
            public MessageEventArgs(SerieMessage data) //constructeur
            {
                this._Seriepm = data;
            }
            public SerieMessage Seriemessage //propriété
            {
                get { return _Seriepm; }
            }
        }

    }
   
}
