using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LDSI.Lwg.Apresentacao.Data.Repositories.Interfaces;
using LDSI.Lwg.Apresentacao.Models;
using Microsoft.AspNetCore.Authorization;

namespace LDSI.Lwg.Apresentacao.Controllers
{
    [Authorize]
    public class DisciplinaController : Controller
    {
        private readonly IDisciplinaRepository _disciplinaRepository;
        private readonly ICursoRepository _cursoRepository;

        public DisciplinaController(IDisciplinaRepository disciplinaRepository, ICursoRepository cursoRepository)
        {
          _disciplinaRepository = disciplinaRepository;
          _cursoRepository = cursoRepository;
        }

        // GET: Disciplina
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _disciplinaRepository.GetAll().Include(c=> c.Curso);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Disciplina/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disciplina = await _disciplinaRepository.GetAll()
                .Include(d => d.Curso)
                .FirstOrDefaultAsync(m => m.DisciplinaId == id);
            if (disciplina == null)
            {
                return NotFound();
            }

            return View(disciplina);
        }

        // GET: Disciplina/Create
        public IActionResult Create()
        {
            ViewData["CursoId"] = new SelectList(_cursoRepository.GetAll().ToList(), "CursoId", "Nome");
            return View();
        }

        // POST: Disciplina/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DisciplinaId,Nome,CursoId")] Disciplina disciplina)
        {
            if (ModelState.IsValid)
            {
                disciplina.DisciplinaId = Guid.NewGuid();
                _disciplinaRepository.Add(disciplina);
                await _disciplinaRepository.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CursoId"] = new SelectList(_cursoRepository.GetAll().ToList(), "CursoId", "CursoId", disciplina.CursoId);
            return View(disciplina);
        }

        // GET: Disciplina/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disciplina = await _disciplinaRepository.GetByIdAsync(id.Value);
            if (disciplina == null)
            {
                return NotFound();
            }
            ViewData["CursoId"] = new SelectList(_cursoRepository.GetAll().ToList(), "CursoId", "CursoId", disciplina.CursoId);
            return View(disciplina);
        }

        // POST: Disciplina/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("DisciplinaId,Nome,CursoId")] Disciplina disciplina)
        {
            if (id != disciplina.DisciplinaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _disciplinaRepository.Update(disciplina);
                    await _disciplinaRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisciplinaExists(disciplina.DisciplinaId))
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
            ViewData["CursoId"] = new SelectList(_cursoRepository.GetAll().ToList(), "CursoId", "CursoId", disciplina.CursoId);
            return View(disciplina);
        }

        // GET: Disciplina/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disciplina = await _disciplinaRepository.GetAll()
                .Include(d => d.Curso)
                .FirstOrDefaultAsync(m => m.DisciplinaId == id);
            if (disciplina == null)
            {
                return NotFound();
            }

            return View(disciplina);
        }

        // POST: Disciplina/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            _disciplinaRepository.Remove(id);
            await _disciplinaRepository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DisciplinaExists(Guid id)
        {
            return _disciplinaRepository.GetAll().Any(e => e.DisciplinaId == id);
        }
    }
}
