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
using System.Configuration;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Sockets;
using Application_xbee_recepteur_données;

namespace Application_xbee_recepteur_données
{
    public partial class Form1 : Form
    {
        C_Xbee Xbee = new C_Xbee();
        UdpClient serveur = new UdpClient();
        C_Mail email = new C_Mail("honeybeeparticulier@gmail.com", "smtp.gmail.com", "587", "honeybeeparticulier@gmail.com", "honeybee201557", true);
        bool connect = false;
        bool mailpoids = false;
        bool mailbatterie = false;
        
        DateTime datetime = DateTime.Today;
        Int32 poidsmin;
        Int32 poidsmax;
        Double poids;
        string adressemail = ConfigurationManager.AppSettings["mail"];
        string adresseipcomplete = ConfigurationManager.AppSettings["adresseip"];
        

        int nbprobleme = 50;
        
        
        public Form1()
        {
            
                InitializeComponent();            
                tabPage1.Text = "Lecture";
                tabPage2.Text = "Réglages";
                l_datetime.Visible = false;
                l_batteriealerte.Visible = false;
                l_poidsalerte.Visible = false;
                if (ConfigurationManager.AppSettings["adresseip"] != " ")
                {
                    string[] decoupeip = adresseipcomplete.Split('.');
                    t_ip3.Text = decoupeip[2];
                    t_ip4.Text = decoupeip[3];
                    l_ipmiss.Visible = false;

                }
                
                if (ConfigurationManager.AppSettings["mail"] != " ")
                { 
                    t_mail.Text = adressemail; //affiche dans t_mail l'adresse mail enregistrée dans app.config
                    l_mailmiss.Visible = false;
                }
                if (ConfigurationManager.AppSettings["poidsmin"] != " ") 
                { 
                    t_poids_min.Text = ConfigurationManager.AppSettings["poidsmin"]; 
                    //affiche dans t_poids_min le contenu du réglage "poidsmin" de l'app.config
                    poidsmin = Convert.ToInt16(t_poids_min.Text); //Convertion du texte de la boite de texte t_poids_min en entier signé 16 bits
                }
                if (ConfigurationManager.AppSettings["poidsmax"] != " ") 
                {
                    t_poids_max.Text = ConfigurationManager.AppSettings["poidsmax"]; 
                    //affiche dans t_poids_max le contenu du réglage "poidsmax" de l'app.config
                    poidsmax = Convert.ToInt16(t_poids_max.Text); //Convertion du texte de la boite de texte t_poids_min en entier signé 16 bits
                
                }
             
                
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                connect = Xbee.ConnecterPortSerie("COM20", "9600"); //Connexion au port COM20 paramétré au préalable avec une vitesse de 9600 bauds
            }
            catch
            {
                MessageBox.Show("Module sans fil récepteur non détecté, vérifiez que la connexion soit effectuée et redémarrez le programme.");
                Application.Exit();
            }
            if (connect == true)
            {
                timer1.Start(); //Demarre le timer qui va executer en continu la lecture des données dans le buffer
            }
        }

       

        private void b_quitter_Click(object sender, EventArgs e)
        {
            Application.Exit(); //Arret de l'application
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int i;
            string donnees = Xbee.ReceptionSerie();//Récupère les données sous forme "poids temperature batterie"        
           if (VerifTrame(donnees) == true)
            {
                l_datetime.Visible = true;
                l_datetime.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm");
                l_batteriealerte.Visible = false;
                l_poidsalerte.Visible = false;
                donnees = donnees.Replace(".",","); //remplace les points dans les données par des virgules afin d'éviter les bugs
                l_reception2.Visible = false;
                nbprobleme = 50;
                string[] decoupe = donnees.Split(' '); //découpe la trame pour séparer le poids, la température et la batterie
                l_poids.Text = decoupe[0]; // dispose les différents éléments dans les labels qui leur sont affectés
                l_temp.Text = decoupe[1];
                l_reception.Visible = true; //affiche que les données sont bien mises à jour
                timer2.Start();                
                Int32 batteriefaible = 20;
                Int32 batteriemoyenne = 51;
                l_batterie.ForeColor = System.Drawing.Color.Green;
                Double batterie = Convert.ToDouble(decoupe[2]); //Conversion de la batterie en entier pour traiter sa valeur
                Double batteriepourcent = (batterie * 100) / 4.6; //Conversion de la natterie en pourcentage
                if (batteriepourcent >= 100) {l_batterie.Text = "100";}
                else if (batteriepourcent < 100) { l_batterie.Text = batteriepourcent.ToString().Substring(0, 2); }
                Double poids = Convert.ToDouble(l_poids.Text); //Conversion du poids réel en entier pour le comparer aux seuils
                if (batteriepourcent < batteriemoyenne) { l_batterie.ForeColor = System.Drawing.Color.Orange; }
                else if (batteriepourcent == 100) { l_batterie.ForeColor = System.Drawing.Color.Green; }
                string heuredirect = DateTime.Now.ToString("HH:mm:ss");
                string momentjournée = "";
                if (heuredirect == "12:00:00")
                {
                    momentjournée = "matin"; 
                    string date = DateTime.Today.ToString("d/M/yyyy");
                    string messageandroid = date + " " + momentjournée + " " + donnees;
                    byte[] msg = Encoding.Default.GetBytes(messageandroid);
                    serveur.Send(msg, msg.Length, adresseipcomplete, 5053); //Envoie les données au smartphone à midi
                }
                if (heuredirect == "21:00:00") 
                {
                    momentjournée = "soir";
                    string date = DateTime.Today.ToString("d/M/yyyy");
                    string messageandroid = date + " " + momentjournée + " " + donnees;
                    byte[] msg = Encoding.Default.GetBytes(messageandroid); //encode les données en une séquence d'octets
                    serveur.Send(msg, msg.Length, adresseipcomplete, 5053);//Envoie les données au smartphone à 21h
                }
              
                if (poids < poidsmin) 
                {
                    l_poidsalerte.Text = "TROP BAS"; //Si le poids est en dessous du seuil de poids minimum, alors message d'erreur
                    l_poidsalerte.Visible = true;
                    l_poids.ForeColor = System.Drawing.Color.Red;
                    if (mailpoids == false) //si aucun mail n'a été envoyé depuis le lancement du programme
                    {
                        try { email.Envoi(ConfigurationManager.AppSettings["mail"], 
                            "honeybeeparticulier@gmail.com",
                            "honeybee201557", 
                            "Aujourd'hui, le " +DateTime.Now.ToString("dd/M/yyyy hh:mm") + ", le poids est en sous régime (" + poids + " kg)"); 
                            mailpoids = true; } //envoie un mail d'alerte à l'adresse enregistrée
                        catch { MessageBox.Show("Echec de l'envoi du mail, vérifiez votre connexion ou l'adresse Email entrée"); }
                    }
                } 
                else if (poids > poidsmax) 
                {
                    l_poidsalerte.Text = "TROP HAUT"; //Si le poids est au dessus du seuil de poids maximum, alors message d'erreur
                    l_poidsalerte.Visible = true;
                    l_poids.ForeColor = System.Drawing.Color.Red;
                    if (mailpoids == false)
                    {
                        try { email.Envoi(ConfigurationManager.AppSettings["mail"], "honeybeeparticulier@gmail.com", "honeybee201557", "Aujourd'hui, le " 
                            + DateTime.Now.ToString("dd/M/yyyy hh:mm") + ", le poids est trop élevé (" + poids + " kg)"); mailpoids = true; }
                        catch { MessageBox.Show("Echec de l'envoi du mail, vérifiez votre connexion ou l'adresse Email entrée"); }
                    }            
                } 
                if (batteriefaible > batteriepourcent) //Avertissement si la batterie est à 20% ou inférieure
                {
                    l_batteriealerte.Visible = true;
                    l_batterie.ForeColor = System.Drawing.Color.Red;
                    if (mailbatterie == false)
                    {
                        try { email.Envoi(ConfigurationManager.AppSettings["mail"], "honeybeeparticulier@gmail.com", "honeybee201557", "Batterie faible ! (" 
                            + batterie + " %) le " + DateTime.Now.ToString("dd/M/yyyy hh:mm")); mailbatterie = true; }
                        catch { MessageBox.Show("Echec de l'envoi du mail, vérifiez votre connexion ou l'adresse Email entrée"); }
                    }
                }
                for (i = 0; i < 3; i++)
                {
                    decoupe[i] = null; //Initialisation du tableau de données
                }

            }
           else
            {
                nbprobleme--;
                if (nbprobleme <= 30)
                {
                    l_reception2.Text = "Mauvaise réception : "+nbprobleme; //affiche un message de mauvaise reception si l'application
                    //n'a pas pu recuperer d'infos 20 fois consecutives
                    l_reception2.Visible = true;
                }
                if (nbprobleme <= 0)
                {
                    timer1.Stop(); // coupe la connexion si la communication entre les modules est mauvaise.
                    timer1.Enabled = false;
                    MessageBox.Show("Communication impossible entre les deux modules, vérifiez que les connexions soient effectuées et redemarrez le programme.");
                    try { email.Envoi(ConfigurationManager.AppSettings["mail"], 
                        "honeybeeparticulier@gmail.com", 
                        "honeybee201557", 
                        "Communication impossible entre les deux modules, vérifiez que les connexions soient effectuées."); 
                    } // Envoie un mail à l'adresse enregistrée pour informer de la mauvaise communication
                    catch { MessageBox.Show("Echec de l'envoi du mail, vérifiez votre connexion ou l'adresse Email entrée"); }
                    
                }
            }
        }

        private void b_reglages_Click(object sender, EventArgs e)
        {
            adresseipcomplete = "192.168." + t_ip3.Text + "." + t_ip4.Text;
            if (VerifMail(t_mail.Text) == true) //Si le format de l'adresse mail est respecté
            {
                adressemail = t_mail.Text;
                //on charge la configuration
                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                //On efface la clé voulue dans app.conf 
                config.AppSettings.Settings.Remove("mail");
                //On la rajoute dans config.App 
                config.AppSettings.Settings.Add("mail", adressemail);
                //On la resauvegarde 
                config.Save();
                ConfigurationManager.RefreshSection("appSettings");
                l_mailmiss.Visible = false;
                
            }
            else 
            { 
                MessageBox.Show("Adresse Email invalide, vérifiez l'orthographe de celle-çi !"); 
            }
            if (VerifIP(t_ip3.Text) == true && VerifIP(t_ip4.Text) == true) //si le format des octets de l'IP sont bons
            {
                
                //on charge la configuration
                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                //On efface la clé voulue dans app.conf 
                config.AppSettings.Settings.Remove("adresseip");
                //On la rajoute dans config.App 
                config.AppSettings.Settings.Add("adresseip", adresseipcomplete);
                //On la resauvegarde 
                config.Save();
                ConfigurationManager.RefreshSection("appSettings");
                b_reglages.ForeColor = System.Drawing.Color.Black;
                l_ipmiss.Visible = false;

            }
            else
            {
                MessageBox.Show("Adresse IP invalide, vérifiez la saisie de celle-çi !");
            }
            try
            {
                //Convertion du texte de la boite de texte t_poids_max en entier signé 32 bits
                poids = Convert.ToDouble(l_poids.Text); //Convertion du texte du label l_poids en entier signé 32 bits
                if (Convert.ToInt16(t_poids_min.Text) > Convert.ToInt16(t_poids_max.Text))
                {
                    MessageBox.Show("Seuils de poids invalides, le seuil de poids maximum ne peut pas être inférieur au seuil de poids minimum");
                }
                
                else if (Convert.ToInt16(t_poids_min.Text) == Convert.ToInt16(t_poids_max.Text))
                {
                    MessageBox.Show("Seuils de poids invalides, le seuil de poids maximum ne peut pas être égal au seuil de poids minimum");
                }
                else if (Convert.ToInt16(t_poids_max.Text) > 150 || Convert.ToInt16(t_poids_min.Text) < 0)
                {
                    MessageBox.Show("Seuils de poids invalides, les seuils de poids ne peuvent être inférieur à 0kg ou supérieur à 150 kg");
                }
                else if (isnumeric(t_poids_max.Text) == false || isnumeric(t_poids_max.Text) == false)
                {
                    MessageBox.Show("Seuils de poids invalides, veuillez entrer des nombres et UNIQUEMENT des nombres s'il vous plait !");
                }
                else
                {

                    System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    //On efface la clé voulue dans app.conf 
                    config.AppSettings.Settings.Remove("poidsmin");
                    //On la rajoute dans config.App 
                    config.AppSettings.Settings.Add("poidsmin", t_poids_min.Text);
                    //On efface la clé voulue dans app.conf 
                    config.AppSettings.Settings.Remove("poidsmax");
                    //On la rajoute dans config.App 
                    config.AppSettings.Settings.Add("poidsmax", t_poids_max.Text);
                    //On la resauvegarde 
                    config.Save();
                    ConfigurationManager.RefreshSection("appSettings");
                    poidsmin = Convert.ToInt16(ConfigurationManager.AppSettings["poidsmin"]); 
                    poidsmax = Convert.ToInt16(ConfigurationManager.AppSettings["poidsmax"]); 
                }
            }
            catch
            {
                MessageBox.Show("Seuils de poids invalides"); //Message d'erreur en cas de saisie invalide des seuils de poids
            }

        }

        public bool VerifMail(string adresse)
        {
            System.Text.RegularExpressions.Regex myRegex = new Regex(@"^([\S][^@]+)@([a-zA-Z]+)\.([a-zA-Z]+)$");
            // verifie que l'adresse est sous format: tout caractere alpha numerique sauf @ + @ + chaine de caractere + point + chaine de caractere
            return myRegex.IsMatch(adresse); // retourne true ou false selon la vérification
        }

        public bool isnumeric(string chaine)
        {
            System.Text.RegularExpressions.Regex myRegex = new Regex(@"^[0-9]+$");
            //Verifie si la chaine est bien un nombre
            return myRegex.IsMatch(chaine); // retourne true ou false selon la vérification
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            l_reception.Visible = false;
        }

        public bool VerifTrame(string data)
        {
            System.Text.RegularExpressions.Regex myRegex = new Regex(@"^\d{2}\.\d\s\d{2}\.\d\s\d{2}\.\d$");
            //verifie si la trame est sous la forme: deux chiffres + point + chiffre + espace + deux chiffres
            //+ point + chiffre + espace + deux chiffres + point + chiffre
            return myRegex.IsMatch(data); // retourne true ou false selon la vérification
        }

        public bool VerifIP(string data)
        {
            System.Text.RegularExpressions.Regex myRegex = new Regex(@"^\d{3}|\d{2}|\d{1}$");
            //Verifie que l'octet de l'adresse ip est un, doux ou trois chiffres
            if (myRegex.IsMatch(data)) //si le format est respecté
            {
                if (isnumeric(data) == true) //Si la chaine est bien un nombre
                {
                    if (Convert.ToInt16(data) > 0 && Convert.ToInt16(data) < 255) // si le nombre < 255
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

     
        }

        private void b_testmail_Click(object sender, EventArgs e)
        {
            if (VerifMail(t_mail.Text) == true) //Si le format de l'adresse mail est respecté
            {
                try
                {
                    email.Envoi(t_mail.Text,
                         "honeybeeparticulier@gmail.com",
                         "honeybee201557",
                         "Le test a reussi, vous pouvez désormais recevoir les mails depuis cette adresse et enregistrer les modifications.");
                } // Envoie un mail à l'adresse enregistrée pour informer de la mauvaise communication
                catch { MessageBox.Show("Echec de l'envoi du mail, vérifiez votre connexion ou l'adresse Email entrée"); }
            }
            else
            {
                MessageBox.Show("Adresse Email invalide");
            }

        }

        private void b_testip_Click(object sender, EventArgs e)
        {

            if (VerifIP(t_ip3.Text) == true && VerifIP(t_ip4.Text) == true) //si le format des octets de l'IP sont bons
            {
                adresseipcomplete = "192.168." + t_ip3.Text + "." + t_ip4.Text;
                string date = DateTime.Today.ToString("d/M/yyyy");
                string messageandroid = date + " " + "matin" + " " + "test" + " " + "test" + " " + "test";
                byte[] msg = Encoding.Default.GetBytes(messageandroid);
                serveur.Send(msg, msg.Length, adresseipcomplete, 5053);
            }
            else
            {
                MessageBox.Show("Ip invalide");
            }

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
