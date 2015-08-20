using System.Collections.Generic;
using API.Models.Dtos;

namespace API.Services
{
	public interface ITagService
	{
		List<TagDto> GetAllTags();
		TagDto GetTag(int id);
		TagDto AddTag(string name);
		void DeleteTag(string name);
		void DeleteTag(int id);
	}
}