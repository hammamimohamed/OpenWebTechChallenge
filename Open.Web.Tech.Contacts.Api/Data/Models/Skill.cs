using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Open.Web.Tech.Contacts.Api.Data.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Skill
    {
        /// <summary>
        /// Id interne
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SkillID { get; set; }

        /// <summary>
        /// Skill UUID
        /// </summary>
        public Guid Uid { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<ContactSkill> SkillContact { get; set; }

    }
}
