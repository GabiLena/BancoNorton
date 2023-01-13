using AutoMapper;
using BancoNorton.Api.DTO;
using BancoNorton.Domain.Model;

namespace BancoNorton.Api.Profiles
{
    public class ContaJuridicaProfile : Profile
    {
        public ContaJuridicaProfile()
        {
            CreateMap<ContaJuridicaDTO, ContaJuridica>();
        }
    }
}
