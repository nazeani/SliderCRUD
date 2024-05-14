using Pronia.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pronia.Business.Services.Abstracts
{
    public interface ITagService
    {
        void Add(Tag tag);
        void Delete(int id);
        void Update(int id, Tag tag);
        Tag Get(Func<Tag, bool> func = null);
        List<Tag> GetAll(Func<Tag, bool> func = null);

    }
}
