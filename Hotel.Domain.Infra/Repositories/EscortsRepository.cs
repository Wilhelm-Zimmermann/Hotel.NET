using Hotel.Domain.Entities;
using Hotel.Domain.Infra.Contexts;
using Hotel.Domain.Queries;
using Hotel.Domain.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Infra.Repositories
{
    public class EscortsRepository : IEscortsRepository
    {
        private readonly DatabaseContext _context;

        public EscortsRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task CreateEscort(Escort escort)
        {
            _context.Escorts.Add(escort);
            await _context.SaveChangesAsync();
        }
    }
}
