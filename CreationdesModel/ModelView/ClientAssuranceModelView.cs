using CreationdesModel.Models;

namespace CreationdesModel.ModelView
{
    public class ClientAssuranceModelView: Client
    {

        public float prixTotal;

        public float getPrixTotal()
        {
            float prixtotal = 0;
            
            return prixtotal;
        }
        
        public ClientAssuranceModelView(Client c)
        {
            this.cin = c.cin;
            this.Nom = c.Nom;
            this.prenom = c.prenom;
            this.tel = c.tel;
            foreach (Location location in c.Locations)
            {
                int nbrAssurance = (location.date_fin - location.date_debut).Days;
                float prix = location.prix_jour * nbrAssurance;
                this.prixTotal = this.prixTotal + prix;
            }
        }
       
    }
}
