using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BoxBack.WebApi.Extensions
{
    public static class EmailExtensions
    {
        public static void SendEmail(MailMessage param)
        {
            using(SmtpClient smtp = new SmtpClient())
            {
                smtp.Host = "smtp-mail.outlook.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("aspenetcore@hotmail.com", "alr20207413*");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                try
                {
                    smtp.Send(param);
                }
                catch (System.Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public static async Task SendEmailAsync(MailMessage param)
        {
            using(SmtpClient smtp = new SmtpClient())
            {
                smtp.Host = "smtp-mail.outlook.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("aspenetcore@hotmail.com", "alr20207413*");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                await Task.Run(() => smtp.SendMailAsync(param));
            }
        }

        // private static async void buttonEnviar_Click(object sender, EventArgs e)
        //     {
        //         using (System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient())
        //         {
        //             smtp.Host = "smtp.gmail.com";
        //             smtp.Port = 587;
        //             smtp.EnableSsl = true;
        //             smtp.UseDefaultCredentials = false;
        //             smtp.Credentials = new System.Net.NetworkCredential("SEUEMAIL@gmail.com", "SUASENHA");
            
        //             using (System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage())
        //             {
        //                 mail.From = new System.Net.Mail.MailAddress("SEUEMAIL@gmail.com");
            
        //                 if (!string.IsNullOrWhiteSpace(textBoxPara.Text))
        //                 {
        //                     mail.To.Add(new System.Net.Mail.MailAddress(textBoxPara.Text));
        //                 }
        //                 else
        //                 {
        //                     MessageBox.Show("Campo 'para' é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                     return;
        //                 }
        //                 if (!string.IsNullOrWhiteSpace(textBoxCC.Text))
        //                     mail.CC.Add(new System.Net.Mail.MailAddress(textBoxCC.Text));
        //                 if (!string.IsNullOrWhiteSpace(textBoxCCo.Text))
        //                     mail.Bcc.Add(new System.Net.Mail.MailAddress(textBoxCCo.Text));
        //                 mail.Subject = textBoxAssunto.Text;
        //                 mail.Body = richTextBoxCorpo.Text;
            
        //                 foreach (string file in listBoxAttachments.Items)
        //                 {
        //                     mail.Attachments.Add(new System.Net.Mail.Attachment(file));
        //                 }
            
        //                 await smtp.SendMailAsync(mail);
        //             }
        //         }
        //     }
    }
}