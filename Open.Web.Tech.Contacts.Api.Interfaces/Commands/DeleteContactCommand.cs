using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace Open.Web.Tech.Contacts.Api.Interfaces.Commands
{
    /// <summary>
    /// DeleteContactCommand
    /// </summary>
    public class DeleteContactCommand : IRequest<bool>
    {
        /// <summary>
        /// Uid
        /// </summary>
        [Required]
        public Guid Uid { get; set; }
    }
}
