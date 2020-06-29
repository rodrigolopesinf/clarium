using System;

namespace Millenium_Model
{
    public class Endereco
    {
        public Endereco()
        {
            Bairro = new Bairro();
        }

        public int? IdEndereco { get; set; }
        public Rota Rota { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public Bairro Bairro { get; set; }
        public DateTime? DataHoraInicio { get; set; }
        public DateTime? DataHoraFim { get; set; }
        public bool Instalacao { get; set; }
        public bool Retirada { get; set; }
    }
}
