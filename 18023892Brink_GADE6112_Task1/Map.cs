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
        //array to store the battlefield
        public string[,] battlefield = new string[20, 20];
        //random to be used throughout the class
        Random rnd = new Random();

        public Map(int unitNo, int buildingNo)
        {
            units = new Unit[unitNo];
            buildings = new Building[buildingNo];
            unitGenerate(units.Length);
            buildingGenerate(buildings.Length);
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
                    case 0: units[i] = new MeleeUnit(newX, newY, 120, 1, tempAttack, 1, team, "💂", false, "Soldier"); break;
                    case 1: units[i] = new RangedUnit(newX, newY, 100, 1, tempAttack, 4, team, "🐎", false, "Archer"); break;
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
                    case 0: buildings[i] = new ResourceBuilding(newX, newY, 200, team, "🏭", "Resource Factory"); break;
                        //rnd next is the random gen of the unittype from the factory building (fixed)
                    case 1: buildings[i] = new FactoryBuilding(newX, newY, 200, team, "🏘️", "Unit Factory", rnd.Next(0,2)); break;
                }
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
        }


    }
}
