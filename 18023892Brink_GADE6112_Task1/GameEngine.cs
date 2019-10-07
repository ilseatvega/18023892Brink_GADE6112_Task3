using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace _18023892Brink_GADE6112_Task1
{
    class GameEngine
    {
        //creating an instance of the map to use in this class
        public Map battlearea = new Map(10, 10, 5);
        //creating an instance of the form to use in this class
        private frmRTSGame gameForm;
        //creating an instance of the groupbox to use in this class
        private GroupBox groupBox;
        //creating an instance of the panel to use in this class
        private Panel pnlUnits;
        //random to be used throughout the class
        Random rnd = new Random();
        //round counter
        public int roundCounter = 0;

        //costructor
        public GameEngine(frmRTSGame gf, GroupBox gb, Panel pnl)
        {
            groupBox = gb;
            gameForm = gf;
            pnlUnits = pnl;
        }

        public void UpdateUnitArea()
        {
            //clearing the controls on the form and adding the groupbox and panel
            gameForm.Controls.Clear();
            //clearing the contents of the panel
            pnlUnits.Controls.Clear();
            gameForm.Controls.Add(groupBox);
            gameForm.Controls.Add(pnlUnits);
            //for each loops to loop through every unit that is generated
            //UNITS
            foreach (Unit u in battlearea.units)
            {
                //creating a new button called b
                Button b = new Button();
                //
                b.Location = new Point(u.X * 40, u.Y * 40);
                //the size of the button will be 40 by 40 (800 (pnl size) div by 20)
                b.Size = new Size(40, 40);
                //button text will be the symbol used in the Map class (switch case for random unit spawns)
                b.Text = u.Symbol;

                //changing button back colour depending on which team the unit belongs to
                if (u.Team == 0)
                {
                    b.BackColor = Color.DarkSeaGreen;
                }
                else
                {
                    b.BackColor = Color.Goldenrod;
                }
                //adding these buttons to only the panel
                pnlUnits.Controls.Add(b);
                //changing the font of the buttons so that the symbols are seen more clearly
                b.Font = new Font(b.Font.FontFamily, 20);
                b.Click += buttonClick;
            }
            //BUILDINGS
            foreach (Building u in battlearea.buildings)
            {
                //creating a new button called b
                Button b = new Button();
                //
                b.Location = new Point(u.X * 40, u.Y * 40);
                //the size of the button will be 40 by 40 (800 (pnl size) div by 20)
                b.Size = new Size(40, 40);
                //button text will be the symbol used in the Map class (switch case for random unit spawns)
                b.Text = u.Symbol;

                //changing button back colour depending on which team the unit belongs to
                if (u.Team == 0)
                {
                    b.BackColor = Color.DarkSeaGreen;
                }
                else
                {
                    b.BackColor = Color.Goldenrod;
                }
                //adding these buttons to only the panel
                pnlUnits.Controls.Add(b);
                //changing the font of the buttons so that the symbols are seen more clearly
                b.Font = new Font(b.Font.FontFamily, 20);
                b.Click += buttonClick;
            }
            //WIZARDS
            foreach (WizardUnit w in battlearea.wizard)
            {
                //creating a new button called b
                Button b = new Button();
                //
                b.Location = new Point(w.X * 40, w.Y * 40);
                //the size of the button will be 40 by 40 (800 (pnl size) div by 20)
                b.Size = new Size(40, 40);
                //button text will be the symbol used in the Map class (switch case for random unit spawns)
                b.Text = w.Symbol;

                //changing button back colour depending on which team the unit belongs to
                b.BackColor = Color.LightSteelBlue;
                //adding these buttons to only the panel
                pnlUnits.Controls.Add(b);
                //changing the font of the buttons so that the symbols are seen more clearly
                b.Font = new Font(b.Font.FontFamily, 20);
                b.Click += buttonClick;
            }
        }

        public void buttonClick(object buttonUnit, EventArgs e)
        {
            //foreach unit on the map
            foreach (Unit u in battlearea.units)
            {
                if (((((Button)buttonUnit).Location.X / 40) == u.X) && ((((Button)buttonUnit).Location.Y / 40) == u.Y))
                {
                    //display to string info
                    gameForm.displayUnitInfo(u.ToString());
                }
            }
            //foreach building on the map
            foreach (Building u in battlearea.buildings)
            {
                //if button clicked then
                if (((((Button)buttonUnit).Location.X / 40) == u.X) && ((((Button)buttonUnit).Location.Y / 40) == u.Y))
                {
                    //display tostring info
                    gameForm.displayUnitInfo(u.ToString());
                }
            }
            foreach (WizardUnit w in battlearea.wizard)
            {
                //if button clicked then
                if (((((Button)buttonUnit).Location.X / 40) == w.X) && ((((Button)buttonUnit).Location.Y / 40) == w.Y))
                {
                    //display tostring info
                    gameForm.displayUnitInfo(w.ToString());
                }
            }
        }
        //the method that contains the mainline logic and updates every round
        public void UpdateUnits()
        {
            foreach (Unit u in battlearea.units)
            {
                if (u.Health <= 0)
                {
                    //death
                    //make the array a list, remove the unit, make list array again
                    var unitList = battlearea.units.ToList();
                    unitList.Remove(u);
                    battlearea.units = unitList.ToArray();
                }
                //if health below 25%
                else if ((u.Health < (u.maxHP * 0.25)))
                {
                    u.Move(rnd.Next(0, 3));
                }
                else
                {
                    if (u.WithinRange(u.ClosestUnitPos(battlearea.units)))
                    {
                        u.Combat(u.ClosestUnitPos(battlearea.units));
                    }
                    else if (u.BuildingRange(u.ClosestBuilding(battlearea.buildings)))
                    {
                        u.BuildingCombat(u.ClosestBuilding(battlearea.buildings));
                    }
                    else
                    {
                        //prioritising unit destruction
                        Unit enemy = u.ClosestUnitPos(battlearea.units);
                        Building bEnemy = u.ClosestBuilding(battlearea.buildings);

                        // for units
                        int horizontalDiff = u.X - enemy.X;
                        int verticalDiff = u.Y - enemy.Y;
                        //for buildings
                        int bhorizontalDiff = u.X - bEnemy.X;
                        int bverticalDiff = u.Y - bEnemy.Y;

                        //UNITS
                        //which diff is higher to prioritise x or y movement
                        if (Math.Abs(horizontalDiff) > Math.Abs(verticalDiff))
                        {
                            //increase x value
                            if (horizontalDiff < 0)
                            {
                                u.Move(0);
                            }
                            //decrease x value
                            else if (horizontalDiff > 0)
                            {
                                u.Move(1);
                            }
                        }
                        else if (Math.Abs(horizontalDiff) > Math.Abs(verticalDiff))
                        {
                            if (verticalDiff < 0)
                            {
                                u.Move(2);
                            }
                            //decrease x value
                            else if (verticalDiff > 0)
                            {
                                u.Move(3);
                            }
                        }
                        else
                        {
                            //BUILDINGS
                            //which diff is higher to prioritise x or y movement
                            if (Math.Abs(bhorizontalDiff) > Math.Abs(bverticalDiff))
                            {
                                //increase x value
                                if (bhorizontalDiff < 0)
                                {
                                    u.Move(0);
                                }
                                //decrease x value
                                else if (bhorizontalDiff > 0)
                                {
                                    u.Move(1);
                                }
                            }
                            else
                            {
                                if (bverticalDiff < 0)
                                {
                                    u.Move(2);
                                }
                                //decrease x value
                                else if (bverticalDiff > 0)
                                {
                                    u.Move(3);
                                }
                            }
                        }
                    }
                }
            }
            this.UpdateUnitArea();
        }

        public void UpdateBuilding()
        {
            //foreach building on the map
            foreach (Building b in battlearea.buildings)
            {
                if (b.Health <= 0)
                {
                    //death
                    //make the array a list, remove the unit, make list array again
                    var unitList = battlearea.buildings.ToList();
                    unitList.Remove(b);
                    battlearea.buildings = unitList.ToArray();
                }
                //if resource building
                else if ((b.GetType()).Equals(typeof(ResourceBuilding)))
                {
                    //call resmanagement method
                    ((ResourceBuilding)b).resManagement();
                }
                //if factory building
                else if ((b.GetType()).Equals(typeof(FactoryBuilding)))
                {
                    if (roundCounter % ((FactoryBuilding)b).Speed == 0)
                    {
                        //change array to list, spawn units from factory, change back to array
                        var unitList = battlearea.units.ToList();
                        //unitList.Add(((FactoryBuilding)b).Spawn());
                        //battlearea.units = unitList.ToArray();

                        if (((FactoryBuilding)b).closestResources(battlearea.buildings))
                        {
                            unitList.Add(((FactoryBuilding)b).Spawn());
                            battlearea.units = unitList.ToArray();
                        }
                    }
                }
            }
            //update panel
            this.UpdateUnitArea();
        }

        public void UpdateWizards()
        {
            foreach (WizardUnit u in battlearea.wizard)
            {
                if (u.Health <= 0)
                {
                    //death
                    //make the array a list, remove the unit, make list array again
                    var unitList = battlearea.wizard.ToList();
                    unitList.Remove(u);
                    battlearea.wizard = unitList.ToArray();
                }
                //if health below 50%
                else if ((u.Health < (u.maxHP * 0.50)))
                {
                    u.Move(rnd.Next(0, 3));
                }
                else
                {
                    if (u.WithinRange(u.ClosestUnitPos(battlearea.units)))
                    {
                        u.wizAttack(battlearea.units);
                    }
                    else
                    {
                        Unit enemy = u.ClosestUnitPos(battlearea.units);

                        int horizontalDiff = u.X - enemy.X;
                        int verticalDiff = u.Y - enemy.Y;

                        //which diff is higher to prioritise x or y movement
                        if (Math.Abs(horizontalDiff) > Math.Abs(verticalDiff))
                        {
                            //increase x value
                            if (horizontalDiff < 0)
                            {
                                u.Move(0);
                            }
                            //decrease x value
                            else if (horizontalDiff > 0)
                            {
                                u.Move(1);
                            }
                        }
                        else
                        {
                            if (verticalDiff < 0)
                            {
                                u.Move(2);
                            }
                            //decrease x value
                            else if (verticalDiff > 0)
                            {
                                u.Move(3);
                            }
                        }
                    }
                }
            }
            this.UpdateUnitArea();
        }

        //calls the save method from map so we can call it in the form
        public void Save()
        {
            battlearea.Save();
        }
        //calls the load method from map so we can call it in the form
        public void Load()
        {
            battlearea.Load();
            UpdateUnitArea();
        }
    }
}
