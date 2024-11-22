using Dapper;
using Dominio.Objeto;
using Repositorio.Repositorio.Interfaces;
using System.Collections.Generic;
using System.Data;

namespace Repositorio.Repositorio
{
    public class RepositorioFreteImpl : IRepositorioFrete
    {
        public void AdicionarFrete(Frete frete)
        {
            using (IDbConnection dbConnection = ConfigBanco.GetConnection())
            {
                string sql = @"INSERT INTO Frete (peso, valor, icms, pedagio, data_frete, id_origem, id_destino, 
                               id_remetente, id_destinatario, id_funcionario, quem_paga, num_conhecimento) 
                               VALUES (@Peso, @Valor, @ICMS, @Pedagio, @DataInicio, @CodigoDaCidadeDeOrigem, 
                               @CodigoDaCidadeDeDestino, @CodigoDoCliente, @CodigoDoDestinatario, 
                               @CodigoDoFuncionario, @QuemPaga, @NumeroDeConhecimento)";

                dbConnection.Execute(sql, new
                {
                    frete.Peso,
                    frete.Valor,
                    frete.ICMS,
                    frete.Pedagio,
                    frete.DataInicio,
                    frete.CodigoDaCidadeDeOrigem,
                    frete.CodigoDaCidadeDeDestino,
                    frete.CodigoDoCliente,
                    frete.CodigoDoDestinatario,
                    frete.CodigoDoFuncionario,
                    frete.QuemPaga,
                    frete.NumeroDeConhecimento
                });
            }
        }

        public void AtualizarFrete(Frete frete)
        {
            using (IDbConnection dbConnection = ConfigBanco.GetConnection())
            {
                string sql = @"UPDATE Frete 
                               SET peso = @Peso, valor = @Valor, icms = @ICMS, pedagio = @Pedagio, 
                               data_frete = @DataInicio, id_origem = @CodigoDaCidadeDeOrigem, 
                               id_destino = @CodigoDaCidadeDeDestino, id_remetente = @CodigoDoCliente, 
                               id_destinatario = @CodigoDoDestinatario, id_funcionario = @CodigoDoFuncionario, 
                               quem_paga = @QuemPaga, num_conhecimento = @NumeroDeConhecimento 
                               WHERE id_frete = @Codigo";

                dbConnection.Execute(sql, new
                {
                    frete.Codigo,
                    frete.Peso,
                    frete.Valor,
                    frete.ICMS,
                    frete.Pedagio,
                    frete.DataInicio,
                    frete.CodigoDaCidadeDeOrigem,
                    frete.CodigoDaCidadeDeDestino,
                    frete.CodigoDoCliente,
                    frete.CodigoDoDestinatario,
                    frete.CodigoDoFuncionario,
                    frete.QuemPaga,
                    frete.NumeroDeConhecimento
                });
            }
        }

        public void DeletarFrete(int id)
        {
            using (IDbConnection dbConnection = ConfigBanco.GetConnection())
            {
                string sql = "DELETE FROM Frete WHERE id_frete = @Codigo";

                dbConnection.Execute(sql, new { Codigo = id });
            }
        }

        public Frete ObterFretePorId(int id)
        {
            using (IDbConnection dbConnection = ConfigBanco.GetConnection())
            {
                string sql = "SELECT * FROM Frete WHERE id_frete = @Codigo";

                return dbConnection.QuerySingleOrDefault<Frete>(sql, new { Codigo = id });
            }
        }

        public IList<Frete> ObterTodosFretes()
        {
            using (IDbConnection dbConnection = ConfigBanco.GetConnection())
            {
                string sql = "SELECT * FROM Frete";

                return dbConnection.Query<Frete>(sql).AsList();
            }
        }
    }
}