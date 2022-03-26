using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace Open.Web.Tech.Contacts.Api.Interfaces.Commands
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteContactSkillCommand : IRequest<bool>
    {
        /// <summary>
        /// UidContact
        /// </summary>
        [Required]
        public Guid ContactUid { get; set; }


        /// <summary>
        /// Uid
        /// </summary>
        [Required]
        public Guid SkillUid { get; set; }
    }
}
