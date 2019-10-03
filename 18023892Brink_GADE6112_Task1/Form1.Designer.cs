namespace _18023892Brink_GADE6112_Task1
{
    partial class frmRTSGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblCurrentRound = new System.Windows.Forms.Label();
            this.lblGameRound = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.rtbUnitInfo = new System.Windows.Forms.RichTextBox();
            this.tmrGameEng = new System.Windows.Forms.Timer(this.components);
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbxUI = new System.Windows.Forms.GroupBox();
            this.pnlUnits = new System.Windows.Forms.Panel();
            this.gbxUI.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCurrentRound
            // 
            this.lblCurrentRound.AutoSize = true;
            this.lblCurrentRound.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentRound.Location = new System.Drawing.Point(130, 45);
            this.lblCurrentRound.Name = "lblCurrentRound";
            this.lblCurrentRound.Size = new System.Drawing.Size(41, 31);
            this.lblCurrentRound.TabIndex = 1;
            this.lblCurrentRound.Text = "...";
            this.lblCurrentRound.Click += new System.EventHandler(this.lblCurrentRound_Click);
            // 
            // lblGameRound
            // 
            this.lblGameRound.AutoSize = true;
            this.lblGameRound.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameRound.Location = new System.Drawing.Point(60, 16);
            this.lblGameRound.Name = "lblGameRound";
            this.lblGameRound.Size = new System.Drawing.Size(193, 29);
            this.lblGameRound.TabIndex = 2;
            this.lblGameRound.Text = "GAME ROUND:";
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(6, 92);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(294, 54);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "START";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnPause
            // 
            this.btnPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPause.Location = new System.Drawing.Point(6, 152);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(294, 54);
            this.btnPause.TabIndex = 4;
            this.btnPause.Text = "PAUSE";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // rtbUnitInfo
            // 
            this.rtbUnitInfo.Enabled = false;
            this.rtbUnitInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbUnitInfo.Location = new System.Drawing.Point(6, 212);
            this.rtbUnitInfo.Name = "rtbUnitInfo";
            this.rtbUnitInfo.Size = new System.Drawing.Size(294, 316);
            this.rtbUnitInfo.TabIndex = 5;
            this.rtbUnitInfo.Text = "";
            // 
            // tmrGameEng
            // 
            this.tmrGameEng.Interval = 1000;
            this.tmrGameEng.Tick += new System.EventHandler(this.tmrGameEng_Tick);
            // 
            // btnLoad
            // 
            this.btnLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.Location = new System.Drawing.Point(6, 594);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(294, 54);
            this.btnLoad.TabIndex = 6;
            this.btnLoad.Text = "LOAD";
            this.btnLoad.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(6, 534);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(294, 54);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // gbxUI
            // 
            this.gbxUI.BackColor = System.Drawing.SystemColors.Control;
            this.gbxUI.Controls.Add(this.btnLoad);
            this.gbxUI.Controls.Add(this.btnSave);
            this.gbxUI.Controls.Add(this.lblCurrentRound);
            this.gbxUI.Controls.Add(this.lblGameRound);
            this.gbxUI.Controls.Add(this.rtbUnitInfo);
            this.gbxUI.Controls.Add(this.btnStart);
            this.gbxUI.Controls.Add(this.btnPause);
            this.gbxUI.Location = new System.Drawing.Point(852, 80);
            this.gbxUI.Name = "gbxUI";
            this.gbxUI.Size = new System.Drawing.Size(306, 661);
            this.gbxUI.TabIndex = 8;
            this.gbxUI.TabStop = false;
            // 
            // pnlUnits
            // 
            this.pnlUnits.Location = new System.Drawing.Point(12, 12);
            this.pnlUnits.Name = "pnlUnits";
            this.pnlUnits.Size = new System.Drawing.Size(800, 800);
            this.pnlUnits.TabIndex = 9;
            // 
            // frmRTSGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 835);
            this.Controls.Add(this.pnlUnits);
            this.Controls.Add(this.gbxUI);
            this.Name = "frmRTSGame";
            this.Text = "RTS!";
            this.Load += new System.EventHandler(this.frmRTSGame_Load);
            this.gbxUI.ResumeLayout(false);
            this.gbxUI.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblCurrentRound;
        private System.Windows.Forms.Label lblGameRound;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.RichTextBox rtbUnitInfo;
        private System.Windows.Forms.Timer tmrGameEng;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox gbxUI;
        private System.Windows.Forms.Panel pnlUnits;
    }
}

