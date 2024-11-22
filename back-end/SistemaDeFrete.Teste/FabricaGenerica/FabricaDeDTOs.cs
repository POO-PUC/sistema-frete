using DTO.DTOs; 

namespace Testes.FabricaGenerica
{
    public static class FabricaDeDTOs
    {
        #region DTOs COM DADOS CORRETOS

        public static DTOCidade FabricaCidadeDTO()
        {
            var dtoCidade = new DTOCidade
            {
                Codigo = 1,
                Nome = "Goiânia",
                CodigoDoEstado = 1,
                PrecoPadrao = 500.00f
            };

            return dtoCidade;
        }

        public static DTOCliente FabricaClienteDTO()
        {
            var dtoCliente= new DTOCliente
            {
                Codigo = 1,
                Endereco = "Rua A, 123",
                Telefone = "(62) 1234-5678",
                DataDeInscricao = DateTime.Today
            };

            return dtoCliente;
        }

        public static DTOEstado FabricaEstadoDTO()
        {
            var dtoEstado = new DTOEstado
            {
                Codigo = 1,
                Nome = "Goiás",
                Uf = "GO",
                ICMSLocal = 17.00f,
                ICMSExterno = 12.00f
            };

            return dtoEstado;
        }

        public static DTOFrete FabricaFreteDTO()
        {
            var dtoFrete = new DTOFrete
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

            return dtoFrete;
        }

        public static DTOFuncionario FabricaFuncionarioDTO()
        {
            var dtoFuncionario = new DTOFuncionario
            {
                Codigo = 1,
                Nome = "João da Silva",
                NumeroDeRegistro = 12345
            };

            return dtoFuncionario;
        }

        public static DTOPessoaFisica FabricaPessoaFisicaDTO()
        {
            var dtoPessoaFisica = new DTOPessoaFisica
            {
                Codigo = 1,
                Nome = "Maria Santos",
                CPF = "123.456.789-00",
                CodigoDoRepresentante = null
            };

            return dtoPessoaFisica;
        }

        public static DTOPessoaJuridica FabricaPessoaJuridicaDTO()
        {
            var dtoPessoaJuridica = new DTOPessoaJuridica
            {
                Codigo = 1,
                RazaoSocial = "Empresa XYZ LTDA",
                InscricaoEstadual = "123456789",
                CNPJ = "12.345.678/0001-90",
                EhRepresentante = true
            };

            return dtoPessoaJuridica;
        }

        #endregion
    }
}
