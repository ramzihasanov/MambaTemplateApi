using Mamba.Core.Repositories.Interfaces;
using Mamba.DAL;
using Mamba.Entites;

namespace Mamba.Data.Repositories.Implementations
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbConrtext appDb) : base(appDb)
        {
        }
    }
}
