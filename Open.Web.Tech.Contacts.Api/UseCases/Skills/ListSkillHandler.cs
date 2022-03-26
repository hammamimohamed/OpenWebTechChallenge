using AutoMapper;
using MediatR;
using Open.Web.Tech.Contacts.Api.Interfaces.Dtos;
using Open.Web.Tech.Contacts.Api.Data.Models;
using Open.Web.Tech.Contacts.Api.Interfaces.Queries;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Open.Web.Tech.Contacts.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Open.Web.Tech.Contacts.Api.UseCases.Skills
{
    /// <summary>
    /// 
    /// </summary>
    public class ListSkillHandler : IRequestHandler<ListSkillQuery, IReadOnlyList<SkillDto>>
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _context;

        /// <summary>
        /// Constructeur : ListSkillHandler
        /// </summary>
        /// <param name="mapper">mapper</param>
        /// <param name="context"></param>
        public ListSkillHandler(IMapper mapper, ApiContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        /// <summary>
        /// IRequestHandler{TRequest,TResponse}.Handle(TRequest, CancellationToken)
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        public Task<IReadOnlyList<SkillDto>> Handle(ListSkillQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            return HandleAsync(request);
        }

        private async Task<IReadOnlyList<SkillDto>> HandleAsync(ListSkillQuery request)
        {
            IReadOnlyList<Skill> listSkillRep = await _context.Skills.ToListAsync();

            return _mapper.Map<IReadOnlyList<Skill>, IReadOnlyList<SkillDto>>(listSkillRep);
        }
    }
}
