using Pronia.Business.Services.Abstracts;
using Pronia.Core.Models;
using Pronia.Core.RepositoryAbstracts;
using Pronia.Data.RepositoryConcrates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pronia.Business.Services.Concrates
{
    public class TagService : ITagService
    {
        ITagRepository _tagRepository;
        public TagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }
        public void Add(Tag tag)
        {
            if (!_tagRepository.GetAll().Any(a => a.Name == tag.Name))
            {
                _tagRepository.Add(tag);
            }
            else { throw new Exception(); }
        }

        public void Delete(int id)
        {
            var aa = _tagRepository.Get(p => p.Id == id);
            _tagRepository.Delete(aa);
        }

        public Tag Get(Func<Tag, bool> func = null)
        {
            return _tagRepository.Get(func);
        }

        public List<Tag> GetAll(Func<Tag, bool> func = null)
        {
            return _tagRepository.GetAll(func);
        }

        public void Update(int id, Tag tag)
        {
            var aa = _tagRepository.Get(p => p.Id == id);
            if (!_tagRepository.GetAll().Any(a => a.Name == tag.Name))
            {
                aa.Name = tag.Name;
                aa.Id = tag.Id;
                aa.Product = tag.Product;
            }

        }
    }
}
