using Microsoft.EntityFrameworkCore.ChangeTracking;
using Pronia.Core.Models;
using Pronia.Core.RepositoryAbstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pronia.Business.Services.Abstracts
{
    public interface IProductService
    {
        void Add(Product product);
        void Delete(int id);
        void Update(int id,Product product);
        Product Get(Func<Product,bool> func=null);
        List<Product> GetAll(Func<Product, bool> func = null);
        
       
    }
}
