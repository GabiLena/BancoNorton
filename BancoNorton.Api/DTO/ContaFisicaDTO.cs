using System.ComponentModel.DataAnnotations;

namespace BancoNorton.Api.DTO;

public class ContaFisicaDTO
{
    public int Id { get; set; }
    public string? NumeroConta { get; set; }

    [Required(ErrorMessage = "O valor de saldo é obrigatório.")]
    public int Saldo { get; set; }
}
