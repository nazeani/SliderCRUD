using Microsoft.EntityFrameworkCore.ChangeTracking;
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
    public class CategoryService : ICategoryService
    {
        ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        void ICategoryService.Add(Category category)
        {
            if (!_categoryRepository.GetAll().Any(a => a.Name == category.Name))
            {
                _categoryRepository.Add(category);
            }
            else { throw new Exception(); }
            _categoryRepository.Commit();
        }

        void ICategoryService.Delete(int id)
        {
            var aa= _categoryRepository.Get(p=>p.Id==id);
            _categoryRepository.Delete(aa);
            _categoryRepository.Commit();
        }

        Category ICategoryService.Get(Func<Category, bool> func)
        {
            return _categoryRepository.Get(func);
        }

        List<Category> ICategoryService.GetAll(Func<Category, bool> func)
        {
           return _categoryRepository.GetAll(func);
        }

        void ICategoryService.Update(int? id, Category category)
        {
            if (id != null)
            {
                var aa = _categoryRepository.Get(p => p.Id == id);
                if (!_categoryRepository.GetAll().Any(a => a.Name == category.Name))
                {

                    aa.Name = category.Name;
                    aa.Id = category.Id;
                    _categoryRepository.Commit();

                }
            }
           
        }
    }
}
