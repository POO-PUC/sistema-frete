using Dominio.Objeto;
using DTO.DTOs;
using Moq;
using Repositorio.Repositorio.Interfaces;
using Servico;

namespace SistemaDeFrete.Teste
{
    public class ServicoClienteTestes
    {
        private readonly Mock<IRepositorioCliente> _mockRepositorioCliente;
        private readonly ServicoCliente _servicoCliente;
        public ServicoClienteTestes()
        {
            _mockRepositorioCliente = new Mock<IRepositorioCliente>();
            _servicoCliente = new ServicoCliente(_mockRepositorioCliente.Object);
        }

        [Fact(DisplayName ="Teste se DTOCliente é nulo")]
        public void AdicionarCliente_QuandoDtoClienteForNulo_DeveLancarArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _servicoCliente.AdicionarCliente(null));
        }

        [Fact (DisplayName= "Teste de adicionar cliente aconteceu")]
        public void AdicionarCliente_DeveChamar_AdicionarClienteNoRepositorio()
        {
            //arrange
            var dtoClienteMock = new DTOCliente { Codigo = 2, Endereco = "Rua A QD 1 LT 2 Bairro C", Telefone = "64999999999", DataDeInscricao = DateTime.Now };
            var listaDeCidades = new List<Cliente>();
            var resultadoEsperado = 2;

            //act
            _mockRepositorioCliente.Setup(r => r.AdicionarCliente(It.IsAny<Cliente>()))
                                        .Callback<Cliente>(cliente => listaDeCidades.Add(cliente));
            _servicoCliente.AdicionarCliente(dtoClienteMock);

            //assert
            _mockRepositorioCliente.Verify(r => r.AdicionarCliente(It.IsAny<Cliente>()), Times.Once);
            Assert.Single(listaDeCidades);
            Assert.Equal(resultadoEsperado, listaDeCidades[0].Codigo);
        }

        [Fact(DisplayName ="Testa se ID invalido para deletar")]
        public void DeletarCliente_QuandoIdForInvalido_DeveLancarArgumentException()
        {
            //assert
            Assert.Throws<ArgumentException>(() => _servicoCliente.DeletarCliente(0));
        }

        [Fact(DisplayName ="Testa se cliente não encontrado para deletar")]
        public void DeletarCliente_QuandoClienteNaoForEncontrada_DeveLancarKeyNotFoundException()
        {
            //arrange
            var idClienteParaDeletar = 1;

            //action
            _mockRepositorioCliente.Setup(r => r.ObterClientePorId(idClienteParaDeletar)).Returns((Cliente)null);

            //assert
            Assert.Throws<KeyNotFoundException>(() => _servicoCliente.DeletarCliente(idClienteParaDeletar));
        }

        [Fact(DisplayName ="Teste deve retornar cliente pelo ID")]
        public void ObterClientePorId_DeveRetornarDtoClienteCorreto()
        {
            var cliente = new Cliente { Codigo = 1 };
            _mockRepositorioCliente.Setup(r => r.ObterClientePorId(1)).Returns(cliente);

            var resultadoEsperado = 1;
            var resultado = _servicoCliente.ObterClientePorId(1);

            Assert.NotNull(resultado);
            Assert.Equal(resultadoEsperado, resultado.Codigo);
        }
    }
}
