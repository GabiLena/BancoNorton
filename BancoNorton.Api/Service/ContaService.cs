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
        private readonly IContaJuridicaRepository _juridicaRepository;
        private readonly IContaFisicaRepository _fisicaRepository;
        private readonly IMapper _mapper;
        private readonly ContaJuridicaDTOValidator _juridicaValidator;
        private readonly ContaFisicaDTOValidator _fisicaValidator;
        public ContaService(IMapper mapper, IContaJuridicaRepository repository, ContaJuridicaDTOValidator validator, IContaFisicaRepository fisicaRepository, ContaFisicaDTOValidator fisicaValidator)
        {
            _mapper = mapper;
            _juridicaRepository = repository;
            _juridicaValidator = validator;
            _fisicaRepository = fisicaRepository;
            _fisicaValidator = fisicaValidator;
        }

        public async Task<bool> AdicionarContaJuridica(ContaJuridicaDTO contaDTO)
        {
            var result = _juridicaValidator.Validate(contaDTO);//valida CNPJ
            if (!result.IsValid)
                throw new Exception(string.Join(" | ", result.Errors.Select(x => x.ErrorMessage)));
            
            int numeroContaInt = await ObterUltimoNumeroContaJuridicaAsync();//obtem ultimo numero de conta criado

            var novaConta = _mapper.Map<ContaJuridica>(contaDTO);// mapeia pra dto
            novaConta.NumeroConta = (numeroContaInt + 1).ToString("000000000");//cria novo numero
            novaConta.DataCriacao = new DateTimeOffset(DateTime.Now);

            return await _juridicaRepository.AddAsync(novaConta);
        }

        public async Task<bool> AdicionarContaFisica(ContaFisicaDTO contaDTO)
        {
            var result = _fisicaValidator.Validate(contaDTO);//valida CPF
            if (!result.IsValid)
                throw new Exception(string.Join(" | ", result.Errors.Select(x => x.ErrorMessage)));

            int numeroContaInt = await ObterUltimoNumeroContaFisicaAsync();//obtem ultimo numero de conta criado

            var novaConta = _mapper.Map<ContaFisica>(contaDTO);// mapeia pra dto
            novaConta.NumeroConta = (numeroContaInt + 1).ToString("000000000");//cria novo numero
            novaConta.DataCriacao = new DateTimeOffset(DateTime.Now);

            return await _fisicaRepository.AddAsync(novaConta);
        }

        private async Task<int> ObterUltimoNumeroContaFisicaAsync()
        {
            var numeroUltimaConta = await _fisicaRepository.ObterNumeroUltimaContaAsync();
            var numeroContaInt = int.Parse(numeroUltimaConta);
            return numeroContaInt;
        }

        private async Task<int> ObterUltimoNumeroContaJuridicaAsync()
        {
            var numeroUltimaConta = await _juridicaRepository.ObterNumeroUltimaContaAsync();
            var numeroContaInt = int.Parse(numeroUltimaConta);
            return numeroContaInt;
        }

        public async Task<ContaFisica?> RecuperaContaFisicaPorId(int id)
        {
            var conta = await _fisicaRepository.FindByIdAsync(id);
            return conta;
        }

        public async Task<ContaJuridica?> RecuperaContaJuridicaPorId(int id)
        {
            var conta = await _juridicaRepository.FindByIdAsync(id);
            return conta;
        }

    }

    public interface IContaService
    {
        Task<bool> AdicionarContaJuridica(ContaJuridicaDTO contaDTO);
        Task<bool> AdicionarContaFisica(ContaFisicaDTO contaDTO);
        Task<ContaFisica?> RecuperaContaFisicaPorId(int id);
        Task<ContaJuridica?> RecuperaContaJuridicaPorId(int id);
    }
}
