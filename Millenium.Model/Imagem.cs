namespace Millenium_Model
{
    public class Imagem
    {
        public Imagem()
        {
            Image = new byte[0];
        }

        public int IdImagem { get; set; }
        public string Nome { get; set; }
        public string Mime { get; set; }
        public byte[] Image { get; set; }
    }
}
