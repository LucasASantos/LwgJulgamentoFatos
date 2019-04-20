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
using Microsoft.AspNetCore.Authorization;

namespace LDSI.Lwg.Apresentacao.Controllers
{
  [Authorize]
  public class CursoController : Controller
  {
    private readonly ICursoRepository _cursoRepository;

    public CursoController(ICursoRepository cursoRepository)
    {
      _cursoRepository = cursoRepository;
    }

    public async Task<IActionResult> Index()
    {
      return View(await _cursoRepository.GetAll().ToListAsync());
    }

    // GET: Curso/Details/5
    public async Task<IActionResult> Details(Guid? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var curso = await _cursoRepository.GetByIdAsync(id.Value);
      if (curso == null)
      {
        return NotFound();
      }

      return View(curso);
    }

    // GET: Curso/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: Curso/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("CursoId,Nome,Unidade")] Curso curso)
    {
      if (ModelState.IsValid)
      {
        curso.CursoId = Guid.NewGuid();
        _cursoRepository.Add(curso);
        await _cursoRepository.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(curso);
    }

    // GET: Curso/Edit/5
    public async Task<IActionResult> Edit(Guid? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var curso = await _cursoRepository.GetByIdAsync(id.Value);
      if (curso == null)
      {
        return NotFound();
      }
      return View(curso);
    }

    // POST: Curso/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, [Bind("CursoId,Nome,Unidade")] Curso curso)
    {
      if (id != curso.CursoId)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _cursoRepository.Update(curso);
          await _cursoRepository.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!CursoExists(curso.CursoId))
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
      return View(curso);
    }

    // GET: Curso/Delete/5
    public async Task<IActionResult> Delete(Guid? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var curso = await _cursoRepository.GetByIdAsync(id.Value);
      if (curso == null)
      {
        return NotFound();
      }

      return View(curso);
    }

    // POST: Curso/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
      _cursoRepository.Remove(id);
      await _cursoRepository.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool CursoExists(Guid id)
    {
      return _cursoRepository.GetAll().Any(e => e.CursoId == id);
    }
  }
}
