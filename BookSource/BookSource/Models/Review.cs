namespace BookSource.Models
{
    public class Review
    {
        public required int IdReview { get; set; }
        public required string Comment { get; set; }
        public required int RIdBook {  get; set; }
        public required int RIdUser {  get; set; }

    }
}
