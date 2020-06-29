using Millenium.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
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
            SmtpClient client;
            MailMessage mail;
            ServerConector(usuario, out client, out mail);

            mail.To.Add(new MailAddress("cpbarbosa@uol.com.br", "Celso Barbosa"));
            mail.Subject = "Contato";
            mail.Body =
                " <br/> CLIENTE:  " + solicitacao.Cliente.NomeFantasia +
                " <br/> DATA DE NASCIMENTO : " + solicitacao.DataNascimento +
                " <br/> TIPO DE SOLICITAÇÃO : " + solicitacao.TipoSolicitacao.Descricao +
                " <br/> NOME : " + solicitacao.Nome +
                " <br/> NOME DA MÃE : " + solicitacao.NomeMae +
                " <br/> NOME DO PAI : " + solicitacao.NomePai +
                " <br/> RG : " + solicitacao.Rg +
                " <br/> CPF : " + solicitacao.Cpf +
                " <br/> " +
                " <br/> LOGRADOURO : " + solicitacao.Endereco.Logradouro +
                " <br/> NÚMERO : " + solicitacao.Endereco.Numero +
                " <br/> COMPLEMENTO : " + solicitacao.Endereco.Complemento +
                " <br/> CEP : " + solicitacao.Endereco.Cep +
                " <br/> BAIRRO : " + solicitacao.Endereco.Bairro +
                " <br/> CIDADE : " + solicitacao.Endereco.Cidade +
                " <br/> ESTADO : " + solicitacao.Endereco.Estado;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            try
            {
                client.Send(mail);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                mail = null;
            }
        }

        private void EnviarEmail(Usuario usuario, string novaSenha)
        {
            SmtpClient client;
            MailMessage mail;
            ServerConector(usuario, out client, out mail);

            mail.To.Add(new MailAddress(usuario.Email, usuario.Nome));
            mail.Subject = "Contato";
            mail.Body =
                " <br/> USUÁRIO:  " + usuario.Login +
                " <br/> SENHA : " + novaSenha;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            try
            {
                client.Send(mail);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                mail = null;
            }
        }

        private static void ServerConector(Usuario usuario, out SmtpClient client, out MailMessage mail)
        {
            client = new SmtpClient
            {
                //EnableSsl = true, // GMail requer SSL
                Port = 8889,      // porta para SSL
                DeliveryMethod = SmtpDeliveryMethod.Network, // modo de envio
                UseDefaultCredentials = false, // vamos utilizar credencias especificas
                Host = "mail.clarium.net.br",
                Credentials = new System.Net.NetworkCredential("clientes@clarium.net.br", "palio@1998")
            };
            mail = new MailMessage
            {
                Sender = new MailAddress(usuario.Email, usuario.Nome),
                From = new MailAddress("clientes@clarium.net.br", "Comunicado")
            };
        }
    }
}
