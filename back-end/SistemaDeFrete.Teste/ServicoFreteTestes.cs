using Dominio.Objeto;
using DTO.DTOs;
using Moq;
using Repositorio.Repositorio.Interfaces;
using Servico;

namespace SistemaDeFrete.Teste
{
    public class ServicoFreteTestes
    {
        private readonly Mock<IRepositorioFrete> _mockRepositorioFrete;
        private readonly ServicoFrete _servicoFrete;
        public ServicoFreteTestes()
        {
            _mockRepositorioFrete = new Mock<IRepositorioFrete>();
            _servicoFrete = new ServicoFrete(_mockRepositorioFrete.Object);
        }

        [Fact(DisplayName = "Teste se DTOFrete é nulo")]
        public void AdicionarFrete_QuandoDtoFreteForNulo_DeveLancarArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _servicoFrete.AdicionarFrete(null));
        }

        [Fact(DisplayName = "Teste de adicionar Frete aconteceu")]
        public void AdicionarFrete_DeveChamar_AdicionarFreteNoRepositorio()
        {
            //arrange
            var dtoFreteMock = new DTOFrete { Codigo = 50, CodigoDaCidadeDeDestino = 1, CodigoDaCidadeDeOrigem = 2 };
            var listaDeFretes = new List<Frete>();
            var resultadoEsperado = 50;

            //act
            _mockRepositorioFrete.Setup(r => r.AdicionarFrete(It.IsAny<Frete>()))
                                        .Callback<Frete>(frete => listaDeFretes.Add(frete));
            _servicoFrete.AdicionarFrete(dtoFreteMock);

            //assert
            _mockRepositorioFrete.Verify(r => r.AdicionarFrete(It.IsAny<Frete>()), Times.Once);
            Assert.Single(listaDeFretes);
            Assert.Equal(resultadoEsperado, listaDeFretes[0].Codigo);
        }

        [Fact(DisplayName = "Testa se ID invalido para deletar")]
        public void DeletarFrete_QuandoIdForInvalido_DeveLancarArgumentException()
        {
            //assert
            Assert.Throws<ArgumentException>(() => _servicoFrete.DeletarFrete(0));
        }

        [Fact(DisplayName = "Testa se frete não encontrado para deletar")]
        public void DeletarFrete_QuandoFreteNaoForEncontrado_DeveLancarKeyNotFoundException()
        {
            //arrange
            var idFreteParaDeletar = 1;

            //action
            _mockRepositorioFrete.Setup(r => r.ObterFretePorId(idFreteParaDeletar)).Returns((Frete)null);

            //assert
            Assert.Throws<KeyNotFoundException>(() => _servicoFrete.DeletarFrete(idFreteParaDeletar));
        }

        [Fact(DisplayName = "Teste deve retornar frete pelo ID")]
        public void ObterFretePorId_DeveRetornarDtoFreteCorreto()
        {
            var frete = new Frete { Codigo = 20 };
            _mockRepositorioFrete.Setup(r => r.ObterFretePorId(20)).Returns(frete);

            var resultadoEsperado = 20;
            var resultado = _servicoFrete.ObterFretePorId(20);

            Assert.NotNull(resultado);
            Assert.Equal(resultadoEsperado, resultado.Codigo);
        }
    }
}
