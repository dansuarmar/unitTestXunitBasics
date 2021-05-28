using System;
using System.Collections.Generic;
using System.Text;
using ClaseExterna.LooseCoupling;

namespace UnitTestBasics.Tests.Mocks
{
    public class CorreosServiceMock : ICorreosService
    {
        bool _correoEnviado;

        public CorreosServiceMock(bool correoEnviado) 
        {
            _correoEnviado = correoEnviado;
        }

        public bool Send(string Emails, string Titulo, string Mensaje)
        {
            return _correoEnviado;
        }
    }
}
