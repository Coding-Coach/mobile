using System.Collections.ObjectModel;

namespace CodingCoach.Core.Services
{
   public class Mentor
   {
      public string                       Id          { get; set; }
      public string                       Name        { get; set; }
      public string                       Avatar      { get; set; }
      public string                       Title       { get; set; }
      public string                       Description { get; set; }
      public string                       Country     { get; set; }
      public ObservableCollection<string> Tags        { get; set; }
      public Channel[ ]                   Channels    { get; set; }
   }

   public class Channel
   {
      public string Type { get; set; }
      public string Id   { get; set; }
   }
}