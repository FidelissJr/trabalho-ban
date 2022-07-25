using ConsoleApp.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ConsoleApp
{
    public class MotoristaDAO
    {
        private const string CONNECTION_STRING = @"Server=192.168.2.184\SQLEXPRESS;Database=Rodoviaria;User Id=sa;Password=sa@123;";
        public List<Motorista> GetMotoristas()
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                List<Motorista> motoristas = conn.Query<Motorista>("SELECT * FROM Motorista").ToList();
                return motoristas;
            }
           
        }

        public void AdicionarMotorista(Motorista motorista)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                string sql = string.Format("INSERT INTO Motorista ({0})", ParametrosInsert);
                conn.Execute(sql, PreencherParametros(motorista));
            }
                
        }

        public List<Motorista> BuscarMotoristaPelaCapacidade(int capacidade)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                List<Motorista> motoristas = conn.Query<Motorista>("select * from motorista where idMotorista IN " +
                    "(select idMotorista from Linha where idOnibus IN " +
                    $"(select idOnibus from Onibus where capacidade = {capacidade}))").ToList();
                return motoristas;
            }
        }

        private string ParametrosInsert
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("cnh, nome, email, ativo, dtNascimento");
                sb.Append(") VALUES (");
                sb.Append("@Cnh, @Nome, @Email, @Ativo, @DtNascimento");
                return sb.ToString();
            }
        }

        private static object PreencherParametros(Motorista motorista)
        {
            return new
            {
                motorista.IdMotorista,
                motorista.Cnh,
                motorista.Nome,
                motorista.Email,
                motorista.Ativo,
                motorista.DtNascimento

            };
        }

//        select m.nome, m.cnh from Motorista m inner join Linha l on m.idMotorista = l.idLinha,
//Onibus o where o.idOnibus = l.idOnibus and o.idOnibus IN
//(select idOnibus from Onibus where capacidade >= ALL(select capacidade from Onibus))


            //public IEnumerable<Motorista> GetMotoristas()
            //{
            //    List<Motorista> usuarios = new List<Motorista>();
            //    using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            //    {
            //        conn.Open();
            //        string sql = "SELECT * FROM Motorista";

            //        using (SqlCommand command = new SqlCommand(sql, conn))
            //        {
            //            SqlDataReader reader = command.ExecuteReader();

            //            while (reader.Read())
            //            {
            //                usuarios.Add(new Motorista
            //                {
            //                    Cnh = (long)reader["cnh"],
            //                    Nome = reader["nome"].ToString(),
            //                    DtNascimento = (DateTime)reader["dtNascimento"],
            //                    Email = reader["email"].ToString(),
            //                    Ativo = (bool)reader["ativo"]
            //                });
            //            }

            //            return usuarios;
            //        }
            //    }
            //}
        }
}
