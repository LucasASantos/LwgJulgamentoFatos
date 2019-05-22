using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LDSI.Lwg.Apresentacao.Data.Context;
using LDSI.Lwg.Apresentacao.Data.Repositories.Interfaces;
using LDSI.Lwg.Apresentacao.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace LDSI.Lwg.Apresentacao.Controllers
{
    [Authorize]
    public class TurmaController : Controller
    {
        private readonly ITurmaRepository _turmaRepository;
        private readonly IDisciplinaRepository _disciplinaRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public TurmaController(ITurmaRepository turmaRepository, IDisciplinaRepository disciplinaRepository, UserManager<ApplicationUser> userManager)
        {
          _turmaRepository = turmaRepository;
          _disciplinaRepository = disciplinaRepository;
          _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            return View(_turmaRepository.GetAll().Include(c => c.Professor).ToList());
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id != null)
            {
                var turma = await _turmaRepository.GetAll()
                    .Include(t => t.Disciplina)
                    .Include(t => t.Professor)
                    .FirstOrDefaultAsync(m => m.TurmaId == id);
                if (turma != null)
                {
                    return View(turma);
                }
                
            }
            return NotFound();
        }

        public IActionResult Create()
        {
            ViewData["DisciplinaId"] = new SelectList(_disciplinaRepository.GetAll().ToList(), "DisciplinaId", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Turma turma)
        {
            if (ModelState.IsValid)
            {
                turma.UserId = await _userManager.GetUserIdAsync(await _userManager.GetUserAsync(User));
                _turmaRepository.Add(turma);
                await _turmaRepository.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DisciplinaId"] = new SelectList(_disciplinaRepository.GetAll().ToList(), "DisciplinaId", "DisciplinaId", turma.DisciplinaId);
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
            return View(turma);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Turma turma)
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

        private bool TurmaExists(Guid id) => _turmaRepository.GetAll().Any(e => e.TurmaId == id);


    }
}
