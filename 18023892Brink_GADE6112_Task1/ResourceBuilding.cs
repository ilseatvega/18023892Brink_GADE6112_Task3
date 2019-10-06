using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _18023892Brink_GADE6112_Task1
{
    class ResourceBuilding : Building
    {
        //variables specific to Resource Building
        string resType;
        int resGen;
        int resGenRound = 20;
        int resRemaining = 1000;
        //random to be used throughout the class
        Random rnd = new Random();

        //constructor that receives parameteres for all the above class variables (except maxhealth)
        //setting the protected ints that were declared to the parameters of this ResourceBuilding method
        public ResourceBuilding(int xPos, int yPos, int health, int team, string symbol, string name, int resremaining, int maxHP) : base(xPos, yPos, 200, team, "🏭", "Resource Factory")
        {
            //this. to refer to the instance of the variable in this class
            this.xPos = xPos;
            this.yPos = yPos;
            this.health = health;
            this.team = team;
            this.symbol = symbol;
            this.name = name;

            //switch to randomly switch between the different resource types
            switch (rnd.Next(0, 3))
            {
                case 0: resType = "Iron"; break;
                case 1: resType = "Gold"; break;
                case 2: resType = "Stone"; break;
            }
        }

        //overriding the abstract methods created in Building
        public override void Destruction()
        {

        }
        public override string ToString()
        {
            return symbol + " " + name + " " + symbol + "\n" + "\n" + "Factory Position: [" + X + "," + Y + "] " + "\n" + "Factory HP: " + Health + "\n"
                + "Resource Type: " + resType + "\n" + "Total Resources Gathered: " + resGen +"\n" + "Resources Per Round: " + resGenRound + "\n"
                + "Resource Pool: " + resRemaining;
        }

        public void resManagement()
        {
                if (resRemaining - resGenRound >= 0)
                {
                    resGen += resGenRound;
                    resRemaining -= resGenRound;
                }
                else
                {
                    resGen += resRemaining;
                    resRemaining = 0;
                }
        }
        public override void Save()
        {
            //saves file to a text file in bin --> debug
            FileStream savefile = new FileStream(Environment.CurrentDirectory + "/ResourceBuildingSave.txt", FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(savefile);

            writer.WriteLine(Team + "," + X + "," + Y + "," + Health + "," + resRemaining);
            Console.WriteLine("Saved!");
            writer.Close();
            savefile.Close();
        }

        //get setters -  wouldnt work unless i put them in the Building class
        public int X { get { return xPos; } set { xPos = value; } }

        public int Y { get { return yPos; } set { yPos = value; } }

        public int maxHP { get { return health; } }

        //didnt use set since the value has been set and wont change (see constructor base at the top)
        public int Health { get { return health; } }

        public int Team { get { return team; } set { team = value; } }

        public string Symbol { get { return symbol; } }

        public string Name { get { return name; } set { name = value; } }
    }
}
