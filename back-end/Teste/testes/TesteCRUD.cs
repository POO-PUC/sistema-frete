using NUnit.Framework;
using Repositorio.Repositorio;
using System;
using Testes.FabricaGenerica;

namespace Testes
{
    [TestFixture]
    public class TesteCRUD
    {
        #region ATRIBUTOS PRIVADOS

        private FabricaDeObjetos _fabricaDeObjetos;

        private RepositorioCidade _repositorioCidade;
        private RepositorioCliente _repositorioCliente;
        private RepositorioEstado _repositorioEstado;
        private RepositorioFrete _repositorioFrete;
        private RepositorioFuncionario _repositorioFuncionario;
        private RepositorioPessoaFisica _repositorioPessoaFisica;
        private RepositorioPessoaJuridica _repositorioPessoaJuridica;

        #endregion

        [SetUp]
        public void SetUp()
        {
            _fabricaDeObjetos = new FabricaDeObjetos();

            _repositorioCidade = new RepositorioCidade();
            _repositorioCliente = new RepositorioCliente();
            _repositorioEstado = new RepositorioEstado();
            _repositorioFrete = new RepositorioFrete();
            _repositorioFuncionario = new RepositorioFuncionario();
            _repositorioPessoaFisica = new RepositorioPessoaFisica();
            _repositorioPessoaJuridica = new RepositorioPessoaJuridica();
        }

        #region CRUD ESTADO

        [Test]
        public void TesteAdicionarEstado()
        {
            var estado = _fabricaDeObjetos.FabricaEstado();

            _repositorioEstado.AdicionarEstado(estado);
        }

        [Test]
        public void TesteObterTodosOsEstados()
        {
            var listaDeEstados = _repositorioEstado.ObterTodosEstados();

            foreach (var estado in listaDeEstados)
            {
                Console.WriteLine($"Código: {estado.Codigo}, Nome: {estado.Nome}, UF: {estado.Uf}, ICMS Local: {estado.ICMSLocal}, ICMS Externo: {estado.ICMSExterno}");
            }
        }

        [Test]
        public void TesteAtualizaEstado()
        {
            var estado = _fabricaDeObjetos.FabricaEstado();

            estado.Nome = "UpdateTeste";

            _repositorioEstado.AtualizarEstado(estado);
        }

        [Test]
        public void TesteDeletarEstado()
        {
            int codigo = 1;

            _repositorioEstado.DeletarEstado(codigo);

            TesteObterTodosOsEstados();
        }

        #endregion

        #region CRUD CIDADE

        [Test]
        public void TesteAdionarCidade()
        {
            var estado = _fabricaDeObjetos.FabricaEstado();
            var cidade = _fabricaDeObjetos.FabricaCidade();

            _repositorioEstado.AdicionarEstado(estado);
            _repositorioCidade.AdicionarCidade(cidade);
        }

        [Test]
        public void TesteObterTodasAsCidade()
        {
            var listaCidade = _repositorioCidade.ObterTodasCidades();

            foreach (var cidade in listaCidade)
            {
                Console.WriteLine($"Código: {cidade.Codigo}, Nome: {cidade.Nome}, Código do Estado: {cidade.CodigoDoEstado}, Preço Padrão: {cidade.PrecoPadrao}");
            }
        }

        [Test]
        public void TesteAtualizarCidade()
        {
            var cidade = _fabricaDeObjetos.FabricaCidade();

            cidade.Nome = "UpdateTeste";

            _repositorioCidade.AtualizarCidade(cidade);
        }

        [Test]
        public void TesteDeletarCidade()
        {
            int codigo = 1; 

            var estado = _fabricaDeObjetos.FabricaEstado();

            _repositorioCidade.DeletarCidade(codigo);
            _repositorioEstado.DeletarEstado(estado.Codigo);

            TesteObterTodasAsCidade();
        }

        #endregion

        #region CRUD FUNCIONARIO

        [Test]
        public void TesteAdicionarFuncionario()
        {
            var funcionario = _fabricaDeObjetos.FabricaFuncionario();

            _repositorioFuncionario.AdicionarFuncionario(funcionario);
        }

        [Test]
        public void TesteObterTodosOsFuncionarios()
        {
            var listaFuncionarios = _repositorioFuncionario.ObterTodosFuncionarios();

            foreach (var funcionario in listaFuncionarios)
            {
                Console.WriteLine($"Código: {funcionario.Codigo}, Nome: {funcionario.Nome}, Número de Registro: {funcionario.NumeroDeRegistro}");
            }

        }

        [Test]
        public void TesteAtualizarFuncionario()
        {
            var funcionario = _fabricaDeObjetos.FabricaFuncionario();

            funcionario.Nome = "UpdateTeste";

            _repositorioFuncionario.AtualizarFuncionario(funcionario);
        }

        [Test]
        public void TesteDeletarFuncionario()
        {
            int codigo = 1;

            _repositorioFuncionario.DeletarFuncionario(codigo);

            TesteObterTodosOsFuncionarios();
        }

        #endregion

        #region CRUD CLIENTE

        [Test]
        public void TesteAdicionarCliente()
        {
            var cliente = _fabricaDeObjetos.FabricaCliente();

            _repositorioCliente.AdicionarCliente(cliente);
        }

        [Test]
        public void TesteObterTodosOsClientes()
        {
            var listaDeClientes = _repositorioCliente.ObterTodosClientes();

            foreach (var cliente in listaDeClientes)
            {
                Console.WriteLine($"Código: {cliente.Codigo}, Endereço: {cliente.Endereco}, Telefone: {cliente.Telefone}, Data de Inscrição: {cliente.DataDeInscricao:dd/MM/yyyy}");
            }
        }

        [Test]
        public void TesteAtualizaCliente()
        {
            var cliente = _fabricaDeObjetos.FabricaCliente();

            cliente.Telefone = "UpdateTeste";

            _repositorioCliente.AtualizarCliente(cliente);
        }

        [Test]
        public void TesteDeletarCliente()
        {
            int codigo = 1; 

            _repositorioCliente.DeletarCliente(codigo);

            TesteObterTodosOsClientes();
        }

        #endregion

        #region CRUD PESSOA FISICA

        [Test]
        public void TesteAdicionarPessoaFisica()
        {
            var cliente = _fabricaDeObjetos.FabricaCliente();
            var pessoaFisica = _fabricaDeObjetos.FabricaPessoaFisica();


            _repositorioCliente.AdicionarCliente(cliente);
            _repositorioPessoaFisica.AdicionarPessoaFisica(pessoaFisica);
        }

        [Test]
        public void TesteObterTodasAsPessoasFisicas()
        {
            var listaPessoasFisicas = _repositorioPessoaFisica.ObterTodasPessoasFisicas();

            foreach (var pessoa in listaPessoasFisicas)
            {
                Console.WriteLine($"Código: {pessoa.Codigo}, Nome: {pessoa.Nome}, CPF: {pessoa.CPF}, Código do Representante: {pessoa.CodigoDoRepresentante}, Endereço: {pessoa.Endereco}, Telefone: {pessoa.Telefone}, Data de Inscrição: {pessoa.DataDeInscricao:dd/MM/yyyy}");
            }
        }

        [Test]
        public void TesteAtualizarPessoaFisica()
        {
            var pessoaFisica = _fabricaDeObjetos.FabricaPessoaFisica();

            pessoaFisica.Nome = "Update Teste";

            _repositorioPessoaFisica.AtualizarPessoaFisica(pessoaFisica);
        }

        [Test]
        public void TesteDeletarPessoaFisica()
        {
            int codigo = 1;

            var cliente = _fabricaDeObjetos.FabricaCliente();

            _repositorioPessoaFisica.DeletarPessoaFisica(codigo);
            _repositorioCliente.DeletarCliente(cliente.Codigo);

            TesteObterTodosOsFuncionarios();
        }

        #endregion

        #region CRUD PESSOA JURIDICA

        [Test]
        public void TesteAdicionarPessoaJuridica()
        {
            var cliente = _fabricaDeObjetos.FabricaCliente();
            var pessoaJuridica = _fabricaDeObjetos.FabricaPessoaJuridica();

            _repositorioCliente.AdicionarCliente(cliente);
            _repositorioPessoaJuridica.AdicionarPessoaJuridica(pessoaJuridica);
        }

        [Test]
        public void TesteObterTodasAsPessoasJuridicas()
        {
            var listaPessoasJuridicas = _repositorioPessoaJuridica.ObterTodasPessoasJuridicas();

            foreach (var pessoaJuridica in listaPessoasJuridicas)
            {
                Console.WriteLine($"Código: {pessoaJuridica.Codigo}, Razão Social: {pessoaJuridica.RazaoSocial}, Inscrição Estadual: {pessoaJuridica.InscricaoEstadual}, CNPJ: {pessoaJuridica.CNPJ}, É Representante: {pessoaJuridica.EhRepresentante}, Endereço: {pessoaJuridica.Endereco}, Telefone: {pessoaJuridica.Telefone}, Data de Inscrição: {pessoaJuridica.DataDeInscricao:dd/MM/yyyy}");
            }
        }

        [Test]
        public void TesteAtualizarPessoaJuridica()
        {
            var pessoaJuridica = _fabricaDeObjetos.FabricaPessoaJuridica();

            pessoaJuridica.RazaoSocial = "UpdateTeste";

            _repositorioPessoaJuridica.AtualizarPessoaJuridica(pessoaJuridica);
        }

        [Test]
        public void TesteDeletarPessoaJuridica()
        {
            int codigo = 1;
            var cliente = _fabricaDeObjetos.FabricaCliente();

            _repositorioPessoaJuridica.DeletarPessoaJuridica(codigo);
            _repositorioCliente.DeletarCliente(cliente.Codigo);

            TesteObterTodosOsFuncionarios();
        }

        #endregion

        #region CRUD FRETE

        [Test]
        public void TesteAdicionarFrete()
        {
            var estado = _fabricaDeObjetos.FabricaEstado();
            var cidade1 = _fabricaDeObjetos.FabricaCidade();
            var cidade2 = _fabricaDeObjetos.FabricaCidade();cidade2.Codigo = 2;
            var cliente1 = _fabricaDeObjetos.FabricaCliente();
            var cliente2 = _fabricaDeObjetos.FabricaCliente(); cliente2.Codigo = 2;
            var funcionario = _fabricaDeObjetos.FabricaFuncionario();
            var frete = _fabricaDeObjetos.FabricaFrete();

            _repositorioEstado.AdicionarEstado(estado);
            _repositorioCidade.AdicionarCidade(cidade1);
            _repositorioCidade.AdicionarCidade(cidade2);
            _repositorioCliente.AdicionarCliente(cliente1);
            _repositorioCliente.AdicionarCliente(cliente2);
            _repositorioFuncionario.AdicionarFuncionario(funcionario);
            _repositorioFrete.AdicionarFrete(frete);
        }

        [Test]
        public void TesteObterTodasAsfretes()
        {
            var listaFretes = _repositorioFrete.ObterTodosFretes();

            foreach (var frete in listaFretes)
            {
                Console.WriteLine($"Código: {frete.Codigo}, Peso: {frete.Peso}, Valor: {frete.Valor}, ICMS: {frete.ICMS}, Pedágio: {frete.Pedagio}, Data Início: {frete.DataInicio:dd/MM/yyyy}, Cidade de Origem: {frete.CodigoDaCidadeDeOrigem}, Cidade de Destino: {frete.CodigoDaCidadeDeDestino}, Cliente: {frete.CodigoDoCliente}, Destinatário: {frete.CodigoDoDestinatario}, Funcionário: {frete.CodigoDoFuncionario}, Quem Paga: {frete.QuemPaga}, Número de Conhecimento: {frete.NumeroDeConhecimento}");
            }
        }

        [Test]
        public void TesteAtualizarFrete()
        {
            var frete = _fabricaDeObjetos.FabricaFrete();

            frete.Pedagio = 40.0F;

            _repositorioFrete.AtualizarFrete(frete);
        }

        [Test]     
        public void TesteDeletarFrete()
        {
            var estado = _fabricaDeObjetos.FabricaEstado();
            var cidade1 = _fabricaDeObjetos.FabricaCidade();
            var cidade2 = _fabricaDeObjetos.FabricaCidade(); cidade2.Codigo = 2;
            var cliente1 = _fabricaDeObjetos.FabricaCliente();
            var cliente2 = _fabricaDeObjetos.FabricaCliente(); cliente2.Codigo = 2;
            var funcionario = _fabricaDeObjetos.FabricaFuncionario();

            int codigo = 1;

            _repositorioFrete.DeletarFrete(codigo);
            _repositorioCidade.DeletarCidade(cidade1.Codigo);
            _repositorioCidade.DeletarCidade(cidade2.Codigo);
            _repositorioEstado.DeletarEstado(estado.Codigo);
            _repositorioCliente.DeletarCliente(cliente1.Codigo);
            _repositorioCliente.DeletarCliente(cliente2.Codigo);
            _repositorioFuncionario.DeletarFuncionario(funcionario.Codigo);

            TesteObterTodosOsFuncionarios();
        }

        #endregion
    }
}
