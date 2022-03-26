using MediatR;
using Open.Web.Tech.Contacts.Api.Interfaces.Dtos;
using System;

namespace Open.Web.Tech.Contacts.Api.Interfaces.Queries
{
    /// <summary>
    /// 
    /// </summary>
    public class GetSkillQuery : IRequest<SkillDto>
    {
        /// <summary>
        /// Uid
        /// </summary>
        public Guid Uid { get; set; }
    }
}
