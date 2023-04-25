using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.namespaces.NetworkNamespace {
    public static class Network {

        public static bool isHtml = false;
        public static MailAddress to;
        private static MailAddress from = new MailAddress("instagramconsoleapp@gmail.com");
        private static MailMessage email;

        public static void sendNotification(string toadmin, Notification notification) {
            to = new MailAddress(toadmin);
            email = new MailMessage(from, to);

            email.IsBodyHtml = isHtml;
            email.Subject = notification.Title;
            email.Body = notification.Text;
            isHtml = false;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 25;
            smtp.Credentials = new NetworkCredential("instagramconsoleapp@gmail.com", "eydutgiswpexleel");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;

            try {
                /* Send method called below is what will send off our email 
                    * unless an exception is thrown.
                    */
                smtp.Send(email);
            }
            catch (SmtpException ex) {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
