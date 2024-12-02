namespace TP_final.Models
{
    public class ActeurFilms
    {
        public int ActeurId{get; set;}
        public Acteur Acteur { get; set; } = new Acteur();
        public int FilmId{ get; set; }
        public films films { get; set; } = new films();
    }
}
