using BancoNorton.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoNorton.Api.DTO;

public class ClienteDTO
{
    [Required(ErrorMessage = "O CPF é obrigatório.")]
    [Range(11, 11, ErrorMessage = "São necessários 11 caracteres para o Cpf.")]
    public string Cpf { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório.")]
    [MaxLength(50, ErrorMessage = "O nome não pode exceder 50 caracteres.")]
    public string Nome { get; set; }
    public ContaDTO Conta { get; set; }// para criar um cliente, uma conta sera criada juntamente
}
