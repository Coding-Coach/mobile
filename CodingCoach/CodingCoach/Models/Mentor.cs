using System.Collections.ObjectModel;
using CodingCoach.DotNetClient.Models;

namespace CodingCoach.Models
{
   public class MentorDto
   {
      public string                        Id                 { get; set; }
      public string                        Name               { get; set; }
      public string                        Avatar             { get; set; }
      public string                        Title              { get; set; }
      public string                        Description        { get; set; }
      public string                        Country            { get; set; }
      public ObservableCollection<string>  Tags               { get; set; }
      public ObservableCollection<Channel> Channels           { get; set; }
      public string                        CountryImageSource => $"https://www.countryflags.io/{Country}/flat/32.png";
      public bool                          IsFavorite         { get; set; }
      public string FavoriteColor => IsFavorite
                                        ? "Red"
                                        : "Gray";
   }

   public class Channel
   {
      public string Type { get; set; }
      public string Id   { get; set; }
   }

   public static class MentorMapper
   {
       public static MentorDto ToMentorDto(this Mentor mentor)
       {
           var mentorDto = new MentorDto();

           mentorDto.Name = mentor.Name;

           return mentorDto;
       }
   }
}