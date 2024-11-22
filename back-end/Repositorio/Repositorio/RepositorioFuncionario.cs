using Dapper;
using Dominio.Objeto;
using System;
using System.Collections.Generic;
using System.Data;

namespace Repositorio.Repositorio
{
    public class RepositorioFuncionario
    {
        public void AdicionarFuncionario(Funcionario funcionario)
        {
            using (IDbConnection dbConnection = ConfigBanco.GetConnection())
            {
                string sql = @"INSERT INTO Funcionario (id_funcionario, nome_funcionario, num_registro) 
                               VALUES (@Codigo, @Nome, @NumeroDeRegistro)";

                dbConnection.Execute(sql, new
                {
                    funcionario.Codigo,
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
                string sql = @"
                             SELECT
                                id_funcionario AS Codigo,
                                nome_funcionario AS Nome,
                                num_registro AS NumeroDeRegistro
                             FROM Funcionario WHERE id_funcionario = @Codigo";

                return dbConnection.QuerySingleOrDefault<Funcionario>(sql, new { Codigo = id });
            }
        }

        public IList<Funcionario> ObterTodosFuncionarios()
        {
            using (IDbConnection dbConnection = ConfigBanco.GetConnection())
            {
                string sql = @"
                            SELECT 
                                id_funcionario AS Codigo,
                                nome_funcionario AS Nome,
                                num_registro AS NumeroDeRegistro
                            FROM Funcionario";

                return dbConnection.Query<Funcionario>(sql).AsList();
            }
        }

        public bool ExisteFuncionario(int codigo)
        {
            if (codigo <= 0) return false;

            using (IDbConnection dbConnection = ConfigBanco.GetConnection())
            {
                string sql = "SELECT COUNT(*) FROM Funcionario WHERE id_funcionario = @codigo";
            
                int count = dbConnection.ExecuteScalar<int>(sql, new { codigo });

                var existe = count == 1;
            
                return existe;
            }
        }
    }

}