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
    //public class FatoController : Controller
    //{
    //    private readonly ApplicationDbContext _context;

    //    public FatoController(ApplicationDbContext context)
    //    {
    //        _context = context;
    //    }

    //    // GET: Fato
    //    public async Task<IActionResult> Index()
    //    {
    //        var applicationDbContext = _context.Fatos.Include(f => f.JulgamentoFatos);
    //        return View(await applicationDbContext.ToListAsync());
    //    }

    //    // GET: Fato/Details/5
    //    public async Task<IActionResult> Details(Guid? id)
    //    {
    //        if (id == null)
    //        {
    //            return NotFound();
    //        }

    //        var fato = await _context.Fatos
    //            .Include(f => f.JulgamentoFatos)
    //            .FirstOrDefaultAsync(m => m.FatoId == id);
    //        if (fato == null)
    //        {
    //            return NotFound();
    //        }

    //        return View(fato);
    //    }

    //    // GET: Fato/Create
    //    public IActionResult Create()
    //    {
    //        ViewData["FatoId"] = new SelectList(_context.Set<JulgamentoFatos>(), "JulgamentoFatosId", "JulgamentoFatosId");
    //        return View();
    //    }

    //    // POST: Fato/Create
    //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Create([Bind("FatoId,Texto,Verdadeiro,Ordem,Topicos,JulgamentoFatosId")] Fato fato)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            fato.FatoId = Guid.NewGuid();
    //            _context.Add(fato);
    //            await _context.SaveChangesAsync();
    //            return RedirectToAction(nameof(Index));
    //        }
    //        ViewData["FatoId"] = new SelectList(_context.Set<JulgamentoFatos>(), "JulgamentoFatosId", "JulgamentoFatosId", fato.FatoId);
    //        return View(fato);
    //    }

    //    // GET: Fato/Edit/5
    //    public async Task<IActionResult> Edit(Guid? id)
    //    {
    //        if (id == null)
    //        {
    //            return NotFound();
    //        }

    //        var fato = await _context.Fatos.FindAsync(id);
    //        if (fato == null)
    //        {
    //            return NotFound();
    //        }
    //        ViewData["FatoId"] = new SelectList(_context.Set<JulgamentoFatos>(), "JulgamentoFatosId", "JulgamentoFatosId", fato.FatoId);
    //        return View(fato);
    //    }

    //    // POST: Fato/Edit/5
    //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Edit(Guid id, [Bind("FatoId,Texto,Verdadeiro,Ordem,Topicos,JulgamentoFatosId")] Fato fato)
    //    {
    //        if (id != fato.FatoId)
    //        {
    //            return NotFound();
    //        }

    //        if (ModelState.IsValid)
    //        {
    //            try
    //            {
    //                _context.Update(fato);
    //                await _context.SaveChangesAsync();
    //            }
    //            catch (DbUpdateConcurrencyException)
    //            {
    //                if (!FatoExists(fato.FatoId))
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
    //        ViewData["FatoId"] = new SelectList(_context.Set<JulgamentoFatos>(), "JulgamentoFatosId", "JulgamentoFatosId", fato.FatoId);
    //        return View(fato);
    //    }

    //    // GET: Fato/Delete/5
    //    public async Task<IActionResult> Delete(Guid? id)
    //    {
    //        if (id == null)
    //        {
    //            return NotFound();
    //        }

    //        var fato = await _context.Fatos
    //            .Include(f => f.JulgamentoFatos)
    //            .FirstOrDefaultAsync(m => m.FatoId == id);
    //        if (fato == null)
    //        {
    //            return NotFound();
    //        }

    //        return View(fato);
    //    }

    //    // POST: Fato/Delete/5
    //    [HttpPost, ActionName("Delete")]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> DeleteConfirmed(Guid id)
    //    {
    //        var fato = await _context.Fatos.FindAsync(id);
    //        _context.Fatos.Remove(fato);
    //        await _context.SaveChangesAsync();
    //        return RedirectToAction(nameof(Index));
    //    }

    //    private bool FatoExists(Guid id)
    //    {
    //        return _context.Fatos.Any(e => e.FatoId == id);
    //    }
    //}
}
