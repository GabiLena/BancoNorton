﻿using BancoNorton.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoNorton.DAL.Repositories
{
    public class ContaJuridicaRepository : Repository<ContaJuridica>, IContaJuridicaRepository
    {
        private readonly AppDbContext _context;

        public ContaJuridicaRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<string> ObterNumeroUltimaContaAsync()
        {
            var conta = await _context.ContasJuridicas.OrderByDescending(c => c.DataCriacao).FirstOrDefaultAsync();
            return conta.NumeroConta;
        }
    }
    public interface IContaJuridicaRepository : IRepository<ContaJuridica>
    {
        Task<string> ObterNumeroUltimaContaAsync();
    }
}
