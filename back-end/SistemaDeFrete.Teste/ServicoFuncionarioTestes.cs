using Dominio.Objeto;
using DTO.DTOs;
using Moq;
using Repositorio.Repositorio.Interfaces;
using Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeFrete.Teste
{
    public class ServicoFuncionarioTestes
    {
        private readonly Mock<IRepositorioFuncionario> _mockRepositorioFuncionario;
        private readonly ServicoFuncionario _servicoFuncionario;
        public ServicoFuncionarioTestes()
        {
            _mockRepositorioFuncionario = new Mock<IRepositorioFuncionario>();
            _servicoFuncionario = new ServicoFuncionario(_mockRepositorioFuncionario.Object);
        }

        [Fact(DisplayName = "Teste se DTOFuncionario é nulo")]
        public void AdicionarFuncionario_QuandoDtoFuncionarioForNulo_DeveLancarArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _servicoFuncionario.AdicionarFuncionario(null));
        }

        [Fact(DisplayName = "Teste de adicionar funcionario aconteceu")]
        public void AdicionarFuncionario_DeveChamar_AdicionarFuncionarioNoRepositorio()
        {
            //arrange
            var dtoFuncionarioMock = new DTOFuncionario { Codigo = 2, Nome = "João", NumeroDeRegistro = 11 };
            var listaDeFuncionarios = new List<Funcionario>();
            var resultadoEsperado = 2;

            //act
            _mockRepositorioFuncionario.Setup(r => r.AdicionarFuncionario(It.IsAny<Funcionario>()))
                                        .Callback<Funcionario>(funcionario => listaDeFuncionarios.Add(funcionario));
            _servicoFuncionario.AdicionarFuncionario(dtoFuncionarioMock);

            //assert
            _mockRepositorioFuncionario.Verify(r => r.AdicionarFuncionario(It.IsAny<Funcionario>()), Times.Once);
            Assert.Single(listaDeFuncionarios);
            Assert.Equal(resultadoEsperado, listaDeFuncionarios[0].Codigo);
        }

        [Fact(DisplayName = "Testa se ID invalido para deletar")]
        public void DeletarFuncionario_QuandoIdForInvalido_DeveLancarArgumentException()
        {
            //assert
            Assert.Throws<ArgumentException>(() => _servicoFuncionario.DeletarFuncionario(0));
        }

        [Fact(DisplayName = "Testa se funcionario não encontrado para deletar")]
        public void DeletarFuncionario_QuandoFuncionarioNaoForEncontrado_DeveLancarKeyNotFoundException()
        {
            //arrange
            var idFuncionarioParaDeletar = 1;

            //action
            _mockRepositorioFuncionario.Setup(r => r.ObterFuncionarioPorId(idFuncionarioParaDeletar)).Returns((Funcionario)null);

            //assert
            Assert.Throws<KeyNotFoundException>(() => _servicoFuncionario.DeletarFuncionario(idFuncionarioParaDeletar));
        }

        [Fact(DisplayName = "Teste deve retornar funcionario pelo ID")]
        public void ObterFuncionarioPorId_DeveRetornarDtoFuncionarioCorreto()
        {
            var funcionario = new Funcionario { Codigo = 2, Nome = "João", NumeroDeRegistro = 11 };
            _mockRepositorioFuncionario.Setup(r => r.ObterFuncionarioPorId(2)).Returns(funcionario);

            var resultadoEsperado = 2;
            var resultado = _servicoFuncionario.ObterFuncionarioPorId(2);

            Assert.NotNull(resultado);
            Assert.Equal(resultadoEsperado, resultado.Codigo);
        }
    }
}
