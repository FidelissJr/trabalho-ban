using System;

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
        public override string ToString()
        {
            return
                $"Id: {IdMotorista}\n" +
                $"Nome: {Nome}\n" +
                $"Cnh: {Cnh}\n" +
                $"Email: {Email}\n" +
                $"Ativo: {Ativo}\n" +
                $"Data de Nascimento: {DtNascimento.ToString("d")}\n\n";
        }

    }
}
