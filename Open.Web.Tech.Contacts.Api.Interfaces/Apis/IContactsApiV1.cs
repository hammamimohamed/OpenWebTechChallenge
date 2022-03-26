using Open.Web.Tech.Contacts.Api.Interfaces.Commands;
using Open.Web.Tech.Contacts.Api.Interfaces.Dtos;
using RestEase;
using System;
using System.Threading.Tasks;

namespace Open.Web.Tech.Contacts.Api.Interfaces.Apis
{
    /// <summary>
    /// Contact management
    /// </summary>
    public partial interface IContactsApiV1
    {
        /// <summary>
        /// Get the list of all contacts
        /// </summary>
        /// <returns>Contact list</returns>
        [Get("api/Contacts")]
        Task<ContactDto> ListAsync();

        /// <summary>
        /// Get contact by uid
        /// </summary>
        /// <param name="contactUid">Contact uid</param>
        /// <returns>Contact.</returns>
        [Get("api/Contacts/{contactUid}")]
        Task<ContactDto> GetContactAsync([Path] Guid contactUid);

        /// <summary>
        /// Create new contact.
        /// </summary>
        /// <param name="request">New contact data.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Contact created.</returns>
        [Post("api/Contacts")]
        Task<ContactDto> CreateContactAsync([Body] CreateContactCommand request);

        /// <summary>
        /// Update contact.
        /// </summary>
        /// <param name="contactUid">Contact uid</param>
        /// <param name="request">Contact to update data.</param>
        /// <returns>Contact updated.</returns>
        [Put("api/Contacts/{contactUid}")]
        Task<ContactDto> UpdateContactAsync([Path] Guid contactUid, [Body] UpdateContactCommand request);

        /// <summary>
        /// Delete contact.
        /// </summary>
        /// <param name="contactUid">Contact uid to delete</param>
        /// <returns>Delete result.</returns>
        [Delete("api/Contacts/{contactUid}")]
        Task<ContactDto> DeleteContactAsync([Path] Guid contactUid);

        /// <summary>
        /// Add new skill to contact.
        /// </summary>
        /// <param name="contactUid">Contact uid</param>
        /// <param name="request">New skill data.</param>
        /// <returns>Contact with skill created.</returns>
        [Post("api/Contacts/{contactUid}/skill")]
        Task<ContactDto> CreateContactSkillsync([Path] Guid contactUid, [Body] CreateContactSkillCommand request);

        /// <summary>
        /// Update contact skill.
        /// </summary>
        /// <param name="contactUid">Contact uid</param>
        /// <param name="skillUid">Skill uid</param>
        /// <param name="request">Contact to update data.</param>
        /// <returns>Contact updated.</returns>
        [Put("api/Contacts/{contactUid}/skill/{skillUid}")]
        Task<ContactDto> UpdateContactSkillAsync([Path] Guid contactUid, [Path] Guid skillUid, [Body] UpdateContactSkillCommand request);

        /// <summary>
        /// Delete contact skill.
        /// </summary>
        /// <param name="contactUid">Contact uid to delete</param>
        /// <param name="skillUid">Skill uid</param>
        /// <returns>Delete result.</returns>
        [Delete("api/Contacts/{contactUid}/skill/{skillUid}")]
        Task<ContactDto> DeleteContactSkillAsync([Path] Guid contactUid, [Path] Guid skillUid);
    }
}
