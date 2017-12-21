using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Application_xbee_recepteur_données;

namespace Application_xbee_recepteur_données
{
    public partial class Form1 : Form
    {
        C_Xbee Xbee = new C_Xbee();
        C_Mail email = new C_Mail("honeybeeparticulier@gmail.com", "smtp.gmail.com", "587", "honeybeeparticulier@gmail.com", "honeybee201557", true);
        bool connect = false;
        DateTime datetime = DateTime.Today;
        
        
        public Form1()
        {
            
                InitializeComponent();
                b_alert.Enabled = false;
                b_lire.Enabled = false;             
                b_lire.Text = "Entrez votre adresse email";
                b_mail.ForeColor = System.Drawing.Color.Red;
                b_connect.Enabled = false;
                t_poids_max.Enabled = false;
                t_poids_min.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void b_connect_Click(object sender, EventArgs e)
        {
            if (b_connect.Text == "Connexion")
            {
                try
                {
                    connect = Xbee.ConnecterPortSerie("COM20", "9600"); //Connexion au port COM20 paramétré au préalable avec une vitesse de 9600 bauds
                }
                catch
                {
                    
                     //Interdire la connexion entre le pc et le récepteur si l'utilisateur choisit un port série différent de celui paramétré (COM20)
                    b_lire.Text = "Verifier la connexion";
                    MessageBox.Show("Module sans fil récepteur non détecté, vérifiez que la connexion soit effectuée.");
                }
                if (connect == true)
                {
                    b_lire.Text = "Appliquer des seuils de poids";
                    b_alert.ForeColor = System.Drawing.Color.Red;
                    b_connect.Text = "Déconnexion";
                    b_connect.ForeColor = System.Drawing.Color.Black;
                    b_alert.Enabled = true;
                    t_poids_max.Enabled = true;
                    t_poids_min.Enabled = true;
                    progressBar1.Value = 33;

                }
                else if (connect == false)
                {
                    b_alert.Enabled = false;
                }
            }
            else
            {
                connect = Xbee.DeconnecterPortSerie();
                timer1.Stop(); //Arrete le timer et donc arrete la lecture des données du buffer
                l_etapes.Text = "Progression du paramétrage";
                if (connect == false)
                {
                    b_connect.Enabled = true;
                    b_connect.Text = "Connexion";
                    b_connect.ForeColor = System.Drawing.Color.Red;
                    b_lire.Enabled = false;
                    b_lire.Text = "Connectez vous";
                    b_alert.Enabled = false;
                    t_poids_max.Enabled = false;
                    t_poids_min.Enabled = false;
                    progressBar1.Value = 0;
                }
                else if (connect == true)
                {
                    b_alert.Enabled = true;
                }
            }

        }

        private void b_deconnect_Click(object sender, EventArgs e)
        {
            connect = Xbee.DeconnecterPortSerie();
            timer1.Stop();
            l_etapes.Text = "Progression du paramétrage";
            if (connect == false)
            {
                b_connect.Enabled = true;
                b_lire.Enabled = false ;
                b_lire.Text = "Connectez vous";
                b_connect.ForeColor = System.Drawing.Color.Red;
                b_alert.Enabled = false;
                t_poids_max.Enabled = false;
                t_poids_min.Enabled = false;
                progressBar1.Value = 0;
            }
            else if (connect == true)
            {
                b_alert.Enabled = true;
            }
            
        }

        private void b_lire_Click(object sender, EventArgs e)
        {
            if (b_lire.Text == "Lancer la lecture des données")
            {
                progressBar1.Value = 100;
                timer1.Start(); //Demarre le timer qui va executer en continu la lecture des données dans le buffer
                b_lire.Text = "Arrêter";
                b_lire.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                timer1.Stop(); //Arrete le timer et donc arrete la lecture des données du buffer
                b_lire.Text = "Lancer la lecture des données";
                b_lire.ForeColor = System.Drawing.Color.Red;
                progressBar1.Value = 75;
                l_etapes.Text = "Progression du paramétrage";
            }
        }

        private void b_quitter_Click(object sender, EventArgs e)
        {
            Application.Exit(); //Arret de l'application
        }

        private void b_alert_Click(object sender, EventArgs e)
        {
            if (b_lire.Text == "Appliquer des seuils de poids") { progressBar1.Value = 66; }
            try
            {
                Int32 poidsmin = Convert.ToInt32(t_poids_min.Text); //Convertion du texte de la boite de texte t_poids_min en entier signé 32 bits
                Int32 poidsmax = Convert.ToInt32(t_poids_max.Text); //Convertion du texte de la boite de texte t_poids_max en entier signé 32 bits
                Int32 poids = Convert.ToInt32(l_poids.Text); //Convertion du texte du label l_poids en entier signé 32 bits
                if (poidsmin > poidsmax) { MessageBox.Show("Seuils de poids invalides, le seuil de poids maximum ne peut pas être inférieur au seuil de poids minimum"); }
                else if (poidsmin == poidsmax) { MessageBox.Show("Seuils de poids invalides, le seuil de poids maximum ne peut pas être égal au seuil de poids minimum"); }
                else if (poidsmax > 150 || poidsmin< 0 ) {MessageBox.Show("Seuils de poids invalides, les seuils de poids ne peuvent être inférieur à 0kg ou supérieur à 150 kg"); }
                    

                else
                {
                    if (poids < poidsmin) 
                    {
                        MessageBox.Show("Poids en sous régime !");//Si le poids est en dessous du seuil de poids minimum, alors message d'erreur
                        try { email.Envoi(t_mail.Text, "honeybeeparticulier@gmail.com", "honeybee201557", "Aujourd'hui, le " + DateTime.Now.ToString("dd/M/yyyy hh:mm") + ", le poids est en sous régime (" + poids + " kg)"); }
                        catch { MessageBox.Show("Echec de l'envoi du mail, vérifiez votre connexion ou l'adresse Email entrée"); }
                        timer1.Enabled = false;
                        timer1.Stop();
                    } 
                    else if (poids > poidsmax) 
                    {
                        MessageBox.Show("Poids trop élevé !"); //Si le poids est au dessus du seuil de poids maximum, alors message d'erreur
                        try { email.Envoi(t_mail.Text, "honeybeeparticulier@gmail.com", "honeybee201557", "Aujourd'hui, le " + DateTime.Now.ToString("dd/M/yyyy hh:mm") + ", le poids est trop élevé (" + poids + " kg)"); }
                        catch { MessageBox.Show("Echec de l'envoi du mail, vérifiez votre connexion ou l'adresse Email entrée"); }
                        timer1.Enabled = false;
                        timer1.Stop();
                    }
                    
                    b_lire.Enabled = true;
                    b_lire.Text = "Lancer la lecture des données";
                    b_lire.ForeColor = System.Drawing.Color.Red;
                    b_alert.ForeColor = System.Drawing.Color.Black;
                }
            }
            catch
            {
                MessageBox.Show("Seuils de poids invalides"); //Message d'erreur en cas de saisie invalide des seuils de poids
            }
            

            


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int i;
            l_etapes.Text = "Scan des données en cours";
            string donnees = Xbee.ReceptionSerie();//Récupère les données sous forme "poids temperature batterie"        
            if (donnees != "")
            {
                
                string[] decoupe = donnees.Split(' '); //découpe la trame pour séparer le poids, la température et la batterie
                l_poids.Text = decoupe[0]; // dispose les différents éléments dans les labels qui leur sont affectés
                l_temp.Text = decoupe[1];
                l_batterie.Text = decoupe[2];
                Int32 batteriefaible = 20;
                Int32 batteriemoyenne = 51;
                l_batterie.ForeColor = System.Drawing.Color.Green;
                Int32 poidsmin = Convert.ToInt32(t_poids_min.Text); //Conversion du poids max en entier pour le comparer au poids réel
                Int32 poidsmax = Convert.ToInt32(t_poids_max.Text);//Conversion du poids min en entier pour le comparer au poids réel
                Int32 batterie = Convert.ToInt32(l_batterie.Text); //Conversion de la battrie en entier pour traiter sa valeur
                Int32 poids = Convert.ToInt32(l_poids.Text); //Conversion du poids réel en entier pour le comparer aux seuils
                if (batterie < batteriemoyenne) { l_batterie.ForeColor = System.Drawing.Color.Orange; }
                if (poids < poidsmin) 
                {
                    MessageBox.Show("Poids en sous régime !"); //Si le poids est en dessous du seuil de poids minimum, alors message d'erreur
                    l_poids.ForeColor = System.Drawing.Color.Red;                    
                    try { email.Envoi(t_mail.Text, "honeybeeparticulier@gmail.com", "honeybee201557", "Aujourd'hui, le " + DateTime.Now.ToString("dd/M/yyyy hh:mm") + ", le poids est en sous régime (" + poids + " kg)"); }
                    catch { MessageBox.Show("Echec de l'envoi du mail, vérifiez votre connexion ou l'adresse Email entrée"); }
                    timer1.Enabled = false;
                    timer1.Stop();
                    b_lire.Text = "Lancer la lecture des données";
                    l_etapes.Text = "Progression du paramétrage";
                    b_lire.ForeColor = System.Drawing.Color.Red;
                    progressBar1.Value = 75;
                } 
                else if (poids > poidsmax) 
                {
                    MessageBox.Show("Poids trop élevé !"); //Si le poids est au dessus du seuil de poids maximum, alors message d'erreur
                    l_poids.ForeColor = System.Drawing.Color.Red;                    
                    try { email.Envoi(t_mail.Text, "honeybeeparticulier@gmail.com", "honeybee201557", "Aujourd'hui, le " + DateTime.Now.ToString("dd/M/yyyy hh:mm") + ", le poids est trop élevé (" + poids + " kg)"); }
                    catch { MessageBox.Show("Echec de l'envoi du mail, vérifiez votre connexion ou l'adresse Email entrée"); }
                    timer1.Enabled = false;
                    timer1.Stop();
                    b_lire.Text = "Lancer la lecture des données";
                    l_etapes.Text = "Progression du paramétrage";
                    b_lire.ForeColor = System.Drawing.Color.Red;
                    progressBar1.Value = 75;
                } 
                if (batteriefaible > batterie) //Avertissement si la batterie est à 20% ou inférieure
                {
                    MessageBox.Show("Batterie faible, pensez à recharger le plus vite possible!");
                    l_batterie.ForeColor = System.Drawing.Color.Red;                
                    try { email.Envoi(t_mail.Text, "honeybeeparticulier@gmail.com", "honeybee201557", "Batterie faible ! (" + batterie + " %) le " + DateTime.Now.ToString("dd/M/yyyy hh:mm")); }
                    catch { MessageBox.Show("Echec de l'envoi du mail, vérifiez votre connexion ou l'adresse Email entrée"); }
                    timer1.Enabled = false;
                    timer1.Stop();
                    b_lire.Text = "Lancer la lecture des données";
                    l_etapes.Text = "Progression du paramétrage";
                    b_lire.ForeColor = System.Drawing.Color.Red;
                    progressBar1.Value = 75;
                }
                for (i = 0; i < 3; i++)
                {
                    decoupe[i] = null; //Initialisation du tableau de données
                }

            }
            else
            {
                timer1.Stop();
                timer1.Enabled = false;
                MessageBox.Show("Communication impossible entre les deux modules, vérifiez que les connexions soient effectuées.");
                b_lire.Text = "Lancer la lecture des données";
                l_etapes.Text = "Progression du paramétrage";
                b_lire.ForeColor = System.Drawing.Color.Red;
                progressBar1.Value = 75;


            }
        }

        private void b_mail_Click(object sender, EventArgs e)
        {
            if (VerifMail(t_mail.Text) == true)
            {
                b_connect.Enabled = true;
                b_mail.ForeColor = System.Drawing.Color.Black;
                b_connect.ForeColor = System.Drawing.Color.Red;
                b_lire.Text = "Appuyez sur le bouton Connexion";
            }
            else {MessageBox.Show("Adresse Email invalide, vérifiez l'orthographe de celle-çi !");}

        }

        public bool VerifMail(string adresse)
        {
            System.Text.RegularExpressions.Regex myRegex = new Regex(@"^([\S]+)@([a-zA-Z]+)\.([a-zA-Z]+)$");
            //([\w]+) ==> caractère alphanumérique apparaissant une fois ou plus 
            return myRegex.IsMatch(adresse); // retourne true ou false selon la vérification
        }
        public bool isnumeric(string chaine)
        {
            System.Text.RegularExpressions.Regex myRegex = new Regex(@"^[0-9]+$");
            return myRegex.IsMatch(chaine); // retourne true ou false selon la vérification
        }
    }
}
