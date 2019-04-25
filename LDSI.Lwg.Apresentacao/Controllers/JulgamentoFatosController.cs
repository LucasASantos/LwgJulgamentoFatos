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
    //public class JulgamentoFatosController : Controller
    //{
    //    private readonly ApplicationDbContext _context;

    //    public JulgamentoFatosController(ApplicationDbContext context)
    //    {
    //        _context = context;
    //    }

    //    // GET: JulgamentoFatos
    //    public async Task<IActionResult> Index()
    //    {
    //        var applicationDbContext = _context.JulgamentoFatoses.Include(j => j.Professor);
    //        return View(await applicationDbContext.ToListAsync());
    //    }

    //    // GET: JulgamentoFatos/Details/5
    //    public async Task<IActionResult> Details(Guid? id)
    //    {
    //        if (id == null)
    //        {
    //            return NotFound();
    //        }

    //        var julgamentoFatos = await _context.JulgamentoFatoses
    //            .Include(j => j.Professor)
    //            .FirstOrDefaultAsync(m => m.JulgamentoFatosId == id);
    //        if (julgamentoFatos == null)
    //        {
    //            return NotFound();
    //        }

    //        return View(julgamentoFatos);
    //    }

    //    // GET: JulgamentoFatos/Create
    //    public IActionResult Create()
    //    {
    //        ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
    //        return View();
    //    }

    //    // POST: JulgamentoFatos/Create
    //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Create([Bind("JulgamentoFatosId,TamanhoEquipe,TempoExibicao,Status,UserId")] JulgamentoFatos julgamentoFatos)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            julgamentoFatos.JulgamentoFatosId = Guid.NewGuid();
    //            _context.Add(julgamentoFatos);
    //            await _context.SaveChangesAsync();
    //            return RedirectToAction(nameof(Index));
    //        }
    //        ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", julgamentoFatos.UserId);
    //        return View(julgamentoFatos);
    //    }

    //    // GET: JulgamentoFatos/Edit/5
    //    public async Task<IActionResult> Edit(Guid? id)
    //    {
    //        if (id == null)
    //        {
    //            return NotFound();
    //        }

    //        var julgamentoFatos = await _context.JulgamentoFatoses.FindAsync(id);
    //        if (julgamentoFatos == null)
    //        {
    //            return NotFound();
    //        }
    //        ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", julgamentoFatos.UserId);
    //        return View(julgamentoFatos);
    //    }

    //    // POST: JulgamentoFatos/Edit/5
    //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Edit(Guid id, [Bind("JulgamentoFatosId,TamanhoEquipe,TempoExibicao,Status,UserId")] JulgamentoFatos julgamentoFatos)
    //    {
    //        if (id != julgamentoFatos.JulgamentoFatosId)
    //        {
    //            return NotFound();
    //        }

    //        if (ModelState.IsValid)
    //        {
    //            try
    //            {
    //                _context.Update(julgamentoFatos);
    //                await _context.SaveChangesAsync();
    //            }
    //            catch (DbUpdateConcurrencyException)
    //            {
    //                if (!JulgamentoFatosExists(julgamentoFatos.JulgamentoFatosId))
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
    //        ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", julgamentoFatos.UserId);
    //        return View(julgamentoFatos);
    //    }

    //    // GET: JulgamentoFatos/Delete/5
    //    public async Task<IActionResult> Delete(Guid? id)
    //    {
    //        if (id == null)
    //        {
    //            return NotFound();
    //        }

    //        var julgamentoFatos = await _context.JulgamentoFatoses
    //            .Include(j => j.Professor)
    //            .FirstOrDefaultAsync(m => m.JulgamentoFatosId == id);
    //        if (julgamentoFatos == null)
    //        {
    //            return NotFound();
    //        }

    //        return View(julgamentoFatos);
    //    }

    //    // POST: JulgamentoFatos/Delete/5
    //    [HttpPost, ActionName("Delete")]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> DeleteConfirmed(Guid id)
    //    {
    //        var julgamentoFatos = await _context.JulgamentoFatoses.FindAsync(id);
    //        _context.JulgamentoFatoses.Remove(julgamentoFatos);
    //        await _context.SaveChangesAsync();
    //        return RedirectToAction(nameof(Index));
    //    }

    //    private bool JulgamentoFatosExists(Guid id)
    //    {
    //        return _context.JulgamentoFatoses.Any(e => e.JulgamentoFatosId == id);
    //    }
    //}
}
