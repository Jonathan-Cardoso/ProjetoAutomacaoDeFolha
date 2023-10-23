﻿using Microsoft.AspNetCore.Mvc;
using ProjetoFolha.Filters;

namespace ProjetoFolha.Controllers
{
    [UsuarioLogado]
    public class HoleriteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
