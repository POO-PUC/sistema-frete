using Dapper;
using Dominio.Objeto;
using Repositorio.Repositorio.Interfaces;
using System.Collections.Generic;
using System.Data;


namespace Repositorio.Repositorio
{
    public class RepositorioClienteImpl : IRepositorioCliente
    {
        public void AdicionarCliente(Cliente cliente)
        {
            using (IDbConnection dbConnection = ConfigBanco.GetConnection())
            {
                string sql = @"INSERT INTO Cliente (endereco, telefone, data_inscricao) 
                               VALUES (@Endereco, @Telefone, @DataDeInscricao)";

                dbConnection.Execute(sql, new
                {
                    cliente.Endereco,
                    cliente.Telefone,
                    cliente.DataDeInscricao
                });
            }
        }

        public void AtualizarCliente(Cliente cliente)
        {
            using (IDbConnection dbConnection = ConfigBanco.GetConnection())
            {
                string sql = @"UPDATE Cliente 
                               SET endereco = @Endereco, telefone = @Telefone, data_inscricao = @DataDeInscricao 
                               WHERE cod_cliente = @Codigo";

                dbConnection.Execute(sql, new
                {
                    cliente.Codigo,
                    cliente.Endereco,
                    cliente.Telefone,
                    cliente.DataDeInscricao
                });
            }
        }

        public void DeletarCliente(int id)
        {
            using (IDbConnection dbConnection = ConfigBanco.GetConnection())
            {
                string sql = "DELETE FROM Cliente WHERE cod_cliente = @Codigo";

                dbConnection.Execute(sql, new { Codigo = id });
            }
        }

        public Cliente ObterClientePorId(int id)
        {
            using (IDbConnection dbConnection = ConfigBanco.GetConnection())
            {
                string sql = "SELECT * FROM Cliente WHERE cod_cliente = @Codigo";

                return dbConnection.QuerySingleOrDefault<Cliente>(sql, new { Codigo = id });
            }
        }

        public IList<Cliente> ObterTodosClientes()
        {
            using (IDbConnection dbConnection = ConfigBanco.GetConnection())
            {
                string sql = "SELECT * FROM Cliente";

                return dbConnection.Query<Cliente>(sql).AsList();
            }
        }

        public bool ClienteExiste(int cod)
        {
            using (IDbConnection dbConnection = ConfigBanco.GetConnection())
            {
                string sql = "SELECT COUNT(*) FROM Cliente WHERE id = @Codigo";
                
                int count = dbConnection.ExecuteScalar<int>(sql, new { Codigo = cod });

                return count > 0;
            }
        }
    }
}
