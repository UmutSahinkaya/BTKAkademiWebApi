using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace BTKAkademi.WebApi.Utilities.AutoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<BookDtoForUpdate,Book>().ReverseMap();
            CreateMap<Book,BookDto>().ReverseMap();
            CreateMap<BookDtoForInsertion, Book>().ReverseMap();
            CreateMap<UserForRegistrationDto, User>().ReverseMap();
        }
    }
}
