namespace GoFood.Domain.Exceptions
{
    public class DeserializeToObjectException : Exception
    {
        private const string _message = "Não foi possivel desserializar para um tipo de objeto específico";
        public DeserializeToObjectException(string message = _message) : base(message) { }
    }
}
