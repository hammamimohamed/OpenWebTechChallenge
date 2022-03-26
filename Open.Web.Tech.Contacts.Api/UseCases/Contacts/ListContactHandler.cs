using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Open.Web.Tech.Contacts.Api.Data;
using Open.Web.Tech.Contacts.Api.Data.Models;
using Open.Web.Tech.Contacts.Api.Interfaces.Dtos;
using Open.Web.Tech.Contacts.Api.Interfaces.Queries;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Open.Web.Tech.Contacts.Api.UseCases.Contacts
{
    /// <summary>
    /// List Contact Handler
    /// </summary>
    public class ListContactHandler : IRequestHandler<ListContactQuery, IReadOnlyList<ContactDto>>
    {
        private readonly IMapper _mapper;

        private readonly ApiContext _context;

        /// <summary>
        /// Constructeur : ListContactHandler
        /// </summary>
        /// <param name="mapper">mapper</param>
        /// <param name="context"></param>
        public ListContactHandler(IMapper mapper, ApiContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        /// <summary>
        /// IRequestHandler{TRequest,TResponse}.Handle(TRequest, CancellationToken)
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        public Task<IReadOnlyList<ContactDto>> Handle(ListContactQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            return HandleAsync(request);
        }

        private async Task<IReadOnlyList<ContactDto>> HandleAsync(ListContactQuery request)
        {

            var listContactRep = await _context.Contacts
                                    .Include(c => c.SkillContact)
                                    .ThenInclude(cs => cs.Skill).ToListAsync();
            return _mapper.Map<IReadOnlyList<Contact>, IReadOnlyList<ContactDto>>(listContactRep);
        }
    }
}
