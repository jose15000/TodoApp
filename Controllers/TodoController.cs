using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    public class TodoController : Controller
    {
        private readonly Contexto _contexto;

        public TodoController(Contexto contexto)
        {
            _contexto = contexto;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _contexto.Todos.ToListAsync());
        }

        [HttpGet]
        public IActionResult Novatarefa()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NovaTarefa(Todo todo)
        {
            await _contexto.Todos.AddAsync(todo);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Delete/")]
        public async Task<IActionResult> Delete(int Id)
        {
            Todo todo = await _contexto.Todos.FindAsync(Id);

            if(todo is not null)
            {
                _contexto.Todos.Remove(todo);
                _contexto.SaveChangesAsync();
            }
            
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            Todo todo = await _contexto.Todos.FindAsync(Id);
           
            return View(todo);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Todo todo)
        {
            _contexto.Todos.Update(todo);
            _contexto.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}

