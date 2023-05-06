using AutoMapper;
using LibrariesPr.Models;

namespace LibrariesPr.Services
{
    public interface ILibraryService
    {
        void Create(CreateLibraryDto dto);
        IEnumerable<LibraryDto> GetAll();
        LibraryDto GetById(int id, IMapper mapper);
    }
}