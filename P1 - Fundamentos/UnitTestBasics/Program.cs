using System;

namespace UnitTestBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Indica el numero que quieres saber si es Primo:");
            var numero = Convert.ToInt32(Console.ReadLine());
            var primos = new ClaseExterna.Primos();
            var resultado = primos.esPrimo(numero);
            if(resultado)
                Console.WriteLine("El numero SI es Primo");
            else
                Console.WriteLine("El numero NO es Primo");
        }
    }
}
