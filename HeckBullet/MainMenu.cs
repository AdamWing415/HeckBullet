using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using HeckBullet.Properties;

namespace HeckBullet
{
    public partial class MainMenu : UserControl
    {
        //adds sounds
        SoundPlayer buttonSound = new SoundPlayer(Resources.button);
        SoundPlayer ambient = new SoundPlayer(Resources.white_noise);

        public MainMenu()
        {
            InitializeComponent();
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            //quits the application
            buttonSound.Play();
            Application.Exit();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            //starts the game and switches too teh game screen
            buttonSound.Play();

            Form Form1 = this.FindForm();
            Form1.Controls.Remove(this);
            GameScreen gs = new GameScreen();
            Form1.Controls.Add(gs);

            gs.Location = new Point(Form1.Width / 2 - gs.Width / 2, Form1.Height / 2 - gs.Height / 2);
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            //focuses the button on load
            startButton.Focus();
            ambient.Play();
        }

        private void controlsButton_Click(object sender, EventArgs e)
        {
            backButton.Show();
            quitButton.Hide();
            startButton.Hide();
            controlsButton.Hide();
            controlsScreen.Show();
            backButton.Focus();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            backButton.Hide();
            quitButton.Show();
            startButton.Show();
            controlsButton.Show();
            controlsScreen.Hide();
            startButton.Focus();
        }
    }
}
