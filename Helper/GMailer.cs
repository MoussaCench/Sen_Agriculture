using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AppSenAgriculture.Helper
{
    public class GMailer
    {
        public static string GmailUsername { get; set; }
        public static string GmailPassword { get; set; }
        public static string GmailHost { get; set; }
        public static int GmailPort { get; set; }
        public static bool GmailSSL { get; set; }
        public static string GmailDisplayName { get; set; }

        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsHtml { get; set; }

        static GMailer()
        {
            GmailHost = ConfigurationManager.AppSettings["SmtpHost"] ?? "smtp.gmail.com";
            GmailPort = int.Parse(ConfigurationManager.AppSettings["SmtpPort"] ?? "587");
            GmailSSL = bool.Parse(ConfigurationManager.AppSettings["SmtpEnableSSL"] ?? "true");
            GmailUsername = ConfigurationManager.AppSettings["SmtpEmail"];
            GmailPassword = ConfigurationManager.AppSettings["SmtpPassword"];
            GmailDisplayName = ConfigurationManager.AppSettings["SmtpDisplayName"] ?? "SenAgriculture";
        }

        public void Send()
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Host = GmailHost;
            smtp.Port = GmailPort;
            smtp.EnableSsl = GmailSSL;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(GmailUsername, GmailPassword);

            try
            {
                using (var message = new MailMessage(new MailAddress(GmailUsername, GmailDisplayName), new MailAddress(ToEmail)))
                {
                    message.Subject = Subject;
                    message.Body = Body;
                    message.IsBodyHtml = IsHtml;
                    smtp.Send(message);
                }
            }
            catch (Exception ex)
            {
                Utils.WriteFileError(ex.ToString());
            }
        }

        public static void senMail(string destinataire, string subjet, string body)
        {
            try
            {
                GMailer mailer = new GMailer();
                mailer.ToEmail = destinataire;
                mailer.Subject = subjet;
                mailer.Body = body;
                mailer.IsHtml = true;
                mailer.Send();
            }
            catch (Exception ex)
            {
                Utils.WriteFileError(ex.ToString());
            }
        }

        public static void SendAccountCreatedEmail(string toEmail, string nom)
        {
            try
            {
                string body = $@"
                    <html>
                    <body style='font-family: Arial, sans-serif;'>
                        <h2 style='color: #4CAF50;'>Bienvenue sur SenAgriculture !</h2>
                        <p>Bonjour <strong>{nom}</strong>,</p>
                        <p>Votre compte a été créé avec succès.</p>
                        <p>Vous pouvez maintenant vous connecter à l'application.</p>
                        <br/>
                        <p style='color: #666;'>Cordialement,<br/>L'équipe SenAgriculture</p>
                    </body>
                    </html>";

                senMail(toEmail, "Compte créé - SenAgriculture", body);
            }
            catch (Exception ex)
            {
                Utils.WriteFileError(ex.ToString());
            }
        }

        public static void SendAccountConnectionEmail(string toEmail, string nom)
        {
            try
            {
                string body = $@"
                    <html>
                    <body style='font-family: Arial, sans-serif;'>
                        <h2 style='color: #2196F3;'>Connexion détectée</h2>
                        <p>Bonjour <strong>{nom}</strong>,</p>
                        <p>Votre compte vient de se connecter à <strong>{DateTime.Now:dd/MM/yyyy HH:mm}</strong>.</p>
                        <p>Si ce n'est pas vous, veuillez contacter l'administrateur immédiatement.</p>
                        <br/>
                        <p style='color: #666;'>Cordialement,<br/>L'équipe SenAgriculture</p>
                    </body>
                    </html>";

                senMail(toEmail, "Connexion à votre compte - SenAgriculture", body);
            }
            catch (Exception ex)
            {
                Utils.WriteFileError(ex.ToString());
            }
        }

        public static void SendPasswordChangedEmail(string toEmail, string nom)
        {
            try
            {
                string body = $@"
                    <html>
                    <body style='font-family: Arial, sans-serif;'>
                        <h2 style='color: #FF9800;'>Mot de passe modifié</h2>
                        <p>Bonjour <strong>{nom}</strong>,</p>
                        <p>Votre mot de passe a été modifié avec succès le <strong>{DateTime.Now:dd/MM/yyyy à HH:mm}</strong>.</p>
                        <p style='color: #d32f2f;'>⚠️ Si vous n'êtes pas à l'origine de cette modification, veuillez contacter l'administrateur <strong>immédiatement</strong>.</p>
                        <br/>
                        <p><strong>Conseils de sécurité :</strong></p>
                        <ul>
                            <li>Ne partagez jamais votre mot de passe</li>
                            <li>Utilisez un mot de passe unique pour chaque service</li>
                            <li>Changez régulièrement vos mots de passe</li>
                        </ul>
                        <br/>
                        <p style='color: #666;'>Cordialement,<br/>L'équipe SenAgriculture</p>
                    </body>
                    </html>";

                senMail(toEmail, "Mot de passe modifié - SenAgriculture", body);
            }
            catch (Exception ex)
            {
                Utils.WriteFileError(ex.ToString());
            }
        }

        //public static void senMail(string address, string subject, string body)
        //{

        //    using (MailMessage message = new MailMessage())
        //    {
        //        message.Subject = subject;
        //        message.Body = "<pre>" + body + "</pre>";
        //        message.To.Add(address);
        //        message.Priority = MailPriority.High;
        //        message.IsBodyHtml = true;
        //        using (SmtpClient client = new SmtpClient())
        //        {
        //            try
        //            {
        //                client.Send(message);
        //            }

        //            catch (Exception e)
        //            {
        //                Utils.WriteFileError(e.ToString());
        //            }
        //        }
        //    }
        //}

    }
}
