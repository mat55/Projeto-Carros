using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Projeto_Carros.Models
{
    [JsonObject(IsReference = true)]
    public class Carros
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public DateTime? Dt_Venda { get; set; }
        public string Cor { get; set; }
        
        public virtual ICollection<Revisoes> Revisoes { get; set; }
        public DateTime? Dt_Inc { get; set; }

        public Carros()
        {

        }

        public Carros(string modelo)
        {
            Modelo = modelo;
        }
    }
}
