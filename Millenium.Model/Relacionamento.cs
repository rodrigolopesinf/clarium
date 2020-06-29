namespace Millenium_Model
{
    public class Relacionamento : ClassePai
    {
        public Relacionamento()
        {
            Cliente = new Cliente();
        }

        public int IdRelacionamento { get; set; }
        public bool Finalizado { get; set; }
        public Cliente Cliente { get; set; }

        public string NomeEmpresa { get; set; }
        public string Descricao { get; set; }

        public int IdTipoProblema { get; set; }
        public int IdInsumo { get; set; }
        public int IdPatrimonio { get; set; }

        public int Contador { get; set; }
    }
}
