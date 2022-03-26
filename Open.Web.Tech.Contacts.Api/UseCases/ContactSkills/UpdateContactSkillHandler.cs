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

namespace Open.Web.Tech.Contacts.Api.UseCases.ContactSkills
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateContactSkillHandler : IRequestHandler<UpdateContactSkillCommand, ContactDto>
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _context;

        /// <summary>
        /// Constructor : UpdateContactSkillHandler
        /// </summary>
        /// <param name="mapper">mapper</param>
        /// <param name="context"></param>
        public UpdateContactSkillHandler(IMapper mapper, ApiContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        /// <summary>
        /// IRequestHandler{TRequest,TResponse}.Handle(TRequest, CancellationToken)
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        public Task<ContactDto> Handle(UpdateContactSkillCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            return HandleAsync(request);
        }

        private async Task<ContactDto> HandleAsync(UpdateContactSkillCommand request)
        {
            // verify if contact skill existe
            ContactSkill contactSkillToUpdate = await _context.ContactSkills
                                                    .Include(c => c.Contact)
                                                    .Include(c => c.Skill)
                                  .FirstOrDefaultAsync(c => c.Contact.Uid == request.ContactUid && c.Skill.Uid == request.SkillUid) ??
                                   throw new KeyNotFoundException("Contact skill not found");

            // verify if level correct
            if (!Enum.TryParse(request.Level, out Level level)) throw new KeyNotFoundException("Wrong level value");
            contactSkillToUpdate.Level = level;
            _context.Update(contactSkillToUpdate);
            _context.SaveChanges();

            return _mapper.Map<Contact, ContactDto>(contactSkillToUpdate.Contact);
        }
    }
}
