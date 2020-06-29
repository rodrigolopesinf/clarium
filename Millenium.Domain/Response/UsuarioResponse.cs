using Millenium.Domain.Entity;
using System;

namespace Millenium.Domain.Response
{
    public class UsuarioResponse
    {
        public string Mensagem { get; set; }
        public bool Existe { get; set; }
        public Usuario Usuario { get; set; }

        public UsuarioResponse RetornaMensagem(Usuario obj)
        {
            if (obj != null)
            {
                return new UsuarioResponse()
                {
                    Mensagem = obj.ValidadeSenha < DateTime.Now
                ? "* A validade de sua senha expirou, entre em contato com o administrador do sistema."
                : String.Empty,
                    Existe = true,
                    Usuario = obj
                };
            }
            else
            {
                return new UsuarioResponse() { Existe = false, Mensagem = "* Usuário e/ou senha inválido." };
            }
            
        }
    }
}