using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DiarioDeSintomas.Models;
using Microsoft.AspNetCore.Authorization; // Necessário para o atributo [Authorize]

namespace DiarioDeSintomas.Controllers
{
    [Authorize] // Garante que todas as actions exigem autenticação
    public class DiarioSintomasController : Controller
    {
        private readonly DiarioContext _context;

        public DiarioSintomasController(DiarioContext context)
        {
            _context = context;
        }

        // GET: DiarioSintomas
        public async Task<IActionResult> Index()
        {
            return View(await _context.DiarioSintomas.ToListAsync());
        }

        // GET: DiarioSintomas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diarioSintoma = await _context.DiarioSintomas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (diarioSintoma == null)
            {
                return NotFound();
            }

            return View(diarioSintoma);
        }

        // GET: DiarioSintomas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DiarioSintomas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataHora,Atividade,Sintoma,Duracao,PressaoArterial,OutrosSintomas,Medicamentos,AlimentacaoHidratacao,Observacoes")] DiarioSintoma diarioSintoma)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diarioSintoma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(diarioSintoma);
        }

        // GET: DiarioSintomas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diarioSintoma = await _context.DiarioSintomas.FindAsync(id);
            if (diarioSintoma == null)
            {
                return NotFound();
            }
            return View(diarioSintoma);
        }

        // POST: DiarioSintomas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataHora,Atividade,Sintoma,Duracao,PressaoArterial,OutrosSintomas,Medicamentos,AlimentacaoHidratacao,Observacoes")] DiarioSintoma diarioSintoma)
        {
            if (id != diarioSintoma.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diarioSintoma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiarioSintomaExists(diarioSintoma.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(diarioSintoma);
        }

        // GET: DiarioSintomas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diarioSintoma = await _context.DiarioSintomas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (diarioSintoma == null)
            {
                return NotFound();
            }

            return View(diarioSintoma);
        }

        // POST: DiarioSintomas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var diarioSintoma = await _context.DiarioSintomas.FindAsync(id);
            if (diarioSintoma != null)
            {
                _context.DiarioSintomas.Remove(diarioSintoma);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool DiarioSintomaExists(int id)
        {
            return _context.DiarioSintomas.Any(e => e.Id == id);
        }
    }
}