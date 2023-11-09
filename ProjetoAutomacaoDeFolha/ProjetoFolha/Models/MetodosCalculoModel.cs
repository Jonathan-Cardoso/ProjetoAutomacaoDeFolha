using Newtonsoft.Json.Linq;
using System.Runtime.Intrinsics.X86;

public class MetodosCalculoModel
{
    private double value;

    public double CalcularSalarioBruto(double horasExtras, double salarioBruto)
    {
        float dias = 30;

        if (horasExtras > 0)
        {
            double valorHora = salarioBruto / dias;
            valorHora *= 1.5;
            double totalHoraExtra = horasExtras * valorHora;
            return salarioBruto + totalHoraExtra;
        }

        return salarioBruto;
    }

    //Sem este método a linha 76 chora na controller "RecibosDePagamentoController
    internal double CalcularSalarioBruto(double horasExtras)
    {
        throw new NotImplementedException();
    }

    public double CalcularINSS(double salarioBruto)
    {
        double acInss = 0;

        switch (salarioBruto)
        {
            case var value when value <= 1320:
                acInss = value * 7.5 / 100;
                break;

            case var value when EstaEntre(1320.01, 2571.29, value):
                acInss = 99;
                acInss += (value - 1320.01) * 9 / 100;
                break;

            case var value when EstaEntre(2571.30, 3856.94, value):
                acInss = 99;
                acInss += 112.62;
                acInss += (value - 2571.30) * 12 / 100;
                break;

            case var value when EstaEntre(3856.95, 7507.49, value):
                acInss = 99;
                acInss += 112.62;
                acInss += 154.28;
                acInss += (value - 3856.95) * 14 / 100;
                break;

            case var value when value >= 7507.49:
                acInss = 99;
                acInss += 112.62;
                acInss += 154.28;
                acInss += 511.08;
                break;

            default:
                throw new Exception("Valor inválido");
        }

        return acInss;
    }

    public double CalcularIRRF(double salarioBruto, double valorINSS)
    {
        double baseCalc = salarioBruto - valorINSS;

        switch (baseCalc)
        {
            case var value when value <= 2112:
                return 0;

            case var value when EstaEntre(2112.01, 2826.65, value):
                return (value * 7.5 / 100) - 158.40;

            case var value when EstaEntre(2826.66, 3751.05, value):
                return (value * 15 / 100) - 370.40;

            case var value when EstaEntre(3751.06, 4664.68, value):
                return (value * 22.5 / 100) - 651.73;

            default:
                return (value * 27.5 / 100) - 884.96;
        }
    }

    private static bool EstaEntre(double min, double max, double value)
    {
        return value >= min && value <= max;
    }
}