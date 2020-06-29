using System.Collections.Generic;

namespace Millenium_Model
{
    public class Cliente : ClassePai
    {
        public Cliente()
        {
            TipoCliente =new TipoCliente();
            Endereco = new Endereco();
            ClassificacaoCliente = new ClassificacaoCliente();
            SituacaoCliente = new SituacaoCliente();
            ListaMaquinas = new List<Maquina>();
        }

        public int IdCliente { get; set; }
        public string CodigoCliente { get; set; }
        public TipoCliente TipoCliente { get; set; }
        public Endereco Endereco { get; set; }
        public ClassificacaoCliente ClassificacaoCliente { get; set; }
        public List<Maquina> ListaMaquinas { get; set; }
        public SituacaoCliente SituacaoCliente { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public string TelefonePrincipal { get; set; }
        public string RamalPrincipal { get; set; }
        public string TelefoneSecundario { get; set; }
        public string RamalSecundario { get; set; }
        public string EmailPrincipal { get; set; }
        public string EmailSecundario { get; set; }
        public string Site { get; set; }
        public int IdDiaVencimento { get; set; }
        public double PrecoDose { get; set; }
        public int MinimoDoses { get; set; }
        public int QuantidadeCortesia { get; set; }
        public bool FaturaEmail { get; set; }
        public string Observacao { get; set; }
        public string DiaVencimento { get; set; }
    }
}
