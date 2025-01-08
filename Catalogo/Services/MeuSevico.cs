namespace Catalogo.Services
{
    public class MeuSevico : IMeuService
    {

        string IMeuService.BemVindo(string nome)
        {
            return $"Bem vindo {nome} \r\n {DateTime.UtcNow}";
        }
    }
}
