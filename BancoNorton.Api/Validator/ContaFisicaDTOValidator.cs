using BancoNorton.Api.DTO;
using FluentValidation;

namespace BancoNorton.Api.Validator
{
    public class ContaFisicaDTOValidator : AbstractValidator<ContaFisicaDTO>
    {
        public ContaFisicaDTOValidator()
        {
            RuleFor(dto => dto.Cpf).IsValidCPF();
        }
    }
}
