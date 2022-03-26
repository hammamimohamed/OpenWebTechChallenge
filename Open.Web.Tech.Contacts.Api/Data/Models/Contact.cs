using System;
using System.Collections.Generic;

namespace Open.Web.Tech.Contacts.Api.Data.Models
{
    /// <summary>
    /// Contact
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// Id interne
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Contact UUID
        /// </summary>
        public Guid Uid { get; set; }

        /// <summary>
        /// Firstname
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Lastname
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Fullname
        /// </summary>
        public string FullName { get; set; }

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
        /// Contact Skills
        /// </summary>
        public ICollection<ContactSkill> SkillContact { get; set; }

    }
}
