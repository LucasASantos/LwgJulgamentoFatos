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
using Microsoft.AspNetCore.Identity;

namespace LDSI.Lwg.Apresentacao.Controllers
{
    public class EquipeController : Controller
    {
        private readonly IEquipeRepository _equipeRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public EquipeController(IEquipeRepository equipeRepository, UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _equipeRepository = equipeRepository;
            _userManager = userManager;
            _context = context;
        }
        // GET: Equipe
        public async Task<IActionResult> Index(Guid julgamentoFatosId)
        {
            ViewBag.JulgamentoFatosId = julgamentoFatosId;
            ViewBag.Alunos = await _context.Users.ToListAsync();
            return View(await _equipeRepository.GetAll().Include(c => c.Integrantes).Where(c => c.JulgamentoFatosId == julgamentoFatosId).ToListAsync());
        }

        public async Task<IActionResult> Create(Guid julgamentoFatosId)
        {
            var equipes = await _equipeRepository.GetAll().Include(c => c.Integrantes).Where(c => c.JulgamentoFatosId == julgamentoFatosId).ToListAsync();
            if(!equipes.Any(c=> c.Integrantes.Any(i=> i.UserId == _userManager.GetUserId(HttpContext.User))))
            {
                var equipe = new Equipe() {
                    Integrantes = new List<Integrante>(),
                    JulgamentoFatosId = julgamentoFatosId,
                };
                equipe.Integrantes.Add(new Integrante()
                {
                    Aluno = await _userManager.GetUserAsync(HttpContext.User),
                    EhLider = true,
                });

                _equipeRepository.Add(equipe);
                await _equipeRepository.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { julgamentoFatosId });
            }
            return RedirectToAction(nameof(Index),new { julgamentoFatosId });
        }

        public async Task<IActionResult> Delete(Guid id, Guid julgamentoFatosId)
        {
            _equipeRepository.Remove(id);
            await _equipeRepository.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { julgamentoFatosId });
        }


        //    // GET: Equipe/Edit/5
        //    public async Task<IActionResult> Edit(Guid? id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var equipe = await _context.Equipe.FindAsync(id);
        //        if (equipe == null)
        //        {
        //            return NotFound();
        //        }
        //        return View(equipe);
        //    }

        //    // POST: Equipe/Edit/5
        //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> Edit(Guid id, [Bind("EquipeId")] Equipe equipe)
        //    {
        //        if (id != equipe.EquipeId)
        //        {
        //            return NotFound();
        //        }

        //        if (ModelState.IsValid)
        //        {
        //            try
        //            {
        //                _context.Update(equipe);
        //                await _context.SaveChangesAsync();
        //            }
        //            catch (DbUpdateConcurrencyException)
        //            {
        //                if (!EquipeExists(equipe.EquipeId))
        //                {
        //                    return NotFound();
        //                }
        //                else
        //                {
        //                    throw;
        //                }
        //            }
        //            return RedirectToAction(nameof(Index));
        //        }
        //        return View(equipe);
        //    }

        //    // GET: Equipe/Delete/5
        //    public async Task<IActionResult> Delete(Guid? id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var equipe = await _context.Equipe
        //            .FirstOrDefaultAsync(m => m.EquipeId == id);
        //        if (equipe == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(equipe);
        //    }

        //    // POST: Equipe/Delete/5
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> DeleteConfirmed(Guid id)
        //    {
        //        var equipe = await _context.Equipe.FindAsync(id);
        //        _context.Equipe.Remove(equipe);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }

        //    private bool EquipeExists(Guid id)
        //    {
        //        return _context.Equipe.Any(e => e.EquipeId == id);
        //    }
    }
}
