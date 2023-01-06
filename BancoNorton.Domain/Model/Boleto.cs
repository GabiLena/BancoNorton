using System.ComponentModel.DataAnnotations;

namespace BancoNorton.Domain.Model;
public class Boleto
{
    public Boleto()
    {

    }

    public Boleto(string codigoBarras, int valor, string cpfDevedor)
    {
        CodigoBarras = codigoBarras;
        Valor = valor;
        CpfDevedor = cpfDevedor;
    }

    [Required]
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "O código de barras é obrigatório.")]
    [Range(10, 10, ErrorMessage = "São necessários 10 caracteres para preencher o Código de Barras.")]
    public string CodigoBarras { get; set; }

    [Required(ErrorMessage = "O valor é obrigatório.")]
    [Range(1, 10000, ErrorMessage = "Preencha valor entre no mínimo 1,00 R$ e no máximo 10.000,00 R$.")]
    public int Valor { get; set; }

    [Required(ErrorMessage = "O CPF de Devedor é obrigatório.")]
    [Range(11, 11, ErrorMessage = "São necessários 11 caracteres para preencher cpf.")]
    public string CpfDevedor { get; set; }
}
