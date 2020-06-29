using System;

namespace Millenium_Model
{
    public class Usuario : ClassePai
    {
        public Usuario()
        {
            Nivel = new Nivel();
        }
        public int IdUsuario { get; set; }
        public Nivel Nivel { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public string Celular { get; set; }
        public DateTime? DataAdmissao { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public DateTime? ValidadeSenha { get; set; }
    }
}
