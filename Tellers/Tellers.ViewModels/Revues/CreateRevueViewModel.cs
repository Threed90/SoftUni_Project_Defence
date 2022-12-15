namespace Tellers.ViewModels.Revues
{
    public class CreateRevueViewModel
    {
        //does not need validation it is getting element from db just for vizualization
        public string? CreatorPictureUrl { get; set; }

        [Required]
        [MinLength(Models.Revue.TextMinLength)]
        [MaxLength(Models.Revue.TextMaxLength)]
        public string Text { get; set; }

        //it is getted from url, does not need validations
        public string StoryId { get; set; }

        [Required]
        [Range(Models.Revue.RatingMinValue, Models.Revue.RatingMaxValue)]
        public double Rating { get; set; }
    }
}
