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
using Microsoft.AspNetCore.Identity;

namespace LDSI.Lwg.Apresentacao.Controllers
{
    public class JulgamentoFatosController : Controller
    {
        private readonly IJulgamentoFatosRepository _julgamentoFatosRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public JulgamentoFatosController(IJulgamentoFatosRepository julgamentoFatosRepository, UserManager<ApplicationUser> userManager)
        {
            _julgamentoFatosRepository = julgamentoFatosRepository;
            _userManager = userManager;
        }

        //public async Task<IActionResult> Index()
        //{
        //    return View(await _julgamentoFatosRepository.GetAll().Include(p => p.Professor).ToListAsync());
        //}

        public async Task<IActionResult> Index(Guid turmaId)
        {
            ViewBag.TurmaId = turmaId;
            return View(await _julgamentoFatosRepository.GetJulagementosOfTurmasAsync(turmaId));
        }


        public IActionResult Create(Guid turmaId)
        {
            ViewBag.TurmaId = turmaId;
            return View();
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Guid turmaId, JulgamentoFatos julgamentoFatos)
        {
            if (ModelState.IsValid)
            {
                julgamentoFatos.UserId = await _userManager.GetUserIdAsync(await _userManager.GetUserAsync(User));
                _julgamentoFatosRepository.Add(julgamentoFatos);
                await _julgamentoFatosRepository.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(julgamentoFatos);
        }

        //public async Task<IActionResult> Edit(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var julgamentoFatos = await _context.JulgamentoFatoses.FindAsync(id);
        //    if (julgamentoFatos == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", julgamentoFatos.UserId);
        //    return View(julgamentoFatos);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(Guid id, JulgamentoFatos julgamentoFatos)
        //{
        //    if (id != julgamentoFatos.JulgamentoFatosId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(julgamentoFatos);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!JulgamentoFatosExists(julgamentoFatos.JulgamentoFatosId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", julgamentoFatos.UserId);
        //    return View(julgamentoFatos);
        //}

        //public async Task<IActionResult> Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var julgamentoFatos = await _context.JulgamentoFatoses
        //        .Include(j => j.Professor)
        //        .FirstOrDefaultAsync(m => m.JulgamentoFatosId == id);
        //    if (julgamentoFatos == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(julgamentoFatos);
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(Guid id)
        //{
        //    var julgamentoFatos = await _context.JulgamentoFatoses.FindAsync(id);
        //    _context.JulgamentoFatoses.Remove(julgamentoFatos);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool JulgamentoFatosExists(Guid id)
        //{
        //    return _context.JulgamentoFatoses.Any(e => e.JulgamentoFatosId == id);
        //}
    }
}
