using Dapper;
using Dominio.Objeto;
using System;
using System.Collections.Generic;
using System.Data;

namespace Repositorio.Repositorio
{
    public class RepositorioPessoaJuridica
    {
        public void AdicionarPessoaJuridica(PessoaJuridica pessoaJuridica)
        {
            using (IDbConnection dbConnection = ConfigBanco.GetConnection())
            {
                string sql = @"INSERT INTO PessoaJuridica (cod_PessoaJuridica, razao_social, inscricao_estadual, cnpj, eh_representante) 
                               VALUES (@Codigo, @RazaoSocial, @InscricaoEstadual, @CNPJ, @EhRepresentante)";

                dbConnection.Execute(sql, new
                {
                    pessoaJuridica.Codigo,
                    pessoaJuridica.RazaoSocial,
                    pessoaJuridica.InscricaoEstadual,
                    pessoaJuridica.CNPJ,
                    pessoaJuridica.EhRepresentante
                });
            }
        }

        public void AtualizarPessoaJuridica(PessoaJuridica pessoaJuridica)
        {
            using (IDbConnection dbConnection = ConfigBanco.GetConnection())
            {
                string sql = @"UPDATE PessoaJuridica 
                               SET razao_social = @RazaoSocial, inscricao_estadual = @InscricaoEstadual, 
                               cnpj = @CNPJ, eh_representante = @EhRepresentante 
                               WHERE cod_PessoaJuridica = @Codigo";

                dbConnection.Execute(sql, new
                {
                    pessoaJuridica.Codigo,
                    pessoaJuridica.RazaoSocial,
                    pessoaJuridica.InscricaoEstadual,
                    pessoaJuridica.CNPJ,
                    pessoaJuridica.EhRepresentante
                });
            }
        }

        public void DeletarPessoaJuridica(int id)
        {
            using (IDbConnection dbConnection = ConfigBanco.GetConnection())
            {
                string sql = "DELETE FROM PessoaJuridica WHERE cod_PessoaJuridica = @Codigo";

                dbConnection.Execute(sql, new { Codigo = id });
            }
        }

        public PessoaJuridica ObterPessoaJuridicaPorId(int id)
        {
            using (IDbConnection dbConnection = ConfigBanco.GetConnection())
            {
                string sql = @"
                            SELECT 
                                cod_PessoaJuridica AS Codigo,
                                razao_social AS RazaoSocial,
                                inscricao_estadual AS InscricaoEstadual,
                                cnpj AS CNPJ,
                                eh_representante AS EhRepresentante
                            FROM PessoaJuridica WHERE cod_PessoaJuridica = @Codigo";

                return dbConnection.QuerySingleOrDefault<PessoaJuridica>(sql, new { Codigo = id });
            }
        }

        public IList<PessoaJuridica> ObterTodasPessoasJuridicas()
        {
            using (IDbConnection dbConnection = ConfigBanco.GetConnection())
            {
                string sql = @"
                            SELECT 
                                cod_PessoaJuridica AS Codigo,
                                razao_social AS RazaoSocial,
                                inscricao_estadual AS InscricaoEstadual,
                                cnpj AS CNPJ,
                                eh_representante AS EhRepresentante
                            FROM PessoaJuridica";

                return dbConnection.Query<PessoaJuridica>(sql).AsList();
            }
        }
        public bool ExistePessoaJuridica(string cnpj)
        {
            if(cnpj.Length > 20 ||  cnpj.Length < 20) return false;

            using (IDbConnection dbConnection = ConfigBanco.GetConnection())
            {
                string sql = "SELECT COUNT(*) FROM PessoaJuridica WHERE cnpj = @cnpj";
                
                int count = dbConnection.ExecuteScalar<int>(sql, new { cnpj });
                    
                var existe = count == 1;

                return existe;
            }
        }
    }
}