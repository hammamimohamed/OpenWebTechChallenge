using MediatR;
using Microsoft.EntityFrameworkCore;
using Open.Web.Tech.Contacts.Api.Data;
using Open.Web.Tech.Contacts.Api.Data.Models;
using Open.Web.Tech.Contacts.Api.Interfaces.Commands;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Open.Web.Tech.Skills.Api.UseCases.Skills
{
    /// <summary>
    /// DeleteSkillHandler
    /// </summary>
    public class DeleteSkillHandler : IRequestHandler<DeleteSkillCommand, bool>
    {
        private readonly ApiContext _context;

        /// <summary>
        /// Constructor : delete Skill Handler
        /// </summary>
        /// <param name="context"></param>
        public DeleteSkillHandler(ApiContext context)
        {
            _context = context;
        }


        /// <summary>
        /// IRequestHandler{TRequest,TResponse}.Handle(TRequest, CancellationToken)
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        public Task<bool> Handle(DeleteSkillCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            return HandleAsync(request);
        }

        private async Task<bool> HandleAsync(DeleteSkillCommand request)
        {
            Skill skillToDelete = await _context.Skills
                                       .FirstOrDefaultAsync(c => c.Uid == request.Uid) ??
                                        throw new KeyNotFoundException("Skill not found");

            _context.Remove(skillToDelete);
            _context.SaveChanges();

            return true;
        }
    }
}
