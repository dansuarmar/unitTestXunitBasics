using System;
using System.Collections.Generic;
using System.Text;
using ClaseExterna.LooseCoupling;

namespace UnitTestBasics.Tests.Mocks
{
//MensajeRepositoryMock.cs
public class MensajeRepositoryMock : IMensajeRepository
{
    public Mensaje Add(Mensaje mensaje)
    {
        return mensaje;
    }
}
}
