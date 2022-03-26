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

namespace Open.Web.Tech.Skills.Api.UseCases.Skills
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateSkillHandler : IRequestHandler<UpdateSkillCommand, SkillDto>
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _context;

        /// <summary>
        /// Constructor : udpate Skill Handler
        /// </summary>
        /// <param name="mapper">mapper</param>
        /// <param name="context"></param>
        public UpdateSkillHandler(IMapper mapper, ApiContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        /// <summary>
        /// IRequestHandler{TRequest,TResponse}.Handle(TRequest, CancellationToken)
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        public Task<SkillDto> Handle(UpdateSkillCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            return HandleAsync(request);
        }

        private async Task<SkillDto> HandleAsync(UpdateSkillCommand request)
        {
            Skill skillToUpdate = await _context.Skills
                                         .FirstOrDefaultAsync(c => c.Uid == request.Uid) ??
                                          throw new KeyNotFoundException("Skill not found");

            skillToUpdate.Code = request.Code;
            skillToUpdate.Name = request.Name;
         
            _context.Update(skillToUpdate);
            _context.SaveChanges();

            return _mapper.Map<Skill, SkillDto>(skillToUpdate);
        }
    }
}
