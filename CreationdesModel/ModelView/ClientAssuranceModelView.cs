using CreationdesModel.Models;

namespace CreationdesModel.ModelView
{
    public class ClientAssuranceModelView: Client
    {

        public float prixTotal;

        public float getPrixTotal()
        {
            float prixtotal = 0;
            foreach(Location location in this.Locations)
            {
                int nbrAssurance = (location.date_fin - location.date_debut).Days;
                prixtotal = prixtotal+(location.prix_jour * nbrAssurance);
            }
            return prixtotal;
        }
        
        public ClientAssuranceModelView(Client c)
        {
            this.cin = c.cin;
            this.Nom = c.Nom;
            this.prenom = c.prenom;
            this.tel = c.tel;
            this.Locations=c.Locations;
            this.prixTotal = getPrixTotal();
        }
       
    }
}
