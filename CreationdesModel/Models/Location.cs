﻿using CreationdesModel.ModelView;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreationdesModel.Models
{
    public class Location
    {
        public int Id { get; set; }
        public int clientId { get; set;}
        public Client Client { get; set; }
        public int voitureId { get; set; }
        public Voiture voiture { get; set;}
        public int client_id { get; set; }
        public int voiture_id { get; set;}
        public DateTime date_debut { get; set;}
        public DateTime date_fin { get; set;}
        public bool Retour { get; set;}
        public float prix_jour { get; set;}


        public Location() { }
        public Location(LocationAddModelview locationAdd)
        {

            this.date_debut = locationAdd.datedebut;
            this.date_fin = locationAdd.datefin;
            this.prix_jour = locationAdd.prixjour;
            this.Retour = false;
            this.clientId = locationAdd.clientId;
            
        }
    }
}
