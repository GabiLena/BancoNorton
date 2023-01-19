using BancoNorton.Api.DTO;
using FluentValidation;

namespace BancoNorton.Api.Validator
{
    public class ClienteDTOValidator : AbstractValidator<ClienteDTO>
    {
        public ClienteDTOValidator()
        {
            RuleFor(dto => dto.Cpf).IsValidCPF();
        }
    }
}
