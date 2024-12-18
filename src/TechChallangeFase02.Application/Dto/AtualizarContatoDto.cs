using System.ComponentModel.DataAnnotations;

namespace TechChallangeFase02.Application.Dto;

public class AtualizarContatoDto
{
    [Required(ErrorMessage = "O nome é obrigatório.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O telefone é obrigatório.")]
    [RegularExpression(@"^\d{9,11}$", ErrorMessage = "O telefone deve ter entre 9 e 11 dígitos, sem formatação.")]
    public string Telefone { get; set; }

    [EmailAddress(ErrorMessage = "E-mail inválido.")]
    public string Email { get; set; }
}