using AutoMapper;
using BancoNorton.Api.DTO;
using BancoNorton.Api.Validator;
using BancoNorton.Domain.Model;
using BancoNorton.Domain.Repository;

namespace BancoNorton.Api.Service
{
    public class ContaService : IContaService
    {
        private readonly IContaFisicaRepository _fisicaRepository;
        private readonly IMapper _mapper;
        public ContaService(IMapper mapper, IContaFisicaRepository fisicaRepository)
        {
            _mapper = mapper;
            _fisicaRepository = fisicaRepository;
        }

        public async Task<string> GeraNumeroContaFisicaAsync(ContaFisicaDTO contaDTO)
        {
            int numeroContaInt = await ObterUltimoNumeroContaFisicaAsync();//obtem ultimo numero de conta criado

            var novaConta = _mapper.Map<ContaFisica>(contaDTO);// mapeia pra dto
            novaConta.NumeroConta = (numeroContaInt + 1).ToString("000000000");//cria novo numero
            novaConta.DataCriacao = new DateTimeOffset(DateTime.Now);
            return novaConta.NumeroConta;
        }
        private async Task<int> ObterUltimoNumeroContaFisicaAsync()
        {
            var numeroUltimaConta = await _fisicaRepository.ObterNumeroUltimaContaAsync();
            var numeroContaInt = int.Parse(numeroUltimaConta);
            return numeroContaInt;
        }
        public async Task<ContaFisica> RecuperaContaFisicaPorIdAsync(int id)
        {
            var conta = await _fisicaRepository.FindByIdAsync(id);
            if (conta == null)
                return null;
            return conta;
        }
        public async Task<bool> TranfereSaldoEntreContasAsync(TansferenciaDTO tansferenciaDTO)
        {
            var contaOrigem = await _fisicaRepository.FindByIdAsync(tansferenciaDTO.IdContaOrigem);
            if (contaOrigem == null)
                throw new Exception("Esta conta não existe.");

            if (contaOrigem.Saldo < tansferenciaDTO.Valor)
                throw new Exception("Saldo insuficiente para transferência.");
            contaOrigem.Saldo -= tansferenciaDTO.Valor;
            //contaOrigem.Saldo = contaOrigem.Saldo - valor;

            var contaOrigemAtualizada = await _fisicaRepository.UpdateAsync(contaOrigem);
            if (contaOrigemAtualizada is false)
                throw new Exception("Não foi possível realizar a transferência.");
            
                var contaDestino = await _fisicaRepository.FindByIdAsync(tansferenciaDTO.IdContaDestino);
                contaDestino.Saldo += tansferenciaDTO.Valor;
            var contaDestinoAtualizada = await _fisicaRepository.UpdateAsync(contaDestino);

            return contaDestinoAtualizada;
        }
    }

    public interface IContaService
    {
        Task<ContaFisica?> RecuperaContaFisicaPorIdAsync(int id);
        Task<string> GeraNumeroContaFisicaAsync(ContaFisicaDTO contaDTO);
        Task<bool> TranfereSaldoEntreContasAsync(TansferenciaDTO tansferenciaDTO);
    }
}
