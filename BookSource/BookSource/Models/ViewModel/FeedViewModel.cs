namespace BookSource.Models.ViewModel
{
    public class FeedViewModel
    {
        // To change to Publication View Model
        public List<Models.ViewModel.PublicationViewModel>? Publications { get; set; }
        public string? Title { get; set; }
        public string? OrderType { get; set; }
        public User? User { get; set; }      // El usuario seleccionado
        public int? IdUser { get; set; }
        public List<User> Users { get; set; }   // Todos los users para el combobox
        
        public List<PublicationLikes>? PublicationsLikes { get; set; } // Todas las relaciones de likes con users para mapearlas
    }
}
