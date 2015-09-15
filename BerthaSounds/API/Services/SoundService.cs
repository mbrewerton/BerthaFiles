using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Exceptions;
using API.Models;
using API.Models.DbContexts;
using API.Models.Dtos;
using API.Repositories;
using API.Services.Storage;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace API.Services
{
    public class SoundService : ISoundService
    {
        private readonly IRepository<Sound> _soundRepository;
	    private readonly IRepository<Category> _categoryRepository;
	    private readonly IRepository<Tag> _tagRepository;
	    private readonly IUnitOfWork _unitOfWork;
        private readonly IMappingEngine _mapper;

	    public SoundService(IRepository<Sound> soundRepository, 
							IRepository<Category> categoryRepository, 
							IRepository<Tag> tagRepository,
							IUnitOfWork unitOfWork, IMappingEngine mapper)
        {
            _soundRepository = soundRepository;
	        _categoryRepository = categoryRepository;
	        _tagRepository = tagRepository;
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

	    public void AddCategoryToSound(int soundId, int categoryId)
	    {
		    var sound = _soundRepository.GetById(soundId);
		    if (sound == null)
			    throw new NullReferenceException(string.Format("Cannot find a Sound with the id: {0}", soundId));

		    var category = _categoryRepository.GetById(categoryId);
		    if (category == null)
			    throw new NullReferenceException(string.Format("Cannot find a Category with the id: {0}", categoryId));

			if (sound.Categories.Contains(category))
				throw new DuplicateItemException(string.Format("{0} is already assigned to {1}.", category.Name, sound.Name));

		    sound.Categories.Add(category);
		    _unitOfWork.Commit();
	    }

	    public void RemoveCategoryFromSound(int soundId, int categoryId)
	    {
			var sound = _soundRepository.GetById(soundId);
			if (sound == null)
				throw new NullReferenceException(string.Format("Cannot find a Sound with the id: {0}", soundId));

			var category = _categoryRepository.GetById(categoryId);
			if (category == null)
				throw new NullReferenceException(string.Format("Cannot find a Category with the id: {0}", categoryId));

			sound.Categories.Remove(category);
			_unitOfWork.Commit();
	    }

	    public void AddTagToSound(int soundId, int tagId)
	    {
		    var sound = _soundRepository.GetById(soundId);
		    if (sound == null)
			    throw new NullReferenceException(string.Format("Cannot find a Sound with the id: {0}", soundId));

		    var tag = _tagRepository.GetById(tagId);
		    if (tag == null)
			    throw new NullReferenceException(string.Format("Cannot find a Tag with the id: {0}", tagId));

		    sound.Tags.Add(tag);
		    _unitOfWork.Commit();
	    }

	    public void RemoveTagFromSound(int soundId, int tagId)
	    {
			var sound = _soundRepository.GetById(soundId);
			if (sound == null)
				throw new NullReferenceException(string.Format("Cannot find a Sound with the id: {0}", soundId));

			var tag = _tagRepository.GetById(tagId);
			if (tag == null)
				throw new NullReferenceException(string.Format("Cannot find a Tag with the id: {0}", tagId));

			sound.Tags.Remove(tag);
			_unitOfWork.Commit();
	    }
    }
}
