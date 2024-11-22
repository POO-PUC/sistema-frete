using Dapper;
using Dominio.Objeto;
using System;
using System.Collections.Generic;
using System.Data;

namespace Repositorio.Repositorio
{
    public class RepositorioCidade
    {
        public void AdicionarCidade(Cidade cidade)
        {
            using (IDbConnection dbConnection = ConfigBanco.GetConnection())
            {
                string sql = @"INSERT INTO Cidade (id_cidade, nome_cidade, id_estado, valor) 
                               VALUES (@Codigo, @Nome, @CodigoDoEstado, @PrecoPadrao)";

                dbConnection.Execute(sql, new
                {
                    cidade.Codigo,
                    cidade.Nome,
                    cidade.CodigoDoEstado,
                    cidade.PrecoPadrao
                });
            }
        }

        public void AtualizarCidade(Cidade cidade)
        {
            using (IDbConnection dbConnection = ConfigBanco.GetConnection())
            {
                string sql = @"UPDATE Cidade 
                               SET nome_cidade = @Nome, id_estado = @CodigoDoEstado, valor = @PrecoPadrao 
                               WHERE id_cidade = @Codigo";

                dbConnection.Execute(sql, new
                {
                    cidade.Codigo,
                    cidade.Nome,
                    cidade.CodigoDoEstado,
                    cidade.PrecoPadrao
                });
            }
        }

        public void DeletarCidade(int id)
        {
            using (IDbConnection dbConnection = ConfigBanco.GetConnection())
            {
                string sql = "DELETE FROM Cidade WHERE id_cidade = @Codigo";

                dbConnection.Execute(sql, new { Codigo = id });
            }
        }

        public Cidade ObterCidadePorId(int id)
        {
            using (IDbConnection dbConnection = ConfigBanco.GetConnection())
            {
                string sql = @"
                            SELECT 
                                id_cidade AS Codigo,
                                nome_cidade AS Nome,
                                id_estado AS CodigoDoEstado,
                                valor AS PrecoPadrao
                            FROM Cidade WHERE id_cidade = @Codigo";

                return dbConnection.QuerySingleOrDefault<Cidade>(sql, new { Codigo = id });
            }
        }

        public IList<Cidade> ObterTodasCidades()
        {
            using (IDbConnection dbConnection = ConfigBanco.GetConnection())
            {
                string sql = @"
                            SELECT 
                                id_cidade AS Codigo,
                                nome_cidade AS Nome,
                                id_estado AS CodigoDoEstado,
                                valor AS PrecoPadrao
                            FROM Cidade";

                return dbConnection.Query<Cidade>(sql).AsList();
            }
        }

        public bool ExisteCidade(int codigo, string nome, int codigoDoEstado)
        {
            if(codigo <= 0) return false;

            using (IDbConnection dbConnection = ConfigBanco.GetConnection())
            {
                string sql = @"SELECT COUNT(*) FROM Cidade WHERE id_cidade = @codigo AND nome_cidade = @nome AND id_estado = @codigoDoEstado";

                int count = dbConnection.ExecuteScalar<int>(sql, new { codigo, nome, codigoDoEstado });

                var existe = count == 1;

                return existe;
            }
        }
    }
}