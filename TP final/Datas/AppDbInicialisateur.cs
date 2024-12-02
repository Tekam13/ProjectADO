using TP_final.Datas.Enums;
using TP_final.Models;

namespace TP_final.Datas
{
    public class AppDbInicialisateur
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AddDbContext>();
                context.Database.EnsureCreated();

                //Acteur
                if(!context.Acteurs.Any())
                {
                    context.Acteurs.AddRange(new List<Acteur>()
                    {
                        new Acteur()
                        {
                            Nom="Acteur1",
                            Photo="https://i.pinimg.com/564x/4e/3c/d7/4e3cd7703945d70ab16cbad1ef18feb7.jpg",
                            bibloigraphie="Information sur l'acteur"
                        },
                        new Acteur()
                        {
                            Nom="Acteur2",
                            Photo="http://dotnothow.net/images/actors/actor-1.jpeg",
                            bibloigraphie="Information sur l'acteur"
                        },
                        new Acteur()
                        {
                            Nom="Acteur3",
                            Photo="https://i.pinimg.com/736x/d3/7a/4f/d37a4f32aa5318f17ca6616d7b728b77.jpg",
                            bibloigraphie="Information sur l'acteur"
                        },
                    });
                    context.SaveChanges();
                }
                //Film
                if (!context.Films.Any())
                {
                    context.Films.AddRange(new List<films>()
                    {
                        new films()
                        {
                            Nom="Film 1",
                            Description="Description 1",
                            Photo="https://images.pexels.com/photos/2527491/pexels-photo-2527491.jpeg?auto=compress&cs=tinysrgb&w=400",
                            debut=DateTime.Now.AddDays(-10),
                            Fin=DateTime.Now.AddDays(-2),
                            prix="12.96",
                            filmCategorie = FilmCategorie.Documentation,
                        },
                        new films()
                        {
                            Nom="Film 2",
                            Description="Description 2",
                            Photo="https://images.pexels.com/photos/2119953/pexels-photo-2119953.png?auto=compress&cs=tinysrgb&w=400",
                            debut=DateTime.Now.AddDays(-10),
                            Fin=DateTime.Now.AddDays(-2),
                            prix="12.96",
                            filmCategorie = FilmCategorie.Horreur,
                        },
                        new films()
                        {
                            Nom="Film 3",
                            Description="Description 3",
                            Photo="https://images.pexels.com/photos/1870320/pexels-photo-1870320.jpeg?auto=compress&cs=tinysrgb&w=400",
                            debut=DateTime.Now.AddDays(-10),
                            Fin=DateTime.Now.AddDays(-2),
                            prix="12.96",
                            filmCategorie = FilmCategorie.Animation,
                        },
                    });
                    context.SaveChanges();
                }
                //Acteur && Film
                if (!context.Acteurs_Films.Any())
                {
                    context.Acteurs_Films.AddRange(new List<ActeurFilms>()
                    {
                        new ActeurFilms()
                        {
                            ActeurId = 1,
                            FilmId= 4,
                        },
                        new ActeurFilms()
                        {
                            ActeurId = 2,
                            FilmId= 5,
                        },
                        new ActeurFilms()
                        {
                            ActeurId = 3,
                            FilmId= 6,
                        },
                    });
                    //context.SaveChanges();
                }
            }
        }
    }
}
