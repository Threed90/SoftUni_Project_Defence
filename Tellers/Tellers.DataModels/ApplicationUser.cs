namespace Tellers.DataModels
{
    using Microsoft.AspNetCore.Identity;

    /// <summary>
    /// Data model class that extending ASP.NET IdentityUser. 
    /// All additional properties are nullable, so the class will follow the GDPR as much possible.
    /// </summary>
    public class ApplicationUser : IdentityUser<Guid>
    {
        /// <summary>
        /// User Profile Id.
        /// </summary>
        public Guid? UserProfileId { get; set; }

        public Profile? UserProfile { get; set; }

        /// <summary>
        /// The date of user account creating.
        /// </summary>
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// The date of last activity of the user.
        /// </summary>
        public DateTime? LatestActivity { get; set; }
    }
}
