using AutoMapper;
using Open.Web.Tech.Contacts.Api.Data.Models;
using Open.Web.Tech.Contacts.Api.Interfaces.Dtos;

namespace Open.Web.Tech.Contacts.Api.Mappers
{
    /// <summary>
    /// 
    /// </summary>
    public class SkillDtoMapping : Profile
    {
        /// <summary>
        /// Constructeur : ContactDtoMapping
        /// </summary>
        public SkillDtoMapping()
        {
            CreateMap<Skill, SkillDto>()
                .ForMember(dto => dto.UidSkill, map => map.MapFrom(source => source.Uid));
        }
    }
}
