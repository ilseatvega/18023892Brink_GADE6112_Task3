using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _18023892Brink_GADE6112_Task1
{
    public partial class frmRTSGame : Form
    {
        
        //creating an instance of map in this class
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

        private void tmrGameEng_Tick(object sender, EventArgs e)
        {
            gameEng.UpdateUnits();
            gameEng.UpdateBuilding();
            lblCurrentRound.Text = "";
            lblCurrentRound.Text = Convert.ToString(gameEng.roundCounter += 1);
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            tmrGameEng.Stop();
        }

        private void lblCurrentRound_Click(object sender, EventArgs e)
        {

        }
    }
}
