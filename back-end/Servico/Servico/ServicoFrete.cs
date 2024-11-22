using Dominio.Objeto;
using DTO.DTOs;
using Repositorio.Conversor;
using Repositorio.Repositorio;
using System;
using System.Collections.Generic;

namespace Servico
{
    public class ServicoFrete
    {
        private readonly RepositorioFrete _repositorioFrete;

        public ServicoFrete()
        {
            _repositorioFrete = new RepositorioFrete();
        }

        public void AdicionarFrete(DTOFrete dtoFrete)
        {
            if (dtoFrete == null)
                throw new ArgumentNullException(nameof(dtoFrete), "O frete não pode ser nulo.");

            var frete = ConversorFrete.ConverterParaDominio(dtoFrete);

            _repositorioFrete.AdicionarFrete(frete);
        }

        public void AtualizarFrete(DTOFrete dtoFrete)
        {
            if (dtoFrete == null)
                throw new ArgumentNullException(nameof(dtoFrete), "O frete não pode ser nulo.");

            var frete = ConversorFrete.ConverterParaDominio(dtoFrete);

            if (frete.Codigo <= 0)
                throw new ArgumentException("O código do frete deve ser válido.");


            _repositorioFrete.AtualizarFrete(frete);
        }

        public void DeletarFrete(int id)
        {
            if (id <= 0)
                throw new ArgumentException("O código do frete deve ser válido.");

            var frete = _repositorioFrete.ObterFretePorId(id);

            if (frete == null)
                throw new KeyNotFoundException("Frete não encontrado.");

            _repositorioFrete.DeletarFrete(id);
        }

        public DTOFrete ObterFretePorId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("O código do frete deve ser válido.");

            var frete = _repositorioFrete.ObterFretePorId(id);

            if (frete == null)
                throw new KeyNotFoundException("Frete não encontrado.");

            var dtoFrete = ConversorFrete.ConverterParaDTO(frete);

            return dtoFrete;
        }

        public IList<DTOFrete> ObterTodosFretes()
        {
            var listaFrete = _repositorioFrete.ObterTodosFretes();
            var listaDTOFrete = new List<DTOFrete>();

            foreach (var frete in listaFrete)
            {
                var dtoFrete = ConversorFrete.ConverterParaDTO(frete);
                listaDTOFrete.Add(dtoFrete);
            }

            return listaDTOFrete;
        }
    }
}
