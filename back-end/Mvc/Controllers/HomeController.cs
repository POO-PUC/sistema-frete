using Dominio.Objeto;
using DTO.DTOs;
using Microsoft.AspNetCore.Mvc;
using Servico;

namespace WebApp.Controllers
{
    public class FreteController : Controller
    {
        private readonly ServicoFrete _servicoFrete;

        //public FreteController()
        //{
        //    _servicoFrete = new ServicoFrete();
        //}

        [HttpPost]
        public ActionResult Create(DTOFrete dtoFrete)
        {
            _servicoFrete.AdicionarFrete(dtoFrete); 
            return RedirectToAction("Index"); 

            return View(dtoFrete); 
        }

        public ActionResult Index()
        {
            IList<DTOFrete> dtoFrete = _servicoFrete.ObterTodosFretes();
            return View(dtoFrete); 
        }

        [HttpGet]
        public ActionResult EditarFrete(int id)
        {
            DTOFrete dtoFrete = _servicoFrete.ObterFretePorId(id);
            return View(dtoFrete); 
        }

        [HttpPost]
        public ActionResult AtualizaFrete(DTOFrete dtoFrete)
        {

            _servicoFrete.AtualizarFrete(dtoFrete); 
            return RedirectToAction("Index");
            
            return View(dtoFrete); 
        }

        [HttpPost]
        public ActionResult Deletar(int id)
        {
            _servicoFrete.DeletarFrete(id); 
            return RedirectToAction("Index"); 
        }

        public ActionResult Detalhes(int id)
        {
            DTOFrete dtoFrete = _servicoFrete.ObterFretePorId(id); 
            return View(dtoFrete);
        }
    }
}
