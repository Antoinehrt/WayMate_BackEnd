using System.ComponentModel.DataAnnotations;

namespace Application.UseCases.Function.Dtos;

public class DtoInputCreateFunction
{
    [Required] public string title { get; set; }
}