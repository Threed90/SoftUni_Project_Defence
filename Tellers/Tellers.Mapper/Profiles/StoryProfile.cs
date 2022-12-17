using System.Globalization;
using Tellers.DataModels;
using Tellers.ViewModels.Story;

namespace Tellers.Mapper.Profiles
{
    public class StoryProfile : AutoMapper.Profile
    {
        public StoryProfile()
        {
            this.CreateMap<Story, StoryDetailsViewModel>()
                .IncludeAllDerived()
                .ForMember(sd => sd.StoryId, s => s.MapFrom(f => (f.Creator == null ? null : f.Id.ToString())))
                .ForMember(sd => sd.CreatorFirstName, s => s.MapFrom(f => (f.Creator == null ? null : f.Creator.FirstName)))
                .ForMember(sd => sd.CreatorId, s => s.MapFrom(f => (f.Creator == null ? null : f.Creator.Id.ToString())))
                .ForMember(sd => sd.CreatorUserId, s => s.MapFrom(f => (f.Creator == null ? null : f.Creator.User.Id.ToString())))
                .ForMember(sd => sd.CreatorMiddleName, s => s.MapFrom(m => (m.Creator == null ? null : m.Creator.MiddleName)))
                .ForMember(sd => sd.CreatorLastName, s => s.MapFrom(l => (l.Creator == null ? null : l.Creator.LastName)))
                .ForMember(sd => sd.CreatorPseudonym, s => s.MapFrom(p => (p.Creator == null ? null : p.Creator.Pseudonym)))
                .ForMember(sd => sd.CreatorUsername, s => s.MapFrom(u => (u.Creator == null ? null : u.Creator.User.UserName)))
                .ForMember(sd => sd.StoryType, s => s.MapFrom(u => u.StoryType.Name))
                .ForMember(sd => sd.Genres, s => s.MapFrom(u => u.Genres.Select(s => s.Name)))
                .ForMember(sd => sd.Year, s => s.MapFrom(date => date.CreatedOn.Year))
                .ForMember(sd => sd.Month, s => s.MapFrom(date => date.CreatedOn.ToString("MMMM", CultureInfo.GetCultureInfo("us-US"))))
                .ForMember(sd => sd.Day, s => s.MapFrom(date => date.CreatedOn.Day))
                .ForMember(sd => sd.TotalRevues, s => s.MapFrom(s => s.Revues.Count()))
                .ForMember(sd => sd.Page, s => s.Ignore())
                .ForMember(sd => sd.IsMarkedAsReaded, s => s.Ignore())
                .ForMember(sd => sd.Revues, s => s.MapFrom(r => r.Revues.OrderByDescending(r => r.CreatedOn).ToList()));

            this.CreateMap<Story, StoryEditFormViewModel>()
                .ForMember(sv => sv.BookPdf, y => y.MapFrom(s => s.PdfFileUrl))
                .ForMember(sv => sv.StorySummery, y => y.MapFrom(s => s.StorySummary))
                .ForMember(sv => sv.StoryId, y => y.MapFrom(s => s.Id.ToString()))
                .ForMember(sv => sv.BookCover, y => y.MapFrom(s => s.BookCoverPicture))
                .ForMember(sv => sv.ExternalAuthor, y => y.MapFrom(s => s.ExternalAuthorName))
                .ForMember(sv => sv.Title, y => y.MapFrom(s => s.Title))
                .ForMember(sv => sv.StoryCreatorUserId, y => y.MapFrom(s => s.Creator.User.Id))
                .ForMember(sv => sv.StoryType, y => y.MapFrom(s => s.StoryType.Id.ToString()))
                .ForMember(sv => sv.GenresNames, y => y.MapFrom(s => string.Join(", ", s.Genres.Select(g => g.Name))))
                .ForMember(sv => sv.Genres, y => y.Ignore())
                .ForMember(sv => sv.StoryTypes, y => y.Ignore());

            this.CreateMap<Story, StoryFilterCardViewModel>()
                .ForMember(sf => sf.Genres, y => y.MapFrom(s => s.Genres))
                .ForMember(sf => sf.StoryType, y => y.MapFrom(s => s.StoryType))
                .ForMember(sf => sf.Summary, y => y.MapFrom(s => s.StorySummary));
                
        }
    }
}
