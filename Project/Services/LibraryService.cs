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
        ILogger<LibraryService> _logger;

        public LibraryService(LibraryDbContext dbContext, IMapper mapper, ILogger<LibraryService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }
        public LibraryDto GetById(int id)
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

        public int Create(CreateLibraryDto dto)
        {
            var library = _mapper.Map<Library>(dto);
            _dbContext.Libraries.Add(library);
            _dbContext.SaveChanges();

            return library.Id;
        }

        public bool Delete(int id)
        {
            _logger.LogWarning($"Library with id: {id} DELETE action invoked");

            var library = _dbContext
            .Libraries
            .FirstOrDefault(x => x.Id == id);

            if (library is null) return false;

            _dbContext.Libraries.Remove(library);
            _dbContext.SaveChanges();

            return true;
        }
        public bool Update(int id, UpdateLibraryDto dto)
        {
            var library = _dbContext
                .Libraries
                .FirstOrDefault(x => x.Id == id);

            if (library is null) return false;

            library.Name = dto.Name;
            library.Description = dto.Description;
            _dbContext.Libraries.Update(library);
            _dbContext.SaveChanges();

            return true;
        }
    }
}
