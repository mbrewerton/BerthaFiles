using System.Collections.Generic;
using API.Models;
using API.Models.Dtos;

namespace API.Services
{
    public interface ISoundService
    {
        IEnumerable<SoundDto> GetAllSounds();
	    void AddCategoryToSound(int soundId, int categoryId);
	    void RemoveCategoryFromSound(int soundId, int categoryId);
	    void AddTagToSound(int soundId, int tagId);
	    void RemoveTagFromSound(int soundId, int tagId);
    }
}