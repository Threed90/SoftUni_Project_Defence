namespace Tellers.Constants
{
    /// <summary>
    /// Static class for data and view models constants.
    /// </summary>
    public static class Models
    {
        public static class AppUser
        {
            public const int UserNameMinLength = 5;
            public const int UserNameMaxLength = 25;

            public const int PasswordMinLength = 5;
            public const int PasswordMaxLength = 50;

            public const int EmailMinLength = 5;
            public const int EmailMaxLength = 60;

        }
        public static class Profile
        {
            public const int FirstNameMinLength = 2;
            public const int FirstNameMaxLength = 100;

            public const int MiddleNameMinLength = 2;
            public const int MiddleNameMaxLength = 100;

            public const int LastNameMinLength = 2;
            public const int LastNameMaxLength = 100;

            public const int PicturePathMaxLength = 256;

            public const int PictureUrlMaxLength = 2048;


            public const int PseudonymMinLength = 1;
            public const int PseudonymMaxLength = 50;
        }

        public static class Country
        {
            public const int NameMinLength = 4;
            public const int NameMaxLength = 60;

            public const int CountryCodeMinLength = 1;
            public const int CountryCodeMaxLength = 10;

            public const int IsoCodeMinLength = 2;
            public const int IsoCodeMaxLength = 2;
        }

        public static class Education
        {
            public const int QualificationNameMinLength = 10;
            public const int QualificationNameMaxLength = 100;

            public const int EducationInstitutionNameMinLength = 10;
            public const int EducationInstitutionNameMaxLength = 120;

            public const int AdditionalDescriptionMinLength = 20;
            public const int AdditionalDescriptionMaxLength = 200;
        }

        public static class Genre
        {
            public const int NameMinLength = 4;
            public const int NameMaxLength = 30;
        }

        public static class Revue
        {
            public const int TextMinLength = 1;
            public const int TextMaxLength = 500;

            public const double RatingMinValue = 0;
            public const double RatingMaxValue = 10;
        }

        public static class Story
        {
            public const int TitleMinLength = 2;
            public const int TitleMaxLength = 100;

            public const int StoryTextMinLength = 50;

            public const int PdfFileMinLength = 10;
            public const int PdfFileUrlMaxLength = 2048;

            public const int StorySummaryMinLength = 10;
            public const int StorySummaryMaxLength = 100;

        }

        public static class StoryType
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 70;
        }

        public static class Town
        {
            public const int NameMinLength = 1;
            public const int NameMaxLength = 40;

            public const int PostCodeMinLength = 2;
            public const int PostCodeMaxLength = 6;
        }

        public static class WorkingExperience
        {
            public const int PositionMinLength = 2;
            public const int PositionMaxLength = 50;

            public const int EmployerNameMinLength = 2;
            public const int EmployerNameMaxLength = 50;

            public const int ActivitiesAndResponcesMinLength = 20;
            public const int ActivitiesAndResponcesMaxLength = 250;
        }
    }
}
