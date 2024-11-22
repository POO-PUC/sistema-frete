using Dapper;
using Dominio.Objeto;
using Repositorio.Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;

namespace Repositorio.Repositorio
{
    public class RepositorioPessoaJuridicaImpl : IRepositorioPessoaJuridica
    {
        public void AdicionarPessoaJuridica(PessoaJuridica pessoaJuridica)
        {
            using (IDbConnection dbConnection = ConfigBanco.GetConnection())
            {
                string sql = @"INSERT INTO PessoaJuridica (razao_social, inscricao_estadual, cnpj, eh_representante) 
                               VALUES (@RazaoSocial, @InscricaoEstadual, @CNPJ, @EhRepresentante)";

                dbConnection.Execute(sql, new
                {
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
                               WHERE id_cliente = @Codigo";

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
                string sql = "SELECT * FROM PessoaJuridica WHERE cod_PessoaJuridica = @Codigo";

                return dbConnection.QuerySingleOrDefault<PessoaJuridica>(sql, new { Codigo = id });
            }
        }

        public IList<PessoaJuridica> ObterTodasPessoasJuridicas()
        {
            using (IDbConnection dbConnection = ConfigBanco.GetConnection())
            {
                string sql = "SELECT * FROM PessoaJuridica";

                return dbConnection.Query<PessoaJuridica>(sql).AsList();
            }
        }
        public bool CNPJExiste(string cnpj)
        {
            using (IDbConnection dbConnection = ConfigBanco.GetConnection())
            {
                string sql = "SELECT COUNT(*) FROM PessoaJuridica WHERE cnpj = @Cnpj";
                
                int count = dbConnection.ExecuteScalar<int>(sql, new { Cnpj = cnpj });

                return count > 0;
            }
        }
    }
}