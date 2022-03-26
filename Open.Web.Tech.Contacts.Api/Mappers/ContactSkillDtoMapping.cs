using AutoMapper;
using Open.Web.Tech.Contacts.Api.Data.Models;
using Open.Web.Tech.Contacts.Api.Interfaces.Dtos;


namespace Open.Web.Tech.Contacts.Api.Mappers
{
    /// <summary>
    /// 
    /// </summary>
    public class ContactSkillDtoMapping : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public ContactSkillDtoMapping()
        {
            CreateMap<ContactSkill, ContactSkillDto>()
               .ForMember(dto => dto.Name, map => map.MapFrom(source => source.Skill.Name))
               .ForMember(dto => dto.Level, map => map.MapFrom(source => source.Level));
        }
    }
}
