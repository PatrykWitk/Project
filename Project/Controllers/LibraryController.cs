using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Entities;

namespace LibrariesPr.Controllers
{
    [Route("api/library")]
    public class LibraryController : ControllerBase
    {
        private readonly LibraryDbContext _dbContext;
        public LibraryController(LibraryDbContext dbContext) {
            _dbContext = dbContext;
        }
        public ActionResult<IEnumerable<Library>> GetAll()
        {
            var libraries = _dbContext
                .Libraries
                .ToList();

            return Ok(libraries);
        }
    }
}
