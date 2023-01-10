using System.ComponentModel.DataAnnotations;

namespace BancoNorton.Domain.Model;
public class Conta
{
    public Conta()
    {

    }

    public Conta(int numeroConta, int saldo, int clienteId)
    {
        NumeroConta = numeroConta;
        Saldo = saldo;
        ClienteId = clienteId;
    }

    [Required]
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "O número de conta é obrigatório.")]
    public int NumeroConta { get; set; }

    [Required(ErrorMessage = "O valor de saldo é obrigatório.")]
    public int Saldo { get; set; }

    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; }
}
