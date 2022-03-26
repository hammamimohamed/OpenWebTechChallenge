using MediatR;
using Open.Web.Tech.Contacts.Api.Interfaces.Dtos;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Open.Web.Tech.Contacts.Api.Interfaces.Commands
{
    /// <summary>
    /// UpdateContactCommand
    /// </summary>
    public class UpdateContactCommand : IRequest<ContactDto>
    {
        /// <summary>
        /// Uid
        /// </summary>
        [JsonIgnore]
        public Guid Uid { get; set; }

        /// <summary>
        /// Firstname
        /// </summary>
        [Required]
        public string Firstname { get; set; }

        /// <summary>
        /// Lastname
        /// </summary>
        [Required]
        public string Lastname { get; set; }

        /// <summary>
        /// Fullname
        /// </summary>
        [Required]
        public string Fullname { get; set; }

        /// <summary>
        /// Address
        /// </summary>
        [Required]
        public string Address { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [Required]
        [EmailAddress(ErrorMessage = "Email address is not valid.")]
        public string Email { get; set; }

        /// <summary>
        /// Mobile phone number
        /// </summary> 
        [Required]
        public string Mobile { get; set; }
    }
}
