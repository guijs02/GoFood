namespace SistemaRecomendacaoRestuaruantes.Domain.Exceptions
{
    public class ApiException : Exception
    {
        private const string _message = "Erro ao relizar a requisição na API";
        public ApiException(string message = _message) : base(message) { }
    }
}
