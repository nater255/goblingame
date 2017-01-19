using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goblins.Characters
{
    public class Adventurer
    {
        public string playerClass = "";                             // Class Name
        public int hitPoints = 0;                                   // HP  
        public int damageModifier = 0;                              // Bonus Damage
        public int goblinsKilled = 0;                               // Enemies Killed
        public bool isAlive = true;                                 // Alive?
        public List<string> attackFlavorText = new List<string>();  // Attack Flavor Text List
        public Random playerRNG = new Random();                     // RNG 

        public void ChooseRole(string roleName)                     // Set Player's Role and Stats
        {
            if (roleName == "paladin")
            {
                playerClass = "Paladin";
                hitPoints = 12;
                damageModifier = 1;
                attackFlavorText.Add("You swing your golden hammer and tense as it smashes into the goblin's unprotected face for");
                attackFlavorText.Add("You raise your hands and emit a blinding flash of light, burning the goblin for");
                attackFlavorText.Add("You bring your shield down upon the goblin's skull, crushing it for");
                attackFlavorText.Add("You invoke the power of the light, setting the goblin ablaze for");
                attackFlavorText.Add("You slam a mailed fist into the goblin's chest, cracking his ribs and dealing");
            }
            if (roleName == "wizard")
            {
                playerClass = "Wizard";
                hitPoints = 7;
                damageModifier = 5;
                attackFlavorText.Add("Flames erupt from your hands, igniting the goblin in a crackeling blaze for");
                attackFlavorText.Add("Your fingers crackle with electricity as you grab the goblin, electrocuting him for");
                attackFlavorText.Add("You invoke a dark god in a forgotten tongue, twisted energies tear the very life from the goblin for");
                attackFlavorText.Add("Cackling maniacally, you raise your arms and the very air around the goblin combusts, burning him for");
                attackFlavorText.Add("You point a lone finger at the goblin, firing a bolt of arcane energy directly into him for");
            }
            if (roleName == "rogue")
            {
                playerClass = "Rogue";
                hitPoints = 10;
                damageModifier = 2;
                attackFlavorText.Add("With a flick of your wrist, you launch a small dagger at the goblin. It connects for");
                attackFlavorText.Add("You grab a handful of sand from the ground, blinding the goblin then stabbing for");
                attackFlavorText.Add("You dart behind the goblin and deftly slash with your dirk for");
                attackFlavorText.Add("You dive and roll towards the goblin, slicing with a small knife for");
                attackFlavorText.Add("You run towards the goblin before dropping to one knee and kicking him for");
            }
            if (roleName == "monk")
            {
                playerClass = "Monk";
                hitPoints = 9;
                damageModifier = 3;
                attackFlavorText.Add("Focusing your inner energies, you release a wave of chi that hits for");
                attackFlavorText.Add("You chant an ancient mantra and fire a dazzling light, burning for");
                attackFlavorText.Add("You leap in the air and deliver a devastating kick to the goblin's head for");
                attackFlavorText.Add("You throw your weight into a powerful punch to the goblin's torso for");
                attackFlavorText.Add("Your fists become a blur as you pummel the goblin for");
            }


        }

        public string AttackText()                                  // Return random attack flavor text
        {
            string randomAttack = attackFlavorText[playerRNG.Next(0, 5)];
            return randomAttack;
        }

        public int GiveDamage()                                     // Player Attacks, returns damage to goblin (int)
        {
            int damageGiven = (playerRNG.Next(1, 6) + damageModifier);
            Console.WriteLine($" {AttackText()} {damageGiven} damage!\n");
            return damageGiven;
        }

        public int TakeDamage()                                     // Player takes damage, returns isAlive (bool)
        {
            int damageIn = playerRNG.Next(1, 4);
            hitPoints -= damageIn;
            if (hitPoints <= 0)
            {
                isAlive = false;
            }
            return damageIn;
        }

        public void GetHeal()                                       // Player Heals
        {
            int amountHealed = playerRNG.Next(1, 5);
            hitPoints += amountHealed;
            Console.WriteLine($" You pop the cork on a vial of red liquid and swallow it greedily, healing yourself for {amountHealed}. You now have {hitPoints} health.");
        }

        public bool HasDied()                                       // Check if dead
        {
            if (hitPoints <= 0)
            {
                Console.WriteLine(" You fall to your knees as the last of your strength leaves you.\n");
                return true;
            }
            return false;
        }
    }
}
