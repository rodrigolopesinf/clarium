namespace Millenium_Model
{
    public class Rota : ClassePai
    {
        public Rota()
        {
            Endereco = new Endereco();
            Dia = new Dia();
            Area = new Area();
            Cliente = new Cliente();
        }

        public int IdRota { get; set; }
        public int Sequencia { get; set; }
        public int IdOperador { get; set; }
        public int IdMaquina { get; set; }
        public string Descricao { get; set; }
        public Dia Dia { get; set; }
        public Endereco Endereco { get; set; }
        public Area Area { get; set; }
        public Cliente Cliente { get; set; }
        public string NomeMaquina { get; set; }
    }
}
