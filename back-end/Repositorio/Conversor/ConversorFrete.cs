using Dominio.Objeto;
using DTO.DTOs;
using Repositorio.Validacoes;
using System;

namespace Repositorio.Conversor
{
    public static class ConversorFrete
    {
        public static DTOFrete ConverterParaDTO(Frete frete)
        {
            var dtoFrete = new DTOFrete();

            dtoFrete.Codigo = frete.Codigo;
            dtoFrete.CodigoDaCidadeDeDestino = frete.CodigoDaCidadeDeDestino;
            dtoFrete.CodigoDaCidadeDeOrigem = frete.CodigoDaCidadeDeOrigem;
            dtoFrete.CodigoDoCliente = frete.CodigoDoCliente;
            dtoFrete.CodigoDoDestinatario = frete.CodigoDoDestinatario;
            dtoFrete.CodigoDoFuncionario = frete.CodigoDoFuncionario;
            dtoFrete.DataInicio = frete.DataInicio;
            dtoFrete.ICMS = frete.ICMS;
            dtoFrete.NumeroDeConhecimento = frete.NumeroDeConhecimento;
            dtoFrete.Pedagio = frete.Pedagio;
            dtoFrete.Peso = frete.Peso;
            dtoFrete.QuemPaga = frete.QuemPaga;
            dtoFrete.Valor = frete.Valor;
            
            return dtoFrete;
        }

        public static Frete ConverterParaDominio(DTOFrete dtoFrete)
        {
            if (dtoFrete == null) return null;

            var frete = new Frete();

            var validacaoFrete = new ValidacaoFrete();

            
                frete.Codigo = dtoFrete.Codigo;
                frete.CodigoDaCidadeDeDestino = dtoFrete.CodigoDaCidadeDeDestino;
                frete.CodigoDaCidadeDeOrigem = dtoFrete.CodigoDaCidadeDeOrigem;
                frete.CodigoDoCliente = dtoFrete.CodigoDoCliente;
                frete.CodigoDoDestinatario = dtoFrete.CodigoDoDestinatario;
                frete.CodigoDoFuncionario = dtoFrete.CodigoDoFuncionario;
                frete.DataInicio = dtoFrete.DataInicio;
                frete.ICMS = dtoFrete.ICMS;
                frete.NumeroDeConhecimento = dtoFrete.NumeroDeConhecimento;
                frete.Pedagio = dtoFrete.Pedagio;
                frete.Peso = dtoFrete.Peso;
                frete.QuemPaga = dtoFrete.QuemPaga;
                frete.Valor = dtoFrete.Valor;
           

            return frete;
        }
    }
}
