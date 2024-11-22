using Dapper;
using Dominio.Objeto;
using System.Collections.Generic;
using System.Data;

namespace Repositorio.Repositorio
{
    public class RepositorioFrete
    {
        public void AdicionarFrete(Frete frete)
        {
            using (IDbConnection dbConnection = ConfigBanco.GetConnection())
            {
                string sql = @"INSERT INTO Frete (id_frete, peso, valor, icms, pedagio, data_frete, id_origem, id_destino, 
                               id_remetente, id_destinatario, id_funcionario, quem_paga, num_conhecimento) 
                               VALUES (@Codigo, @Peso, @Valor, @ICMS, @Pedagio, @DataInicio, @CodigoDaCidadeDeOrigem, 
                               @CodigoDaCidadeDeDestino, @CodigoDoCliente, @CodigoDoDestinatario, 
                               @CodigoDoFuncionario, @QuemPaga, @NumeroDeConhecimento)";

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
                string sql = @"
                            SELECT 
                                id_frete AS Codigo,
                                peso AS Peso,
                                valor AS Valor,
                                icms AS ICMS,
                                pedagio AS Pedagio,
                                data_frete AS DataInicio,
                                id_origem AS CodigoDaCidadeDeOrigem,
                                id_destino AS CodigoDaCidadeDeDestino,
                                id_remetente AS CodigoDoCliente,
                                id_destinatario AS CodigoDoDestinatario,
                                id_funcionario AS CodigoDoFuncionario,
                                quem_paga AS QuemPaga,
                                num_conhecimento AS NumeroDeConhecimento
                            FROM Frete WHERE id_frete = @Codigo";

                return dbConnection.QuerySingleOrDefault<Frete>(sql, new { Codigo = id });
            }
        }

        public IList<Frete> ObterTodosFretes()
        {
            using (IDbConnection dbConnection = ConfigBanco.GetConnection())
            {
                string sql = @"
                            SELECT 
                                id_frete AS Codigo,
                                peso AS Peso,
                                valor AS Valor,
                                icms AS ICMS,
                                pedagio AS Pedagio,
                                data_frete AS DataInicio,
                                id_origem AS CodigoDaCidadeDeOrigem,
                                id_destino AS CodigoDaCidadeDeDestino,
                                id_remetente AS CodigoDoCliente,
                                id_destinatario AS CodigoDoDestinatario,
                                id_funcionario AS CodigoDoFuncionario,
                                quem_paga AS QuemPaga,
                                num_conhecimento AS NumeroDeConhecimento
                            FROM Frete";

                return dbConnection.Query<Frete>(sql).AsList();
            }
        }



        public bool ExisteFrete(int codigo)
        {
            if (codigo <= 0) return false;

            using (IDbConnection dbConnection = ConfigBanco.GetConnection())
            {
                string sql = @"SELECT COUNT(*) FROM Frete WHERE id_frete = @codigo";

                int count = dbConnection.ExecuteScalar<int>(sql, new { codigo });

                var existe = count == 1;

                return existe;
            }
        }
    }
}