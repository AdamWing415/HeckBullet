namespace HeckBullet
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.startButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.controlsButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.controlsScreen = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.controlsScreen)).BeginInit();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.Transparent;
            this.startButton.FlatAppearance.BorderColor = System.Drawing.Color.OrangeRed;
            this.startButton.FlatAppearance.BorderSize = 3;
            this.startButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Navy;
            this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startButton.Font = new System.Drawing.Font("Century Gothic", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.ForeColor = System.Drawing.Color.OrangeRed;
            this.startButton.Location = new System.Drawing.Point(16, 459);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(260, 70);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "START";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // quitButton
            // 
            this.quitButton.BackColor = System.Drawing.Color.Transparent;
            this.quitButton.FlatAppearance.BorderColor = System.Drawing.Color.OrangeRed;
            this.quitButton.FlatAppearance.BorderSize = 3;
            this.quitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Navy;
            this.quitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.quitButton.Font = new System.Drawing.Font("Century Gothic", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitButton.ForeColor = System.Drawing.Color.OrangeRed;
            this.quitButton.Location = new System.Drawing.Point(16, 611);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(260, 70);
            this.quitButton.TabIndex = 1;
            this.quitButton.Text = "QUIT";
            this.quitButton.UseVisualStyleBackColor = false;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // TitleLabel
            // 
            this.TitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.TitleLabel.Font = new System.Drawing.Font("Century Gothic", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.ForeColor = System.Drawing.Color.OrangeRed;
            this.TitleLabel.Location = new System.Drawing.Point(-8, 331);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(455, 122);
            this.TitleLabel.TabIndex = 2;
            this.TitleLabel.Text = "BULLET";
            // 
            // controlsButton
            // 
            this.controlsButton.BackColor = System.Drawing.Color.Transparent;
            this.controlsButton.FlatAppearance.BorderColor = System.Drawing.Color.OrangeRed;
            this.controlsButton.FlatAppearance.BorderSize = 3;
            this.controlsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Navy;
            this.controlsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.controlsButton.Font = new System.Drawing.Font("Century Gothic", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.controlsButton.ForeColor = System.Drawing.Color.OrangeRed;
            this.controlsButton.Location = new System.Drawing.Point(16, 535);
            this.controlsButton.Name = "controlsButton";
            this.controlsButton.Size = new System.Drawing.Size(260, 70);
            this.controlsButton.TabIndex = 3;
            this.controlsButton.Text = "CONTROLS";
            this.controlsButton.UseVisualStyleBackColor = false;
            this.controlsButton.Click += new System.EventHandler(this.controlsButton_Click);
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.Transparent;
            this.backButton.FlatAppearance.BorderColor = System.Drawing.Color.OrangeRed;
            this.backButton.FlatAppearance.BorderSize = 3;
            this.backButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Navy;
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.Font = new System.Drawing.Font("Century Gothic", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.ForeColor = System.Drawing.Color.OrangeRed;
            this.backButton.Location = new System.Drawing.Point(629, 616);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(260, 70);
            this.backButton.TabIndex = 4;
            this.backButton.Text = "BACK";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Visible = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // controlsScreen
            // 
            this.controlsScreen.BackColor = System.Drawing.Color.Transparent;
            this.controlsScreen.Image = global::HeckBullet.Properties.Resources.Controls_Screen;
            this.controlsScreen.Location = new System.Drawing.Point(0, 0);
            this.controlsScreen.Name = "controlsScreen";
            this.controlsScreen.Size = new System.Drawing.Size(900, 700);
            this.controlsScreen.TabIndex = 5;
            this.controlsScreen.TabStop = false;
            this.controlsScreen.Visible = false;
            // 
            // MainMenu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Teal;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.controlsScreen);
            this.Controls.Add(this.controlsButton);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.startButton);
            this.DoubleBuffered = true;
            this.Name = "MainMenu";
            this.Size = new System.Drawing.Size(900, 700);
            this.Load += new System.EventHandler(this.MainMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.controlsScreen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Button controlsButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.PictureBox controlsScreen;
    }
}
