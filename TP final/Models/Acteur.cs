using System.ComponentModel.DataAnnotations;

namespace TP_final.Models
{
    public class Acteur
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Photo de profile")]
        [Required(ErrorMessage = "La photo est requise")]
        public string Photo { get; set; }
        [Required(ErrorMessage ="Le Nom est requis")]
        [StringLength(50, MinimumLength =2, ErrorMessage ="Le nom doit etre compris entre 2 et 50")]
        public string Nom { get; set; }
        [Required(ErrorMessage = "La bibloigraphie est requise")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "La bibloigraphie doit etre compris entre 2 et 100")]
        public string bibloigraphie { get; set; }
        public List<ActeurFilms> ActeurFilms { get; set; }

        public override string ToString()
        {
            return $"Acteur : {Nom} , {bibloigraphie}";
        }
    }
}
