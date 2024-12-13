namespace BookSource.Models.ViewModel
{
    public class ReviewViewModel
    {
        public required string Comment { get; set; }
        public required string UserName { get; set; }
        public string? UserImgUrl { get; set; }

    }
}
