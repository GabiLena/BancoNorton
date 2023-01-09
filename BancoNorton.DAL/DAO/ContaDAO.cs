using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoNorton.DAL.DAO
{
    public class ContaDAO
    {
        [Required(ErrorMessage = "O número de conta é obrigatório.")]
        public int NumeroConta { get; set; }

        [Required(ErrorMessage = "O valor de saldo é obrigatório.")]
        public int Saldo { get; set; }
    }
}
