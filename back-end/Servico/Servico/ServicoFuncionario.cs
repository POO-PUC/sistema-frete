using Dominio.Objeto;
using DTO.DTOs;
using Repositorio.Conversor;
using Repositorio.Repositorio;
using System;
using System.Collections.Generic;

namespace Servico
{
    public class ServicoFuncionario
    {
        private readonly RepositorioFuncionario _repositorioFuncionario;

        public ServicoFuncionario()
        {
            _repositorioFuncionario = new RepositorioFuncionario();
        }

        public void AdicionarFuncionario(DTOFuncionario dtoFuncionario)
        {
            if (dtoFuncionario == null)
                throw new ArgumentNullException(nameof(dtoFuncionario), "O funcionário não pode ser nulo.");

            var funcionario = ConversorFuncionario.ConverterParaDominio(dtoFuncionario);

            _repositorioFuncionario.AdicionarFuncionario(funcionario);
        }

        public void AtualizarFuncionario(DTOFuncionario dtoFuncionario)
        {
            if (dtoFuncionario == null)
                throw new ArgumentNullException(nameof(dtoFuncionario), "O funcionário não pode ser nulo.");

            var funcionario = ConversorFuncionario.ConverterParaDominio(dtoFuncionario);

            _repositorioFuncionario.AtualizarFuncionario(funcionario);
        }

        public void DeletarFuncionario(int id)
        {
            if (id <= 0)
                throw new ArgumentException("O código do funcionário deve ser válido.");

            var funcionario = _repositorioFuncionario.ObterFuncionarioPorId(id);

            if (funcionario == null)
                throw new KeyNotFoundException("Funcionário não encontrado.");

            _repositorioFuncionario.DeletarFuncionario(id);
        }

        public DTOFuncionario ObterFuncionarioPorId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("O código do funcionário deve ser válido.");

            var funcionario = _repositorioFuncionario.ObterFuncionarioPorId(id);

            if (funcionario == null)
                throw new KeyNotFoundException("Funcionário não encontrado.");

            return ConversorFuncionario.ConverterParaDTO(funcionario);
        }

        public IList<DTOFuncionario> ObterTodosFuncionarios()
        {
            var listaFuncionarios = _repositorioFuncionario.ObterTodosFuncionarios();
            var listaDTOFuncionarios = new List<DTOFuncionario>();

            foreach (var funcionario in listaFuncionarios)
            {
                listaDTOFuncionarios.Add(ConversorFuncionario.ConverterParaDTO(funcionario));
            }

            return listaDTOFuncionarios;
        }
    }
}
