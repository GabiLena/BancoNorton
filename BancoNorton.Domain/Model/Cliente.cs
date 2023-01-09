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
        //ContaId = contaId;
    }

    [Required]
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "O CPF é obrigatório.")]
    [Range(11, 11, ErrorMessage = "São necessários 11 caracteres para o Cpf.")]
    public string Cpf { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório.")]
    [MaxLength(50, ErrorMessage = "O nome não pode exceder 50 caracteres.")]
    public string Nome { get; set; }

    public int ContaId { get; set; }
    public Conta? Conta { get; set; }
}
