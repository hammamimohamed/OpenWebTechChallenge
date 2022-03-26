using System;

namespace Open.Web.Tech.Contacts.Api.Interfaces.Dtos
{
    /// <summary>
    /// SkillDto
    /// </summary>
    public class SkillDto
    {
        /// <summary>
        /// Uid
        /// </summary>
        public Guid UidSkill { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Level
        /// </summary>
        public string Code { get; set; }
    }
}
