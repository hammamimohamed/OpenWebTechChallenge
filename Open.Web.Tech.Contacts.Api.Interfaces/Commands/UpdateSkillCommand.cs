using MediatR;
using Open.Web.Tech.Contacts.Api.Interfaces.Dtos;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Open.Web.Tech.Contacts.Api.Interfaces.Commands
{
    /// <summary>
    /// UpdateSkillCommand
    /// </summary>
    public class UpdateSkillCommand : IRequest<SkillDto>
    {
        /// <summary>
        /// Uid
        /// </summary>
        [JsonIgnore]
        public Guid Uid { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Level
        /// </summary>
        [Required]
        public string Code { get; set; }
    }
}
