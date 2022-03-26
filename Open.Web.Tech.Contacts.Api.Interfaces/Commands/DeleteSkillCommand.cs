using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace Open.Web.Tech.Contacts.Api.Interfaces.Commands
{
    /// <summary>
    /// DeleteSkillCommand
    /// </summary>
    public class DeleteSkillCommand : IRequest<bool>
    {
        /// <summary>
        /// Uid
        /// </summary>
        [Required]
        public Guid Uid { get; set; }
    }
}
