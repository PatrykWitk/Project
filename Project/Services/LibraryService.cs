using AutoMapper;
using LibrariesPr.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Entities;

namespace LibrariesPr.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly LibraryDbContext _dbContext;
        private readonly IMapper _mapper;

        public LibraryService(LibraryDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public LibraryDto GetById(int id, IMapper mapper)
        {
            var library = _dbContext
                .Libraries
                .Include(r => r.Address)
                .Include(r => r.Books)
                .FirstOrDefault(x => x.Id == id);

            var result = _mapper.Map<LibraryDto>(library);

            if (library is null) return null;

            return result;
        }

        public IEnumerable<LibraryDto> GetAll()
        {
            var libraries = _dbContext
                .Libraries
                .Include(r => r.Address)
                .Include(r => r.Books)
                .ToList();

            var librariesDtos = _mapper.Map<List<LibraryDto>>(libraries);

            return librariesDtos;
        }

        public void Create(CreateLibraryDto dto)
        {
            var library = _mapper.Map<Library>(dto);
            _dbContext.Libraries.Add(library);
            _dbContext.SaveChanges();
        }
    }
}
