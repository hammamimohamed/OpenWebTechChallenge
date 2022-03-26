using MediatR;
using Microsoft.EntityFrameworkCore;
using Open.Web.Tech.Contacts.Api.Interfaces.Commands;
using Open.Web.Tech.Contacts.Api.Data;
using Open.Web.Tech.Contacts.Api.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Open.Web.Tech.Contacts.Api.UseCases.Contacts
{
    /// <summary>
    /// Delete Contact Handler
    /// </summary>
    public class DeleteContactHandler : IRequestHandler<DeleteContactCommand, bool>
    {
        private readonly ApiContext _context;

        /// <summary>
        /// Constructor : delete Contact Handler
        /// </summary>
        /// <param name="context"></param>
        public DeleteContactHandler(ApiContext context)
        {
            _context = context;
        }


    /// <summary>
    /// IRequestHandler{TRequest,TResponse}.Handle(TRequest, CancellationToken)
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    public Task<bool> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            return HandleAsync(request);
        }

        private async Task<bool> HandleAsync(DeleteContactCommand request)
        {
            Contact contactToDelete = await _context.Contacts
                                       .FirstOrDefaultAsync(c => c.Uid == request.Uid) ??
                                        throw new KeyNotFoundException("Contact not found"); 

            _context.Remove(contactToDelete);
            _context.SaveChanges();

            return true;
        }
    }
}
