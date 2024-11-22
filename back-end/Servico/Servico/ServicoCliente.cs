using Dominio.Objeto;
using DTO.DTOs;
using Repositorio.Conversor;
using Repositorio.Repositorio;
using System;
using System.Collections.Generic;

namespace Servico
{
    public class ServicoCliente
    {
        private readonly RepositorioCliente _repositorioCliente;

        public ServicoCliente()
        {
            _repositorioCliente = new RepositorioCliente();
        }

        public void AdicionarCliente(DTOCliente dtoCliente)
        {
            if (dtoCliente == null)
                throw new ArgumentNullException(nameof(dtoCliente), "O cliente não pode ser nulo.");

            var cliente = ConversorCliente.ConverterParaDominio(dtoCliente);

            _repositorioCliente.AdicionarCliente(cliente);
        }

        public void AtualizarCliente(DTOCliente dtoCliente)
        {
            if (dtoCliente == null)
                throw new ArgumentNullException(nameof(dtoCliente), "O cliente não pode ser nulo.");

            var cliente = ConversorCliente.ConverterParaDominio(dtoCliente);

            _repositorioCliente.AtualizarCliente(cliente);
        }

        public void DeletarCliente(int id)
        {
            if (id <= 0)
                throw new ArgumentException("O código do cliente deve ser válido.");

            var cliente = _repositorioCliente.ObterClientePorId(id);

            if (cliente == null)
                throw new KeyNotFoundException("Cliente não encontrado.");

            _repositorioCliente.DeletarCliente(id);
        }

        public DTOCliente ObterClientePorId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("O código do cliente deve ser válido.");

            var cliente = _repositorioCliente.ObterClientePorId(id);

            if (cliente == null)
                throw new KeyNotFoundException("Cliente não encontrado.");

            var dtoCliente = ConversorCliente.ConverterParaDTO(cliente);

            return dtoCliente;
        }

        public IList<DTOCliente> ObterTodosClientes()
        {
            var listaClientes = _repositorioCliente.ObterTodosClientes();
            var listaDTOCliente = new List<DTOCliente>();

            foreach (var cliente in listaClientes)
            {
                var dtoCliente = ConversorCliente.ConverterParaDTO(cliente);
                listaDTOCliente.Add(dtoCliente);
            }

            return listaDTOCliente;
        }
    }
}
