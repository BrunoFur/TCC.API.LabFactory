using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.Text.RegularExpressions;
using TCC.API.LabFactory.Infra;
using TCC.API.LabFactory.Model;

namespace TCC.API.LabFactory.Repository
{
    public class EmailRepository
    {
        //private readonly Conexao contexto = new Conexao();

        public void EnviarEmail(List<string> emails, string assunto, string mensagem, List<string> anexos, Email email)
        {
            try
            {
                MailMessage mail = PreparaMensagem(emails, assunto, mensagem, anexos, email);

                SmtpClient smtp = new SmtpClient(email.Provedor, 587);
                smtp.EnableSsl = true;
                smtp.Timeout = 10000;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(email.Login, email.Senha);
                smtp.Send(mail);
                smtp.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public MailMessage PreparaMensagem(List<string> emails, string assunto, string mensagem, List<string> anexos, Email email)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(email.Login);

            foreach (var e_mail in emails)
            {
                if (ValidarEmail(e_mail))
                {
                    mail.To.Add(e_mail);
                }
            }

            mail.Subject = assunto;
            mail.Body = mensagem;
            mail.IsBodyHtml = true;

            foreach (var anexo in anexos)
            {
                Attachment anexoEmail = new Attachment(anexo, MediaTypeNames.Application.Octet);
                ContentDisposition disposition = anexoEmail.ContentDisposition;
                disposition.CreationDate = File.GetCreationTime(anexo);
                disposition.ModificationDate = File.GetLastWriteTime(anexo);
                disposition.ReadDate = File.GetLastAccessTime(anexo);

                mail.Attachments.Add(anexoEmail);
            }

            return mail;
        }

        public bool ValidarEmail(string email)
        {
            try
            {
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                if (regex.IsMatch(email))
                {
                    return true;
                }
                else
                {
                    throw new Exception("Email inválido");
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
