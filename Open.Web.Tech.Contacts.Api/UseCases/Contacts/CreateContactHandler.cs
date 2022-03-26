using AutoMapper;
using MediatR;
using Open.Web.Tech.Contacts.Api.Interfaces.Commands;
using Open.Web.Tech.Contacts.Api.Interfaces.Dtos;
using Open.Web.Tech.Contacts.Api.Data.Models;
using System;
using System.Threading;
using System.Threading.Tasks;
using Open.Web.Tech.Contacts.Api.Data;

namespace Open.Web.Tech.Contacts.Api.UseCases.Contacts
{
    /// <summary>
    /// Create Contact Handler
    /// </summary>
    public class CreateContactHandler : IRequestHandler<CreateContactCommand, ContactDto>
    {
        private readonly IMapper _mapper;

        private readonly ApiContext _context;

        /// <summary>
        /// Constructor : Create new Contact Handler
        /// </summary>
        /// <param name="mapper">mapper</param>
        /// <param name="context"></param>
        public CreateContactHandler(IMapper mapper, ApiContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        /// <summary>
        /// IRequestHandler{TRequest,TResponse}.Handle(TRequest, CancellationToken)
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        public Task<ContactDto> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            return HandleAsync(request);
        }

        private async Task<ContactDto> HandleAsync(CreateContactCommand request)
        {
            Contact contactToAdd = new Contact() 
            { 
                FirstName = request.Firstname,
                LastName = request.Lastname,
                FullName = request.Fullname,
                Address = request.Address,
                Email = request.Email,
                Mobile = request.Mobile,
                Uid = Guid.NewGuid(),
            };

            await _context.AddAsync(contactToAdd);
            _context.SaveChanges();

            return _mapper.Map<Contact, ContactDto>(contactToAdd);
        }
    }
}
