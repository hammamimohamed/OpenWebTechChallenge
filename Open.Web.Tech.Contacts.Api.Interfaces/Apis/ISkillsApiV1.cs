using Open.Web.Tech.Contacts.Api.Interfaces.Commands;
using Open.Web.Tech.Contacts.Api.Interfaces.Dtos;
using RestEase;
using System;
using System.Threading.Tasks;

namespace Open.Web.Tech.Contacts.Api.Interfaces.Apis
{
    /// <summary>
    /// Skill management
    /// </summary>
    public interface ISkillsApiV1
    {
        /// <summary>
        /// Get the list of all skills
        /// </summary>
        /// <returns>Skill list</returns>
        [Get("api/Skills")]
        Task<SkillDto> ListAsync();

        /// <summary>
        /// Get skill by uid
        /// </summary>
        /// <param name="skillUid">Skill uid</param>
        /// <returns>Skill.</returns>
        [Get("api/Skills/{skillUid}")]
        Task<SkillDto> GetSkillAsync([Path] Guid skillUid);

        /// <summary>
        /// Create new skill.
        /// </summary>
        /// <param name="request">New skill data.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Skill created.</returns>
        [Post("api/Skills")]
        Task<SkillDto> CreateSkillAsync([Body] CreateSkillCommand request);

        /// <summary>
        /// Update skill.
        /// </summary>
        /// <param name="skillUid">Skill uid</param>
        /// <param name="request">Skill to update data.</param>
        /// <returns>Skill updated.</returns>
        [Put("api/Skills/{skillUid}")]
        Task<SkillDto> UpdateSkillAsync([Path] Guid skillUid, [Body] UpdateSkillCommand request);

        /// <summary>
        /// Delete skill.
        /// </summary>
        /// <param name="skillUid">Skill uid to delete</param>
        /// <returns>Delete result.</returns>
        [Delete("api/Skills/{skillUid}")]
        Task<SkillDto> DeleteSkillAsync([Path] Guid skillUid);
    }
}
