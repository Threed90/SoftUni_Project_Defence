namespace Tellers.ViewModels.User
{
    /// <summary>
    /// View model for registration form
    /// </summary>
    public class RegisterViewModel
    {
        [Required]
        [MinLength(Models.Profile.FirstNameMinLength)]
        [MaxLength(Models.Profile.FirstNameMaxLength)]
        public string FirstName { get; init; } = null!;

        //[Required]
        [MinLength(Models.Profile.FirstNameMinLength)]
        [MaxLength(Models.Profile.FirstNameMaxLength)]
        public string? MiddleName { get; init; }

        [Required]
        [MinLength(Models.Profile.FirstNameMinLength)]
        [MaxLength(Models.Profile.FirstNameMaxLength)]
        public string LastName { get; init; } = null!;

        [Required]
        [EmailAddress]
        [MinLength(Models.AppUser.EmailMinLength)]
        [MaxLength(Models.AppUser.EmailMaxLength)]
        public string Email { get; init; } = null!;

        [Required]
        [MinLength(Models.AppUser.UserNameMinLength)]
        [MaxLength(Models.AppUser.UserNameMaxLength)]
        public string UserName { get; init; } = null!;

        [Required]
        [MinLength(Models.AppUser.PasswordMinLength)]
        [MaxLength(Models.AppUser.PasswordMaxLength)]
        public string Password { get; init; } = null!;

        [Required]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; init; } = null!;

        [Required]
        [Range(typeof(bool), "true", "true", ErrorMessage = "You have to agree with our terms in order to use our services.")]
        public bool AcceptedAgreement { get; init; }

    }
}
