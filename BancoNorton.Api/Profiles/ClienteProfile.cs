using AutoMapper;
using BancoNorton.Api.DTO;
using BancoNorton.Domain.Model;

namespace BancoNorton.Api.Profiles
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<ClienteDTO, Cliente>();
        }
    }
}
