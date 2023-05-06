using AutoMapper;
using LibrariesPr.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Entities;

namespace LibrariesPr.Controllers
{
    [Route("api/library")]
    public class LibraryController : ControllerBase
    {
        private readonly LibraryDbContext _dbContext;
        private readonly IMapper _mapper;
        public LibraryController(LibraryDbContext dbContext, IMapper mapper) {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateLibrary([FromBody]CreateLibraryDto dto)
        {
            var library = _mapper.Map<Library>(dto);
            _dbContext.Libraries.Add(library);
            _dbContext.SaveChanges();

            return Created($"/api/resturant/{library.Id}", null);
        }

        [HttpGet]
        public ActionResult<IEnumerable<LibraryDto>> GetAll()
        {
            var libraries = _dbContext
                .Libraries
                .Include(r => r.Address) 
                .Include(r => r.Books)
                .ToList();

            var librariesDtos = _mapper.Map<List<LibraryDto>>(libraries);

            return Ok(librariesDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<LibraryDto> Get(int id)
        {
            var library = _dbContext
                .Libraries
                .FirstOrDefault(x => x.Id == id);

            var libraryDto = _mapper.Map<LibraryDto>(library);

            return Ok(libraryDto);
        }
    }
}
