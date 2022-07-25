using ConsoleApp.AcessoBanco;
using ConsoleApp.Model;
using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int opcao = -1;
                do
                {
                    Console.Clear();
                    Console.WriteLine("1-Cadastrar Motorista" +
                        "\n2-Listar Motoristas" +
                        "\n3-Cadastrar Onibus" +
                        "\n4-Listar Onibus" +
                        "\n5-Cadastrar Linha" +
                        "\n6-Listar Linha" +
                        "\n7-Buscar nome do motorista pela capacidade do onibus: " +
                        "\n8-Buscar o onibus de maior capacidade: " +
                        "\n9-Buscar quantidade de linhas para cada onibus: ");
                    //"\n10-Buscar o onibus de maior capacidade: ");
                    Console.Write("Opção desejada: ");
                    opcao = int.Parse(Console.ReadLine());
                    switch (opcao)
                    {
                        case 1:
                            AdicionarMotorista();
                            break;
                        case 2:
                            ListarMotoristas();
                            break;
                        case 3:
                            AdicionarOnibus();
                            break;
                        case 4:
                            ListarOnibus();
                            break;
                        case 5:
                            AdicionarLinha();
                            break;
                        case 6:
                            ListarLinha();
                            break;
                        case 7:
                            Console.Write("Capacidade do ônibus: ");
                            int capacidade = int.Parse(Console.ReadLine());
                            BuscarMotoristaPelaCapacidade(capacidade);
                            break;
                        case 8:
                            BuscarOnibusMaiorCapacidade();
                            break;
                        case 9:
                            BuscarOnibusLinhas();
                            break;
                        default:
                            Console.WriteLine("Informe uma opção válida..");
                            break;
                    }
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadLine();


                }
                while (opcao != 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }

        #region Motorista

        public static void AdicionarMotorista()
        {
            try
            {

                Console.WriteLine("----------CADASTRO DE MOTORISTA----------\n\n\n");
                MotoristaDAO dao = new MotoristaDAO();
                //Leitura de dados e criação do objeto Motorista
                Console.Write("Nome: ");
                string nome = Console.ReadLine();
                Console.Write("Email: ");
                string email = Console.ReadLine();
                Console.Write("CNH: ");
                int cnh = int.Parse(Console.ReadLine());
                Console.Write("Ativo(true/false): ");
                bool ativo = bool.Parse(Console.ReadLine());
                Console.Write("Data de Nascimento (dd/mm/aaaa): ");
                DateTime dtNascimento = DateTime.Parse(Console.ReadLine());

                Motorista motorista = new Motorista(cnh, nome, email, ativo, dtNascimento);
                dao.AdicionarMotorista(motorista);
                Console.WriteLine("Motorista adicinado com sucesso!");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static void ListarMotoristas()
        {
            Console.WriteLine("----------MOTORISTAS----------\n\n\n");
            MotoristaDAO dao = new MotoristaDAO();
            List<Motorista> motoristas = dao.GetMotoristas();
            foreach (Motorista motorista in motoristas)
                Console.WriteLine(motorista.ToString());
        }

        public static void BuscarMotoristaPelaCapacidade(int capacidade)
        {
            Console.WriteLine("----------MOTORISTAS----------\n\n\n");
            MotoristaDAO dao = new MotoristaDAO();
            List<Motorista> motoristas = dao.BuscarMotoristaPelaCapacidade(capacidade);
            foreach (Motorista motorista in motoristas)
                Console.WriteLine(motorista.ToString());
        }

        #endregion

        #region Onibus
        public static void AdicionarOnibus()
        {
            try
            {

                Console.WriteLine("----------CADASTRO DE ONIBUS----------\n\n\n");
                OnibusDAO dao = new OnibusDAO();
                //Leitura de dados e criação do objeto Motorista
                Console.Write("Modelo: ");
                string modelo = Console.ReadLine();
                Console.Write("Placa: ");
                string placa = Console.ReadLine();
                Console.Write("Cor: ");
                string cor = Console.ReadLine();
                Console.Write("Capacidade");
                int capacidade = int.Parse(Console.ReadLine());
                Console.Write("Observação: ");
                string observacao = Console.ReadLine();

                Onibus onibus = new Onibus(cor, placa, modelo, observacao, capacidade);
                dao.AdicionarOnibus(onibus);
                Console.WriteLine("Onibus adicionado com sucesso!");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public static void ListarOnibus()
        {
            Console.WriteLine("----------Onibus----------\n\n\n");
            OnibusDAO dao = new OnibusDAO();
            List<Onibus> onibus = dao.GetOnibus();
            foreach (Onibus o in onibus)
                Console.WriteLine(o.ToString());
        }
        public static void BuscarOnibusMaiorCapacidade()
        {
            Console.WriteLine("----------Onibus de maior capacidade----------\n\n\n");
            OnibusDAO dao = new OnibusDAO();
            List<Onibus> onibus = dao.BuscarOnibusMaiorCapacidade();
            foreach (Onibus o in onibus)
                Console.WriteLine(o.ToString());
        }
        public static void BuscarOnibusLinhas()
        {
            Console.WriteLine("----------Onibus mais utilizado em linhas----------\n\n\n");
            OnibusDAO dao = new OnibusDAO();
            List<Onibus> onibus = dao.GetOnibus();
            foreach (Onibus o in onibus)
            {
                Console.WriteLine($"Modelo: {o.Modelo}");
                Console.WriteLine($"Placa: {o.Placa}");
                Console.WriteLine($"Qtd. Linhas: {dao.CountOnibusLinha(o.IdOnibus)}\n\n");
            }
        }
        #endregion

        #region Linha
        public static void AdicionarLinha()
        {
            try
            {

                Console.WriteLine("----------CADASTRO DE LINHA----------\n\n\n");
                LinhaDAO dao = new LinhaDAO();
                //Leitura de dados e criação do objeto Motorista
                Console.Write("Nome da Linha: ");
                string nome = Console.ReadLine();
                Console.Write("Trajeto: ");
                string trajeto = Console.ReadLine();
                Console.Write("Id do Motorista Responsável: ");
                int? idMotorista = int.Parse(Console.ReadLine());
                Console.Write("Id do Onibus Responsável: ");
                int? idOnibus = int.Parse(Console.ReadLine());
                Linha linha = new Linha(nome, trajeto, idMotorista == 0 ? null : idMotorista, idOnibus == 0 ? null : idMotorista);
                dao.AdicionarLinha(linha);
                Console.WriteLine("Linha adicinada com sucesso!");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Falha ao adicionar linha" + ex);
            }
        }

        public static void ListarLinha()
        {
            Console.WriteLine("----------LINHAS----------\n\n\n");
            LinhaDAO dao = new LinhaDAO();
            List<Linha> linhas = dao.GetLinhas();
            foreach (Linha linha in linhas)
            {
                Console.WriteLine($"Nome: {linha.Nome}");
                Console.WriteLine($"Trajeto: {linha.Trajeto}");
                if (linha.Onibus != null)
                    Console.WriteLine($"Onibus Placa: {linha.Onibus.Placa}");
                else
                    Console.WriteLine("Linha sem Ônibus");
                if (linha.Motorista != null)
                    Console.WriteLine($"Motorista: {linha.Motorista.Nome} - CNH: {linha.Motorista.Cnh}\n\n");
                else
                    Console.WriteLine("Linha sem Motorista\n\n");

            }
        }
        #endregion

    }
}
