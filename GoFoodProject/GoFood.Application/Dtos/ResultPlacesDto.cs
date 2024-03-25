using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFood.Application.Dtos
{
    public record class ResultPlacesDto(string Name,
                                        string Vicinity, 
                                        string Icon, 
                                        double Rating, 
                                        bool IsOpen, 
                                        List<Photo> Photos,
                                        string? PhotoReference)
    {
        public Dictionary<string, string> DictionaryFotos { get; set; } = new();
    }
}
