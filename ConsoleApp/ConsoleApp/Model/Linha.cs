using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Model
{
    public class Linha
    {
        public Linha()
        {
        }
        public Linha(string nome, string trajeto, int? idMotorista, int? idOnibus)
        {
            Nome = nome;
            Trajeto = trajeto;
            IdMotorista = idMotorista;
            IdOnibus = idOnibus;
        }

        public int IdLinha { get; set; }
        public string Nome { get; set; }
        public string Trajeto { get; set; }
        public int? IdMotorista { get; set; }
        public Motorista Motorista { get; set; }
        public int? IdOnibus { get; set; }
        public Onibus Onibus { get; set; }
    }
}
