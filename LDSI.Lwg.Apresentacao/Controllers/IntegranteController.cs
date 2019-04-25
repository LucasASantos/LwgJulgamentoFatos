using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LDSI.Lwg.Apresentacao.Data.Context;
using LDSI.Lwg.Apresentacao.Models;

namespace LDSI.Lwg.Apresentacao.Controllers
{
    //public class IntegranteController : Controller
    //{
    //    private readonly ApplicationDbContext _context;

    //    public IntegranteController(ApplicationDbContext context)
    //    {
    //        _context = context;
    //    }

    //    // GET: Integrante
    //    public async Task<IActionResult> Index()
    //    {
    //        var applicationDbContext = _context.Integrante.Include(i => i.Aluno).Include(i => i.Equipe);
    //        return View(await applicationDbContext.ToListAsync());
    //    }

    //    // GET: Integrante/Details/5
    //    public async Task<IActionResult> Details(Guid? id)
    //    {
    //        if (id == null)
    //        {
    //            return NotFound();
    //        }

    //        var integrante = await _context.Integrante
    //            .Include(i => i.Aluno)
    //            .Include(i => i.Equipe)
    //            .FirstOrDefaultAsync(m => m.IntegranteId == id);
    //        if (integrante == null)
    //        {
    //            return NotFound();
    //        }

    //        return View(integrante);
    //    }

    //    // GET: Integrante/Create
    //    public IActionResult Create()
    //    {
    //        ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
    //        ViewData["IntegranteId"] = new SelectList(_context.Equipe, "EquipeId", "EquipeId");
    //        return View();
    //    }

    //    // POST: Integrante/Create
    //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Create([Bind("IntegranteId,EhLider,UserId,EquipeId")] Integrante integrante)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            integrante.IntegranteId = Guid.NewGuid();
    //            _context.Add(integrante);
    //            await _context.SaveChangesAsync();
    //            return RedirectToAction(nameof(Index));
    //        }
    //        ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", integrante.UserId);
    //        ViewData["IntegranteId"] = new SelectList(_context.Equipe, "EquipeId", "EquipeId", integrante.IntegranteId);
    //        return View(integrante);
    //    }

    //    // GET: Integrante/Edit/5
    //    public async Task<IActionResult> Edit(Guid? id)
    //    {
    //        if (id == null)
    //        {
    //            return NotFound();
    //        }

    //        var integrante = await _context.Integrante.FindAsync(id);
    //        if (integrante == null)
    //        {
    //            return NotFound();
    //        }
    //        ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", integrante.UserId);
    //        ViewData["IntegranteId"] = new SelectList(_context.Equipe, "EquipeId", "EquipeId", integrante.IntegranteId);
    //        return View(integrante);
    //    }

    //    // POST: Integrante/Edit/5
    //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Edit(Guid id, [Bind("IntegranteId,EhLider,UserId,EquipeId")] Integrante integrante)
    //    {
    //        if (id != integrante.IntegranteId)
    //        {
    //            return NotFound();
    //        }

    //        if (ModelState.IsValid)
    //        {
    //            try
    //            {
    //                _context.Update(integrante);
    //                await _context.SaveChangesAsync();
    //            }
    //            catch (DbUpdateConcurrencyException)
    //            {
    //                if (!IntegranteExists(integrante.IntegranteId))
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
    //        ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", integrante.UserId);
    //        ViewData["IntegranteId"] = new SelectList(_context.Equipe, "EquipeId", "EquipeId", integrante.IntegranteId);
    //        return View(integrante);
    //    }

    //    // GET: Integrante/Delete/5
    //    public async Task<IActionResult> Delete(Guid? id)
    //    {
    //        if (id == null)
    //        {
    //            return NotFound();
    //        }

    //        var integrante = await _context.Integrante
    //            .Include(i => i.Aluno)
    //            .Include(i => i.Equipe)
    //            .FirstOrDefaultAsync(m => m.IntegranteId == id);
    //        if (integrante == null)
    //        {
    //            return NotFound();
    //        }

    //        return View(integrante);
    //    }

    //    // POST: Integrante/Delete/5
    //    [HttpPost, ActionName("Delete")]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> DeleteConfirmed(Guid id)
    //    {
    //        var integrante = await _context.Integrante.FindAsync(id);
    //        _context.Integrante.Remove(integrante);
    //        await _context.SaveChangesAsync();
    //        return RedirectToAction(nameof(Index));
    //    }

    //    private bool IntegranteExists(Guid id)
    //    {
    //        return _context.Integrante.Any(e => e.IntegranteId == id);
    //    }
    //}
}
