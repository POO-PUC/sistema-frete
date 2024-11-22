using Dapper;
using Dominio.Objeto;
using System.Collections.Generic;
using System.Data;

namespace Repositorio.Repositorio
{
    public class RepositorioEstado
    {
        public void AdicionarEstado(Estado estado)
        {
            using (IDbConnection dbConnection = ConfigBanco.GetConnection())
            {
                string sql = @"INSERT INTO Estado (id_estado,nome_estado, uf, icms_local, icms_outro_uf) 
                               VALUES (@Codigo, @Nome, @Uf, @ICMSLocal, @ICMSExterno)";

                dbConnection.Execute(sql, new
                {
                    estado.Codigo,
                    estado.Nome,
                    estado.Uf,
                    estado.ICMSLocal,
                    estado.ICMSExterno
                });
            }
        }

        public void AtualizarEstado(Estado estado)
        {
            using (IDbConnection dbConnection = ConfigBanco.GetConnection())
            {
                string sql = @"UPDATE Estado 
                               SET nome_estado = @Nome, uf = @Uf, icms_local = @ICMSLocal, icms_outro_uf = @ICMSExterno 
                               WHERE id_estado = @Codigo";

                dbConnection.Execute(sql, new
                {
                    estado.Codigo,
                    estado.Nome,
                    estado.Uf,
                    estado.ICMSLocal,
                    estado.ICMSExterno
                });
            }
        }

        public void DeletarEstado(int id)
        {
            using (IDbConnection dbConnection = ConfigBanco.GetConnection())
            {
                string sql = "DELETE FROM Estado WHERE id_estado = @Codigo";

                dbConnection.Execute(sql, new { Codigo = id });
            }
        }

        public Estado ObterEstadoPorId(int id)
        {
            using (IDbConnection dbConnection = ConfigBanco.GetConnection())
            {
                string sql = @"
                            SELECT 
                                id_estado AS Codigo,
                                nome_estado AS Nome,
                                uf,
                                icms_local AS ICMSLocal,
                                icms_outro_uf AS ICMSExterno
                            FROM Estado WHERE id_estado = @Codigo";

                return dbConnection.QuerySingleOrDefault<Estado>(sql, new { Codigo = id });
            }
        }

        public IList<Estado> ObterTodosEstados()
        {
            using (IDbConnection dbConnection = ConfigBanco.GetConnection())
            {
                string sql = @"
                            SELECT 
                                id_estado AS Codigo,
                                nome_estado AS Nome,
                                uf,
                                icms_local AS ICMSLocal,
                                icms_outro_uf AS ICMSExterno
                            FROM Estado";

                return dbConnection.Query<Estado>(sql).AsList();
            }
        }

        public bool ExisteEstado(int codigo)
        {
            if (codigo <= 0) return false;

            using (IDbConnection dbConnection = ConfigBanco.GetConnection())
            {
                string sql = @"SELECT COUNT(*) FROM Estado WHERE id_estado = @codigo";
                
                int count = dbConnection.ExecuteScalar<int>(sql, new { codigo });

                var existe = count == 1;

                return existe;
            }
        }
    }
}