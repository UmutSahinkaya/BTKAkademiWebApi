using AutoMapper;
using Entities.DataTransferObject;
using Entities.Models;

namespace BTKAkademi.WebApi.Utilities.AutoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<BookDtoForUpdate,Book>().ReverseMap(); BookDtoForInsertion
            CreateMap<BookDto,Book>().ReverseMap();
            CreateMap<BookDtoForInsertion, Book>().ReverseMap();
        }
    }
}
