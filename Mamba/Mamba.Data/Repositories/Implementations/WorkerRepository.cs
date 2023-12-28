using Mamba.Core.Repositories.Interfaces;
using Mamba.DAL;
using Mamba.Entites;

namespace Mamba.Data.Repositories.Implementations
{
    public class WorkerRepository : GenericRepository<Worker>, IWorkerRepository
    {
        public WorkerRepository(AppDbConrtext appDb) : base(appDb)
        {
        }
    }
}
