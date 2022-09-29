using AutoMapper;
using BookCatalog.Dtos;
using BookCatalog.Models;

namespace BookCatalog.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDto>().ReverseMap();
        }
    }
}
