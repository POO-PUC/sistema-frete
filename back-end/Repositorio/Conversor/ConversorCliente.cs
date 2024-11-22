using Dominio.Objeto;
using DTO.DTOs;
using Repositorio.Validacoes;
using System;

namespace Repositorio.Conversor
{
    public static class ConversorCliente
    {
        public static DTOCliente ConverterParaDTO(Cliente cliente)
        {
            if (cliente == null) return null;

            var dtoCliente = new DTOCliente();

            dtoCliente.Codigo = cliente.Codigo;
            dtoCliente.DataDeInscricao = cliente.DataDeInscricao;
            dtoCliente.Endereco = cliente.Endereco;
            dtoCliente.Telefone = cliente.Telefone;

            return dtoCliente;
        }

        public static Cliente ConverterParaDominio(DTOCliente dtoCliente)
        {
            if (dtoCliente == null) return null;

            var cliente = new Cliente();

            var validacaoCliente = new ValidacaoCliente();

            
                cliente.Codigo = dtoCliente.Codigo;
                cliente.DataDeInscricao = dtoCliente.DataDeInscricao;
                cliente.Endereco = dtoCliente.Endereco;
                cliente.Telefone = dtoCliente.Telefone;
            

            return cliente;
        }
    }
}
