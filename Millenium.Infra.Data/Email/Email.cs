using Millenium.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Millenium.Infra.Data.Email
{
    public class Email
    {
        public Email() { }

        public Email(Solicitacao solicitacao, Usuario usuario)
        {
            EnviarEmail(solicitacao, usuario);
        }

        public Email(Usuario usuario, string novaSenha)
        {
            EnviarEmail(usuario, novaSenha);
        }

        private void EnviarEmail(Solicitacao solicitacao, Usuario usuario)
        {
            try
            {
                MailMessage m = new MailMessage();
                SmtpClient sc = new SmtpClient();
                m.From = new MailAddress("suporte@milleniumpesquisas.com.br");
                m.To.Add(new MailAddress("cpbarbosa@uol.com.br", "Celso Barbosa"));
                m.Subject = "Contato";
                m.Body =
                    " <br/> Sua solicitação está concluída, acesse http://www.milleniumpesquisas.com.br/ para visualizar a resposta. ";
                m.IsBodyHtml = true;
                sc.Host = "mail.milleniumpesquisas.com.br";
                sc.Port = 25;
                sc.Credentials = new NetworkCredential("suporte@milleniumpesquisas.com.br", "Fiesta@1991");
                sc.EnableSsl = false;
                sc.Send(m);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void EnviarEmail(Usuario usuario, string novaSenha)
        {
            try
            {
                MailMessage m = new MailMessage();
                SmtpClient sc = new SmtpClient();
                m.From = new MailAddress("suporte@milleniumpesquisas.com.br");
                m.To.Add(new MailAddress(usuario.Email, usuario.Nome));
                m.Subject = "Contato";
                m.Body =
                    " <br/> USUÁRIO:  " + usuario.Login +
                    " <br/> SENHA : " + novaSenha;
                m.IsBodyHtml = true;
                sc.Host = "mail.milleniumpesquisas.com.br";
                sc.Port = 25;
                sc.Credentials = new NetworkCredential("suporte@milleniumpesquisas.com.br", "Fiesta@1991");
                sc.EnableSsl = false;
                sc.Send(m);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static void ServerConector(Usuario usuario, out SmtpClient client, out MailMessage mail)
        {
            client = new SmtpClient
            {
                Host = "mail.milleniumpesquisas.com.br",
                Port = 25,      // porta para SSL
                Credentials = new NetworkCredential("suporte@milleniumpesquisas.com.br", "Fiesta@1991"),
                EnableSsl = false, // GMail requer SSL
            };
            mail = new MailMessage
            {
                Sender = new MailAddress(usuario.Email, usuario.Nome),
                From = new MailAddress("rodrigolopesinf@gmail.com", "Comunicado")
            };
        }
    }
}
