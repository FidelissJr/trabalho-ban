using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Model
{
    public class Motorista
    {
        public Motorista(int cnh, string nome, string email, bool ativo, DateTime dtNascimento)
        {
            Cnh = cnh;
            Nome = nome;
            Email = email;
            Ativo = ativo;
            DtNascimento = dtNascimento;
        }

        public Motorista()
        {

        }
        public int IdMotorista { get; set; }
        public int Cnh { get; set; }
        public string Nome { get; set; }       
        public string Email { get; set; }
        public bool Ativo { get; set; }
        public DateTime DtNascimento { get; set; }

    }
}
