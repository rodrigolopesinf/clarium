using System;
using System.Collections.Generic;

namespace Millenium_Model
{
    public class Maquina : ClassePai
    {
        public Maquina()
        {
            Modelo = new Modelo();
            StatusMaquina = new StatusMaquina();
            Endereco = new Endereco();
            Rota = new Rota();
            Cliente = new Cliente();
            ListaTipoDoses = new List<TipoDose>();
        }

        public int IdMaquina { get; set; }
        public Endereco Endereco { get; set; }
        public Modelo Modelo { get; set; }
        public StatusMaquina StatusMaquina { get; set; }
        public Rota Rota { get; set; }
        public Cliente Cliente { get; set; }
        public string NumeroSerie { get; set; }
        public string NumeroIdentificacao { get; set; }
        public string Voltagem { get; set; }
        public string Observacao { get; set; }
        public DateTime? DataAquisicao { get; set; }
        public List<TipoDose> ListaTipoDoses { get; set; }
    }
}
