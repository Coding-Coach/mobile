namespace CodingCoach.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        Contact
    }

    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}