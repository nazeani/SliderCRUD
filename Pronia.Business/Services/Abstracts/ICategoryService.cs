using Pronia.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pronia.Business.Services.Abstracts
{
    public interface ICategoryService
    {
        void Add(Category category);
        void Delete(int id);
        void Update(int? id, Category category);
        Category Get(Func<Category, bool> func = null);
        List<Category> GetAll(Func<Category, bool> func = null);

    }
}
