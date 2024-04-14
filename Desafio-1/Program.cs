using System;

public class Calculadora
{
    public string Marca { get; set; }
    public string Serie { get; set; }

    public Calculadora(string marca, string serie)
    {
        Marca = marca;
        Serie = serie;
    }

    public double Sumar(double num1, double num2)
    {
        return num1 + num2;
    }

    public double Restar(double num1, double num2)
    {
        return num1 - num2;
    }

    public double Multiplicar(double num1, double num2)
    {
        return num1 * num2;
    }

    public double Dividir(double num1, double num2)
    {
        if (num2 == 0)
        {
            throw new DivideByZeroException("Error: División por cero");
        }
        return num1 / num2;
    }
}

public class CalculadoraCientifica : Calculadora
{
    public CalculadoraCientifica(string marca, string serie) : base(marca, serie)
    {
    }

    public double Potenciar(double baseNum, double exponente)
    {
        return Math.Pow(baseNum, exponente);
    }

    public double Raiz(double baseNum, double indice)
    {
        if (indice <= 0)
        {
            throw new ArgumentOutOfRangeException("El índice debe ser mayor que cero");
        }
        return Math.Pow(baseNum, 1 / indice);
    }

    public double Modulo(double dividendo, double divisor)
    {
        if (divisor == 0)
        {
            throw new DivideByZeroException("Error: No se puede calcular el módulo por cero");
        }
        return dividendo % divisor;
    }

    public double Logaritmo(double baseNum, double numero)
    {
        if (baseNum <= 0 || baseNum == 1 || numero <= 0)
        {
            throw new ArgumentOutOfRangeException("Los argumentos deben ser válidos para el cálculo del logaritmo");
        }
        return Math.Log(numero, baseNum);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Bienvenido a la calculadora");
        Console.WriteLine("Seleccione el tipo de calculadora:");
        Console.WriteLine("1. Básica");
        Console.WriteLine("2. Científica");

        string tipoCalculadora = Console.ReadLine();
        Calculadora calculadora;

        if (tipoCalculadora == "1")
        {
            calculadora = new Calculadora("Marca X", "Serie 123");
        }
        else if (tipoCalculadora == "2")
        {
            calculadora = new CalculadoraCientifica("Marca Y", "Serie 456");
        }
        else
        {
            Console.WriteLine("Opción no válida. Saliendo del programa.");
            return;
        }

        Console.WriteLine("Ingrese el primer número:");
        double num1 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Ingrese el segundo número:");
        double num2 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Seleccione la operación:");
        Console.WriteLine("1. Sumar");
        Console.WriteLine("2. Restar");
        Console.WriteLine("3. Multiplicar");
        Console.WriteLine("4. Dividir");

        string operacion = Console.ReadLine();
        double resultado = 0;

        switch (operacion)
        {
            case "1":
                resultado = calculadora.Sumar(num1, num2);
                break;
            case "2":
                resultado = calculadora.Restar(num1, num2);
                break;
            case "3":
                resultado = calculadora.Multiplicar(num1, num2);
                break;
            case "4":
                try
                {
                    resultado = calculadora.Dividir(num1, num2);
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
                break;
            default:
                Console.WriteLine("Operación no válida. Saliendo del programa.");
                return;
        }

        Console.WriteLine("El resultado es: " + resultado);
    }
}
