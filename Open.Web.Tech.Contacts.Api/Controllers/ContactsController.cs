using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Open.Web.Tech.Contacts.Api.Data.Models;
using Open.Web.Tech.Contacts.Api.Interfaces.Commands;
using Open.Web.Tech.Contacts.Api.Interfaces.Dtos;
using Open.Web.Tech.Contacts.Api.Interfaces.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Open.Web.Tech.Contacts.Api.Controllers
{
    /// <summary>
    /// Contacts Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrator,SimpleUser")]
    public class ContactsController : ControllerBase
    {
        /// <summary>
        /// Mediator 
        /// </summary>
        private readonly IMediator _mediator;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="mediator">Mediator.</param>
        public ContactsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get the list of all contacts
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>Contact list</returns>
        [HttpGet]
        [Route("", Name = "ListContact")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IReadOnlyList<ContactDto>> ListAsync(CancellationToken cancellationToken)
            => await _mediator.Send(new ListContactQuery(), cancellationToken);

        /// <summary>
        /// Get contact by uid
        /// </summary>
        /// <param name="contactUid">Contact uid</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Contact.</returns>
        [HttpGet]
        [Route("{contactUid:Guid}", Name = "GetContact")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ContactDto>> GetContactAsync(Guid contactUid, CancellationToken cancellationToken)
            => await _mediator.Send(new GetContactQuery() { Uid = contactUid }, cancellationToken);
   


        /// <summary>
        /// Create new contact.
        /// </summary>
        /// <param name="request">New contact data.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Contact created.</returns>
        [HttpPost]
        [Route("", Name = "CreateContact")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<ContactDto>> CreateContactAsync([FromBody] CreateContactCommand request, CancellationToken cancellationToken)
            => await _mediator.Send(request, cancellationToken);

        /// <summary>
        /// Update contact.
        /// </summary>
        /// <param name="contactUid">Contact uid</param>
        /// <param name="request">Contact to update data.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Contact updated.</returns>
        [HttpPut]
        [Route("{contactUid:Guid}", Name = "UpdateContact")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<ContactDto>> UpdateContactAsync(Guid contactUid, [FromBody] UpdateContactCommand request, CancellationToken cancellationToken)
        {
            request.Uid = contactUid;
            return await _mediator.Send(request, cancellationToken);
        }

        /// <summary>
        /// Delete contact.
        /// </summary>
        /// <param name="contactUid">Contact uid to delete</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Delete result.</returns>
        [HttpDelete]
        [Route("{contactUid:Guid}", Name = "DeleteContact")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<bool>> DeleteContactAsync(Guid contactUid, CancellationToken cancellationToken)
         => await _mediator.Send(new DeleteContactCommand() { Uid = contactUid }, cancellationToken);

        /// <summary>
        /// Add new skill to contact.
        /// </summary>
        /// <param name="contactUid">Contact uid</param>
        /// <param name="request">New skill data.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Contact with skill created.</returns>
        [HttpPost]
        [Route("{contactUid:Guid}/skill", Name = "CreateContactSkill")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ContactDto>> CreateContactSkillsync(Guid contactUid, [FromBody] CreateContactSkillCommand request, CancellationToken cancellationToken)
        {
            // get user connected
            var currentUser = GetCurrentUser();

            // if user conneted is diffrente of contact so modification is forbidden
            if(currentUser.ContactUid != contactUid)
            {
                return Forbid();
            }

            request.UidContact = contactUid;
            return await _mediator.Send(request, cancellationToken);
        }

        /// <summary>
        /// Update contact skill.
        /// </summary>
        /// <param name="contactUid">Contact uid</param>
        /// <param name="skillUid">Skill uid</param>
        /// <param name="request">Contact to update data.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Contact updated.</returns>
        [HttpPut]
        [Route("{contactUid:Guid}/skill/{skillUid:Guid}", Name = "UpdateContactSkill")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ContactDto>> UpdateContactSkillAsync(Guid contactUid, Guid skillUid, [FromBody] UpdateContactSkillCommand request, CancellationToken cancellationToken)
        {
            // get user connected
            var currentUser = GetCurrentUser();

            // if user conneted is diffrente of contact so modification is forbidden
            if (currentUser.ContactUid != contactUid)
            {
                Forbid();
            }

            request.ContactUid = contactUid;
            request.SkillUid = skillUid;
            return await _mediator.Send(request, cancellationToken);
        }

        /// <summary>
        /// Delete contact skill.
        /// </summary>
        /// <param name="contactUid">Contact uid to delete</param>
        /// <param name="skillUid">Skill uid</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Delete result.</returns>
        [HttpDelete]
        [Route("{contactUid:Guid}/skill/{skillUid:Guid}", Name = "DeleteContactSkill")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<bool>> DeleteContactSkillAsync(Guid contactUid, Guid skillUid, CancellationToken cancellationToken)
        {
            // get user connected
            var currentUser = GetCurrentUser();

            // if user conneted is diffrente of contact so modification is forbidden
            if (currentUser.ContactUid != contactUid)
            {
                Forbid();
            }
            return await _mediator.Send(new DeleteContactSkillCommand() { ContactUid = contactUid, SkillUid = skillUid }, cancellationToken); 
        }

        private User GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaims = identity.Claims;

                return new User
                {
                    UserName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                    EmailAddress = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value,
                    Role = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value,
                    ContactUid = Guid.Parse(userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Actor)?.Value)
                };
            }
            return null;
        }
    }
}
