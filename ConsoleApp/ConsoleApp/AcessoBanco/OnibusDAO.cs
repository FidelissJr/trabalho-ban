﻿using ConsoleApp.Model;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ConsoleApp.AcessoBanco
{
    public class OnibusDAO
    {

        private const string CONNECTION_STRING = @"Server=192.168.2.184\SQLEXPRESS;Database=Rodoviaria;User Id=sa;Password=sa@123;";
        public List<Onibus> GetOnibus()
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                List<Onibus> onibus = conn.Query<Onibus>("SELECT * FROM Onibus").ToList();
                return onibus;
            }

        }

        public void AdicionarOnibus(Onibus onibus)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                string sql = string.Format("INSERT INTO Onibus ({0})", ParametrosInsert);
                conn.Execute(sql, new Onibus
                {
                    IdOnibus = onibus.IdOnibus,
                    Placa = onibus.Placa,
                    Observacao = onibus.Observacao,
                    Cor = onibus.Cor,
                    Modelo = onibus.Modelo,
                    Capacidade = onibus.Capacidade
                });
            }
        }

        public List<Onibus> BuscarOnibusMaiorCapacidade()
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                List<Onibus> onibus = conn.Query<Onibus>("SELECT * FROM Onibus o1 WHERE NOT EXISTS(Select * From Onibus o2 Where o2.capacidade > o1.capacidade)").ToList();
                return onibus;
            }

        }

        //public List<Onibus> BuscarOnibusLinhas()
        //{
        //    using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
        //    {
        //        List<Onibus> onibus = conn.Query<Onibus>("SELECT idOnibus, COUNT(idLinha) AS capacidade FROM Linha GROUP BY idOnibus ORDER BY COUNT(idOnibus) DESC;").ToList();
        //        return onibus;
        //    }
        //}

        public int CountOnibusLinha(int idOnibus)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                return conn.Query<int>("SELECT COUNT(*) FROM Linha WHERE idOnibus = @IdOnibus", new { IdOnibus = idOnibus }).FirstOrDefault();
            }
        }
        private string ParametrosInsert
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("placa, observacao, cor, modelo, capacidade");
                sb.Append(") VALUES (");
                sb.Append("@Placa, @Observacao, @Cor, @Modelo, @Capacidade");
                return sb.ToString();
            }
        }
    }
}
