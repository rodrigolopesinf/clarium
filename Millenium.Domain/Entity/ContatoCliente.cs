namespace Millenium.Domain.Entity
{
    public class ContatoCliente
    {
        public int IdCliente { get; set; }
        public int IdContato { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Contato Contato { get; set; }
    }
}
