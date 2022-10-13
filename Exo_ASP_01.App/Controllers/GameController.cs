using Exo_ASP_01.App.Data;
using Exo_ASP_01.App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exo_ASP_01.App.Controllers
{
    public class GameController : Controller
    {
        [ViewData]
        public string Title { get; set; }


        public IActionResult Index()
        {
            // Modification du titre de la page
            Title = "Liste";  // Equivalent à → ViewData["Title"] = "...";

            // Récuperation des données de la « DB »
            IEnumerable<Game> games = FakeDB.GetGames();

            // Génération de la vue avec les données necessaires
            return View(games);
        }

        public IActionResult Detail(int id)
        {
            //Récuperation du jeu
            Game? game = FakeDB.GetGameById(id);

            // Envoi d'une erreur 404 si le jeu n'est pas trouvé
            if(game is null)
            {
                return NotFound();
            }

            // Définition du title de la page
            Title = "Detail de " + game.Name;

            // Génération d'une vue pour un jeu
            return View(game);
        }
    }
}
