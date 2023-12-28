using AutoMapper.Execution;
using Mamba.Core.Repositories.Interfaces;
using Mamba.DAL;
using Mamba.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mamba.Data.Repositories.Implementations
{
    public class PositionRepository : GenericRepository<Position>, IPositionRepository
    {
        public PositionRepository(AppDbConrtext appDb) : base(appDb)
        {
        }
    }
}
