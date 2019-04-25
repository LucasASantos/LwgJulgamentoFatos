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
    //public class EquipeController : Controller
    //{
    //    private readonly ApplicationDbContext _context;

    //    public EquipeController(ApplicationDbContext context)
    //    {
    //        _context = context;
    //    }

    //    // GET: Equipe
    //    public async Task<IActionResult> Index()
    //    {
    //        return View(await _context.Equipe.ToListAsync());
    //    }

    //    // GET: Equipe/Details/5
    //    public async Task<IActionResult> Details(Guid? id)
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

    //    // GET: Equipe/Create
    //    public IActionResult Create()
    //    {
    //        return View();
    //    }

    //    // POST: Equipe/Create
    //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Create([Bind("EquipeId")] Equipe equipe)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            equipe.EquipeId = Guid.NewGuid();
    //            _context.Add(equipe);
    //            await _context.SaveChangesAsync();
    //            return RedirectToAction(nameof(Index));
    //        }
    //        return View(equipe);
    //    }

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
    //}
}
