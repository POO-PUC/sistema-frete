using Dominio.Objeto;
using DTO.DTOs;
using Repositorio.Conversor;
using Repositorio.Repositorio;
using System;
using System.Collections.Generic;

namespace Servico
{
    public class ServicoPessoaFisica
    {
        private readonly RepositorioPessoaFisica _repositorioPessoaFisica;

        public ServicoPessoaFisica()
        {
            _repositorioPessoaFisica = new RepositorioPessoaFisica();
        }

        public void AdicionarPessoaFisica(DTOPessoaFisica dtoPessoaFisica)
        {
            if (dtoPessoaFisica == null)
                throw new ArgumentNullException(nameof(dtoPessoaFisica), "Os dados da pessoa física não podem ser nulos.");

            var pessoaFisica = ConversorPessoaFisica.ConverterParaDominio(dtoPessoaFisica);

            _repositorioPessoaFisica.AdicionarPessoaFisica(pessoaFisica);
        }

        public void AtualizarPessoaFisica(DTOPessoaFisica dtoPessoaFisica)
        {
            if (dtoPessoaFisica == null)
                throw new ArgumentNullException(nameof(dtoPessoaFisica), "Os dados da pessoa física não podem ser nulos.");

            var pessoaFisica = ConversorPessoaFisica.ConverterParaDominio(dtoPessoaFisica);

            _repositorioPessoaFisica.AtualizarPessoaFisica(pessoaFisica);
        }

        public void DeletarPessoaFisica(int id)
        {
            if (id <= 0)
                throw new ArgumentException("O código da pessoa física deve ser válido.");

            var pessoaFisica = _repositorioPessoaFisica.ObterPessoaFisicaPorId(id);
            if (pessoaFisica == null)
                throw new KeyNotFoundException("Pessoa física não encontrada.");

            _repositorioPessoaFisica.DeletarPessoaFisica(id);
        }

        public DTOPessoaFisica ObterPessoaFisicaPorId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("O código da pessoa física deve ser válido.");

            var pessoaFisica = _repositorioPessoaFisica.ObterPessoaFisicaPorId(id);
            
            if (pessoaFisica == null)
                throw new KeyNotFoundException("Pessoa física não encontrada.");

            return ConversorPessoaFisica.ConverterParaDTO(pessoaFisica);
        }

        public IList<DTOPessoaFisica> ObterTodasPessoasFisicas()
        {
            var listaPessoasFisicas = _repositorioPessoaFisica.ObterTodasPessoasFisicas();
            var listaDTOPessoasFisicas = new List<DTOPessoaFisica>();

            foreach (var pessoaFisica in listaPessoasFisicas)
            {
                listaDTOPessoasFisicas.Add(ConversorPessoaFisica.ConverterParaDTO(pessoaFisica));
            }

            return listaDTOPessoasFisicas;
        }
    }
}
