using AutoMapper;
using LibrariesPr.Models;
using LibrariesPr.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Entities;

namespace LibrariesPr.Controllers
{
    [Route("api/library")]
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryService _libraryService;

        public LibraryController(ILibraryService libraryService) {
            _libraryService = libraryService;
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody]UpdateLibraryDto dto, [FromRoute]int id) { 
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isUpdated = _libraryService.Update(id, dto);

            if (!isUpdated)
            {
                return NotFound();
            }

            return Ok();

        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        { 
            var isDeleted = _libraryService.Delete(id);

            if(isDeleted)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult CreateLibrary([FromBody]CreateLibraryDto dto)
        {
            if(!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var id = _libraryService.Create(dto);

       

            return Created($"/api/resturant/{id}", null);
        }

        [HttpGet]
        public ActionResult<IEnumerable<LibraryDto>> GetAll()
        {
            var librariesDtos = _libraryService.GetAll();

            return Ok(librariesDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<LibraryDto> Get(int id)
        {
            var libraryDto = _libraryService.GetById(id);

            if(libraryDto == null)
            {
                return NotFound();
            }


            return Ok(libraryDto);
        }
    }
}
