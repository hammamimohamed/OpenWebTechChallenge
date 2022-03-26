using MediatR;
using Open.Web.Tech.Contacts.Api.Interfaces.Dtos;
using System;

namespace Open.Web.Tech.Contacts.Api.Interfaces.Queries
{
    /// <summary>
    /// GetContactQuery
    /// </summary>
    public class GetContactQuery : IRequest<ContactDto>
    {
        /// <summary>
        /// Uid
        /// </summary>
        public Guid Uid { get; set; }
    }
}
