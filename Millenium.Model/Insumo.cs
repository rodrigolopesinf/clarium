namespace Millenium_Model
{
    public class Insumo : ClassePai
    {
        public int IdInsumo { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public string CodigoProduto { get; set; }
        public string CodigoCfop { get; set; }
        public int Quantidade { get; set; }
        public int QuantidadeAtual { get; set; }

        public int TotalInsumos { get; set; }
    }
}
