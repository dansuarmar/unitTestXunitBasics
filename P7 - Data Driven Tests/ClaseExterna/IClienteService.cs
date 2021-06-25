using System;

namespace ClaseExterna
{
    //IClienteService.cs
    public interface IClienteService
    {
        Cliente GetCliente(Guid IdCliente);
    }
}