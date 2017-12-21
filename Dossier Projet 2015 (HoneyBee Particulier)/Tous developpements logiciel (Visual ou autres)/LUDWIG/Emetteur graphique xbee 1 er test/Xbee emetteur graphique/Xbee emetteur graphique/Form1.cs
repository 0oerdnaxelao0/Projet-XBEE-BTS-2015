using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using Xbee_emetteur_graphique;

namespace Xbee_emetteur_graphique
{
    
    public partial class Form1 : Form
    {
        C_Serie Xbee = new C_Serie();
        
        public Form1()
        {
            InitializeComponent();
            b_ouvrir.Enabled = false;
            b_deconnect.Enabled = false;
            b_envoi.Enabled = false;
           
        }

        private void b_quitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void b_ouvrir_Click(object sender, EventArgs e)
        {
            string myFile = "";//le nom du fichier
            string data = "";


            //choisir le fichier
            OpenFileDialog myofd = new OpenFileDialog();
            myofd.InitialDirectory = @"d:\";
            if (myofd.ShowDialog() == DialogResult.OK)
            {
                myFile = myofd.FileName;
            }

            //ouvrir, lire le fichier et le fermer
            if (myFile != "")
            {
                StreamReader mystr = new StreamReader(myFile);
                data = mystr.ReadToEnd();
                mystr.Close();
            }

            //afficher le contenu lu
            textBox1.Text = data;
        }

        private void b_connect_Click(object sender, EventArgs e)
        {
               bool connect = false;
               connect = Xbee.ConnecterPortSerie("COM1", "9600");
               if (connect == true)
               {
                   l_connexion.Text = "Connecté !";
                   b_connect.Enabled = false;
                   b_deconnect.Enabled = true;
                   b_ouvrir.Enabled = true;
                   b_envoi.Enabled = true;
                   
                   //if (IS_OK) MessageBox.Show("Le module est connecté");
                   //else MessageBox.Show("Ancun module de connecté");
               }
               else if (connect ==false)
               {
                   l_connexion.Text = "Erreur communication";
                   b_envoi.Enabled = false;
                   b_ouvrir.Enabled = false;
               }
                 
                 
       }          

       private void b_deconnect_Click(object sender, EventArgs e)
       {
       try
            {
                Xbee.DeconnecterPortSerie();
                l_connexion.Text = "Deconnecté !";
                b_connect.Enabled = true;
                b_deconnect.Enabled = false;
                b_envoi.Enabled = false;
                b_ouvrir.Enabled = false;
            }
            catch
            {
                l_connexion.Text = "Erreur deconnexion";
            }
        }

        private void b_envoi_Click(object sender, EventArgs e)
        {
            string Texte = textBox1.Text;
            Xbee.TransmissionSerie(Texte);
        }


    }
}
