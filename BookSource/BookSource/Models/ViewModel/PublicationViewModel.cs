using System.Collections.Generic;

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
        public static PublicationViewModel PublicationMapper(Publication publication)
        {
            return new PublicationViewModel
            {
                IdPublication = publication.IdPublication,
                IdUser = publication.RIdUser,
                Title = publication.Title,
                Content = publication.Content,
                PubImage = publication.PubImage
            };
        }
        public static List<PublicationViewModel> ListPubMapper(List<Publication> pubList)
        {
            List<PublicationViewModel> list = new List<PublicationViewModel>();
            foreach (Publication item in pubList)
            {
                list.Add(PublicationMapper(item));
            }
            return list;
        }
    }
}
