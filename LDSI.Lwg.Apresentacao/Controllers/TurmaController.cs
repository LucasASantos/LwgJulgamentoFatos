using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LDSI.Lwg.Apresentacao.Data.Context;
using LDSI.Lwg.Apresentacao.Data.Repositories.Interfaces;
using LDSI.Lwg.Apresentacao.Models;
using Microsoft.AspNetCore.Authorization;

namespace LDSI.Lwg.Apresentacao.Controllers
{
    [Authorize]
    public class TurmaController : Controller
    {
        private readonly ITurmaRepository _turmaRepository;
        private readonly IDisciplinaRepository _disciplinaRepository;
        private readonly ApplicationDbContext _context;

        public TurmaController(ITurmaRepository turmaRepository, IDisciplinaRepository disciplinaRepository, ApplicationDbContext context)
        {
          _turmaRepository = turmaRepository;
          _disciplinaRepository = disciplinaRepository;
          _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _turmaRepository.GetAll().Include(t => t.Disciplina).Include(t => t.Professor);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turma = await _turmaRepository.GetAll()
                .Include(t => t.Disciplina)
                .Include(t => t.Professor)
                .FirstOrDefaultAsync(m => m.TurmaId == id);
            if (turma == null)
            {
                return NotFound();
            }

            return View(turma);
        }

        public IActionResult Create()
        {
            ViewData["DisciplinaId"] = new SelectList(_disciplinaRepository.GetAll().ToList(), "DisciplinaId", "Nome");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TurmaId,Codigo,DisciplinaId,UserId")] Turma turma)
        {
            if (ModelState.IsValid)
            {
                turma.TurmaId = Guid.NewGuid();
                _turmaRepository.Add(turma);
                await _turmaRepository.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DisciplinaId"] = new SelectList(_disciplinaRepository.GetAll().ToList(), "DisciplinaId", "DisciplinaId", turma.DisciplinaId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Nome", turma.UserId);
            return View(turma);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turma = await _turmaRepository.GetByIdAsync(id.Value);
            if (turma == null)
            {
                return NotFound();
            }
            ViewData["DisciplinaId"] = new SelectList(_disciplinaRepository.GetAll().ToList(), "DisciplinaId", "DisciplinaId", turma.DisciplinaId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Nome", turma.UserId);
            return View(turma);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("TurmaId,Codigo,DisciplinaId,UserId")] Turma turma)
        {
            if (id != turma.TurmaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _turmaRepository.Update(turma);
                    await _turmaRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurmaExists(turma.TurmaId))
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
            ViewData["DisciplinaId"] = new SelectList(_disciplinaRepository.GetAll().ToList(), "DisciplinaId", "DisciplinaId", turma.DisciplinaId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Nome", turma.UserId);
            return View(turma);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turma = await _turmaRepository.GetAll()
                .Include(t => t.Disciplina)
                .Include(t => t.Professor)
                .FirstOrDefaultAsync(m => m.TurmaId == id);
            if (turma == null)
            {
                return NotFound();
            }

            return View(turma);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            _turmaRepository.Remove(id);
            await _turmaRepository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TurmaExists(Guid id)
        {
            return _turmaRepository.GetAll().Any(e => e.TurmaId == id);
        }
    }
}
