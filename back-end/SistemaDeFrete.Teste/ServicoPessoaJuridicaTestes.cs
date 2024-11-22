using Dominio.Objeto;
using DTO.DTOs;
using Moq;
using Repositorio.Repositorio.Interfaces;
using Servico;

namespace SistemaDeFrete.Teste
{
    public class ServicoPessoaJuridicaTestes
    {
        private readonly Mock<IRepositorioPessoaJuridica> _mockRepositorioPessoaJuridica;
        private readonly ServicoPessoaJuridica _servicoPessoaJuridica;
        public ServicoPessoaJuridicaTestes()
        {
            _mockRepositorioPessoaJuridica = new Mock<IRepositorioPessoaJuridica>();
            _servicoPessoaJuridica = new ServicoPessoaJuridica(_mockRepositorioPessoaJuridica.Object);
        }

        [Fact(DisplayName = "Teste se DTOPessoaJuridica é nulo")]
        public void AdicionarPessoaJuridica_QuandoDtoPessoaJuridicaForNulo_DeveLancarArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _servicoPessoaJuridica.AdicionarPessoaJuridica(null));
        }

        [Fact(DisplayName = "Teste de adicionar Pessoa Juridica aconteceu")]
        public void AdicionarPessoaJuridica_DeveChamar_AdicionarPessoaJuridicaoRepositorio()
        {
            //arrange
            var dtoPessoaJuridicaMock = new DTOPessoaJuridica { Codigo = 2, RazaoSocial = "Empresa Teste", CNPJ = "00000000000000" };
            var listaDePessoaJuridica = new List<PessoaJuridica>();
            var resultadoEsperado = "00000000000000";

            //act
            _mockRepositorioPessoaJuridica.Setup(r => r.AdicionarPessoaJuridica(It.IsAny<PessoaJuridica>()))
                                        .Callback<PessoaJuridica>(pessoaJuridica => listaDePessoaJuridica.Add(pessoaJuridica));
            _servicoPessoaJuridica.AdicionarPessoaJuridica(dtoPessoaJuridicaMock);

            //assert
            _mockRepositorioPessoaJuridica.Verify(r => r.AdicionarPessoaJuridica(It.IsAny<PessoaJuridica>()), Times.Once);
            Assert.Single(listaDePessoaJuridica);
            Assert.Equal(resultadoEsperado, listaDePessoaJuridica[0].CNPJ);
        }

        [Fact(DisplayName = "Testa se ID invalido para deletar")]
        public void DeletarPessoaJuridica_QuandoIdForInvalido_DeveLancarArgumentException()
        {
            //assert
            Assert.Throws<ArgumentException>(() => _servicoPessoaJuridica.DeletarPessoaJuridica(0));
        }

        [Fact(DisplayName = "Testa se Pessoa Juridica não encontrado para deletar")]
        public void DeletarPessoaJuridica_QuandoPessoaJuridicaNaoForEncontrado_DeveLancarKeyNotFoundException()
        {
            //arrange
            var idPessoaJuridicaParaDeletar = 1;

            //action
            _mockRepositorioPessoaJuridica.Setup(r => r.ObterPessoaJuridicaPorId(idPessoaJuridicaParaDeletar)).Returns((PessoaJuridica)null);

            //assert
            Assert.Throws<KeyNotFoundException>(() => _servicoPessoaJuridica.DeletarPessoaJuridica(idPessoaJuridicaParaDeletar));
        }

        [Fact(DisplayName = "Teste deve retornar Pessoa Juridica pelo ID")]
        public void ObterPessoaJuridicaPorId_DeveRetornarDtoPessoaJuridicaCorreto()
        {
            var pessoaJuridica = new PessoaJuridica { Codigo = 2, RazaoSocial = "Empresa Teste", CNPJ = "00000000000000" };
            _mockRepositorioPessoaJuridica.Setup(r => r.ObterPessoaJuridicaPorId(2)).Returns(pessoaJuridica);

            var resultadoEsperado = "00000000000000";
            var resultado = _servicoPessoaJuridica.ObterPessoaJuridicaPorId(2);

            Assert.NotNull(resultado);
            Assert.Equal(resultadoEsperado, resultado.CNPJ);
        }
    }
}
