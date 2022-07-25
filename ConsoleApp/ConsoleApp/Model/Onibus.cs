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
        public int IdOnibus { get; set; }
        public string Cor { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Observacao { get; set; }
        public int Capacidade { get; set; }

        public override string ToString()
        {
            return
                $"Id: {IdOnibus}\n" +
                $"Modelo: {Modelo}\n" +
                $"Placa: {Placa}\n" +
                $"Cor: {Cor}\n" +
                $"Capacidade: {Capacidade}" +
                $"Observação: {Observacao}\n\n";
        }

    }
}
