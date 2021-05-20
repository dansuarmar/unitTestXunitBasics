using System;

namespace ClaseExterna
{
    public class Primos
    {
        public bool esPrimo(int numero) 
        {
            for (int contador = 2; contador < numero / 2; contador++) 
            {
                if (numero % contador == 0)
                    return false;
            }
            return true;
        }
    }
}
