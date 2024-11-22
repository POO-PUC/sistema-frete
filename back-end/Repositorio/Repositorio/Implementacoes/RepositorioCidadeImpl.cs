using Dapper;
using Dominio.Objeto;
using Repositorio.Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;

namespace Repositorio.Repositorio
{
    public class RepositorioCidadeImpl : IRepositorioCidade
    {
        public void AdicionarCidade(Cidade cidade)
        {
            using (IDbConnection dbConnection = ConfigBanco.GetConnection())
            {
                string sql = @"INSERT INTO Cidade (nome_cidade, id_estado, valor) 
                               VALUES (@Nome, @CodigoDoEstado, @PrecoPadrao)";

                dbConnection.Execute(sql, new
                {
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
                string sql = "SELECT * FROM Cidade WHERE id_cidade = @Codigo";

                return dbConnection.QuerySingleOrDefault<Cidade>(sql, new { Codigo = id });
            }
        }

        public IList<Cidade> ObterTodasCidades()
        {
            using (IDbConnection dbConnection = ConfigBanco.GetConnection())
            {
                string sql = "SELECT * FROM Cidade";

                return dbConnection.Query<Cidade>(sql).AsList();
            }
        }
        public bool CidadeExiste(string nomeCidade, int codigoEstado)
        {
            using (IDbConnection dbConnection = ConfigBanco.GetConnection())
            {
                string sql = @"SELECT COUNT(*) FROM Cidade WHERE nome_cidade = @NomeCidade AND id_estado = @CodigoEstado";
                
                int count = dbConnection.ExecuteScalar<int>(sql, new
                {
                    NomeCidade = nomeCidade,
                    CodigoEstado = codigoEstado
                });

                return count > 0;
            }
        }
    }
}