using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Models;
using API.Models.Dtos;
using API.Repositories;
using AutoMapper;

namespace API.Services
{
	public class TagService : ITagService
	{
		private readonly IRepository<Tag> _tagRepository;
		private readonly IUnitOfWork _unitOfWork;

		public TagService(IRepository<Tag> TagRepository, IUnitOfWork unitOfWork)
		{
			_tagRepository = TagRepository;
			_unitOfWork = unitOfWork;
		}

		public List<TagDto> GetAllTags()
		{
			var tags = _tagRepository.GetAll().ToList();
			var dtos = Mapper.Map<List<Tag>, List<TagDto>>(tags);
			return dtos;
		}

		public TagDto GetTag(int id)
		{
			var tag = Mapper.Map<Tag, TagDto>(_tagRepository.GetFirstWhere(x => x.Id == id));
			return tag;
		}

		public TagDto AddTag(string name)
		{
			var found = _tagRepository.GetSingleOrDefaultWhere(x => x.Name.ToLower() == name.ToLower());
			if (found != null)
			{
				throw new NullReferenceException("A Tag by that name already exists.");
			}
				
			var newTag = new Tag
			{
				Name = name
			};
			_tagRepository.Add(newTag);
			_unitOfWork.Commit();

			return Mapper.Map<Tag, TagDto>(newTag);
		}

		public void DeleteTag(string name)
		{
			var tag = _tagRepository.GetSingleOrDefaultWhere(x => x.Name.ToLower() == name.ToLower());
			if (tag == null)
				throw new NullReferenceException("A Tag by that name does not exist.");

			_tagRepository.Delete(tag);
			_unitOfWork.Commit();
		}
	}
}
