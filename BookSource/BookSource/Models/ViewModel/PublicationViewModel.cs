namespace BookSource.Models.ViewModel
{
    public class PublicationViewModel
    {

        public int IdPublication { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        public string? PubImage { get; set; }
        public required int IdUser { get; set; }
        public int likes { get; set; }
        public static PublicationViewModel UserMapper(Publication publication)
        {
            return new PublicationViewModel
            {
                IdUser = publication.RIdUser,
                Title = publication.Title,
                Content = publication.Content,
                PubImage = publication.PubImage,
                //likes = _
            };
        }
    }
}
