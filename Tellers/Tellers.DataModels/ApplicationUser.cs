namespace Tellers.DataModels
{
    using Microsoft.AspNetCore.Identity;
    public class ApplicationUser : IdentityUser<Guid>
    {

        public int? UserProfileId { get; set; }

        public Profile? UserProfile { get; init; }

        public DateTime? CreatedOn { get; set; }
        public DateTime? LatestActivity { get; set; }
    }
}
