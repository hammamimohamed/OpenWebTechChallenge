namespace Open.Web.Tech.Contacts.Api.Data.Models
{
    /// <summary>
    /// 
    /// </summary>
    public enum Level
    {
        /// <summary>
        /// leve A
        /// </summary>
        A,

        /// <summary>
        /// leve B
        /// </summary>
        B,

        /// <summary>
        /// leve C
        /// </summary>
        /// 
        C,

        /// <summary>
        /// leve D
        /// </summary>
        D,

        /// <summary>
        /// leve F
        /// </summary>
        F
    }

    /// <summary>
    /// 
    /// </summary>
    public class ContactSkill
    {
        /// <summary>
        /// id skill contact
        /// </summary>
        public int ContactSkillID { get; set; }

        /// <summary>
        /// Contact id
        /// </summary>
        public int ContactID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int SkillID { get; set; }

        /// <summary>
        /// Level (expertise)
        /// </summary>
        public Level Level { get; set; }

        /// <summary>
        /// Contact
        /// </summary>
        public Contact Contact { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Skill Skill { get; set; }
    }
}
