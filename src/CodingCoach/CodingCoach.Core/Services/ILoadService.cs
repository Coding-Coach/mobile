using System.Reflection;

namespace CodingCoach.Core.Services
{
   public interface ILoadService
   {
      string GetTextFromEmbeddedResource( string filename );
   }

   public class LoadService : ILoadService
   {
      public string GetTextFromEmbeddedResource( string filename )
      {
         var assembly = typeof(LoadService).GetTypeInfo().Assembly;
         var stream   = assembly.GetManifestResourceStream( "CodingCoach.Core." + filename );
         var text     = "";
         if ( stream == null )
            return text;
         using ( var reader = new System.IO.StreamReader( stream ) )
         {
            text = reader.ReadToEnd();
         }
         return text;
      }
   }
}