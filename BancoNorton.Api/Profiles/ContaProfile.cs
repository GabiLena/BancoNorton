using AutoMapper;
using BancoNorton.Api.DTO;
using BancoNorton.Domain.Model;

namespace BancoNorton.Api.Profiles
{
    public class ContaProfile : Profile
    {
        public ContaProfile()
        {
            CreateMap<ContaJuridicaDTO, Conta>();
        }
    }
}
