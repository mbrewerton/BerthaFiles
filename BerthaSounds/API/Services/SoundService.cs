﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Models;
using API.Models.DbContexts;
using API.Models.Dtos;
using API.Repositories;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace API.Services
{
    public class SoundService : ISoundService
    {
        private readonly IRepository<Sound> _soundRepository;
	    private readonly IRepository<Category> _categoryRepository;
	    private readonly IUnitOfWork _unitOfWork;
        private readonly IMappingEngine _mapper;

        public SoundService(IRepository<Sound> soundRepository, IRepository<Category> categoryRepository, IUnitOfWork unitOfWork, IMappingEngine mapper)
        {
            _soundRepository = soundRepository;
	        _categoryRepository = categoryRepository;
	        _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<SoundDto> GetAllSounds()
        {
	        var sounds = _soundRepository.GetAll()
				.Include(x => x.Categories)
				.Include(x => x.Tags);

            if (sounds.Any())
            {
                return _mapper.Map<List<Sound>, List<SoundDto>>(_soundRepository.GetAll().ToList());
            }

            return null;
        }

	    public void AddCategoryToSound(SoundDto soundDto, CategoryDto categoryDto)
	    {
		    var sound = _soundRepository.GetById(soundDto.Id);
		    if (sound == null)
			    throw new NullReferenceException(string.Format("Cannot find a Category with the id: {0}", soundDto.Id));

		    var category = _categoryRepository.GetById(categoryDto.Id);
			if (category == null)
				throw new NullReferenceException(string.Format("Cannot find a Category with the id: {0}", categoryDto.Id));

			sound.Categories.Add(category);
			_unitOfWork.Commit();
	    }

        public void UploadSound(List<SoundDto> sound)
        {
            
        }
    }
}
