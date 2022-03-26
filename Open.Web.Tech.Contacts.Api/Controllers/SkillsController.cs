using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Open.Web.Tech.Contacts.Api.Interfaces.Commands;
using Open.Web.Tech.Contacts.Api.Interfaces.Dtos;
using Open.Web.Tech.Contacts.Api.Interfaces.Queries;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Open.Web.Tech.Contacts.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrator,SimpleUser")]
    public class SkillsController : ControllerBase
    {
        /// <summary>
        /// Mediator 
        /// </summary>
        private readonly IMediator _mediator;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="mediator">Mediator.</param>
        public SkillsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get the list of all skills
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>Skill list</returns>
        [HttpGet]
        [Route("", Name = "ListSkill")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IReadOnlyList<SkillDto>> ListAsync(CancellationToken cancellationToken)
            => await _mediator.Send(new ListSkillQuery(), cancellationToken);

        /// <summary>
        /// Get skill by uid
        /// </summary>
        /// <param name="skillUid">Skill uid</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Skill.</returns>
        [HttpGet]
        [Route("{skillUid:Guid}", Name = "GetSkill")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SkillDto>> GetSkillAsync(Guid skillUid, CancellationToken cancellationToken)
            => await _mediator.Send(new GetSkillQuery() { Uid = skillUid }, cancellationToken);


        /// <summary>
        /// Create new skill.
        /// </summary>
        /// <param name="request">New skill data.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Skill created.</returns>
        [HttpPost]
        [Route("", Name = "CreateSkill")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SkillDto>> CreateSkillAsync([FromBody] CreateSkillCommand request, CancellationToken cancellationToken)
            => await _mediator.Send(request, cancellationToken);


        /// <summary>
        /// Update skill.
        /// </summary>
        /// <param name="skillUid">Skill uid</param>
        /// <param name="request">Skill to update data.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Skill updated.</returns>
        [HttpPut]
        [Route("{skillUid:Guid}", Name = "UpdateSkill")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<SkillDto>> UpdateSkillAsync(Guid skillUid, [FromBody] UpdateSkillCommand request, CancellationToken cancellationToken)
        {
            request.Uid = skillUid;
            return await _mediator.Send(request, cancellationToken);
        }

        /// <summary>
        /// Delete skill.
        /// </summary>
        /// <param name="skillUid">Skill uid to delete</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Delete result.</returns>
        [HttpDelete]
        [Route("{skillUid:Guid}", Name = "DeleteSkill")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<bool>> DeleteSkillAsync(Guid skillUid, CancellationToken cancellationToken)
         => await _mediator.Send(new DeleteSkillCommand() { Uid = skillUid }, cancellationToken);

    }
}
