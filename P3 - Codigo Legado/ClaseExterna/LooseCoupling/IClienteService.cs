using System;

namespace ClaseExterna.LooseCoupling
{
    //IClienteService.cs
    public interface IClienteService
    {
        Cliente GetCliente(Guid IdCliente);
    }
}