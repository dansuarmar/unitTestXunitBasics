using System;
using System.Collections.Generic;
using System.Text;

namespace ClaseExterna.LooseCoupling
{
    //ValidadorEmailHelperProxy.cs
    public class ValidadorEmailHelperProxy : IValidadorEmailHelperProxy
    {
        public bool EsValido(string email)
        {
            return ValidadorEmailHelper.EsValido(email);
        }
    }
}
