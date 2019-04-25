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

namespace LDSI.Lwg.Apresentacao.Controllers
{
  //public class FatoController : Controller
  //{
  //  private readonly IFatoRepository _fatoRepository;
  //  private readonly IJulgamentoFatosRepository _julgamentoFatosRepository;

  //  public FatoController(IFatoRepository fatoRepository, IJulgamentoFatosRepository julgamentoFatosRepository)
  //  {
  //    _fatoRepository = fatoRepository;
  //    _julgamentoFatosRepository = julgamentoFatosRepository;
  //  }
  //  public async Task<IActionResult> Index()
  //  {
  //    return View(await _fatoRepository.GetAll().Include(c=>c.JulgamentoFatos).ToListAsync());
  //  }

  //  public async Task<IActionResult> Details(Guid? id)
  //  {
  //    if (id == null)
  //    {
  //      return NotFound();
  //    }

  //    var fato = await _fatoRepository.GetAll().Include(c=> c.JulgamentoFatos)
  //        .FirstOrDefaultAsync(m => m.FatoId == id);
  //    if (fato == null)
  //    {
  //      return NotFound();
  //    }

  //    return View(fato);
  //  }

  //  public async Task<IActionResult> Create()
  //  {
  //    ViewData["FatoId"] = new SelectList(await _julgamentoFatosRepository.GetAll().ToListAsync(), "JulgamentoFatosId", "JulgamentoFatosId");
  //    return View();
  //  }

  //  [HttpPost]
  //  [ValidateAntiForgeryToken]
  //  public async Task<IActionResult> Create([Bind("FatoId,Texto,Verdadeiro,Ordem,Topicos,JulgamentoFatosId")] Fato fato)
  //  {
  //    if (ModelState.IsValid)
  //    {
  //      fato.FatoId = Guid.NewGuid();
  //      _context.Add(fato);
  //      await _context.SaveChangesAsync();
  //      return RedirectToAction(nameof(Index));
  //    }
  //    ViewData["FatoId"] = new SelectList(_context.Set<JulgamentoFatos>(), "JulgamentoFatosId", "JulgamentoFatosId", fato.FatoId);
  //    return View(fato);
  //  }

  //  public async Task<IActionResult> Edit(Guid? id)
  //  {
  //    if (id == null)
  //    {
  //      return NotFound();
  //    }

  //    var fato = await _context.Fatos.FindAsync(id);
  //    if (fato == null)
  //    {
  //      return NotFound();
  //    }
  //    ViewData["FatoId"] = new SelectList(_context.Set<JulgamentoFatos>(), "JulgamentoFatosId", "JulgamentoFatosId", fato.FatoId);
  //    return View(fato);
  //  }

  //  [HttpPost]
  //  [ValidateAntiForgeryToken]
  //  public async Task<IActionResult> Edit(Guid id, [Bind("FatoId,Texto,Verdadeiro,Ordem,Topicos,JulgamentoFatosId")] Fato fato)
  //  {
  //    if (id != fato.FatoId)
  //    {
  //      return NotFound();
  //    }

  //    if (ModelState.IsValid)
  //    {
  //      try
  //      {
  //        _context.Update(fato);
  //        await _context.SaveChangesAsync();
  //      }
  //      catch (DbUpdateConcurrencyException)
  //      {
  //        if (!FatoExists(fato.FatoId))
  //        {
  //          return NotFound();
  //        }
  //        else
  //        {
  //          throw;
  //        }
  //      }
  //      return RedirectToAction(nameof(Index));
  //    }
  //    ViewData["FatoId"] = new SelectList(_context.Set<JulgamentoFatos>(), "JulgamentoFatosId", "JulgamentoFatosId", fato.FatoId);
  //    return View(fato);
  //  }

  //  public async Task<IActionResult> Delete(Guid? id)
  //  {
  //    if (id == null)
  //    {
  //      return NotFound();
  //    }

  //    var fato = await _context.Fatos
  //        .Include(f => f.JulgamentoFatos)
  //        .FirstOrDefaultAsync(m => m.FatoId == id);
  //    if (fato == null)
  //    {
  //      return NotFound();
  //    }

  //    return View(fato);
  //  }

  //  [HttpPost, ActionName("Delete")]
  //  [ValidateAntiForgeryToken]
  //  public async Task<IActionResult> DeleteConfirmed(Guid id)
  //  {
  //    var fato = await _context.Fatos.FindAsync(id);
  //    _context.Fatos.Remove(fato);
  //    await _context.SaveChangesAsync();
  //    return RedirectToAction(nameof(Index));
  //  }

  //  private bool FatoExists(Guid id)
  //  {
  //    return _context.Fatos.Any(e => e.FatoId == id);
  //  }
  //}
}
