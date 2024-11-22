using Dominio.Objeto;
using DTO.DTOs;
using Repositorio.Validacoes;
using System;

namespace Repositorio.Conversor
{
    public static class ConversorCidade
    {
        public static DTOCidade ConverterParaDTO(Cidade cidade)
        {
            if (cidade == null) return null;

            var dtoCidade = new DTOCidade();

            dtoCidade.Codigo = cidade.Codigo;
            dtoCidade.CodigoDoEstado = cidade.CodigoDoEstado;
            dtoCidade.Nome = cidade.Nome;
            dtoCidade.PrecoPadrao = cidade.PrecoPadrao;

            return dtoCidade;
        }

        public static Cidade ConverterParaDominio(DTOCidade dtoCidade)
        {
            if (dtoCidade == null) return null;

            var cidade = new Cidade();

            var validacaoCidade = new ValidacaoCidade();
                cidade.Codigo = dtoCidade.Codigo;
                cidade.CodigoDoEstado = dtoCidade.CodigoDoEstado;
                cidade.Nome = dtoCidade.Nome;
                cidade.PrecoPadrao = dtoCidade.PrecoPadrao;
           

            return cidade;
        }
    }
}
