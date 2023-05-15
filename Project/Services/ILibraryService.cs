using AutoMapper;
using LibrariesPr.Models;

namespace LibrariesPr.Services
{
    public interface ILibraryService
    {
        int Create(CreateLibraryDto dto);
        IEnumerable<LibraryDto> GetAll();
        LibraryDto GetById(int id);

        bool Delete(int id);
        public bool Update(int id, UpdateLibraryDto dto);
    }
}