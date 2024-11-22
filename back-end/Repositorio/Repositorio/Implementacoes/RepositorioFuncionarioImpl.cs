using Dapper;
using Dominio.Objeto;
using Repositorio.Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;

namespace Repositorio.Repositorio
{
    public class RepositorioFuncionarioImpl : IRepositorioFuncionario
    {
        public void AdicionarFuncionario(Funcionario funcionario)
        {
            using (IDbConnection dbConnection = ConfigBanco.GetConnection())
            {
                string sql = @"INSERT INTO Funcionario (nome_funcionario, num_registro) 
                               VALUES (@Nome, @NumeroDeRegistro)";

                dbConnection.Execute(sql, new
                {
                    funcionario.Nome,
                    funcionario.NumeroDeRegistro
                });
            }
        }

        public void AtualizarFuncionario(Funcionario funcionario)
        {
            using (IDbConnection dbConnection = ConfigBanco.GetConnection())
            {
                string sql = @"UPDATE Funcionario 
                               SET nome_funcionario = @Nome, num_registro = @NumeroDeRegistro 
                               WHERE id_funcionario = @Codigo";

                dbConnection.Execute(sql, new
                {
                    funcionario.Codigo,
                    funcionario.Nome,
                    funcionario.NumeroDeRegistro
                });
            }
        }

        public void DeletarFuncionario(int id)
        {
            using (IDbConnection dbConnection = ConfigBanco.GetConnection())
            {
                string sql = "DELETE FROM Funcionario WHERE id_funcionario = @Codigo";

                dbConnection.Execute(sql, new { Codigo = id });
            }
        }

        public Funcionario ObterFuncionarioPorId(int id)
        {
            using (IDbConnection dbConnection = ConfigBanco.GetConnection())
            {
                string sql = "SELECT * FROM Funcionario WHERE id_funcionario = @Codigo";

                return dbConnection.QuerySingleOrDefault<Funcionario>(sql, new { Codigo = id });
            }
        }

        public IList<Funcionario> ObterTodosFuncionarios()
        {
            using (IDbConnection dbConnection = ConfigBanco.GetConnection())
            {
                string sql = "SELECT * FROM Funcionario";

                return dbConnection.Query<Funcionario>(sql).AsList();
            }
        }
    public bool NumeroDeRegistroExiste(int registryNumber)
    {
        using (IDbConnection dbConnection = ConfigBanco.GetConnection())
        {
            string sql = "SELECT COUNT(*) FROM Funcionario WHERE num_registro = @RegistryNumber";
            
            int count = dbConnection.ExecuteScalar<int>(sql, new { RegistryNumber = registryNumber });

            return count > 0;
        }
    }
    }

}