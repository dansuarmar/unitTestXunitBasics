namespace ClaseExterna.LooseCoupling
{
    public interface ICorreosService
    {
        void Send(string Emails, string Titulo, string Mensaje);
    }
}