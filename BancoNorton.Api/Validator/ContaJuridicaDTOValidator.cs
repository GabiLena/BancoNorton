using BancoNorton.Api.DTO;
using FluentValidation;

namespace BancoNorton.Api.Validator;
public class ContaJuridicaDTOValidator : AbstractValidator<ContaJuridicaDTO>
{
    public ContaJuridicaDTOValidator()
    {
        RuleFor(dto => dto.Cnpj).IsValidCNPJ();
    }
}
