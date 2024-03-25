using System.ComponentModel;

namespace GoFood.Domain.InputModels
{
    public class UserInputModel
    {
        public string Endereco { get; set; }
        public int Radius { get; set; } = 500;
        public bool IsOpen { get; set; }
        public int QtdAvaliacoes { get; set; }
    }
}
