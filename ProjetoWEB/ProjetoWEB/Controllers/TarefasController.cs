using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoWEB.Context;
using ProjetoWEB.Models;

namespace ProjetoWEB.Controllers
{
    public class TarefasController : Controller
    {
        private readonly UsuarioContext _context;
        public TarefasController(UsuarioContext context)
        {
            _context = context;
        }

        public IActionResult Sair()
        {
            return RedirectToAction("Index","Home");
        }

        public IActionResult Editar(int ID)
        {
            var busca = _context.Tarefas.Find(ID);
            return View(busca); 
        }

        [HttpPost]
        public async Task<IActionResult> EditarTarefa(Tarefas tarefas)
        {
            var TarefaBanco = await _context.Tarefas.FindAsync(tarefas.ID);

           if (TarefaBanco != null)
           {
                TarefaBanco.DataTarefa = tarefas.DataTarefa;
                TarefaBanco.DetalhesTarefa = tarefas.DetalhesTarefa;
                TarefaBanco.Prioridadade = tarefas.Prioridadade;

                _context.Update(TarefaBanco);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { ID = tarefas.ID_Usuario });
           }

           return NotFound();

            
        }


        public IActionResult Deletar(int ID)
        {
            var busca = _context.Tarefas.Find(ID);
            return View(busca); 
        }
        [HttpPost]
        public async Task<IActionResult> DeletarTarefa(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);
            var UsuarioId = tarefa.ID_Usuario;

            if(tarefa == null)
                return NotFound();
            
            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new {ID = UsuarioId});

        }
        public IActionResult Detalhes(int ID)
        {
            var busca = _context.Tarefas.Find(ID);
            return View(busca);
        }
        public async Task<IActionResult> Index(int id)
        {
            //Aqui usamos o viewbag para armazenar o ID do usuario a ser passado
            ViewBag.ID= id;
      
            var listaTarefas = await _context.Tarefas
                                      .Where(t => t.ID_Usuario == id)
                                      .ToListAsync();

            if (listaTarefas == null || !listaTarefas.Any())
            {
                return View();
            }

            return View(listaTarefas);
        }

        public IActionResult Criar(int ID)
        {
            var tarefa = new Tarefas();
            tarefa.ID_Usuario = ID;
            return View(tarefa);
        }

        [HttpPost]
        public async Task<IActionResult> CriarNovaTarefa(Tarefas tarefa)
        {
            _context.Add(tarefa);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { id = tarefa.ID_Usuario});
        }
    }
}
