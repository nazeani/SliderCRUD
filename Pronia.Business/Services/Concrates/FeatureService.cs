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
    public class FeatureService : IFeatureService
    {
        IFeatureRepository _featureRepository;
        public FeatureService(IFeatureRepository FeatureRepository)
        {
            _featureRepository = FeatureRepository;
        }
        public void AddF(Feature feature)
        {
            _featureRepository.Add(feature);
            _featureRepository.Commit();
        }

        public void DeleteF(int id)
        {
            var aa = _featureRepository.Get(p => p.Id == id);
            _featureRepository.Delete(aa);
            _featureRepository.Commit();
        }

        public Feature Get(Func<Feature, bool> func = null)
        {
            return _featureRepository.Get(func);

        }

        public List<Feature> GetAll(Func<Feature, bool> func = null)
        {
            return _featureRepository.GetAll(func);
        }

        public void UpdateF(int? id, Feature feature)
        {
            if (id != null)
            {
                var aa = _featureRepository.Get(p => p.Id == id);
                aa.Id = feature.Id;
                aa.Icon = feature.Icon;
                aa.Title = feature.Title;
                aa.Description = feature.Description;
                _featureRepository.Commit();
            }
        }
    }
}
