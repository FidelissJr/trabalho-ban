using ConsoleApp.Model;
using Dapper;
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
    }
}
