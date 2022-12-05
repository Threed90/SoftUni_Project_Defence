namespace Tellers.Mapper.Interfaces
{
    using AutoMapper;

    /// <summary>
    /// Interface for profile collection designing.
    /// </summary>
    public interface IProfileCollection
    {
        IReadOnlyCollection<Profile> GetProfiles();

        void AddProfile(Profile profile);

        bool RemoveProfile(Profile profile);

        /// <summary>
        /// It is not following the open-closed principle.
        /// </summary>
        void SetDefaultProfiles();
    }
}
