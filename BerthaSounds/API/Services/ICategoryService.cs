using System.Collections.Generic;
using API.Models.Dtos;

namespace API.Services
{
	public interface ICategoryService
	{
		List<CategoryDto> GetAllCategories();
		CategoryDto GetCategory(int id);
		CategoryDto AddCategory(string name, string description);
		void DeleteCategory(string name);
	}
}