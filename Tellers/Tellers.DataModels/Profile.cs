namespace Tellers.DataModels
{
    public class Profile
    {
        public Profile()
        {
            this.MySideFriends = new HashSet<Profile>();
            this.OtherSideFriends = new HashSet<Profile>();
            this.Followers = new HashSet<Profile>();
            this.Followings = new HashSet<Profile>();
            this.Posts = new HashSet<Story>();
            this.Revues = new HashSet<Revue>();
            this.MyStories = new HashSet<Story>();
            this.MyReads = new HashSet<Story>();
            this.IsDeleted= false;
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        //[Required]
        [MaxLength(Models.Profile.FirstNameMaxLength)]
        public string? FirstName { get; set; } = null!;

        //[Required]
        [MaxLength(Models.Profile.MiddleNameMaxLength)]
        public string? MiddleName { get; set; }

        //[Required]
        [MaxLength(Models.Profile.LastNameMaxLength)]
        public string? LastName { get; set; } = null!;
                
        [MaxLength(Models.Profile.PictureUrlMaxLength)]
        public string? PictureUrl { get; set; }

        [MaxLength(Models.Profile.PseudonymMaxLength)]
        public string? Pseudonym { get; set; }

        public bool IsDeleted { get; set; }

        [ForeignKey(nameof(Bio))]
        public Guid? AdditionalInfoId { get; set; }
        public Bio? AdditionalInfo { get; set; }

        public Guid? UserId { get; set; }
        public ApplicationUser? User { get; set; } = null!;

        public ICollection<Profile> MySideFriends { get; set; }
        public ICollection<Profile> OtherSideFriends { get; set; }
        public ICollection<Profile> Followers { get; set; }
        public ICollection<Profile> Followings { get; set; }

        [InverseProperty(nameof(Story.Creator))]
        public ICollection<Story> Posts { get; set; }

        [InverseProperty(nameof(Story.Authors))]
        public ICollection<Story> MyStories { get; set; }

        [InverseProperty(nameof(Story.Readers))]
        public ICollection<Story> MyReads { get; set; }

        public ICollection<Revue> Revues { get; set; }
    }
}
