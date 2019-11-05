using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Carros.Models
{
    public class Revisoes
    {
        public int Codigo { get; set; }
        public DateTime? Dt_Revisao { get; set; }
        [Column(TypeName = "decimal(9,3)")]
        public decimal? Valor { get; set; }
        [StringLength(200)]
        public string Oficina { get; set; }
        public int CarrosCodigo { get; set; }
        public Carros Carros { get; set; }
        public DateTime? Dt_Inc { get; set; }


        public Revisoes ()
        {

        }

        public Revisoes(DateTime? dt_Revisao, decimal? valor, string oficina, Carros carros, DateTime? dt_Inc)
        {
            Dt_Revisao = dt_Revisao;
            Valor = valor;
            Oficina = oficina;
            Carros = carros;
            Dt_Inc = dt_Inc;
        }
    }
}
