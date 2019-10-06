using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _18023892Brink_GADE6112_Task1
{
    class Map
    {
        //array to store the seperate units
        public Unit[] units;
        //array to store the seperate buildings
        public Building[] buildings;
        //array to store the seperate wizards
        public WizardUnit[] wizard;
        //array to store the battlefield
        public string[,] battlefield = new string[20, 20];
        //random to be used throughout the class
        Random rnd = new Random();

        //added the wizard
        public Map(int unitNo, int buildingNo, int wizNo)
        {
            units = new Unit[unitNo];
            buildings = new Building[buildingNo];
            wizard = new WizardUnit[wizNo];
            unitGenerate(units.Length);
            buildingGenerate(buildings.Length);
            wizGenerate(wizard.Length);
        }

        //method to randomly generate battlefield with units
        public void unitGenerate (int unitNo)
        {
            for (int i = 0; i < unitNo; i++)
            {
                //random position for units (x value)
                int newX = rnd.Next(0, 20);
                //random position for units(x value)
                int newY = rnd.Next(0, 20);
                //mod function that checks if i is odd or even (to switch between teams)
                int team = i % 2;
                //declaring tempattack (attack strength)
                int tempAttack = 0;
                //switch to determine which attack strength will be used (using rnd to randomise the case)
                switch (rnd.Next(0,4))
                {
                    case 0: tempAttack = 5; break;
                    case 1: tempAttack = 10; break;
                    case 2: tempAttack = 15; break;
                    case 3: tempAttack = 20; break;
                }
                //switch to determine which unit type will spawn (using rnd)
                switch (rnd.Next(0, 2))
                {
                    case 0: units[i] = new MeleeUnit(newX, newY, 120, 1, tempAttack, 1, team, "💂", false, "Soldier",120); break;
                    case 1: units[i] = new RangedUnit(newX, newY, 100, 1, tempAttack, 4, team, "🐎", false, "Archer", 120); break;
                }
                
            }
        }

        public void buildingGenerate(int buildingNo)
        {
            for (int i = 0; i < buildingNo; i++)
            {
                //random position for units (x value)
                int newX = rnd.Next(0, 20);
                //random position for units(x value)
                int newY = rnd.Next(0, 20);
                //mod function that checks if i is odd or even (to switch between teams)
                int team = i % 2;
                string buildType = "";
                //switch to determine which attack strength will be used (using rnd to randomise the case)
                switch (rnd.Next(0, 3))
                {
                    case 0: buildType = "Iron"; break;
                    case 1: buildType = "Gold"; break;
                    case 2: buildType = "Stone"; break;
                }
                switch (rnd.Next(0, 2))
                {
                    case 0: buildings[i] = new ResourceBuilding(newX, newY, 200, team, "🏭", "Resource Factory", 1000, 200); break;
                        //rnd next is the random gen of the unittype from the factory building (fixed)
                    case 1: buildings[i] = new FactoryBuilding(newX, newY, 200, team, "🏘️", "Unit Factory", rnd.Next(0,2), 200); break;
                }
            }
        }

        //method to randomly generate battlefield with units
        public void wizGenerate(int wizNo)
        {
            for (int i = 0; i < wizNo; i++)
            {
                //random position for units (x value)
                int newX = rnd.Next(0, 20);
                //random position for units(x value)
                int newY = rnd.Next(0, 20);
                //declaring tempattack (attack strength)
                int tempAttack = 0;
                //switch to determine which attack strength will be used (using rnd to randomise the case)
                switch (rnd.Next(0, 4))
                {
                    case 0: tempAttack = 10; break;
                    case 1: tempAttack = 20; break;
                    case 2: tempAttack = 30; break;
                    case 3: tempAttack = 40; break;
                }
                wizard[i] = new WizardUnit(newX, newY, 80, 1, tempAttack, 1, 2, "🧙", false, "Wizard", 80);
            }
        }

        //a save method that will be used in game engine to the be used in the form
        public void Save()
        {
            //clearing the text file (previous save)
            File.Create(Environment.CurrentDirectory + "/RangedUnitSave.txt").Close();
            File.Create(Environment.CurrentDirectory + "/MeleeUnitSave.txt").Close();
            File.Create(Environment.CurrentDirectory + "/ResourceBuildingSave.txt").Close();
            File.Create(Environment.CurrentDirectory + "/FactoryBuildingSave.txt").Close();
            File.Create(Environment.CurrentDirectory + "/WizardSave.txt").Close();

            //for each unit, call the save method from that class
            foreach (Unit u in units)
            {
                u.Save();
            }
            //for each building, call the save method from that class
            foreach (Building b in buildings)
            {
                b.Save();
            }
            foreach (WizardUnit w in wizard)
            {
                w.Save();
            }
        }
        //a method to load the info from the save files
        public void Load()
        {
            //lists to temporarily store the variables (will move to arrays at the end)
            List<Unit> loadUnits = new List<Unit>();
            List<Building> loadBuildings = new List<Building>();

            //RANGEDUNITS
            //a string array that reads and stores all the text
            string[] rangeArr = File.ReadAllLines(@"RangedUnitSave.txt");
            //a for each loop that runs through the lines in the array and splits them at the end of a line
            foreach (string line in rangeArr)
            {
                line.Split('\n');
            }
            //foreach to split at comma and add to list
            foreach (string line in rangeArr)
            {
                //splitting at the comma
                string[] arrAttributes = line.Split(',');
                //0= team, 1= x, 2= y, 3= health, 4= attack
                //adding units to list
                loadUnits.Add(new RangedUnit(Int32.Parse(arrAttributes[1]), Int32.Parse(arrAttributes[2]), Int32.Parse(arrAttributes[3]), 1, Int32.Parse(arrAttributes[4]), 4, Int32.Parse(arrAttributes[0]), "🐎", false, "Archer", 100));
            }

            //MELEEUNITS
            //a string array that reads and stores all the text
            string[] meleeArr = File.ReadAllLines(@"MeleeUnitSave.txt");
            //splits the stream to a string array
            foreach (string line in meleeArr)
            {
                line.Split('\n');
            }
            foreach (string line in meleeArr)
            {
                //splitting at the comma
                string[] arrAttributes = line.Split(',');
                //0= team, 1= x, 2= y, 3= health, 4= attack
                //adding units to list
                loadUnits.Add(new MeleeUnit(Int32.Parse(arrAttributes[1]), Int32.Parse(arrAttributes[2]), Int32.Parse(arrAttributes[3]), 1, Int32.Parse(arrAttributes[4]), 1, Int32.Parse(arrAttributes[0]), "💂", false, "Soldier", 120));
            }

            //WIZARDS
            //a string array that reads and stores all the text
            string[] wizArr = File.ReadAllLines(@"WizardSave.txt");
            //splits the stream to a string array
            foreach (string line in wizArr)
            {
                line.Split('\n');
            }
            foreach (string line in wizArr)
            {
                //splitting at the comma
                string[] arrAttributes = line.Split(',');
                //0= team, 1= x, 2= y, 3= health, 4= attack
                //adding units to list
                loadUnits.Add(new WizardUnit(Int32.Parse(arrAttributes[1]), Int32.Parse(arrAttributes[2]), Int32.Parse(arrAttributes[3]), 1, Int32.Parse(arrAttributes[4]), 1, Int32.Parse(arrAttributes[0]), "🧙", false, "Wizard", 80));
            }

            //FACTORYBULDING
            //a string array that reads and stores all the text
            string[] factoryArr = File.ReadAllLines(@"FactoryBuildingSave.txt");
            //splits the stream to a string array
            foreach (string line in factoryArr)
            {
                line.Split('\n');
            }
            foreach (string line in factoryArr)
            {
                //splitting at the comma
                string[] arrAttributes = line.Split(',');
                //0= team, 1= x, 2= y, 3= health, 4= unit type
                //adding buildings to list
                loadBuildings.Add(new FactoryBuilding(Int32.Parse(arrAttributes[1]), Int32.Parse(arrAttributes[2]), Int32.Parse(arrAttributes[3]), Int32.Parse(arrAttributes[0]), "🏘️", "Unit Factory", Int32.Parse(arrAttributes[4]), 200));
            }

            //RESOURCEBUILDING
            //a string array that reads and stores all the text
            string[] resourceArr = File.ReadAllLines(@"ResourceBuildingSave.txt"); ;
            //splits the stream to a string array
            foreach (string line in resourceArr)
            {
            //splitting at the comma
            string[] arrAttributes = line.Split(',');
            //0= team, 1= x, 2= y, 3= health, 4= res remaining
            //adding buildings to list
            loadBuildings.Add(new ResourceBuilding(Int32.Parse(arrAttributes[1]), Int32.Parse(arrAttributes[2]), Int32.Parse(arrAttributes[3]), Int32.Parse(arrAttributes[0]), "🏭", "Resource Factory", Int32.Parse(arrAttributes[4]), 200));
            }
            //changing lists to arrays, and making those arrays equal to the units and buildings array
            units = loadUnits.ToArray();
            buildings = loadBuildings.ToArray();
        }
    }
}
