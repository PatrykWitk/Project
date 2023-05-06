using AutoMapper;
using LibrariesPr.Models;
using Project.Entities;

namespace LibrariesPr
{
    public class LibraryMappingProfile : Profile
    {
        public LibraryMappingProfile() 
        { 
            CreateMap<Library, LibraryDto>()
                .ForMember(m => m.City, c => c.MapFrom(s => s.Address.City))
                .ForMember(m => m.Street, c => c.MapFrom(s => s.Address.Street))
                .ForMember(m => m.PostalCode, c => c.MapFrom(s => s.Address.PostalCode));


            CreateMap<Book, BookDto>();

            CreateMap<CreateLibraryDto, Library>()
                 .ForMember(m => m.Address, c => c.MapFrom(dto => new Address() { City = dto.City, PostalCode = dto.PostalCode, Street = dto.Street }));
        }
    }
}
