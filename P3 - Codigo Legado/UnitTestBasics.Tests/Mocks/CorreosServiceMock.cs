using System;
using System.Collections.Generic;
using System.Text;
using ClaseExterna.LooseCoupling;

namespace UnitTestBasics.Tests.Mocks
{
    //CorreosServiceMock.cs
    public class CorreosServiceMock : ICorreosService
    {
        bool _correoEnviado;

        public CorreosServiceMock(bool simularCorreoEnviado) 
        {
            _correoEnviado = simularCorreoEnviado;
        }

        public void Send(string Emails, string Titulo, string Mensaje)
        {
            if (!_correoEnviado)
                throw new Exception("Error al enviar correo.");
        }
    }
}
