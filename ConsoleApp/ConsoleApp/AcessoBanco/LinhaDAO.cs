using ConsoleApp.Model;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ConsoleApp.AcessoBanco
{
    public class LinhaDAO
    {
        private const string CONNECTION_STRING = @"Server=192.168.2.184\SQLEXPRESS;Database=Rodoviaria;User Id=sa;Password=sa@123;";
        public List<Linha> GetLinhas()
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                var linhaDictionary = new Dictionary<int, Linha>();
                var linhas = conn.Query<Linha, Onibus, Motorista, Linha>(
                    "select* from Linha l LEFT JOIN Onibus o on o.idOnibus = l.idOnibus LEFT JOIN Motorista m ON l.idMotorista = m.idMotorista",
                    (linha, onibus, motorista) =>
                    {
                        Linha linhaEntry;

                        if (!linhaDictionary.TryGetValue(linha.IdLinha, out linhaEntry))
                        {
                            linhaEntry = linha;
                            linhaDictionary.Add(linhaEntry.IdLinha, linhaEntry);
                        }

                        if (onibus != null)
                            linhaEntry.Onibus = onibus;
                        if (motorista != null)
                            linhaEntry.Motorista = motorista;

                        return linhaEntry;
                    }

                    , splitOn: "idOnibus, idMotorista").Distinct().ToList();

                return linhas;
            }

        }

        public void AdicionarLinha(Linha linha)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                string sql = string.Format("INSERT INTO Linha (nome, trajeto, idMotorista, idOnibus) VALUES (@Nome, @Trajeto, @IdMotorista, @IdOnibus)");
                conn.Execute(sql, new Linha
                {
                    IdLinha = linha.IdLinha,
                    Nome = linha.Nome,
                    Trajeto = linha.Trajeto,
                    IdMotorista = linha.IdMotorista,
                    IdOnibus = linha.IdOnibus
                });
            }

        }

    }
}
