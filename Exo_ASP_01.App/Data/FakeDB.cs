using Exo_ASP_01.App.Models;

namespace Exo_ASP_01.App.Data
{
    public static class FakeDB
    {
        private static IList<Game> _Games = new List<Game>()
        {
            new Game()
            {
                Id = 1,
                Name = "Borderlands 2",
                Description = "Borderlands 2 is a 2012 first-person shooter video game developed by Gearbox Software and published by 2K Games. Taking place five years following the events of Borderlands (2009), the game is once again set on the planet of Pandora. The story follows a new group of Vault Hunters who must ally with the Crimson Raiders, a resistance group made up of civilian survivors and guerrilla fighters, to defeat the tyrannical Handsome Jack before he can unlock the power of a new Vault. The game features the ability to explore the in-game world and complete both main missions and optional side quests, either in offline splitscreen, single-player or online cooperative gameplay. Like its predecessor, the game features a procedurally generated loot system which is capable of generating numerous combinations of weapons and other gear.",
                Genres = new List<GameGenre>()
                {
                    new GameGenre()
                    {
                        Id = 1,
                        Name = "FPS",
                        Description = "First-person shooter"
                    },
                    new GameGenre()
                    {

                        Id = 2,
                        Name = "Action-RPG",
                        Description = "Action role-playing"
                    }
                },
                Price = 9.99,
                ReleaseYear = 2012,
                PEGI = "18",
                ImgSrc = "/images/Borderlands_2.png"
            },
            new Game()
            {
                Id = 2,
                Name = "Call of Duty: Vanguard",
                Description = null,
                Genres= new List<GameGenre>()
                {
                    new GameGenre()
                    {
                        Id = 1,
                        Name = "FPS",
                        Description = "First-person shooter"
                    }
                },
                ReleaseYear = 2021,
                Price = 79.99,
                PEGI = "18",
                ImgSrc = "/images/call-of-duty-vanguard.jpg"
            },
            new Game()
            {
                Id = 3,
                Name = "Super Mario Galaxy",
                Description = "Un jeu avec Mario :o",
                Genres= new List<GameGenre>()
                {
                    new GameGenre()
                    {
                        Id = 3,
                        Name = "Plates-formes",
                        Description = null
                    }
                },
                ReleaseYear = 2007,
                Price = 25.99,
                PEGI = "3+",
                ImgSrc = "/images/mario_galaxy.jpg"
            },
            new Game()
            {
                Id = 4,
                Name = "Pong",
                Description = "| •  |",
                Genres= new List<GameGenre>()
                {
                    new GameGenre()
                    {
                        Id = 5,
                        Name = "Sport",
                        Description = null
                    }
                },
                ReleaseYear = 1972,
                Price = 0,
                PEGI = "0+",
                ImgSrc = null
            }
        };
        private static int _LastId = 4;

        public static IEnumerable<Game> GetGames()
        {
            return _Games.Select(game => new Game()
            {
                Id = game.Id,
                Name = game.Name,
                Description = game.Description,
                Genres = game.Genres,
                Price = game.Price,
                ReleaseYear = game.ReleaseYear,
                PEGI = game.PEGI,
                ImgSrc = game.ImgSrc
            });
        }

        public static Game? GetGameById(int id)
        {
            Game? result = _Games.SingleOrDefault(g => g.Id == id);

            if (result == null)
                return null;

            return new Game()
            {
                Id = result.Id,
                Name = result.Name,
                Description = result.Description,
                Genres = result.Genres,
                Price = result.Price,
                ReleaseYear = result.ReleaseYear,
                PEGI = result.PEGI,
                ImgSrc = result.ImgSrc
            };
        }

        public static int? InsertGame(Game game)
        {
            if (_Games.FirstOrDefault(g => string.Compare(g.Name, game.Name, true) == 0) != null)
            {
                return null;
            }

            _LastId++;

            _Games.Add(new Game()
            {
                Id = _LastId,
                Name = game.Name,
                Description = game.Description,
                Genres = game.Genres,
                Price = game.Price,
                ReleaseYear = game.ReleaseYear,
                PEGI = game.PEGI,
                ImgSrc = game.ImgSrc
            });

            return _LastId;
        }
    }
}
