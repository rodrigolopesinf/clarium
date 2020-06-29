namespace Millenium_Model
{
    public class Patrimonio : ClassePai
    {
        public int IdPatrimonio { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public bool Autorizado { get; set; }
    }
}
