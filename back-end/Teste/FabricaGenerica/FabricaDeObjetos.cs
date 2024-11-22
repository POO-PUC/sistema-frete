using Dominio.Objeto;
using System;

namespace Testes.FabricaGenerica
{
    public class FabricaDeObjetos
    {
        #region OBJETOS COM DADOS CORRETOS

        public Cidade FabricaCidade()
        {
            var cidade = new Cidade
            {
                Codigo = 1,
                Nome = "Goiânia",
                CodigoDoEstado = 1,
                PrecoPadrao = 500.00f
            };

            return cidade;
        }

        public Cliente FabricaCliente()
        {
            var cliente = new Cliente
            {
                Codigo = 1,
                Endereco = "Rua A, 123",
                Telefone = "(62) 1234-5678",
                DataDeInscricao = DateTime.Today
            };

            return cliente;
        }

        public Estado FabricaEstado()
        {
            var estado = new Estado
            {
                Codigo = 1,
                Nome = "Goiás",
                Uf = "GO",
                ICMSLocal = 17.00f,
                ICMSExterno = 12.00f
            };

            return estado;
        }

        public Frete FabricaFrete()
        {
            var frete = new Frete
            {
                Codigo = 1,
                Peso = 1500.00f,
                Valor = 3000.00f,
                ICMS = 5.00f,
                Pedagio = 30.00f,
                DataInicio = DateTime.Today,
                CodigoDaCidadeDeOrigem = 1,
                CodigoDaCidadeDeDestino = 2,
                CodigoDoCliente = 1,
                CodigoDoDestinatario = 2,
                CodigoDoFuncionario = 1,
                QuemPaga = "Remetente",
                NumeroDeConhecimento = "123456789"
            };

            return frete;
        }

        public Funcionario FabricaFuncionario()
        {
            var funcionario = new Funcionario
            {
                Codigo = 1,
                Nome = "João da Silva",
                NumeroDeRegistro = 12345
            };

            return funcionario;
        }

        public PessoaFisica FabricaPessoaFisica()
        {
            var pessoaFisica = new PessoaFisica
            {
                Codigo = 1,
                Nome = "Maria Santos",
                CPF = "123.456.789-00",
                CodigoDoRepresentante = null
            };

            return pessoaFisica;
        }

        public PessoaJuridica FabricaPessoaJuridica()
        {
            var pessoaJuridica = new PessoaJuridica
            {
                Codigo = 1,
                RazaoSocial = "Empresa XYZ LTDA",
                InscricaoEstadual = "123456789",
                CNPJ = "12.345.678/0001-90",
                EhRepresentante = true
            };

            return pessoaJuridica;
        }

        #endregion
    }
}
