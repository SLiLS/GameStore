using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace GameStore.DAL.EF
{
   public class Initializer : DropCreateDatabaseIfModelChanges<GameContext>
    {
        protected override void Seed(GameContext context)
        {
            context.Games.Add(new Entities.Game { GameName = "World of Warcraft", GameDescription = "World of Warcraft® is an online role-playing experience set in the award-winning Warcraft universe. Players assume the roles of Warcraft heroes as they explore, adventure, and quest across a vast world. Being Massively Multiplayer,  World of Warcraft allows thousands of players to interact within the same world.", GameCategory = "MMORPG", Price = 0 });
            context.Games.Add(new Entities.Game { GameName = "The Forest", GameDescription = "As the lone survivor of a passenger jet crash, you find yourself in a mysterious forest battling to stay alive against a society of cannibalistic .", GameCategory = "Survival", Price = 10 });
            context.Games.Add(new Entities.Game { GameName = "7 Days to die", GameDescription = "With over 2.5 million copies sold on PC (digital download) 7 Days to Die has redefined the survival genre, with unrivaled crafting and world-building content. Set in a brutally unforgiving post-apocalyptic world overrun by the undead, 7 Days to Die is an open-world game that is a unique combination of first person shooter, survival horror, tower defense, and role-playing games. It presents combat, crafting, looting, mining, exploration, and character growth, in a way that has seen a rapturous response from fans worldwide. Play the definitive zombie survival sandbox RPG that came first. Navezgane awaits!", GameCategory = "Survival", Price = 17 });
            context.Games.Add(new Entities.Game { GameName = "RESIDENT EVIL 2", GameDescription = "A deadly virus engulfs the residents of Raccoon City in September of 1998, plunging the city into chaos as flesh eating zombies roam the streets for survivors.", GameCategory = "Horror", Price = 55 });
            context.Games.Add(new Entities.Game { GameName = "Rust", GameDescription = "The only aim in Rust is to survive.To do this you will need to overcome struggles such as hunger, thirst and cold.Build a fire.Build a shelter.Kill animals for meat.Protect yourself from other players, and kill them for meat.Create alliances with other players and form a town. ", GameCategory = "Crafting", Price = 17 });
            context.Games.Add(new Entities.Game { GameName = "Hurtworld", GameDescription = "Hurtworld is a hardcore multiplayer survival FPS with a focus on deep survival progression that doesn't become trivial once you establish some basic needs. That feeling when you're freezing to death trying to make a fire, or you're defenceless being chased by creatures. These experiences are what make a survival game. When you overcome that challenge and find a level of comfort it's a great feeling, but what do you do next?", GameCategory = "Survival", Price = 13 });
        }
    }
}
