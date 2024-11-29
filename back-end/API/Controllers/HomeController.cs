using DTO.DTOs;
using Microsoft.AspNetCore.Mvc;
using Servico;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ServicoEstado _servicoEstado;
        private readonly ServicoCidade _servicoCidade;
        private readonly ServicoCliente _servicoCliente;
        private readonly ServicoPessoaFisica _servicoPessoaFisica;
        private readonly ServicoPessoaJuridica _servicoPessoaJuridica;
        private readonly ServicoFuncionario _servicoFuncionario;
        private readonly ServicoFrete _servicoFrete;

        public HomeController(
            ServicoEstado servicoEstado,
            ServicoCidade servicoCidade,
            ServicoCliente servicoCliente,
            ServicoPessoaFisica servicoPessoaFisica,
            ServicoPessoaJuridica servicoPessoaJuridica,
            ServicoFuncionario servicoFuncionario,
            ServicoFrete servicoFrete)
        {
            _servicoEstado = servicoEstado;
            _servicoCidade = servicoCidade;
            _servicoCliente = servicoCliente;
            _servicoPessoaFisica = servicoPessoaFisica;
            _servicoPessoaJuridica = servicoPessoaJuridica;
            _servicoFuncionario = servicoFuncionario;
            _servicoFrete = servicoFrete;
        }

        #region CRUD FRETE

        [HttpPost("AdicionarFrete")]
        public IActionResult AdicionarFrete([FromBody] DTOFrete dtoFrete)
        {
            _servicoFrete.AdicionarFrete(dtoFrete);
            return Ok();
        }

        [HttpGet("ObterFretes")]
        public ActionResult<IEnumerable<DTOFrete>> ObterFretes()
        {
            var fretes = _servicoFrete.ObterTodosFretes();
            return Ok(fretes);
        }

        [HttpGet("ObterFrete/{id}")]
        public ActionResult<DTOFrete> ObterFrete(int id)
        {
            var frete = _servicoFrete.ObterFretePorId(id);
            if (frete == null)
                return NotFound();
            return Ok(frete);
        }

        [HttpPut("AtualizarFrete/{id}")]
        public IActionResult AtualizarFrete(int id, [FromBody] DTOFrete dtoFrete)
        {
            if (id != dtoFrete.Codigo)
                return BadRequest();

            _servicoFrete.AtualizarFrete(dtoFrete);
            return NoContent();
        }

        [HttpDelete("DeletarFrete/{id}")]
        public IActionResult DeletarFrete(int id)
        {
            _servicoFrete.DeletarFrete(id);
            return NoContent();
        }

        [HttpGet("ArrecadacaoComFretesPorEstado/{estado}")]
        public IActionResult ArrecadacaoComFretesPorEstado(string estado)
        {
            if (string.IsNullOrWhiteSpace(estado))
            {
                return BadRequest("O estado informado não pode ser vazio.");
            }

            try
            {
                var resultado = _servicoFrete.ArrecadacaoComFretesPorEstado(estado);

                if (resultado == null || !resultado.Any())
                {
                    return NotFound($"Não foram encontrados fretes para o estado: {estado}");
                }

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        #endregion

        #region CRUD ESTADO

        [HttpPost("AdicionarEstado")]
        public IActionResult AdicionarEstado([FromBody] DTOEstado dtoEstado)
        {
            _servicoEstado.AdicionarEstado(dtoEstado);
            return Ok();
        }

        [HttpGet("ObterEstados")]
        public ActionResult<IEnumerable<DTOEstado>> ObterEstados()
        {
            var estados = _servicoEstado.ObterTodosEstados();
            return Ok(estados);
        }

        [HttpGet("ObterEstado/{id}")]
        public ActionResult<DTOEstado> ObterEstado(int id)
        {
            var estado = _servicoEstado.ObterEstadoPorId(id);
            if (estado == null)
                return NotFound();
            return Ok(estado);
        }

        [HttpPut("AtualizarEstado/{id}")]
        public IActionResult AtualizarEstado(int id, [FromBody] DTOEstado dtoEstado)
        {
            if (id != dtoEstado.Codigo)
                return BadRequest();

            _servicoEstado.AtualizarEstado(dtoEstado);
            return NoContent();
        }

        [HttpDelete("DeletarEstado/{id}")]
        public IActionResult DeletarEstado(int id)
        {
            _servicoEstado.DeletarEstado(id);
            return NoContent();
        }

        #endregion

        #region CRUD CIDADE

        [HttpPost("AdicionarCidade")]
        public IActionResult AdicionarCidade([FromBody] DTOCidade dtoCidade)
        {
            _servicoCidade.AdicionarCidade(dtoCidade);
            return Ok();
        }

        [HttpGet("ObterCidades")]
        public ActionResult<IEnumerable<DTOCidade>> ObterCidades()
        {
            var cidades = _servicoCidade.ObterTodasCidades();
            return Ok(cidades);
        }

        [HttpGet("ObterCidade/{id}")]
        public ActionResult<DTOCidade> ObterCidade(int id)
        {
            var cidade = _servicoCidade.ObterCidadePorId(id);
            if (cidade == null)
                return NotFound();
            return Ok(cidade);
        }

        [HttpPut("AtualizarCidade/{id}")]
        public IActionResult AtualizarCidade(int id, [FromBody] DTOCidade dtoCidade)
        {
            if (id != dtoCidade.Codigo)
                return BadRequest();

            _servicoCidade.AtualizarCidade(dtoCidade);
            return NoContent();
        }

        [HttpDelete("DeletarCidade/{id}")]
        public IActionResult DeletarCidade(int id)
        {
            _servicoCidade.DeletarCidade(id);
            return NoContent();
        }

        #endregion

        #region CRUD CLIENTE

        [HttpPost("AdicionarCliente")]
        public IActionResult AdicionarCliente([FromBody] DTOCliente dtoCliente)
        {
            _servicoCliente.AdicionarCliente(dtoCliente);
            return Ok();
        }

        [HttpGet("ObterClientes")]
        public ActionResult<IEnumerable<DTOCliente>> ObterClientes()
        {
            var clientes = _servicoCliente.ObterTodosClientes();
            return Ok(clientes);
        }

        [HttpGet("ObterCliente/{id}")]
        public ActionResult<DTOCliente> ObterCliente(int id)
        {
            var cliente = _servicoCliente.ObterClientePorId(id);
            if (cliente == null)
                return NotFound();
            return Ok(cliente);
        }

        [HttpPut("AtualizarCliente/{id}")]
        public IActionResult AtualizarCliente(int id, [FromBody] DTOCliente dtoCliente)
        {
            if (id != dtoCliente.Codigo)
                return BadRequest();

            _servicoCliente.AtualizarCliente(dtoCliente);
            return NoContent();
        }

        [HttpDelete("DeletarCliente/{id}")]
        public IActionResult DeletarCliente(int id)
        {
            _servicoCliente.DeletarCliente(id);
            return NoContent();
        }

        #endregion

        #region CRUD PESSOA FÍSICA

        [HttpPost("AdicionarPessoaFisica")]
        public IActionResult AdicionarPessoaFisica([FromBody] DTOPessoaFisica dtoPessoaFisica)
        {
            _servicoPessoaFisica.AdicionarPessoaFisica(dtoPessoaFisica);
            return Ok();
        }

        [HttpGet("ObterPessoasFisicas")]
        public ActionResult<IEnumerable<DTOPessoaFisica>> ObterPessoasFisicas()
        {
            var pessoasFisicas = _servicoPessoaFisica.ObterTodasPessoasFisicas();
            return Ok(pessoasFisicas);
        }

        [HttpGet("ObterPessoaFisica/{id}")]
        public ActionResult<DTOPessoaFisica> ObterPessoaFisica(int id)
        {
            var pessoaFisica = _servicoPessoaFisica.ObterPessoaFisicaPorId(id);
            if (pessoaFisica == null)
                return NotFound();
            return Ok(pessoaFisica);
        }

        [HttpPut("AtualizarPessoaFisica/{id}")]
        public IActionResult AtualizarPessoaFisica(int id, [FromBody] DTOPessoaFisica dtoPessoaFisica)
        {
            if (id != dtoPessoaFisica.Codigo)
                return BadRequest();

            _servicoPessoaFisica.AtualizarPessoaFisica(dtoPessoaFisica);
            return NoContent();
        }

        [HttpDelete("DeletarPessoaFisica/{id}")]
        public IActionResult DeletarPessoaFisica(int id)
        {
            _servicoPessoaFisica.DeletarPessoaFisica(id);
            return NoContent();
        }

        #endregion

        #region CRUD PESSOA JURÍDICA

        [HttpPost("AdicionarPessoaJuridica")]
        public IActionResult AdicionarPessoaJuridica([FromBody] DTOPessoaJuridica dtoPessoaJuridica)
        {
            _servicoPessoaJuridica.AdicionarPessoaJuridica(dtoPessoaJuridica);
            return Ok();
        }

        [HttpGet("ObterPessoasJuridicas")]
        public ActionResult<IEnumerable<DTOPessoaJuridica>> ObterPessoasJuridicas()
        {
            var pessoasJuridicas = _servicoPessoaJuridica.ObterTodasPessoasJuridicas();
            return Ok(pessoasJuridicas);
        }

        [HttpGet("ObterPessoaJuridica/{id}")]
        public ActionResult<DTOPessoaJuridica> ObterPessoaJuridica(int id)
        {
            var pessoaJuridica = _servicoPessoaJuridica.ObterPessoaJuridicaPorId(id);
            if (pessoaJuridica == null)
                return NotFound();
            return Ok(pessoaJuridica);
        }

        [HttpPut("AtualizarPessoaJuridica/{id}")]
        public IActionResult AtualizarPessoaJuridica(int id, [FromBody] DTOPessoaJuridica dtoPessoaJuridica)
        {
            if (id != dtoPessoaJuridica.Codigo)
                return BadRequest();

            _servicoPessoaJuridica.AtualizarPessoaJuridica(dtoPessoaJuridica);
            return NoContent();
        }

        [HttpDelete("DeletarPessoaJuridica/{id}")]
        public IActionResult DeletarPessoaJuridica(int id)
        {
            _servicoPessoaJuridica.DeletarPessoaJuridica(id);
            return NoContent();
        }

        #endregion

        #region CRUD FUNCIONÁRIO

        [HttpPost("AdicionarFuncionario")]
        public IActionResult AdicionarFuncionario([FromBody] DTOFuncionario dtoFuncionario)
        {
            _servicoFuncionario.AdicionarFuncionario(dtoFuncionario);
            return Ok();
        }

        [HttpGet("ObterFuncionarios")]
        public ActionResult<IEnumerable<DTOFuncionario>> ObterFuncionarios()
        {
            var funcionarios = _servicoFuncionario.ObterTodosFuncionarios();
            return Ok(funcionarios);
        }

        [HttpGet("ObterFuncionario/{id}")]
        public ActionResult<DTOFuncionario> ObterFuncionario(int id)
        {
            var funcionario = _servicoFuncionario.ObterFuncionarioPorId(id);
            if (funcionario == null)
                return NotFound();
            return Ok(funcionario);
        }

        [HttpPut("AtualizarFuncionario/{id}")]
        public IActionResult AtualizarFuncionario(int id, [FromBody] DTOFuncionario dtoFuncionario)
        {
            if (id != dtoFuncionario.Codigo)
                return BadRequest();

            _servicoFuncionario.AtualizarFuncionario(dtoFuncionario);
            return NoContent();
        }

        [HttpDelete("DeletarFuncionario/{id}")]
        public IActionResult DeletarFuncionario(int id)
        {
            _servicoFuncionario.DeletarFuncionario(id);
            return NoContent();
        }

        #endregion
    }
}
