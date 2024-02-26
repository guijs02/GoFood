namespace GoFood.Client.Domain.Model
{
    public class UserInputModel
    {
        public string Endereco { get; set; }
        public int Radius { get; set; } = 500;
        public string QtdAvaliacoes { get; set; }
    }
}
