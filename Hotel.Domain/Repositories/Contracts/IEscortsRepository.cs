using Hotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Repositories.Contracts
{
    public interface IEscortsRepository
    {
        Task CreateEscort(Escort escort);
    }
}
