using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Application_xbee_recepteur_données
{
    class C_Mail
    {
        #region Variables
        string _mailexp, _serversmtp = "", _usersmtp = "", _pwdsmtp = "";
        int _portsmtp;
        bool _smtpssl = false;
        #endregion

        #region Constructeur
        public C_Mail(string mailexp, string serversmtp, string portsmtp, string usersmtp, string pwdsmtp, bool sslsmtp)
        {
            _mailexp = mailexp;
            _serversmtp = serversmtp;
            _portsmtp = Convert.ToInt16(portsmtp);
            _usersmtp = usersmtp;
            _pwdsmtp = pwdsmtp;
            _smtpssl = sslsmtp;
        }
        #endregion

        #region Traitements
        public bool Envoi(string destinataire, string usern, string userp, string body)
        {
            try
            {

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(_mailexp);
                mail.To.Add(new MailAddress(destinataire));
                mail.Subject = "Alerte Honey Bee";
                mail.Body = body;
                SmtpClient SmtpServer = new SmtpClient();
                SmtpServer.Host = _serversmtp;
                SmtpServer.Port = _portsmtp;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                SmtpServer.Credentials = new NetworkCredential(_usersmtp, _pwdsmtp);
                SmtpServer.EnableSsl = _smtpssl;
                SmtpServer.Send(mail);
                return true;
            }
            catch { return false; }
        }
        #endregion


    }
}