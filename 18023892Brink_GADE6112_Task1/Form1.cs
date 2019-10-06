using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _18023892Brink_GADE6112_Task1
{
    public partial class frmRTSGame : Form
    {
        
        //creating an instance of game eng in this class
        GameEngine gameEng;

        public frmRTSGame()
        {
            InitializeComponent();
            gameEng = new GameEngine(this, this.gbxUI, this.pnlUnits);
            gameEng.UpdateUnitArea();
        }

        private void frmRTSGame_Load(object sender, EventArgs e)
        {
            
        }

        //code that runs when the button "Start" is clicked
        private void btnStart_Click(object sender, EventArgs e)
        {
            tmrGameEng.Start();
        }

        //displaying the unit info from the ToString() methods in the rtb
        public void displayUnitInfo(string unitInfo)
        {
            rtbUnitInfo.Clear();
            rtbUnitInfo.Text = unitInfo;
        }

        //updating units and buildings, as well as the round counter
        private void tmrGameEng_Tick(object sender, EventArgs e)
        {
            gameEng.UpdateUnits();
            gameEng.UpdateBuilding();
            gameEng.UpdateWizards();
            lblCurrentRound.Text = "";
            lblCurrentRound.Text = Convert.ToString(gameEng.roundCounter += 1);
        }

        //stopping the timer when game is paused
        private void btnPause_Click(object sender, EventArgs e)
        {
            tmrGameEng.Stop();
        }

        private void lblCurrentRound_Click(object sender, EventArgs e)
        {

        }

        //saving current info to text file (one file for each different building and unit type)
        private void btnSave_Click(object sender, EventArgs e)
        {
            //save (called from game engine, which called from map which called from the unit and building children classes)
            gameEng.Save();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            //the load method from game eng which was called from map
            gameEng.Load();
        }
    }
}
