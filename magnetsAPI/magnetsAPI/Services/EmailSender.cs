using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace magnetsAPI.Services
{
    public class EmailSender
    {
        public void SendEmail(String corpoEmail, String emailTo)
        {
            //Criamos uma variável pra agrupar os dados
            var dados = corpoEmail;

            //Após capturar alguns dados importantes, temos que enviar pra o e-mail.
            var servidor = new SmtpClient("e-mail server url", 587);

            //Transmissão de dados criptografados
            servidor.EnableSsl = false;
            #region email
            servidor.Credentials = new NetworkCredential("E-Mail Account", "Passwd.");
            #endregion

            //Montamos e enviamos um e-mail
            var email = new MailMessage();

            email.To.Add(emailTo);
            email.Bcc.Add("e-mail address");

            email.From = new MailAddress("e-mail address");

            email.Subject = "Assunto";
            email.Body = dados.ToString();

            email.IsBodyHtml = true;

            servidor.Send(email);
        }
    }
}