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
	public class CategoryService : ICategoryService
	{
		private readonly IRepository<Category> _categoryRepository;
		private readonly IUnitOfWork _unitOfWork;

		public CategoryService(IRepository<Category> categoryRepository, IUnitOfWork unitOfWork)
		{
			_categoryRepository = categoryRepository;
			_unitOfWork = unitOfWork;
		}

		public List<CategoryDto> GetAllCategories()
		{
			var categories = _categoryRepository.GetAll().ToList();
			var dtos = Mapper.Map<List<Category>, List<CategoryDto>>(categories);
			return dtos;
		}

		public CategoryDto GetCategory(int id)
		{
			var category = Mapper.Map<Category, CategoryDto>(_categoryRepository.GetFirstWhere(x => x.Id == id));
			return category;
		}

		public CategoryDto AddCategory(string name, string description)
		{
			var found = _categoryRepository.GetSingleOrDefaultWhere(x => x.Name == name);
			if (found != null)
			{
				if (found.Name == name)
					throw new NullReferenceException("A category with that name already exists.");
			}
				
			var newCategory = new Category
			{
				Name = name,
				Description = description
			};
			_categoryRepository.Add(newCategory);
			_unitOfWork.Commit();

			return Mapper.Map<Category, CategoryDto>(newCategory);
		}

		public void DeleteCategory(string name)
		{
			var category = _categoryRepository.GetSingleOrDefaultWhere(x => x.Name == name);
			if (category == null)
				throw new NullReferenceException("A category by that name name does not exist.");

			_categoryRepository.Delete(category);
			_unitOfWork.Commit();
		}

		public void DeleteCategory(int id)
		{
			var category = _categoryRepository.GetById(id);
			if (category == null)
				throw new NullReferenceException(string.Format("A Category with id '{0}' does not exist.", id));

			_categoryRepository.Delete(category);
			_unitOfWork.Commit();
		}
	}
}
