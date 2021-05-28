namespace ClaseExterna.LooseCoupling
{
    public interface ICorreosService
    {
        bool Send(string Emails, string Titulo, string Mensaje);
    }
}