using System;
using Microsoft.SPOT.Hardware;



namespace Acquisition
{

    class C_Panda_I2C
    {

        //Création d'objet I2c
        I2CDevice.Configuration Temperature = new I2CDevice.Configuration(0x4D, 400); //DS1621
        I2CDevice.Configuration Poids = new I2CDevice.Configuration(0x49, 100); //PCF8591P
        I2CDevice MyI2C;
        I2CDevice.I2CTransaction[] xActions; //Création d'opérations
        //Représente une instance de l'interface I2c pour un dispositif I2c

        public C_Panda_I2C() //Constructeur
        {
            MyI2C = new I2CDevice(Poids);
        }

        public void Dispose() //Libère les ressources utilisées par l'objet de I2CDevice
        {
            MyI2C.Dispose();
            xActions = null;
        }

        public double AcquisitionTemperature()
        {
            byte[] temp = new byte[2]; //Besoin de 2 octets
            double realtemp = 0.0; //15 chiffres de précision(virgule flottante)

            MyI2C.Config = Temperature;
            xActions = new I2CDevice.I2CTransaction[3]; //Création de 3 transactions

            byte[] commande1 = new byte[1] { 238 }; //Commande EE(Début de conversion)
            byte[] commande2 = new byte[1] { 170 }; //Commande AA(Lecture de la température)

            //Transactions
            xActions[0] = I2CDevice.CreateWriteTransaction(commande1); //Représente une transaction I2c qui écrit dans le dispositif adressé
            xActions[1] = I2CDevice.CreateWriteTransaction(commande2);
            xActions[2] = I2CDevice.CreateReadTransaction(temp); //Représente une transaction I2c qui lit le dispositif adressé

            MyI2C.Execute(xActions, 1000); //Accès au bus I2c avec un délai de 1sec

            realtemp = temp[0];
            if (temp[1] != 0) //(opérateur d'inégalité)
                realtemp = realtemp + 0.5;

            return realtemp;

        }

        public double AquisitionPoids()
        {

            byte[] poids = new byte[1];
            double masse = 0.0;

            MyI2C.Config = Poids;
            xActions = new I2CDevice.I2CTransaction[2]; 

            byte[] commande = new byte[1] { 0x01 }; //Mettre 1 pour lire la masse sur AIN1(Broche 2) 

            xActions[0] = I2CDevice.CreateWriteTransaction(commande);
            xActions[1] = I2CDevice.CreateReadTransaction(poids);

            MyI2C.Execute(xActions, 1000);

            masse = (( 4.7 * poids[0]) / 255.0 * 20 ) ; //Calcul d'acquisition poids
            return masse;

        }

        public double AquisitionTensionAlim() 
        {

            double tensionalims = 0;
            MyI2C.Config = Poids;
            xActions = new I2CDevice.I2CTransaction[2];

            byte[] commande = new byte[1] { 0x00 }; //Mettre 0 pour lire la masse sur AIN0(Broche 1)
            xActions[0] = I2CDevice.CreateWriteTransaction(commande);

            byte[] alims = new byte[1];
            xActions[1] = I2CDevice.CreateReadTransaction(alims);

            MyI2C.Execute(xActions, 1000);

            tensionalims = ( 4.7 * alims[0]) / 255 ; 
            return tensionalims;

        }

       
        public byte decToBcd(int val)
        {
            return (byte)((val / 10 * 16) + (val % 10));
        }

        public byte bcdToDec(byte val)
        {
            return (byte)((val / 16 * 10) + (val % 16));
        }



    }
}
