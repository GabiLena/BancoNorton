using AutoMapper;
using BancoNorton.Api.DTO;
using BancoNorton.Domain.Model;

namespace BancoNorton.Api.Profiles
{
    public class ContaFisicaProfile : Profile
    {
        public ContaFisicaProfile()
        {
            CreateMap<ContaFisicaDTO, ContaFisica>();
        }
    }
}
