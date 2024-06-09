using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GoFood.Application.InputModels
{
    public class UserInputModel
    {
        [Required(ErrorMessage = "Insira o endereço!")]
        public string Endereco { get; set; }
        public int Radius { get; set; } = 500;
        public bool IsOpen { get; set; }
        public int QtdAvaliacoes { get; set; }
    }
}
