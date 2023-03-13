namespace CreationdesModel.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Nom { get; set; }

        public string prenom { get; set;}

        public string tel { get; set;}
        public string cin { get; set;}
        public List<Location> Locations { get; set; }
    }
}
