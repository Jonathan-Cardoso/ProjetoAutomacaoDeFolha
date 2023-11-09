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
            List<RecibosDePagamentoModel> folhas =
                _recibosDePagamentoRepositorio.BuscarTodosRecibos();
            return View(folhas);
        }

        public IActionResult Holerite(int id)
        {
           
            RecibosDePagamentoModel folha =
                _recibosDePagamentoRepositorio.ListarPorIdRecibo(id);

           // RecibosDePagamentoModel holerite = new RecibosDePagamentoModel();
           // folha = holerite;
            ViewData["ID"] = id;
            //ViewData["ID2"] = id2;
            CadastroFuncionarioModel funcionario = _recibosDePagamentoRepositorio.ListarPorCodFun(id);
            folha.CadastroFuncionarioModel = funcionario;
            return View(folha);
        }

        /*public IActionResult GeradorDeHolerite()
        {
            return View();
        }*/
        /*public IActionResult GeradorDeHolerite(int id)
        {
            CadastroFuncionarioModel funcionario = _cadastroFuncionarioRepositorio.ListarPorId(id);
            var setorModel = _setorRepositorio.ListarPorId(id);
            funcionario.SetorModel = setorModel;
            RecibosDePagamentoModel recibo = new RecibosDePagamentoModel();

            recibo.CadastroFuncionarioModel = funcionario;

            ViewData["MyNumber"] = id;


            return View(recibo);
        }*/

        //Metodo anterior esta comentado acima (Calculos estão na Model: MetodosCalculoModel)
        public IActionResult GeradorDeHolerite(int id)
        {
            CadastroFuncionarioModel funcionario = _cadastroFuncionarioRepositorio.ListarPorId(id);
            SetorModel setorModel = _setorRepositorio.ListarPorId(funcionario.SetorModel.Id_ST);
            funcionario.SetorModel = setorModel;
            RecibosDePagamentoModel recibos = _recibosDePagamentoRepositorio.ListarPorIdRecibo(funcionario.recibosDePagamento.Id_RP);

            // Adiciona os cálculos aqui
            MetodosCalculoModel metodosCalculo = new MetodosCalculoModel();
            metodosCalculo.CalcularSalarioBruto(funcionario.recibosDePagamento.HorasExtras);
            double inss = metodosCalculo.CalcularINSS(funcionario.salarioBruto);
            double irrf = metodosCalculo.CalcularIRRF(funcionario.salarioBruto, inss);

            // Define os valores nos atributos do funcionário
            funcionario.recibosDePagamento.DescontoINSS = inss;
            funcionario.recibosDePagamento.DescontoIR = irrf;
            funcionario.recibosDePagamento.TotalVencimentos = funcionario.salarioBruto + funcionario.recibosDePagamento.HorasExtras;
            funcionario.recibosDePagamento.TotalDescontos = inss + irrf;
            funcionario.recibosDePagamento.SalarioLiquido = funcionario.recibosDePagamento.TotalVencimentos - funcionario.recibosDePagamento.TotalDescontos;

            RecibosDePagamentoModel recibo = new RecibosDePagamentoModel
            {
                CadastroFuncionarioModel = funcionario
            };

            ViewData["MyNumber"] = id;

            return View(recibo);
        }



        [HttpPost]
        public IActionResult GeradorDeHolerite(RecibosDePagamentoModel recibo)
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

            return View(recibo);
        }
    }
}