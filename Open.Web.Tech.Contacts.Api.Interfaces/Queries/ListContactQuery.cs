using MediatR;
using Open.Web.Tech.Contacts.Api.Interfaces.Dtos;
using System.Collections.Generic;

namespace Open.Web.Tech.Contacts.Api.Interfaces.Queries
{
    /// <summary>
    /// ListContactQuery
    /// </summary>
    public class ListContactQuery : IRequest<IReadOnlyList<ContactDto>>
    {
    }
}
