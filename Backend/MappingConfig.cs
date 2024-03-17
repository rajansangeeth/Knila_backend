using AutoMapper;
using Backend.Models;
using Backend.Models.DTO;

namespace Backend
{
    public class MappingConfig: Profile
    {
        public MappingConfig()
        {
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<ContactDto, CreateContactDto>().ReverseMap();
            CreateMap<UpdateContactDto, ContactDto>().ReverseMap();
            CreateMap<Contact, CreateContactDto>().ReverseMap();
            CreateMap<Contact, UpdateContactDto>().ReverseMap();
            CreateMap<Contact, ContactDto>().ReverseMap();
        }
    }
}
