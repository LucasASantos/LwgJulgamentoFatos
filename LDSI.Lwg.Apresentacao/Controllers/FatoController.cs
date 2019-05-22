using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LDSI.Lwg.Apresentacao.Data.Repositories.Interfaces;
using LDSI.Lwg.Apresentacao.Models;
using Microsoft.AspNetCore.Authorization;

namespace LDSI.Lwg.Apresentacao.Controllers
{
    [Authorize(Policy = "Professor")]
    public class FatoController : Controller
    {
        private readonly IFatoRepository _fatoRepository;

        public FatoController(IFatoRepository fatoRepository)
        {
            _fatoRepository = fatoRepository;
        }
        public async Task<IActionResult> Index(Guid julgamentoFatosId, Guid turmaId)
        {
            ViewBag.JulgamentoId = julgamentoFatosId;
            ViewBag.TurmaId = turmaId;
            var a = await _fatoRepository.GetAll().Where(c => c.JulgamentoFatosId == julgamentoFatosId).ToListAsync();
            return View(a);
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fato = await _fatoRepository.GetAll().Include(c => c.JulgamentoFatos)
                .FirstOrDefaultAsync(m => m.FatoId == id);
            if (fato == null)
            {
                return NotFound();
            }

            return View(fato);
        }

        public IActionResult Create(Guid julgamentoFatosId, Guid turmaId)
        {
            ViewBag.JulgamentoId = julgamentoFatosId;
            ViewBag.TurmaId = turmaId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Fato fato, Guid julgamentoFatosId, Guid turmaId)
        {
            if (ModelState.IsValid)
            {
                fato.JulgamentoFatosId = julgamentoFatosId;
                fato.TurmaId = turmaId;
                _fatoRepository.Add(fato);
                await _fatoRepository.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { julgamentoFatosId, turmaId});
            }
            ViewBag.JulgamentoId = julgamentoFatosId;
            ViewBag.TurmaId = turmaId;
            return View();
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null) return NotFound();

            var fato = await _fatoRepository.GetByIdAsync(id.Value);

            if (fato == null) return NotFound();

            return View(fato);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Fato fato)
        {
            if (id != fato.FatoId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _fatoRepository.Update(fato);
                    await _fatoRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                    if (!FatoExists(fato.FatoId)) return NotFound();

                    throw;

                }
                return Json(true);
            }
            return Json(false);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null) return NotFound();

            var fato = await _fatoRepository.GetByIdAsync(id.Value);

            if (fato == null) return NotFound();

            return View(fato);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            _fatoRepository.Remove(id);
            await _fatoRepository.SaveChangesAsync();
            return Json(true);
        }

        private bool FatoExists(Guid id)
        {
            return _fatoRepository.GetAll().Any(e => e.FatoId == id);
        }
    }
}
