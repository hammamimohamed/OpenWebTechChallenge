using AutoMapper;
using Open.Web.Tech.Contacts.Api.Data.Models;
using Open.Web.Tech.Contacts.Api.Interfaces.Dtos;

namespace Open.Web.Tech.Contacts.Api.Mappers
{
    /// <summary>
    /// ContactDtoMapping
    /// </summary>
    public class ContactDtoMapping : Profile
    {
        /// <summary>
        /// Constructeur : ContactDtoMapping
        /// </summary>
        public ContactDtoMapping()
        {
            CreateMap<Contact, ContactDto>()
                .ForMember(dto => dto.UidContact, map => map.MapFrom(source => source.Uid))
                    .ForMember(dto => dto.Skills, map => map.MapFrom(source => source.SkillContact));
        }
    }
}
