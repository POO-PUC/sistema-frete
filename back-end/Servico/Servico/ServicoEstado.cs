using Dominio.Objeto;
using DTO.DTOs;
using Repositorio.Conversor;
using Repositorio.Repositorio;
using System;
using System.Collections.Generic;

namespace Servico
{
    public class ServicoEstado
    {
        private readonly RepositorioEstado _repositorioEstado;

        public ServicoEstado()
        {
            _repositorioEstado = new RepositorioEstado();
        }

        public void AdicionarEstado(DTOEstado dtoEstado)
        {
            if (dtoEstado == null)
                throw new ArgumentNullException(nameof(dtoEstado), "O estado não pode ser nulo.");

            var estado = ConversorEstado.ConverterParaDominio(dtoEstado);

            _repositorioEstado.AdicionarEstado(estado);
        }

        public void AtualizarEstado(DTOEstado dtoEstado)
        {
            if (dtoEstado == null)
                throw new ArgumentNullException(nameof(dtoEstado), "O estado não pode ser nulo.");

            var estado = ConversorEstado.ConverterParaDominio(dtoEstado);

            _repositorioEstado.AtualizarEstado(estado);
        }

        public void DeletarEstado(int id)
        {
            if (id <= 0)
                throw new ArgumentException("O código do estado deve ser válido.");

            var estado = _repositorioEstado.ObterEstadoPorId(id);

            if (estado == null)
                throw new KeyNotFoundException("Estado não encontrado.");

            _repositorioEstado.DeletarEstado(id);
        }

        public DTOEstado ObterEstadoPorId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("O código do estado deve ser válido.");

            var estado = _repositorioEstado.ObterEstadoPorId(id);

            if (estado == null)
                throw new KeyNotFoundException("Estado não encontrado.");

            var dtoEstado = ConversorEstado.ConverterParaDTO(estado);

            return dtoEstado;
        }

        public IList<DTOEstado> ObterTodosEstados()
        {
            var listaEstado = _repositorioEstado.ObterTodosEstados();
            var listaDTOEstado = new List<DTOEstado>();

            foreach (var estado in listaEstado)
            {
                var dtoEstado = ConversorEstado.ConverterParaDTO(estado);
                listaDTOEstado.Add(dtoEstado);
            }

            return listaDTOEstado;
        }
    }
}
