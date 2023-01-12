using BancoNorton.Domain.Model;
using System.ComponentModel.DataAnnotations;

namespace BancoNorton.Api.DTO;

public class ContaJuridicaDTO
{
    public string? NumeroConta { get; set; }

    [Required(ErrorMessage = "O valor de saldo é obrigatório.")]
    public int Saldo { get; set; }

    [Required(ErrorMessage = "O CNPJ é obrigatório.")]
    public string Cnpj { get; set; }
    public int ClienteId { get; set; }
}
