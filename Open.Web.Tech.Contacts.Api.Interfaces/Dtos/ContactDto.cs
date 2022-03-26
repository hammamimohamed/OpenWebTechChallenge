using System;
using System.Collections.Generic;
namespace Open.Web.Tech.Contacts.Api.Interfaces.Dtos
{
    /// <summary>
    /// ContactDto
    /// </summary>
    public class ContactDto
    {
        /// <summary>
        /// Uid
        /// </summary>
        public Guid UidContact { get; set; }

        /// <summary>
        /// Firstname
        /// </summary>
        public string Firstname { get; set; }

        /// <summary>
        /// Lastname
        /// </summary>
        public string Lastname { get; set; }

        /// <summary>
        /// Fullname
        /// </summary>
        public string Fullname { get; set; }

        /// <summary>
        /// Address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Mobile phone number
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// Navigation: List of skill
        /// </summary>
        public virtual IList<ContactSkillDto> Skills { get; set; }
    }
}
