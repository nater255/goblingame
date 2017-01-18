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
            /* To-Do:
                 - Actual c# classes for PlayerClass, Goblin
                 - Methods outside main to call for actions (PlayerAttack, PlayerHeal, EnemyAttack, 
                    PlayerHealthCheck, EnemyHealthCheck,
                 - Randomize who attacks/heals first           
                 - Enemy healing                                                                  */


            Random randomAttackInt = new Random();              // Random Number Generator
            string playerClass = "";                            // Player Class
            int playerHitPoints = 0;                            // Player HP
            int goblinHitPoints = randomAttackInt.Next(2, 8);   // Enemy HP
            int goblinsKilled = 0;                              // Enemies Killed
            int hitDamage = 0;                                  // Damage 
            int damageModifier = 0;                             // Player Class Damage Bonus
            bool playerIsAlive = true;                          // Player alive/dead
            string playerAction = "";                           // Player Attack/Heal Choice

            List<string> playerAttacks = new List<string>();    // Player Class-based flavor text for attacks

            List<string> enemyReactions = new List<string>();   // Enemy Reactions flavor text
            enemyReactions.Add("The goblin screams and jumps back, but continues to attack.");
            enemyReactions.Add("The goblin falls to the ground, but quickly scrambles back to his feet, snarling.");
            enemyReactions.Add("The goblin spits blood and howls, his eyes filled with hatred.");
            enemyReactions.Add("The goblin is dazed but quickly recovers.");
            enemyReactions.Add("Black blood oozes from behind the goblins patchwork armor, his breathing ragged.");

            List<string> enemyAttacks = new List<string>();     // Enemy Attacks flavor text
            enemyAttacks.Add("The goblin lunges at you, his rusty blade connecting under your arm for");
            enemyAttacks.Add("The goblin throws a vial of black liquid. It bursts on your shoulder, sizzling and burning you for");
            enemyAttacks.Add("The goblin swings his curved sword in a reckless arc, slicing your legs for");
            enemyAttacks.Add("The goblin dances in close and lurches suddenly, scratching and biting for");
            enemyAttacks.Add("The goblin screams a horrible battlecry and lashes out with a barbed whip for");

            /* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
               ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ ACTUAL GAME CODE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
               ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
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
                playerClass = (Console.ReadLine()).ToLower();  // Force any correct spelling to lower to set class

                if (playerClass == "paladin") // PALADIN SETUP
                {
                    playerClass = "Paladin";
                    playerHitPoints = 12;
                    damageModifier = 1;
                    playerAttacks.Add("You swing your golden hammer and tense as it smashes into the goblin's unprotected face for");
                    playerAttacks.Add("You raise your hands and emit a blinding flash of light, burning the goblin for");
                    playerAttacks.Add("You bring your shield down upon the goblin's skull, crushing it for");
                    playerAttacks.Add("You invoke the power of the light, setting the goblin ablaze for");
                    playerAttacks.Add("You slam a mailed fist into the goblin's chest, cracking his ribs and dealing");
                    break;
                }
                if (playerClass == "wizard") // WIZARD SETUP
                {
                    playerClass = "Wizard";
                    playerHitPoints = 7;
                    damageModifier = 4;
                    playerAttacks.Add("Flames erupt from your hands, igniting the goblin in a crackeling blaze for");
                    playerAttacks.Add("Your fingers crackle with electricity as you grab the goblin, electrocuting him for");
                    playerAttacks.Add("You invoke a dark god in a forgotten tongue, twisted energies tear the very life from the goblin for");
                    playerAttacks.Add("Cackling maniacally, you raise your arms and the very air around the goblin combusts, burning him for");
                    playerAttacks.Add("You point a lone finger at the goblin, firing a bolt of arcane energy directly into him for");
                    break;
                }
                if (playerClass == "rogue") // ROGUE SETUP
                {
                    playerClass = "Rogue";
                    playerHitPoints = 10;
                    damageModifier = 2;
                    playerAttacks.Add("With a flick of your wrist, you launch a small dagger at the goblin. It connects for");
                    playerAttacks.Add("You grab a handful of sand from the ground, blinding the goblin then stabbing for");
                    playerAttacks.Add("You dart behind the goblin and deftly slash with your dirk for");
                    playerAttacks.Add("You dive and roll towards the goblin, slicing with a small knife for");
                    playerAttacks.Add("You run towards the goblin before dropping to one knee and kicking him for");
                    break;
                }
                if (playerClass == "monk") // MONK SETUP
                {
                    playerClass = "Monk";
                    playerHitPoints = 9;
                    damageModifier = 3;
                    playerAttacks.Add("Focusing your inner energies, you release a wave of chi that hits for");
                    playerAttacks.Add("You chant an ancient mantra and fire a dazzling light, burning for");
                    playerAttacks.Add("You leap in the air and deliver a devastating kick to the goblin's head for");
                    playerAttacks.Add("You throw your weight into a powerful punch to the goblin's torso for");
                    playerAttacks.Add("Your fists become a blur as you pummel the goblin for");
                    break;
                }
            }

            Console.WriteLine($"\n You are a mighty {playerClass} and have {playerHitPoints} health. Your attacks deal {damageModifier} bonus damage.\n");
            Console.WriteLine($" You are attacked by a band of goblins. What will you do, {playerClass}?");

            while (playerIsAlive)
            {
                Console.WriteLine("  ____________         __________");
                Console.WriteLine($" |            |\\      |          |\\      [Player HP: {playerHitPoints}]");
                Console.WriteLine(" |   ATTACK   | |     |   HEAL   | |");
                Console.WriteLine($" |____________| |     |__________| |     [Enemy HP: {goblinHitPoints}]");
                Console.WriteLine("  \\____________\\|      \\__________\\|\n");
                while (true)
                {
                    playerAction = (Console.ReadLine()).ToLower();

                    if (playerAction == "attack")     // ATTACK LOOP
                    {
                        hitDamage = (randomAttackInt.Next(1, 4));
                        Console.WriteLine($"\n {enemyAttacks[randomAttackInt.Next(1, 5)]} {hitDamage} damage!\n");
                        playerHitPoints -= hitDamage;
                        if (playerHitPoints <= 0)
                        {
                            Console.WriteLine($" You fall to your knees as the last of your strength leaves you.\n");
                            playerIsAlive = false;
                            break;
                        }

                        hitDamage = (randomAttackInt.Next(1, 6) + damageModifier);
                        Console.WriteLine($" {playerAttacks[randomAttackInt.Next(0, 5)]} {hitDamage} damage!\n");
                        goblinHitPoints -= hitDamage;
                        if (goblinHitPoints <= 0)
                        {
                            goblinsKilled += 1;
                            Console.WriteLine($" The goblin falls to the ground dead, but another rushes forward to take his place!");
                            goblinHitPoints = randomAttackInt.Next(2, 8);
                            break;
                        }
                        else
                        {
                            Console.WriteLine($" {enemyReactions[randomAttackInt.Next(0, 5)]}");
                        }
                    }

                    else if (playerAction == "heal")      // HEAL LOOP
                    {
                        hitDamage = randomAttackInt.Next(1, 5);
                        playerHitPoints += hitDamage;
                        Console.WriteLine($" You pop the cork on a vial of red liquid and swallow it greedily, healing yourself for {hitDamage}. You now have {playerHitPoints} health.");

                        hitDamage = randomAttackInt.Next(1, 4);
                        Console.WriteLine($"\n {enemyAttacks[randomAttackInt.Next(1, 5)]} {hitDamage} damage.\n");
                        playerHitPoints -= hitDamage;
                        if (playerHitPoints <= 0)
                        {
                            Console.WriteLine($" You fall to your knees as the last of your strength leaves you.");
                            playerIsAlive = false;
                            break;
                        }
                    }
                    break;
                }
            }
            Console.WriteLine(" ____________________________________________________________________________");
            Console.WriteLine($@"
 You fought valiantly, {playerClass}, but the goblin horde was too strong. Countless
 goblins overrun you, cursing and taunting in their guttural tongue. As the world
 fades to black, you realize you never truly had a chance against such odds. None
 can doubt that you were brave, but they were legion...          
                                                                            
                                                                            
                    ___                                            
                   |   |                                            
                   |   |                                            
              _____|   |_____                                      
             |               |                                      
             |_____     _____|                                      
                   |   |                  {goblinsKilled} Goblins Killed       
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
