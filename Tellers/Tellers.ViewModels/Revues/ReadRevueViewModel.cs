namespace Tellers.ViewModels.Revues
{
    public class ReadRevueViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; } = null!;
        public double Rating { get; set; }

        public string? CreatorPictureUrl { get; set; }

        public string? CreatorUsername { get; set; }
        public string? CreatorId { get; set; }
        public string? CreatorFirstName { get; set; }
        public string? CreatorMiddleName { get; set; }
        public string? CreatorLastName { get; set; }
        public string? CreatorPseudonym { get; set; }

        public string? StoryId { get; set; }   
    }
}