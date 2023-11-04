﻿using Microsoft.AspNetCore.Mvc;
using ProjetoFolha.Filters;
using ProjetoFolha.Models;
using ProjetoFolha.Repositorio;

namespace ProjetoFolha.Controllers
{
    [UsuarioLogado]
    public class RecibosDePagamentoController : Controller
    {

        private readonly IRecibosDePagamentoRepositorio _recibosDePagamentoRepositorio;
        private readonly ICadastroFuncionarioRepositorio _cadastroFuncionarioRepositorio;
        private readonly ISetorRepositorio _setorRepositorio;

        public RecibosDePagamentoController(ISetorRepositorio setorRepositorio, IRecibosDePagamentoRepositorio recibosDePagamentoRepositorio, ICadastroFuncionarioRepositorio cadastroFuncionarioRepositorio)
        {
            _recibosDePagamentoRepositorio = recibosDePagamentoRepositorio;
            _cadastroFuncionarioRepositorio = cadastroFuncionarioRepositorio;
            _setorRepositorio = setorRepositorio;
        }

        public IActionResult Index()
        {
            return View();
        }

        /*public IActionResult GeradorDeHolerite()
        {
            return View();
        }*/
        public IActionResult GeradorDeHolerite(int id)
        {
            CadastroFuncionarioModel funcionario = _cadastroFuncionarioRepositorio.ListarPorId(id);
            var setorModel = _setorRepositorio.ListarPorId(id);
            funcionario.SetorModel = setorModel;
            RecibosDePagamentoModel recibo = new RecibosDePagamentoModel();
            recibo.CadastroFuncionarioModel = funcionario;
            
            return View(recibo);
        }

        [HttpPost]
        public IActionResult GeradorDeHolerite(RecibosDePagamentoModel recibo)
        {
            
            if (ModelState.IsValid)
            {


                if (recibo.TotalVencimentos != null)
                {
                    _recibosDePagamentoRepositorio.Gerar(recibo);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("TotalVencimentos", "O TotalVencimentos não foi fornecido.");
                }
            }
            return View(recibo);
        }
    }
}
