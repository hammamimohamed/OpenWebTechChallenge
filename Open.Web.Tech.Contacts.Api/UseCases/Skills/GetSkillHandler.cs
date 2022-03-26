using AutoMapper;
using MediatR;
using Open.Web.Tech.Contacts.Api.Interfaces.Dtos;
using Open.Web.Tech.Contacts.Api.Data.Models;
using Open.Web.Tech.Contacts.Api.Interfaces.Queries;
using System;
using System.Threading;
using System.Threading.Tasks;
using Open.Web.Tech.Contacts.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Open.Web.Tech.Contacts.Api.UseCases.Skills
{
    /// <summary>
    /// 
    /// </summary>
    public class GetSkillHandler : IRequestHandler<GetSkillQuery, SkillDto>
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _context;

        /// <summary>
        /// Constructor : Get Skill Handler
        /// </summary>
        /// <param name="mapper">mapper</param>
        /// <param name="context"></param>
        public GetSkillHandler(IMapper mapper, ApiContext context)
        {
            _mapper = mapper;
            _context = context;
        }



        /// <summary>
        /// IRequestHandler{TRequest,TResponse}.Handle(TRequest, CancellationToken)
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        public Task<SkillDto> Handle(GetSkillQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            return HandleAsync(request);
        }

        private async Task<SkillDto> HandleAsync(GetSkillQuery request)
        {
            Skill skill =  await _context.Skills.FirstOrDefaultAsync(c => c.Uid == request.Uid);

            return _mapper.Map<Skill, SkillDto>(skill);
        }
    }
}
