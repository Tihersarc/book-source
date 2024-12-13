namespace BookSource.Models.ViewModel
{
    public class FeedViewModel
    {
        // To change to Publication View Model
        public List<Publication>? Publications { get; set; }
        public string? Title { get; set; }
        public string? OrderType { get; set; }
        public User User { get; set; }      // El usuario seleccionado
        public List<User> Users { get; set; }   // Todos los users para el combobox
    }
}
