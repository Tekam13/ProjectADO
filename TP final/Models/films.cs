using System.ComponentModel.DataAnnotations;
using TP_final.Datas.Enums;

namespace TP_final.Models
{
    public class films
    {
        [Key]
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public DateTime debut { get; set; }
        public DateTime Fin { get; set; }
        public string prix { get; set; }
        public FilmCategorie filmCategorie { get; set; }
        public List<ActeurFilms> ActeurFilms { get; set; }
        public override string ToString()
        {
            return $"Films : {Nom} ({debut.Year}-{Fin.Year}) prix {prix}";
        }
    }
}
