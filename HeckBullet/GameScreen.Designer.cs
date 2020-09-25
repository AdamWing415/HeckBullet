namespace HeckBullet
{
    partial class GameScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.endlabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 15;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // endlabel
            // 
            this.endlabel.BackColor = System.Drawing.Color.Maroon;
            this.endlabel.Font = new System.Drawing.Font("Dutch801 XBd BT", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endlabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.endlabel.Location = new System.Drawing.Point(287, 193);
            this.endlabel.Name = "endlabel";
            this.endlabel.Size = new System.Drawing.Size(317, 171);
            this.endlabel.TabIndex = 0;
            this.endlabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.endlabel.Visible = false;
            // 
            // GameScreen
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.endlabel);
            this.DoubleBuffered = true;
            this.Name = "GameScreen";
            this.Size = new System.Drawing.Size(900, 700);
            this.Load += new System.EventHandler(this.GameScreen_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameScreen_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GameScreen_KeyUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.GameScreen_PreviewKeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label endlabel;
    }
}
