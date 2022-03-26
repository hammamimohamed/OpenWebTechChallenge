using MediatR;
using Open.Web.Tech.Contacts.Api.Interfaces.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Open.Web.Tech.Contacts.Api.Interfaces.Commands
{
    /// <summary>
    /// /
    /// </summary>
    public class CreateSkillCommand : IRequest<SkillDto>
    {
        /// <summary>
        /// Name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Code
        /// </summary>
        [Required]
        public string Code { get; set; }
    }
}
