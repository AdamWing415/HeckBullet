using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeckBullet
{
    public partial class MainMenu : UserControl
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            Form Form1 = this.FindForm();
            Form1.Controls.Remove(this);
            GameScreen gs = new GameScreen();
            Form1.Controls.Add(gs);

            gs.Location = new Point(Form1.Width / 2 - gs.Width / 2, Form1.Height / 2 - gs.Height / 2);
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            startButton.Focus();
        }

      
    }
}
