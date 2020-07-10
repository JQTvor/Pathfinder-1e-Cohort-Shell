using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cohort_Generator
{
    class BasicCharactistics
    {
        public string race { get; set; }
        public string pclass { get; set; }
        public string allignment { get; set; }

        public int[] attributes { get; set; }

        Random raceCatagory = new Random();
        Random allignSelect = new Random();

        bool skill = false;

        public string Race()
        {

        int raceClass = raceCatagory.Next(1, 21);

                if (raceClass < 18)
                {
                    Random baseRace = new Random();
                    string[] Base = { "Dwarf", "Elf", "Gnome", "Half-Elf", "Half-Orc", "Halfling", "Human" };

                    int raceSelect = baseRace.Next(0, Base.Count());


                    race = Base[raceSelect];
                    return race;
                }

                if (raceClass == 18 || raceClass == 19)
                {
                    Random standardRace = new Random();
                    string[] Standard = { "Catfolk", "Duergar", "Gnoll", "Grippli", "Goblin", "Hobgoblin", "Ifrit",
                "Kobold", "Lizardfolk", "Monkey Goblin", "Orc", "Oread", "Ratfolk", "Sylph",
                "Triaxian", "Undine", "Vanara"};


                    int raceSelect = standardRace.Next(0, Standard.Count());


                    race = Standard[raceSelect];
                    return race;

                }

                if (raceClass == 20)
                {
                    Random otherRace = new Random();
                    string[] Other = {"Aquatic Elf", "Astomoi", "Caligni", "Changling", "Deep One Hybrid",
            "Ganzi", "Gillmen", "Kitsune", "Kuru", "Merfolk", "Munavri", "Nagaji", "Orang-Pendak",
            "Reptoid", "Samsaran", "Strix", "Wayang"};

                    int raceSelect = otherRace.Next(0, Other.Count());
                    race = Other[raceSelect];
                   
                    return race;
                }

            return Race();
        }


        public string PCClass()
        {

            int raceClass = raceCatagory.Next(1, 21);

            if (raceClass < 18)
            {
                Random classSelect = new Random();

                string[] coreClass = { "Barbarian", "Bard", "Cleric", "Druid", "Fighter", "Monk", "Paladin", "Ranger", "Rogue", "Sorcerer", "Wizard" };
                int selected = classSelect.Next(0, coreClass.Count());


                pclass = coreClass[selected];
            }

            if(raceClass == 18 || raceClass == 19)
            {
                Random classSelect = new Random();
                string[] baseClass = { "Alchemist", "Cavalier", "Gunslinger", "Inquisitor", "Magus", "Monk", "Omdura", "Oracle", "Shifter", "Summoner", "Witch", "Vampire Hunter", "Vigilante" };
                int selected = classSelect.Next(0, baseClass.Count());

                pclass = baseClass[selected];
            }

            if (raceClass == 20)
            {
                Random classSelect = new Random();
                string[] hybridClass = { "Arcanist", "Bloodrager", "Brawler", "Hunter", "Investigator", "Shaman", "Skald", "Slayer", "Swashbuckler", "Warpriest" };
                int selected = classSelect.Next(0, hybridClass.Count());

                pclass = hybridClass[selected];
            }

            return pclass;
            
        }

        public string Allignment()
        {
            string[] allignOptions = { "Chaotic Evil", "Chaotic Good", "Neutral Evil", "Neutral",  "Neutral Good", "Lawful Evil", "Lawful Good" };
            int selected = allignSelect.Next(0, allignOptions.Count());

            allignment = allignOptions[selected];

            if (pclass == "Paladin")
            {
                allignment = allignOptions.Last();
            }

            if(pclass == "Monk")
            {
                int lawful = allignSelect.Next(allignOptions.Count() - 1, allignOptions.Count());
                allignment = allignOptions[lawful];
            }
                

            if(pclass == "Barbarian")
            {
                int unlawful = allignSelect.Next(allignOptions.Count() - allignOptions.Count(), allignOptions.Count() - 2);
                allignment = allignOptions[unlawful];
            }

            if(pclass == "Druid" || pclass == "Shifter" || pclass == "Hunter")
            {
                int neutral = allignSelect.Next(allignOptions.Count() - 5, allignOptions.Count() - 2);
                allignment = allignOptions[neutral];
            }

            return allignment;  
        }


        public int[] AbilityScores()
        {

            //Melee
            if (pclass == "Barbarian" || pclass == "Fighter" || pclass == "Paladin" ||
                 pclass == "Cavalier" || pclass == "Shifter" || pclass == "Monk")
            {
                int[] intAbilityScores = { 15, 13, 14, 10, 10, 8 };
                attributes = intAbilityScores;
            }

            //Ranged
            if (pclass == "Ranger" || pclass == "Rogue" || pclass == "Gunslinger")
            {
                int[] intAbilityScores = { 13, 15, 14, 12, 10, 8 };
               attributes = intAbilityScores;
            }

            //Wisdom Caster
            if (pclass == "Cleric" || pclass == "Druid" || pclass == "Shaman" || pclass == "Warpriest" ||
                pclass == "Omdura")
            {
                int[] intAbilityScores = { 12, 8, 14, 10, 15, 13 };
                attributes = intAbilityScores;
            }

            //Intelligence Caster
            if (pclass == "Wizard" || pclass == "Alchemist" || pclass == "Magus" || pclass == "Witch" ||
                pclass == "Arcanist")
            {
                int[] intAbilityScores = { 8, 14, 12, 15, 10, 13 };
                attributes = intAbilityScores;
            }

            //Charisma Caster
            if (pclass == "Bard" || pclass == "Oracle" || pclass == "Summoner" || pclass == "Bloodrager" ||
               pclass == "Skald")
            {
                int[] intAbilityScores = { 8, 14, 12, 13, 10, 15 };
                attributes = intAbilityScores;
            }

            //Skill NPC
            if(attributes == null)
            {
                skill = true;
                int[] intAbilityScores = { 12, 14, 13, 15, 8, 10 };
                attributes = intAbilityScores;

            }

            //Strength -4
            //Other Races
            if (race == "Kobold")
            {
                attributes[0] = attributes[0] - 4;
            }

            //Strength -2
            //Other Races
            if (race == "Munavri" || race == "Gnome" || race == "Halfling" || race == "Goblin" || race == "Ratfolk" ||
                race == "Undine" || race == "Triaxian" || race == "Undine" || race =="Grippli" || race == "Kitsune")
            {
                attributes[0] = attributes[0] - 2;
            }
            //Strength +2
            //Humans
            if(race == "Human" && pclass == "Barbarian" || race == "Human" && pclass == "Fighter" || 
                race == "Human" && pclass == "Paladin" || race == "Human" && pclass == "Cavalier" || 
                race == "Human" && pclass == "Shifter" || race == "Human" && pclass == "Monk" ||
                //Half-Orcs
                race == "Half-Orc" && pclass == "Barbarian" || race == "Half-Orc" && pclass == "Fighter" ||
                race == "Half-Orc" && pclass == "Paladin" || race == "Half-Orc" && pclass == "Cavalier" ||
                race == "Half-Orc" && pclass == "Shifter" || race == "Half-Orc" && pclass == "Monk" ||
                //Half-Elves
                race == "Half-Elf" && pclass == "Barbarian" || race == "Half-Elf" && pclass == "Fighter" ||
                race == "Half-Elf" && pclass == "Paladin" || race == "Half-Elf" && pclass == "Cavalier" ||
                race == "Half-Elf" && pclass == "Shifter" || race == "Half-Elf" && pclass == "Monk" ||
                //Other races
                race == "Reptoid" || race == "Orang-Pendak" || race == "Oread" || race == "Nagaji" || race == "Suli" || race == "Gnoll" || race == "Lizardfolk")
            {
                attributes[0] = attributes[0] + 2;
            }

            //Strength +4
            if(race == "Orc")
            {
                attributes[0] = attributes[0] + 4;
            }

            //Dex -2
            if (race == "Reptoid" || race == "Deep One Hybrid")
            {
                attributes[1] = attributes[1] - 2;
            }

            //Dex +2
            //Half Orc
            if (race == "Half-Orc" && pclass == "Ranger" || race == "Half-Orc" && pclass == "Rogue" || race == "Half-Orc" && pclass == "Gunslinger" ||
               //Half Elf
                race == "Half-Elf" && pclass == "Ranger" || race == "Half-Elf" && pclass == "Rogue" || race == "Half-Elf" && pclass == "Gunslinger" ||
                //Human
                race == "Human" && pclass == "Ranger" || race == "Human" && pclass == "Rogue" || race == "Human" && pclass == "Gunslinger" ||
                //Other Races
                race == "Wayang" || race == "Strix" || race == "Merfolk" || race == "Kuru" || race == "Kitsune" || race == "Caligni" || race == "Aquatic Elf" || race == "Vanara" || race == "Undine" || race == "Sylph" || race == "Elf" || race == "Halfling" || race == "Catfolk" || race == "Grippli" ||
                race == "Hobgoblin" || race == "Ifrit" || race == "Kobold" || race == "Ratfolk")
            {
                attributes[1] = attributes[1] + 2;
            }

            //Dex +4
            if (race == "Munavri" || race == "Goblin" || race == "Monkey Goblin")
            {
                attributes[1] = attributes[1] + 4;
            }

            //Con-2
            if (race == "Samsaran" || race == "Changling" || race == "Astomoi" || race == "Aquatic Elf" || race == "Sylph" || race == "Elf" || race == "Kobold")
            {
                attributes[2] = attributes[2] - 2;
            }

            //Con +2
            if (race == "Munavri" || race == "Merfolk" || race == "Kuru" || race == "Gillmen" || race == "Ganzi" || race == "Deep One Hybrid" || race == "Caligni" || race == "Triaxian" || race == "Dwarf" || race == "Gnome" || race == "Duergar" || race == "Gnoll" ||
                race == "Hobgobling" || race == "Ifrit" || race == "Lizardfolk")
            {
                attributes[1] = attributes[1] + 2;
            }

            //Int -2
            if (race == "Orang-Pendak" || race == "Nagaji" || race == "Kuru" || race == "Ganzi" || race == "Caligni" || race == "Orc")
            {
                attributes[3] = attributes[3] - 2;
            }

            //Int +2
            if (skill == true && race == "Human" || skill == true && race == "Half-Orc" || skill == true && race == "Half-Elf" ||
                race == "Half-Orc" && pclass == "Wizard" || race == "Half-Orc" && pclass == "Alchemist" || race == "Half-Orc" && pclass == "Magus" || race == "Half-Orc" && pclass == "Witch" || race == "Half-Orc" && pclass == "Arcanist" ||
                race == "Half-Elf" && pclass == "Wizard" || race == "Half-Elf" && pclass == "Alchemist" || race == "Half-Elf" && pclass == "Magus" || race == "Half-Elf" && pclass == "Witch" || race == "Half-Elf" && pclass == "Arcanist" ||
                race == "Human" && pclass == "Wizard" || race == "Human" && pclass == "Alchemist" || race == "Human" && pclass == "Magus" || race == "Human" && pclass == "Witch" || race == "Human" && pclass == "Arcanist" ||
                race == "Wayang" || race == "Samsaran" || race == "Munavri" || race == "Astomoi" || race == "Aquatic Elf" || race == "Sylph" || race == "Elf" || race == "Ratfolk")
            {
                attributes[3] = attributes[3] + 2;
            }

            //Wis -2
            if (race == "Wayang" || race == "Gillmen" || race == "Catfolk" || race == "Monkey Goblin" || race == "Orc")
            {
                attributes[4] = attributes[4] - 2;
            }

            //Wis +2
            if (race == "Half-Orc" && pclass == "Cleric" || race == "Half-Orc" && pclass == "Druid" || race == "Half-Orc" && pclass == "Shaman" || race == "Half-Orc" && pclass == "Warpriest" || race == "Half-Orc" && pclass == "Omdura" ||
                race == "Half-Elf" && pclass == "Cleric" || race == "Half-Elf" && pclass == "Druid" || race == "Half-Elf" && pclass == "Shaman" || race == "Half-Elf" && pclass == "Warpriest" || race == "Half-Elf" && pclass == "Omdura" ||
                race == "Human" && pclass == "Cleric" || race == "Human" && pclass == "Druid" || race == "Human" && pclass == "Shaman" || race == "Human" && pclass == "Warpriest" || race == "Human" && pclass == "Omdura" ||
                    race == "Samsaran" || race == "Orang-Pendak" || race == "Munavri" || race == "Deep One Hybrid" || race == "Changling" || race == "Astomoi" || race == "Vanara" || race == "Undine" || race == "Triaxian" || race == "Dwarf" || race == "Duergar" || race == "Grippli" || race == "Oread")
            {
                attributes[4] = attributes[4] + 2;
            }

            //Cha -4
            if (race == "Duergar")
            {
                attributes[5] = attributes[5] - 4;
            }

            //Cha -2
            if (race == "Strix" || race == "Vanara" || race == "Dwarf" || race == "Monkey Goblin" || race == "Goblin" || race == "Orc" || race == "Oread")
            {
                attributes[5] = attributes[5] - 2;
            }

            //Cha +2
            if (race == "Half-Orc" && pclass == "Bard" || race == "Half-Orc" && pclass == "Oracle" || race == "Half-Orc" && pclass == "Summoner" || race == "Half-Orc" && pclass == "Bloodrager" || race == "Half-Orc" && pclass == "Skald" ||
                race == "Half-Elf" && pclass == "Bard" || race == "Half-Elf" && pclass == "Oracle" || race == "Half-Elf" && pclass == "Summoner" || race == "Half-Elf" && pclass == "Bloodrager" || race == "Half-Elf" && pclass == "Skald" ||
                race == "Human" && pclass == "Bard" || race == "Human" && pclass == "Oracle" || race == "Human" && pclass == "Summoner" || race == "Human" && pclass == "Bloodrager" || race == "Human" && pclass == "Skald" ||
                race == "Reptoid" || race == "Nagaji" || race == "Munavri" || race == "Merfolk" || race == "Kitsune" || race == "Gillmen" || race == "Ganzi" || race == "Changling" || race == "Gnome" || race == "Halfling" || race == "Catfolk" )
            {
                attributes[5] = attributes[5] + 2;
            }




            return attributes;
        }

    }
}
