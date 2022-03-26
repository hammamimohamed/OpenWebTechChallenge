using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Open.Web.Tech.Contacts.Api.Data;
using Open.Web.Tech.Contacts.Api.Data.Models;
using Open.Web.Tech.Contacts.Api.Interfaces.Commands;
using Open.Web.Tech.Contacts.Api.Interfaces.Dtos;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Open.Web.Tech.Contacts.Api.UseCases.ContactSkills
{
    /// <summary>
    /// CreateContactSkillHandler
    /// </summary>
    public class CreateContactSkillHandler : IRequestHandler<CreateContactSkillCommand, ContactDto>
    {
        private readonly IMapper _mapper;

        private readonly ApiContext _context;

        /// <summary>
        /// Constructor : CreateContactSkillHandler
        /// </summary>
        /// <param name="mapper">mapper</param>
        /// <param name="context"></param>
        public CreateContactSkillHandler(IMapper mapper, ApiContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        /// <summary>
        /// IRequestHandler{TRequest,TResponse}.Handle(TRequest, CancellationToken)
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        public Task<ContactDto> Handle(CreateContactSkillCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            return HandleAsync(request);
        }

        private async Task<ContactDto> HandleAsync(CreateContactSkillCommand request)
        {
            // verify if contact existe
            Contact contactToUpdate = await _context.Contacts
                                            .Include(c => c.SkillContact)
                                           .ThenInclude(cs => cs.Skill)
                                         .FirstOrDefaultAsync(c => c.Uid == request.UidContact) ??
                                          throw new KeyNotFoundException("Contact not found");

            // verify if level correct
            if (!Enum.TryParse(request.Level, out Level level)) throw new KeyNotFoundException("Wrong level value");


            Skill skillToAdd = await _context.Skills.FirstOrDefaultAsync(c => c.Name.ToUpper() == request.Name.ToUpper());

            // if Skill doesn't existe, I create it
            if (skillToAdd == null)
            {
                skillToAdd = new Skill()
                {
                    Name = request.Name,
                    Code = request.Name,
                    Uid = Guid.NewGuid(),
                    // Only for teste use, this value will be auto generated
                    SkillID = new Random().Next()
                };
                await _context.AddAsync(skillToAdd);
                _context.SaveChanges();
            }

            ContactSkill contactSkill = new ContactSkill()
            {
                Contact = contactToUpdate,
                Skill = skillToAdd,
                Level = level
            };

            contactToUpdate.SkillContact.Add(contactSkill);
            _context.SaveChanges();
            return _mapper.Map<Contact, ContactDto>(contactToUpdate);
        }
    }
}
