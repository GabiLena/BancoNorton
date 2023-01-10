using BancoNorton.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoNorton.Api.DTO;

public class ContaDTO
{
    [Required(ErrorMessage = "O número de conta é obrigatório.")]
    public int NumeroConta { get; set; }

    [Required(ErrorMessage = "O valor de saldo é obrigatório.")]
    public int Saldo { get; set; }
    public Cliente? Cliente { get; set; }// para criar uma conta, por id de cliente já existente
}
