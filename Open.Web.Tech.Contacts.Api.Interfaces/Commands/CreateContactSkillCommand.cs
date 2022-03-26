using MediatR;
using Open.Web.Tech.Contacts.Api.Interfaces.Dtos;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Open.Web.Tech.Contacts.Api.Interfaces.Commands
{
    /// <summary>
    /// AddSkillContactCommand
    /// </summary>
    public class CreateContactSkillCommand : IRequest<ContactDto>
    {
        /// <summary>
        /// Uid
        /// </summary>
        [JsonIgnore]
        public Guid UidContact { get; set; }

        /// <summary>
        /// Uid
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Level A/B/C/D/E/F
        /// </summary>
        [Required]
        public string Level { get; set; }
    }
}
