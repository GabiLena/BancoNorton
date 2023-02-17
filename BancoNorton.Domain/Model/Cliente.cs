using System.ComponentModel.DataAnnotations;

namespace BancoNorton.Domain.Model;
public class Cliente
{
    public Cliente()
    {

    }

    public Cliente(string cpf, string nome)
    {
        Cpf = cpf;
        Nome = nome;
    }

    [Required]
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "O cpf é obrigatório.")]
    public string Cpf { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório.")]
    [MaxLength(50, ErrorMessage = "O nome não pode exceder 50 caracteres.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "A Idade é obrigatória.")]
    [Range(18, 90, ErrorMessage = "A Idade deve ser entre 18 à 90 anos.")]
    public int Idade { get; set; }

    public List<ContaFisica> ContasFisicas { get; set; } = new();
}
