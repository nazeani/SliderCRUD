using Pronia.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pronia.Business.Services.Abstracts
{
    public interface IFeatureService
    {
        void AddF(Feature feature);
        void DeleteF(int id);
        void UpdateF(int? id, Feature feature);
        Feature Get(Func<Feature, bool> func = null);
        List<Feature> GetAll(Func<Feature, bool> func = null);
    }
}
