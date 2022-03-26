using MediatR;
using Microsoft.EntityFrameworkCore;
using Open.Web.Tech.Contacts.Api.Data;
using Open.Web.Tech.Contacts.Api.Data.Models;
using Open.Web.Tech.Contacts.Api.Interfaces.Commands;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Open.Web.Tech.Contacts.Api.UseCases.ContactSkills
{
    /// <summary>
    /// DeleteContactSkillHandler
    /// </summary>
    public class DeleteContactSkillHandler : IRequestHandler<DeleteContactSkillCommand, bool>
    {
        private readonly ApiContext _context;

        /// <summary>
        /// Constructor : Delete Contact Skill Handler
        /// </summary>
        /// <param name="context"></param>
        public DeleteContactSkillHandler(ApiContext context)
        {
            _context = context;
        }


        /// <summary>
        /// IRequestHandler{TRequest,TResponse}.Handle(TRequest, CancellationToken)
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        public Task<bool> Handle(DeleteContactSkillCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            return HandleAsync(request);
        }

        private async Task<bool> HandleAsync(DeleteContactSkillCommand request)
        {
            ContactSkill contactSkillToDelete = await _context.ContactSkills
                                 .FirstOrDefaultAsync(c => c.Contact.Uid == request.ContactUid && c.Skill.Uid == request.SkillUid) ??
                                  throw new KeyNotFoundException("Contact skill not found");

            _context.Remove(contactSkillToDelete);
            _context.SaveChanges();
            return true;
        }
    }
}
