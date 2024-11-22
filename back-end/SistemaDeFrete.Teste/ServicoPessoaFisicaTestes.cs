using Dominio.Objeto;
using DTO.DTOs;
using Moq;
using Repositorio.Repositorio.Interfaces;
using Servico;

namespace SistemaDeFrete.Teste
{
    public class ServicoPessoaFisicaTestes
    {
        private readonly Mock<IRepositorioPessoaFisica> _mockRepositorioPessoaFisica;
        private readonly ServicoPessoaFisica _servicoPessoaFisica;
        public ServicoPessoaFisicaTestes()
        {
            _mockRepositorioPessoaFisica = new Mock<IRepositorioPessoaFisica>();
            _servicoPessoaFisica = new ServicoPessoaFisica(_mockRepositorioPessoaFisica.Object);
        }

        [Fact(DisplayName = "Teste se DTOPessoaFisica é nulo")]
        public void AdicionarPessoaFisica_QuandoDtoPessoaFisicaForNulo_DeveLancarArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _servicoPessoaFisica.AdicionarPessoaFisica(null));
        }

        [Fact(DisplayName = "Teste de adicionar Pessoa Fisica aconteceu")]
        public void AdicionarPessoaFisica_DeveChamar_AdicionarPessoaFisicaoRepositorio()
        {
            //arrange
            var dtoPessoaFisicaMock = new DTOPessoaFisica { Codigo = 2, Nome = "José", CPF = "00000000000" };
            var listaDePessoaFisica = new List<PessoaFisica>();
            var resultadoEsperado = "00000000000";

            //act
            _mockRepositorioPessoaFisica.Setup(r => r.AdicionarPessoaFisica(It.IsAny<PessoaFisica>()))
                                        .Callback<PessoaFisica>(pessoaFisica => listaDePessoaFisica.Add(pessoaFisica));
            _servicoPessoaFisica.AdicionarPessoaFisica(dtoPessoaFisicaMock);

            //assert
            _mockRepositorioPessoaFisica.Verify(r => r.AdicionarPessoaFisica(It.IsAny<PessoaFisica>()), Times.Once);
            Assert.Single(listaDePessoaFisica);
            Assert.Equal(resultadoEsperado, listaDePessoaFisica[0].CPF);
        }

        [Fact(DisplayName = "Testa se ID invalido para deletar")]
        public void DeletarPessoaFisica_QuandoIdForInvalido_DeveLancarArgumentException()
        {
            //assert
            Assert.Throws<ArgumentException>(() => _servicoPessoaFisica.DeletarPessoaFisica(0));
        }

        [Fact(DisplayName = "Testa se Pessoa Fisica não encontrado para deletar")]
        public void DeletarPessoaFisica_QuandoPessoaFisicaNaoForEncontrado_DeveLancarKeyNotFoundException()
        {
            //arrange
            var idPessoaFisicaParaDeletar = 1;

            //action
            _mockRepositorioPessoaFisica.Setup(r => r.ObterPessoaFisicaPorId(idPessoaFisicaParaDeletar)).Returns((PessoaFisica)null);

            //assert
            Assert.Throws<KeyNotFoundException>(() => _servicoPessoaFisica.DeletarPessoaFisica(idPessoaFisicaParaDeletar));
        }

        [Fact(DisplayName = "Teste deve retornar Pessoa Fisica pelo ID")]
        public void ObterPessoaFisicaPorId_DeveRetornarDtoPessoaFisicaCorreto()
        {
            var pessoaFisica = new PessoaFisica { Codigo = 2, Nome = "José", CPF = "00000000000" };
            _mockRepositorioPessoaFisica.Setup(r => r.ObterPessoaFisicaPorId(2)).Returns(pessoaFisica);

            var resultadoEsperado = "00000000000";
            var resultado = _servicoPessoaFisica.ObterPessoaFisicaPorId(2);

            Assert.NotNull(resultado);
            Assert.Equal(resultadoEsperado, resultado.CPF);
        }
    }
}
