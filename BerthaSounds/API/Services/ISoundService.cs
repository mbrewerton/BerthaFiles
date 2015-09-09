using System.Collections.Generic;
using API.Models;
using API.Models.Dtos;

namespace API.Services
{
    public interface ISoundService
    {
        IEnumerable<SoundDto> GetAllSounds();
        void UploadSound(List<SoundDto> sound);
	    void AddCategoryToSound(int soundId, int categoryId);
	    void RemoveCategoryFromSound(int soundId, int categoryId);
    }
}