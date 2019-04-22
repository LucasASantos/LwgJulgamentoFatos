using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LDSI.Lwg.Apresentacao.Models;
using Microsoft.AspNetCore.Authorization;

namespace LDSI.Lwg.Apresentacao.Controllers
{
  [Authorize]
  public class HomeController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
