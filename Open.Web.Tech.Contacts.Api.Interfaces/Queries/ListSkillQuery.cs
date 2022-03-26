using MediatR;
using Open.Web.Tech.Contacts.Api.Interfaces.Dtos;
using System.Collections.Generic;

namespace Open.Web.Tech.Contacts.Api.Interfaces.Queries
{
    /// <summary>
    /// ListSkillQuery
    /// </summary>
    public class ListSkillQuery : IRequest<IReadOnlyList<SkillDto>>
    {
    }
}
