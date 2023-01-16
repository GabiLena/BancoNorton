using BancoNorton.Domain.Model;
using System.ComponentModel.DataAnnotations;

namespace BancoNorton.Api.DTO;

public class ContaFisicaDTO
{
    public string? NumeroConta { get; set; }

    [Required(ErrorMessage = "O valor de saldo é obrigatório.")]
    public int Saldo { get; set; }

    [Required(ErrorMessage = "O CPF é obrigatório.")]
    public string Cpf { get; set; }
    public int ClienteId { get; set; }
}
