using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Open.Web.Tech.Contacts.Api.Interfaces.Commands;
using Open.Web.Tech.Contacts.Api.Data;
using Open.Web.Tech.Contacts.Api.Data.Models;
using Open.Web.Tech.Contacts.Api.Interfaces.Dtos;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Open.Web.Tech.Contacts.Api.UseCases.Contacts
{
    /// <summary>
    /// Update Contact Handler
    /// </summary>
    public class UpdateContactHandler : IRequestHandler<UpdateContactCommand, ContactDto>
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _context;

        /// <summary>
        /// Constructor : udpate Contact Handler
        /// </summary>
        /// <param name="mapper">mapper</param>
        /// <param name="context"></param>
        public UpdateContactHandler(IMapper mapper, ApiContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        /// <summary>
        /// IRequestHandler{TRequest,TResponse}.Handle(TRequest, CancellationToken)
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        public Task<ContactDto> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            return HandleAsync(request);
        }

        private async Task<ContactDto> HandleAsync(UpdateContactCommand request)
        {
            Contact contactToUpdate = await _context.Contacts
                                         .FirstOrDefaultAsync(c => c.Uid == request.Uid) ??
                                          throw new KeyNotFoundException("Contact not found");

            contactToUpdate.FirstName = request.Firstname;
            contactToUpdate.LastName = request.Lastname;
            contactToUpdate.FullName = request.Fullname;
            contactToUpdate.Address = request.Address;
            contactToUpdate.Email = request.Email;
            contactToUpdate.Mobile = request.Mobile;
            _context.Update(contactToUpdate);
            _context.SaveChanges();

            return _mapper.Map<Contact, ContactDto>(contactToUpdate);
        }
    }
}
