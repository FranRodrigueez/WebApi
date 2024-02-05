using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace WebApi
{
    public class Mail
    {
       

        public void send(Users user)
        {
            MailAddress to = new MailAddress(user.email);
            MailAddress from = new MailAddress("f.rodriguez@cesjuanpablosegundocadiz.es");

            MailMessage email = new MailMessage(from, to);
            email.Subject = "Probando el email";
            email.Body = "Hola desde C#";

            // Adjuntar el archivo PDF
            byte[] pdfBytes = PDFGenerator.test(); // Llamada al método que genera el PDF
            Attachment pdfAttachment = PDFGenerator.CreateAsAttachment(pdfBytes, "archivo.pdf");
            email.Attachments.Add(pdfAttachment);

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Credentials = new NetworkCredential("f.rodriguez@cesjuanpablosegundocadiz.es", "vzwh lrau plbq lcwi");
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;

            try
            {   
                smtpClient.Send(email);
            }
            catch (SmtpException ex) 
            { 
                Console.WriteLine(ex.ToString());            
            }
        }
    }

}
