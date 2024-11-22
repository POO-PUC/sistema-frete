using Dominio.Objeto;
using DTO.DTOs;
using Repositorio.Conversor;
using Repositorio.Repositorio;
using System;
using System.Collections.Generic;

namespace Servico
{
    public class ServicoPessoaJuridica
    {
        private readonly RepositorioPessoaJuridica _repositorioPessoaJuridica;

        public ServicoPessoaJuridica()
        {
            _repositorioPessoaJuridica = new RepositorioPessoaJuridica();
        }

        public void AdicionarPessoaJuridica(DTOPessoaJuridica dtoPessoaJuridica)
        {
            if (dtoPessoaJuridica == null)
                throw new ArgumentNullException(nameof(dtoPessoaJuridica), "Os dados da pessoa jurídica não podem ser nulos.");

            var pessoaJuridica = ConversorPessoaJuridica.ConverterParaDominio(dtoPessoaJuridica);

            _repositorioPessoaJuridica.AdicionarPessoaJuridica(pessoaJuridica);
        }

        public void AtualizarPessoaJuridica(DTOPessoaJuridica dtoPessoaJuridica)
        {
            if (dtoPessoaJuridica == null)
                throw new ArgumentNullException(nameof(dtoPessoaJuridica), "Os dados da pessoa jurídica não podem ser nulos.");

            var pessoaJuridica = ConversorPessoaJuridica.ConverterParaDominio(dtoPessoaJuridica);

            _repositorioPessoaJuridica.AtualizarPessoaJuridica(pessoaJuridica);
        }

        public void DeletarPessoaJuridica(int id)
        {
            if (id <= 0)
                throw new ArgumentException("O código da pessoa jurídica deve ser válido.");

            var pessoaJuridica = _repositorioPessoaJuridica.ObterPessoaJuridicaPorId(id);

            if (pessoaJuridica == null)
                throw new KeyNotFoundException("Pessoa jurídica não encontrada.");

            _repositorioPessoaJuridica.DeletarPessoaJuridica(id);
        }

        public DTOPessoaJuridica ObterPessoaJuridicaPorId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("O código da pessoa jurídica deve ser válido.");

            var pessoaJuridica = _repositorioPessoaJuridica.ObterPessoaJuridicaPorId(id);

            if (pessoaJuridica == null)
                throw new KeyNotFoundException("Pessoa jurídica não encontrada.");

            return ConversorPessoaJuridica.ConverterParaDTO(pessoaJuridica);
        }

        public IList<DTOPessoaJuridica> ObterTodasPessoasJuridicas()
        {
            var listaPessoasJuridicas = _repositorioPessoaJuridica.ObterTodasPessoasJuridicas();
            var listaDTOPessoasJuridicas = new List<DTOPessoaJuridica>();

            foreach (var pessoaJuridica in listaPessoasJuridicas)
            {
                listaDTOPessoasJuridicas.Add(ConversorPessoaJuridica.ConverterParaDTO(pessoaJuridica));
            }

            return listaDTOPessoasJuridicas;
        }
    }
}
