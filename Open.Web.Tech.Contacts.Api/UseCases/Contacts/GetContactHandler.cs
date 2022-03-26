using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Open.Web.Tech.Contacts.Api.Data;
using Open.Web.Tech.Contacts.Api.Data.Models;
using Open.Web.Tech.Contacts.Api.Interfaces.Dtos;
using Open.Web.Tech.Contacts.Api.Interfaces.Queries;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Open.Web.Tech.Contacts.Api.UseCases.Contacts
{
    /// <summary>
    /// Get Contact Handler
    /// </summary>
    public class GetContactHandler : IRequestHandler<GetContactQuery, ContactDto>
    {
        private readonly IMapper _mapper;

        private readonly ApiContext _context;

        /// <summary>
        /// Constructor : Get Contact Handler
        /// </summary>
        /// <param name="mapper">mapper</param>
        /// <param name="context"></param>
        public GetContactHandler(IMapper mapper, ApiContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        /// <summary>
        /// IRequestHandler{TRequest,TResponse}.Handle(TRequest, CancellationToken)
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        public Task<ContactDto> Handle(GetContactQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            return HandleAsync(request);
        }

        private async Task<ContactDto> HandleAsync(GetContactQuery request)
        {
            Contact contact = await _context.Contacts
                                    .Include(c => c.SkillContact)
                                    .ThenInclude(cs => cs.Skill)
                                        .FirstOrDefaultAsync(c => c.Uid == request.Uid);
            return _mapper.Map<Contact, ContactDto>(contact);
        }
    }
}
