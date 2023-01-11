using BancoNorton.Domain.Model;
using System.ComponentModel.DataAnnotations;

namespace BancoNorton.Api.DTO;

public class ContaJuridicaDTO
{
    [Required(ErrorMessage = "O número de conta é obrigatório.")]
    public int NumeroConta { get; set; }

    [Required(ErrorMessage = "O valor de saldo é obrigatório.")]
    public int Saldo { get; set; }

    [Required(ErrorMessage = "O CNPJ é obrigatório.")]
    public string Cnpj { get; set; }
}
