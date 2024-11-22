using Dominio.Objeto;
using DTO.DTOs;
using Moq;
using Repositorio.Repositorio.Interfaces;
using Servico;

namespace SistemaDeFrete.Teste
{
    public class ServicoEstadoTestes
    {
        private readonly Mock<IRepositorioEstado> _mockRepositorioEstado;
        private readonly ServicoEstado _servicoEstado;
        public ServicoEstadoTestes()
        {
            _mockRepositorioEstado = new Mock<IRepositorioEstado>();
            _servicoEstado = new ServicoEstado(_mockRepositorioEstado.Object);
        }

        [Fact(DisplayName = "Teste se DTOEstado é nulo")]
        public void AdicionarEstado_QuandoDtoEstadoForNulo_DeveLancarArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _servicoEstado.AdicionarEstado(null));
        }

        [Fact(DisplayName = "Teste de adicionar estado aconteceu")]
        public void AdicionarEstado_DeveChamar_AdicionarEstadoNoRepositorio()
        {
            //arrange
            var dtoEstadoMock = new DTOEstado { Codigo = 2, Nome = "Goiás", Uf = "GO"};
            var listaDeEstados = new List<Estado>();
            var resultadoEsperado = 2;

            //act
            _mockRepositorioEstado.Setup(r => r.AdicionarEstado(It.IsAny<Estado>()))
                                        .Callback<Estado>(estado => listaDeEstados.Add(estado));
            _servicoEstado.AdicionarEstado(dtoEstadoMock);

            //assert
            _mockRepositorioEstado.Verify(r => r.AdicionarEstado(It.IsAny<Estado>()), Times.Once);
            Assert.Single(listaDeEstados);
            Assert.Equal(resultadoEsperado, listaDeEstados[0].Codigo);
        }

        [Fact(DisplayName = "Testa se ID invalido para deletar")]
        public void DeletarEstado_QuandoIdForInvalido_DeveLancarArgumentException()
        {
            //assert
            Assert.Throws<ArgumentException>(() => _servicoEstado.DeletarEstado(0));
        }

        [Fact(DisplayName = "Testa se cliente não encontrado para deletar")]
        public void DeletarEstado_QuandoEstadoNaoForEncontrado_DeveLancarKeyNotFoundException()
        {
            //arrange
            var idEstadoParaDeletar = 1;

            //action
            _mockRepositorioEstado.Setup(r => r.ObterEstadoPorId(idEstadoParaDeletar)).Returns((Estado)null);

            //assert
            Assert.Throws<KeyNotFoundException>(() => _servicoEstado.DeletarEstado(idEstadoParaDeletar));
        }

        [Fact(DisplayName = "Teste deve retornar estado pelo ID")]
        public void ObterEstadoPorId_DeveRetornarDtoEstadoCorreto()
        {
            var estado = new Estado { Codigo = 2, Nome = "Goiás", Uf = "GO" };
            _mockRepositorioEstado.Setup(r => r.ObterEstadoPorId(2)).Returns(estado);

            var resultadoEsperado = 2;
            var resultado = _servicoEstado.ObterEstadoPorId(2);

            Assert.NotNull(resultado);
            Assert.Equal(resultadoEsperado, resultado.Codigo);
        }
    }
}
