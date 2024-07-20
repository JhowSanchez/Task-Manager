using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoWEB.Context;
using ProjetoWEB.Models;

namespace ProjetoWEB.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioContext _context;

        public UsuarioController(UsuarioContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }
        
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmaLogin(string email, string senha)
        {
            var usuario = await _context.Usuarios.SingleOrDefaultAsync(u => u.Email == email);
            if (usuario == null)
                return NotFound(new {msg ="Usuario não encontrando!"});

            if (usuario.Senha == senha)
                return RedirectToAction("Index", "Tarefas", new { id = usuario.ID});
            else
                return NotFound();

        }
        [HttpPost]
        public async Task<IActionResult> CadastroUsuario(string email, string senha,DateTime dataNascimento)
        {
            Usuario usuario = new Usuario();
            usuario.Email = email;  
            usuario.Senha = senha;
            usuario.Login = email;
            usuario.DataNascimento = dataNascimento;
            var banco = await _context.Usuarios.SingleOrDefaultAsync(u => u.Email == email);
            if (banco == null)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return Ok(new { mensagem ="Cadastro Realizado com Sucesso." });
            }
            return Ok(new { mensagem = "Usuario ja existente no banco de dados!!!"});
            
        }
       
    }
}
