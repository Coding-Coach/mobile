namespace CodingCoach.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        Contact,
        Logout
    }

    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}