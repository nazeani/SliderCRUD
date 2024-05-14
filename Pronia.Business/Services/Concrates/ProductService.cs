using Pronia.Business.Services.Abstracts;
using Pronia.Core.Models;
using Pronia.Core.RepositoryAbstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pronia.Business.Services.Concrates
{
    public class ProductService : IProductService
    {
        IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public void Add(Product product)
        {
            _productRepository.Add(product);
        }

        public void Delete(int id)
        {
            var aa = _productRepository.Get(p => p.Id == id);
            _productRepository.Delete(aa);
        }

        public Product Get(Func<Product, bool> func = null)
        {
            return _productRepository.Get(func);
        }

        public List<Product> GetAll(Func<Product, bool> func = null)
        {
            return _productRepository.GetAll(func);
        }

        public void Update(int id, Product product)
        {
            var aa = _productRepository.Get(p => p.Id == id);
                aa.Name = product.Name;
                aa.Id = product.Id;
            aa.Description = product.Description;
            aa.Category = product.Category;
            aa.CategoryId = product.CategoryId;
            aa.Tag = product.Tag;
            aa.Price = product.Price;

            
        }
    }
}
