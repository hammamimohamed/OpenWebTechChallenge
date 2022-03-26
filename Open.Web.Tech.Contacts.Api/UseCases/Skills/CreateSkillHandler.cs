using AutoMapper;
using MediatR;
using Open.Web.Tech.Contacts.Api.Interfaces.Commands;
using Open.Web.Tech.Contacts.Api.Interfaces.Dtos;
using Open.Web.Tech.Contacts.Api.Data.Models;
using System;
using System.Threading;
using System.Threading.Tasks;
using Open.Web.Tech.Contacts.Api.Data;

namespace Open.Web.Tech.Contacts.Api.UseCases.Skills
{
    /// <summary>
    /// CreateSkillHandler
    /// </summary>
    public class CreateSkillHandler : IRequestHandler<CreateSkillCommand, SkillDto>
    {
        private readonly IMapper _mapper;

        private readonly ApiContext _context;

        /// <summary>
        /// Constructor : Create new Skill Handler
        /// </summary>
        /// <param name="mapper">mapper</param>
        /// <param name="context"></param>
        public CreateSkillHandler(IMapper mapper, ApiContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        /// <summary>
        /// IRequestHandler{TRequest,TResponse}.Handle(TRequest, CancellationToken)
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        public Task<SkillDto> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            return HandleAsync(request);
        }

        private async Task<SkillDto> HandleAsync(CreateSkillCommand request)
        {
            Skill skillToAdd = new Skill()
            {
                Uid = Guid.NewGuid(),
                Code = request.Code,
                Name = request.Name,
                // Only for teste use, this value will be auto generated
                SkillID = new Random().Next()
            };

            await _context.AddAsync(skillToAdd);
            _context.SaveChanges();

            return _mapper.Map<Skill, SkillDto>(skillToAdd);
        }
    }
}
