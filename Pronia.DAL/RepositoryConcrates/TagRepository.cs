using Pronia.Core.Models;
using Pronia.Core.RepositoryAbstracts;
using Pronia.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pronia.Data.RepositoryConcrates
{
    public class TagRepository : GenericRepository<Tag>, ITagRepository
    {
        public TagRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
