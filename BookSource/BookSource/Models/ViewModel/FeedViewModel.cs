namespace BookSource.Models.ViewModel
{
    public class FeedViewModel
    {
        // To change to Publication View Model
        public List<Publication>? Publications { get; set; }
        public string? Content { get; set; }
        public string? OrderType { get; set; }
        public User User { get; set; }
        public List<User> Users { get; set; }
    }
}
