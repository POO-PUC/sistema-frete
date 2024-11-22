using Dominio.Objeto;
using DTO.DTOs;
using Repositorio.Conversor;
using Repositorio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Servico
{
    public class ServicoCidade
    {
        private readonly RepositorioCidade _repositorioCidade;

        public ServicoCidade()
        {
            _repositorioCidade = new RepositorioCidade();
        }

        public void AdicionarCidade(DTOCidade dtoCidade)
        {
            if (dtoCidade == null)
                throw new ArgumentNullException(nameof(dtoCidade), "A cidade não pode ser nula.");

            var cidade = ConversorCidade.ConverterParaDominio(dtoCidade);

            _repositorioCidade.AdicionarCidade(cidade);
        }

        public void AtualizarCidade(DTOCidade dtoCidade)
        {
            if (dtoCidade == null)
                throw new ArgumentNullException(nameof(dtoCidade), "A cidade não pode ser nula.");

            var cidade = ConversorCidade.ConverterParaDominio(dtoCidade);

            _repositorioCidade.AtualizarCidade(cidade);
        }

        public void DeletarCidade(int id)
        {
            if (id <= 0)
                throw new ArgumentException("O código da cidade deve ser válido.");

            var cidade = _repositorioCidade.ObterCidadePorId(id);

            if (cidade == null)
                throw new KeyNotFoundException("Cidade não encontrada.");

            _repositorioCidade.DeletarCidade(id);
        }

        public DTOCidade ObterCidadePorId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("O código da cidade deve ser válido.");

            var cidade = _repositorioCidade.ObterCidadePorId(id);

            if (cidade == null)
                throw new KeyNotFoundException("Cidade não encontrada.");

            var dtoCidade = ConversorCidade.ConverterParaDTO(cidade);

            return dtoCidade;
        }

        public IList<DTOCidade> ObterTodasCidades()
        {
            var listaCidade =  _repositorioCidade.ObterTodasCidades();

            var listaDTOCidade = listaCidade.Select(cidade => ConversorCidade.ConverterParaDTO(cidade)).ToList();

            return listaDTOCidade;
        }
    }
}
