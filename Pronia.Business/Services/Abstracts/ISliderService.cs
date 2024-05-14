using Pronia.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pronia.Business.Services.Abstracts
{
    public interface ISliderService
    {
        void Add(Slider slidery);
        void Delete(int id);
        void Update(int? id, Slider slider);
        Slider Get(Func<Slider, bool> func = null);
        List<Slider> GetAll(Func<Slider, bool> func = null);
    }
}
