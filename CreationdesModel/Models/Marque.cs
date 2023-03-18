namespace CreationdesModel.Models
{
    public class Marque
    {
        public int? Id { get; set; }
        public string Libelle { get; set;}
        public List<Voiture>? Voitures { get; set;}
        public static List<Marque> getAll(Mycontext db)
        {
            return db.marques.ToList();
        }
    }
}
