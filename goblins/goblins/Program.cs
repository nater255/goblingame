using goblins.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goblins
{
    class Program
    {
        static void Main(string[] args)
        {
            Adventurer player = new Adventurer();
            Enemy goblin = new Enemy();

            Random goblinRandomizer = new Random();             // Random Number Generator
            int hitDamage = 0;                                  // Damage 
            string playerAction = "";                           // Player Attack/Heal Choice

            Console.WriteLine("  _________________________________________________________________________________ ");
            Console.WriteLine(" |                                                                                 |\\");
            Console.WriteLine(" |            [GENERIC FANTASY GAME WHERE GOBLINS ARE MEAN TO YOU]                 | |");
            Console.WriteLine(" |_________________________________________________________________________________| |");
            Console.WriteLine("  \\_________________________________________________________________________________\\|\n");
            Console.WriteLine("          Greetings, adventurer! Choose your class before you embark...        ");
            Console.WriteLine("  _______________        ______________         _____________         _____________ ");
            Console.WriteLine(" |               |\\     |              |\\      |             |\\      |             |\\");
            Console.WriteLine(" |    PALADIN    | |    |    WIZARD    | |     |    ROGUE    | |     |    MONK     | |");
            Console.WriteLine(" | HP:12  Atk: 1 | |    | HP:7  Atk: 5 | |     | HP:10 Atk:2 | |     | HP:9 Atk:3  | |");
            Console.WriteLine(" |_______________| |    |______________| |     |_____________| |     |_____________| |");
            Console.WriteLine("  \\_______________\\|     \\______________\\|      \\_____________\\|      \\_____________\\|\n");

            while (true)
            {
                player.ChooseRole((Console.ReadLine()).ToLower());
                if (player.playerClass != "")
                {
                    break;
                }
            }

            Console.WriteLine($"\n You are a mighty {player.playerClass} and have {player.hitPoints} health. Your attacks deal {player.damageModifier} bonus damage.\n");
            Console.WriteLine($" You are attacked by a band of goblins. What will you do, {player.playerClass}?");
            goblin.SetUp();

            while (player.isAlive)
            {
                Console.WriteLine("  ____________         __________");
                Console.WriteLine($" |            |\\      |          |\\      [Player HP: {player.hitPoints}]");
                Console.WriteLine(" |   ATTACK   | |     |   HEAL   | |");
                Console.WriteLine($" |____________| |     |__________| |     [Enemy HP: {goblin.hitPoints}]");
                Console.WriteLine("  \\____________\\|      \\__________\\|\n");
                while (true)
                {
                    playerAction = (Console.ReadLine()).ToLower();
                    if (playerAction == "attack")
                    {
                        hitDamage = player.TakeDamage();
                        Console.WriteLine($"\n {goblin.Attack()} {hitDamage} damage!\n");
                        if (player.HasDied())
                        {
                            break;
                        }

                        if (goblin.TakeDamage(player.GiveDamage())) // Player attacks, Goblin Takes Damage, Is Goblin dead?
                        {
                            goblin.NewGoblin();
                            player.goblinsKilled += 1;
                            break;
                        }
                        else
                        {
                            goblin.React();
                        }
                    }

                    else if (playerAction == "heal")
                    {
                        player.GetHeal();

                        hitDamage = player.TakeDamage();
                        Console.WriteLine($"\n {goblin.Attack()} {hitDamage} damage!\n");
                        if (player.HasDied())
                        {
                            break;
                        }
                    }
                    break;
                }
            }
            Console.WriteLine(" ____________________________________________________________________________");
            Console.WriteLine($@"
 You fought valiantly, {player.playerClass}, but the goblin horde was too strong. Countless
 goblins overrun you, cursing and taunting in their guttural tongue. As the world
 fades to black, you realize you never truly had a chance against such odds. None
 can doubt that you were brave, but they were legion...          
                                                                            
                                                                            
                    ___                                            
                   |   |                                            
                   |   |                                            
              _____|   |_____                                      
             |               |                                      
             |_____     _____|                                      
                   |   |                  {player.goblinsKilled} Goblins Killed       
                   |   |                                            
                   |   |                          O                      
                   |   |                          |                      
             ______|   |______                 o__|__o                   
            |                 |                  | |                     
            |                 |                  | |                     
 ___________|                 |__________________|_|_________________________");
            Console.ReadLine();

        }
    }
}
