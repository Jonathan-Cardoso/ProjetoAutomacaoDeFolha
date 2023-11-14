using Microsoft.AspNetCore.Mvc;
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
        public IActionResult GeradorDeHolerite(int id)
        {
            CadastroFuncionarioModel funcionario = _recibosDePagamentoRepositorio.ListarPorCodFun(id);
            var setorModel = _setorRepositorio.ListarPorId(id);
            funcionario.SetorModel = setorModel;
            RecibosDePagamentoModel recibo = new RecibosDePagamentoModel();
            //MetodosCalculoModel metodo = new MetodosCalculoModel();
            recibo.SalarioBruto = funcionario.salarioBruto;
            //int horasExtras = recibo.HorasExtras;
            //double salarioBruto = recibo.SalarioBruto;
            //double totalSalarioBruto = metodo.CalcularSalarioBruto(horasExtras, salarioBruto);
            //recibo.TotalVencimentos = totalSalarioBruto;

            recibo.CadastroFuncionarioModel = funcionario;

            ViewData["MyNumber"] = id;


            return View(recibo);
        }

        //Metodo anterior esta comentado acima (Calculos estão na Model: MetodosCalculoModel)
        /*public IActionResult GeradorDeHolerite(int id)
        {
            CadastroFuncionarioModel funcionario = _cadastroFuncionarioRepositorio.ListarPorId(id);
            SetorModel setorModel = _setorRepositorio.ListarPorId(funcionario.Id_ST);
            funcionario.SetorModel = setorModel;
            //List<RecibosDePagamentoModel> recibos = _recibosDePagamentoRepositorio.BuscarTodosRecibos(funcionario.Cod_Fun);
            RecibosDePagamentoModel recibo = _recibosDePagamentoRepositorio.ListarPorIdRecibo(funcionario.Cod_Fun);
            funcionario.recibosDePagamento = recibo;
           // Adiciona os cálculos aqui
           MetodosCalculoModel metodosCalculo = new MetodosCalculoModel();
            //metodosCalculo.CalcularSalarioBruto(funcionario.recibosDePagamento.HorasExtras);
            double inss = metodosCalculo.CalcularINSS(funcionario.salarioBruto);
            double irrf = metodosCalculo.CalcularIRRF(funcionario.salarioBruto, inss);

            //Define os valores nos atributos do funcionário

            funcionario.recibosDePagamento.DescontoINSS = inss;
            funcionario.recibosDePagamento.DescontoIR = irrf;
            funcionario.recibosDePagamento.TotalVencimentos = funcionario.salarioBruto + funcionario.recibosDePagamento.HorasExtras;
            funcionario.recibosDePagamento.TotalDescontos = inss + irrf;
            funcionario.recibosDePagamento.SalarioLiquido = funcionario.recibosDePagamento.TotalVencimentos - funcionario.recibosDePagamento.TotalDescontos;

            funcionario.recibosDePagamento.CadastroFuncionarioModel = funcionario;

            ViewData["MyNumber"] = id;

            return View(funcionario.recibosDePagamento);
        }*/



        [HttpPost]
        public IActionResult GeradorDeHolerite(RecibosDePagamentoModel holerite)
        {
            //RecibosDePagamentoModel holerite = new RecibosDePagamentoModel();
            MetodosCalculoModel metodo = new MetodosCalculoModel();
            int horasExtras = holerite.HorasExtras;
            double salarioBruto = holerite.SalarioBruto;
            double totalSalarioBruto = metodo.CalcularSalarioBruto(horasExtras, salarioBruto);
            holerite.TotalVencimentos = totalSalarioBruto;
            double calcINSS = holerite.TotalVencimentos;
            double descontoINSS = metodo.CalcularINSS(calcINSS);
            double valorDescINSS = descontoINSS;
            double calcIRRF = holerite.TotalVencimentos;
            double descontoIRRF = metodo.CalcularIRRF(calcIRRF, valorDescINSS);

            //double totalDescontos = (descontoINSS - metodo.CalcularIRRF(calcIRRF, valorDescINSS));
            double totalDescontos = descontoINSS+descontoIRRF;
            // Supondo que você tenha um objeto chamado "holerite"
            holerite.DescontoINSS = descontoINSS;
            holerite.DescontoIR = descontoIRRF;
            holerite.TotalDescontos = totalDescontos;
            holerite.SalarioLiquido = holerite.TotalVencimentos - totalDescontos;

            if (holerite.TotalVencimentos != null)
            {
                _recibosDePagamentoRepositorio.Gerar(holerite);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("TotalVencimentos", "O TotalVencimentos não foi fornecido.");
            }

            return View(holerite);
        }
    }
}