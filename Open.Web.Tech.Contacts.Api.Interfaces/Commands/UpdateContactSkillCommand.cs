using MediatR;
using Open.Web.Tech.Contacts.Api.Interfaces.Dtos;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace Open.Web.Tech.Contacts.Api.Interfaces.Commands
{
    /// <summary>
    /// Update Contact Skill Command
    /// </summary>
    public class UpdateContactSkillCommand : IRequest<ContactDto>
    {
        /// <summary>
        /// UidContact
        /// </summary>
        [JsonIgnore]
        public Guid ContactUid { get; set; }

        /// <summary>
        /// Uid
        /// </summary>
        [JsonIgnore]
        public Guid SkillUid { get; set; }

        /// <summary>
        /// Level
        /// </summary>
        [Required]
        public string Level { get; set; }
    }
}
