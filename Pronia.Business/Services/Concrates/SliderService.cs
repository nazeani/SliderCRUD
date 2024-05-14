using Microsoft.AspNetCore.Hosting;
using Pronia.Business.Exceptions;
using Pronia.Business.Extensions;
using Pronia.Business.Services.Abstracts;
using Pronia.Core.Models;
using Pronia.Core.RepositoryAbstracts;
using Pronia.Data.Migrations;
using Pronia.Data.RepositoryConcrates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pronia.Business.Services.Concrates
{
    public class SliderService : ISliderService
    {
        private readonly ISliderRepository _sliderRepository;
        private readonly IWebHostEnvironment _env;


        public SliderService(ISliderRepository sliderRepository, IWebHostEnvironment env)
        {
            _sliderRepository=sliderRepository;
            _env = env;
        }

        public void Add(Slider slider)
        {
            slider.ImageUrl = Helper.SaveFile(_env.WebRootPath, "uploads/sliders", slider.ImageFile);
                _sliderRepository.Add(slider);
                _sliderRepository.Commit();
        }

        public void Delete(int id)
        {
            var existSlider=_sliderRepository.Get(x=>x.Id == id);
            if (existSlider == null) throw new EntityNotFoundException("Slider tapilmadi");
            Helper.DeleteFile(_env.WebRootPath, "uploads/sliders", existSlider.ImageUrl); ;
            _sliderRepository.Delete(existSlider);
            _sliderRepository.Commit() ;
        }

        public Slider Get(Func<Slider, bool> func = null)
        {
            return _sliderRepository.Get(func);
        }

        public List<Slider> GetAll(Func<Slider, bool> func = null)
        {
            return _sliderRepository.GetAll(func);
        }

        public void Update(int? id, Slider slider)
        {
            var oldSlider = _sliderRepository.Get(x => x.Id == id);
            if (oldSlider == null) throw new EntityNotFoundException("Slider tapilmadi");
            if (slider.ImageUrl != null)
            {
                Helper.DeleteFile(_env.WebRootPath, "uploads/sliders",oldSlider.ImageUrl);
                oldSlider.ImageUrl = Helper.SaveFile(_env.WebRootPath, "uploads/sliders",slider.ImageFile);
            }
            oldSlider.Title = slider.Title;
            oldSlider.Percent = slider.Percent;
            oldSlider.RedirectUrl = slider.RedirectUrl;
            oldSlider.Description = slider.Description;

            //42ci deqiqeupdatein postunu falanda yaart
            //_sliderRepository.Commit();

        }
    }
}
