using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LDSI.Lwg.Apresentacao.Data.Context;
using LDSI.Lwg.Apresentacao.Models;
using LDSI.Lwg.Apresentacao.Data.Repositories.Interfaces;

namespace LDSI.Lwg.Apresentacao.Controllers
{
    public class AlunosTurmaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ITurmaRepository _turmaRepository;
        private readonly IDisciplinaRepository _disciplinaRepository;

        public AlunosTurmaController(ApplicationDbContext context, ITurmaRepository turmaRepository, IDisciplinaRepository disciplinaRepository)
        {
            _turmaRepository = turmaRepository;
            _context = context;
            _disciplinaRepository = disciplinaRepository;
        }

        public async Task<IActionResult> Index(Guid turmaId)
        {
            ViewBag.TurmaId = turmaId;
            ViewBag.CodTurma = _turmaRepository.GetById(turmaId).Codigo;
            var applicationDbContext = _context.AlunoTurmas.Include(a => a.Aluno).Include(a => a.Turma);
            return View(await applicationDbContext.ToListAsync());
        }

        public IActionResult Create(Guid turmaId)
        {
            ViewBag.TurmaId = turmaId;
            var disciplinaid = _turmaRepository.GetById(turmaId).DisciplinaId;
            ViewData["AlunoId"] = new SelectList(_context.Users.Where(c => c.CursoId == _disciplinaRepository.GetById(disciplinaid).CursoId),"Id", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AlunoTurma alunoTurma)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(alunoTurma);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index), new { turmaId = alunoTurma.TurmaId });
                }
                catch (Exception)
                {
                }
            }
            return View(alunoTurma);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(AlunoTurma alunoTurma)
        {
            _context.AlunoTurmas.Remove(alunoTurma);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index),new { turmaId = alunoTurma.TurmaId });
        }

    }
}
