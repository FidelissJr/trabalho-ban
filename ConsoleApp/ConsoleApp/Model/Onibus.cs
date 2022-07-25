using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Model
{
    public class Onibus
    {
        public Onibus(string cor, string placa, string modelo, string observacao, int capacidade)
        {
            Cor = cor;
            Placa = placa;
            Modelo = modelo;
            Observacao = observacao;
            Capacidade = capacidade;
        }

        public Onibus()
        {
        }
        public long IdOnibus { get; set; }
        public string Cor { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Observacao { get; set; }
        public int Capacidade { get; set; }

    }
}
