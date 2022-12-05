namespace Tellers.Mapper
{
    using AutoMapper;
    using Interfaces;

    /// <summary>
    /// The class allow you to get needed profiles configurations for Automapper.
    /// </summary>
    public class ProfileCollection : IProfileCollection
    {
        /// <summary>
        /// Inner collection of profiles.
        /// </summary>
        private readonly List<Profile> profiles;

        /// <summary>
        /// Create instance with empty initial profile collection.
        /// </summary>
        public ProfileCollection()
        {
            this.profiles = new List<Profile>();
        }

        /// <summary>
        /// Create instance of the class with the given initial profile collection.
        /// </summary>
        /// <param name="profiles"></param>
        public ProfileCollection(IEnumerable<Profile> profiles)
        {
            this.profiles = profiles.ToList();
        }

        /// <summary>
        /// Allow you to add a Profile to already existing collection.
        /// </summary>
        /// <param name="profile"></param>
        public void AddProfile(Profile profile)
        {
            this.profiles.Add(profile);
        }

        /// <summary>
        /// Allow you to remove a Profile from already existing collection.
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        public bool RemoveProfile(Profile profile)
        {
            return this.profiles.Remove(profile);
        }

        /// <summary>
        /// Allow you to get the inner collection of Profiles as read only.
        /// </summary>
        /// <returns></returns>
        public IReadOnlyCollection<Profile> GetProfiles()
        {
            return this.profiles.AsReadOnly();
        }

        /// <summary>
        /// Fill the inner collection with already defined profiles.
        /// Profiles here are predefined, based on the existing application project and server layer logic.
        /// Method is not open for extentions or modifications. Actually is working fine only for Tellers.App and Tellers.Server.
        /// </summary>
        public void SetDefaultProfiles()
        {
            
        }
    }
}
