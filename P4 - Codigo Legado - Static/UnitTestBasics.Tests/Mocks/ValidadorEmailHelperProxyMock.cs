using System;
using System.Collections.Generic;
using System.Text;
using ClaseExterna.LooseCoupling;

namespace UnitTestBasics.Tests.Mocks
{
    //ValidadorEmailHelperProxyMock.cs
    public class ValidadorEmailHelperProxyMock : IValidadorEmailHelperProxy
    {
        bool respuesta;

        public ValidadorEmailHelperProxyMock(bool queRegresar) 
        {
            respuesta = queRegresar;
        }

        public bool EsValido(string email)
        {
            return respuesta;
        }
    }
}
