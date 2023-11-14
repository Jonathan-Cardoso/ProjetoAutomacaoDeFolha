using Newtonsoft.Json.Linq;
using System.Runtime.Intrinsics.X86;

public class MetodosCalculoModel
{
    private double value;

    public double CalcularSalarioBruto(int horasExtras, double salarioBruto)
    {
        float dias = 30;
        float horas = 8;
        if (horasExtras > 0)
        {
            double valorHora = ((salarioBruto / dias) / horas);
            valorHora *= 1.5;
            double totalHoraExtra = horasExtras * valorHora;
            return salarioBruto + totalHoraExtra;
        }

        return salarioBruto;
    }

    public double CalcularINSS(double salarioBruto)
    {
        //double acInss = 0;
        double descontoINSS = 0;

        if (salarioBruto <= 1320.00)
        {
            descontoINSS = salarioBruto * 0.075;
        }
        else if (salarioBruto <= 2571.29)
        {
            descontoINSS = (salarioBruto - 1320.00) * 0.09 + 99.00;
        }
        else if (salarioBruto <= 3856.94)
        {
            descontoINSS = (salarioBruto - 2571.29) * 0.12 + 99.00 + 112.61;
        }
        else
        {
            double faixa1 = 1320.00 * 0.075;
            double faixa2 = (2571.29 - 1320.00) * 0.09;
            double faixa3 = (3856.94 - 2571.29) * 0.12;
            double faixa4 = (salarioBruto - 3856.94) * 0.14;
            descontoINSS = faixa1 + faixa2 + faixa3 + faixa4;
        } return descontoINSS;
        /*switch (salarioBruto)
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
        }*/

        //return acInss;
    }

    public double CalcularIRRF(double salarioBruto, double valorINSS)
    {
        //double baseCalc = salarioBruto - valorINSS;

        double baseCalculoIR = salarioBruto - valorINSS;

        double impostoDeRenda = 0;

        if (baseCalculoIR <= 1903.98)
        {
            impostoDeRenda = 0;
        }
        else if (baseCalculoIR <= 2826.65)
        {
            impostoDeRenda = (baseCalculoIR - 1903.98) * 0.075;
        }
        else if (baseCalculoIR <= 3751.05)
        {
            impostoDeRenda = (baseCalculoIR - 2826.65) * 0.15;
        }
        else if (baseCalculoIR <= 4664.68)
        {
            impostoDeRenda = (baseCalculoIR - 3751.05) * 0.225;
        }
        else
        {
            impostoDeRenda = (baseCalculoIR - 4664.68) * 0.275;
        }
        return impostoDeRenda;
        /*if (baseCalc <= 2112)
        {
            return 0;
        }
        else if (EstaEntre(2112.01, 2826.65, baseCalc))
        {
            return (baseCalc * 0.075) - 158.40;
        }
        else if (EstaEntre(2826.66, 3751.05, baseCalc))
        {
            return (baseCalc * 0.15) - 370.40;
        }
        else if (EstaEntre(3751.06, 4664.68, baseCalc))
        {
            return (baseCalc * 0.225) - 651.73;
        }
        else
        {
            return (baseCalc * 0.275) - 884.96;
        }*/
    }

    // Função para verificar se um valor está entre dois limites
    private bool EstaEntre(double limiteInferior, double limiteSuperior, double valor)
    {
        return valor >= limiteInferior && valor <= limiteSuperior;
    }

}