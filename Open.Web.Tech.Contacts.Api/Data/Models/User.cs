using System;

namespace Open.Web.Tech.Contacts.Api.Data.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class User
    {
        /// <summary>
        /// User ID
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Guid ContactUid { get; set; }

        /// <summary>
        /// User name
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Email address
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Role
        /// </summary>
        public string Role { get; set; }

    }
}
