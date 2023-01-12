using AutoMapper;
using BancoNorton.Api.DTO;
using BancoNorton.Api.Validator;
using BancoNorton.DAL;
using BancoNorton.DAL.Repositories;
using BancoNorton.Domain.Model;

namespace BancoNorton.Api.Service
{
    public class ContaService : IContaService
    {
        private readonly IContaRepository _repository;
        private readonly IMapper _mapper;
        private readonly ContaJuridicaDTOValidator _validator;
        public ContaService(IMapper mapper, IContaRepository repository, ContaJuridicaDTOValidator validator)
        {
            _mapper = mapper;
            _repository = repository;
            _validator = validator;
        }

        public async Task<bool> AdicionarContaJuridica(ContaJuridicaDTO contaDTO)
        {
            var result = _validator.Validate(contaDTO);//valida CNPJ
            if (!result.IsValid)
                throw new Exception(string.Join(" | ", result.Errors.Select(x => x.ErrorMessage)));
            
            int numeroContaInt = await ObterUltimoNumeroContaAsync();//obtem ultimo numero de conta criado

            var novaConta = _mapper.Map<ContaJuridica>(contaDTO);// mapeia pra dto
            novaConta.NumeroConta = (numeroContaInt + 1).ToString("000000000");//cria novo numero
            novaConta.DataCriacao = new DateTimeOffset(DateTime.Now);

            return await _repository.AddAsync(novaConta);
        }

        private async Task<int> ObterUltimoNumeroContaAsync()
        {
            var numeroUltimaConta = await _repository.ObterNumeroUltimaContaAsync();
            var numeroContaInt = int.Parse(numeroUltimaConta);
            return numeroContaInt;
        }
    }

    public interface IContaService
    {
        Task<bool> AdicionarContaJuridica(ContaJuridicaDTO contaDTO);
    }
}
