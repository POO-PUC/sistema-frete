using Dominio.Objeto;
using DTO.DTOs;
using Moq;
using Repositorio.Repositorio.Interfaces;
using Servico;

namespace SistemaDeFrete.Teste
{
    public class ServicoCidadeTestes
    {
        private readonly Mock<IRepositorioCidade> _mockRepositorioCidade;
        private readonly ServicoCidade _servicoCidade;
        public ServicoCidadeTestes()
        {
            _mockRepositorioCidade = new Mock<IRepositorioCidade>();
            _servicoCidade = new ServicoCidade(_mockRepositorioCidade.Object);
        }

        [Fact(DisplayName ="Teste se DTOCidade é nulo")]
        public void AdicionarCidade_QuandoDtoCidadeForNulo_DeveLancarArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _servicoCidade.AdicionarCidade(null));
        }

        [Fact (DisplayName= "Teste de adicionar cidade aconteceu")]
        public void AdicionarCidade_DeveChamar_AdicionarCidadeNoRepositorio()
        {
            //arrange
            var dtoCidadeMock = new DTOCidade { Codigo = 2, Nome = "Goiânia", CodigoDoEstado = 2, PrecoPadrao = 2.45f };
            var listaDeCidades = new List<Cidade>();
            var resultadoEsperado = "Goiânia";

            //act
            _mockRepositorioCidade.Setup(r => r.AdicionarCidade(It.IsAny<Cidade>()))
                                        .Callback<Cidade>(cidade => listaDeCidades.Add(cidade));
            _servicoCidade.AdicionarCidade(dtoCidadeMock);

            //assert
            _mockRepositorioCidade.Verify(r => r.AdicionarCidade(It.IsAny<Cidade>()), Times.Once);
            Assert.Single(listaDeCidades);
            Assert.Equal(resultadoEsperado, listaDeCidades[0].Nome);
        }

        [Fact(DisplayName ="Testa se ID invalido para deletar")]
        public void DeletarCidade_QuandoIdForInvalido_DeveLancarArgumentException()
        {
            //assert
            Assert.Throws<ArgumentException>(() => _servicoCidade.DeletarCidade(0));
        }

        [Fact(DisplayName ="Testa se cidade não encontrada para deletar")]
        public void DeletarCidade_QuandoCidadeNaoForEncontrada_DeveLancarKeyNotFoundException()
        {
            //action
            _mockRepositorioCidade.Setup(r => r.ObterCidadePorId(1)).Returns((Cidade)null);

            //assert
            Assert.Throws<KeyNotFoundException>(() => _servicoCidade.DeletarCidade(1));
        }

        [Fact(DisplayName ="Teste deve retornar cidade pelo ID")]
        public void ObterCidadePorId_DeveRetornarDtoCidadeCorreto()
        {
            var cidade = new Cidade { Codigo = 1, Nome = "São Paulo" };
            _mockRepositorioCidade.Setup(r => r.ObterCidadePorId(1)).Returns(cidade);

            var resultadoEsperado = "São Paulo";
            var resultado = _servicoCidade.ObterCidadePorId(1);

            Assert.NotNull(resultado);
            Assert.Equal(resultadoEsperado, resultado.Nome);
        }
    }
}