using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HeckBullet.Properties;

namespace HeckBullet
{
    public partial class GameScreen : UserControl

    {
        List<Bullet> HeroBullets = new List<Bullet>();
        List<Bullet> enemyBullet = new List<Bullet>();
        List<Ship> ships = new List<Ship>();

        SolidBrush healthBrush = new SolidBrush(Color.Red);

        bool wKeyDown, aKeyDown, sKeyDown, dKeyDown, spaceDown, QDown, dodging, invincible;

        int x, y, size, heroHealth, BossHealth;

        int counter, dodgeCounter;

        String direction;

        Image image;



        public GameScreen()
        {
            InitializeComponent();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            this.Focus();
            Ship hero = new Ship(this.Width / 2 - 25, this.Height / 2 + 200, 50, 50, Resources.HeroShip_fw1_);
            ships.Add(hero);
            Ship boss = new Ship(this.Width / 2 - 150, 0, 300, 150, Resources.placeholder);
            ships.Add(boss);
            heroHealth = 2;
            BossHealth = 2000;
            size = 15;
            dodgeCounter = 25;
            dodging = false;
        }
        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    spaceDown = true;
                    break;
                case Keys.Q:
                    QDown = true;
                    break;
                case Keys.W:
                    wKeyDown = true;
                    break;
                case Keys.A:
                    aKeyDown = true;
                    break;
                case Keys.S:
                    sKeyDown = true;
                    break;
                case Keys.D:
                    dKeyDown = true;
                    break;
            }

        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    spaceDown = false;
                    break;
                case Keys.Q:
                    QDown = false;
                    break;
                case Keys.W:
                    wKeyDown = false;
                    break;
                case Keys.A:
                    aKeyDown = false;
                    break;
                case Keys.S:
                    sKeyDown = false;
                    break;
                case Keys.D:
                    dKeyDown = false;
                    break;
            }
        }
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            Rectangle heroRec = new Rectangle(ships[0].x, ships[0].y, ships[0].width, ships[0].height);
            Rectangle bossRec = new Rectangle(ships[1].x, ships[1].y, ships[1].width, ships[1].height);

            foreach (Bullet b in HeroBullets)
            {
                b.HeroBulletMove(5);
            }

            if (dodging == false)
            {
                if (spaceDown == true && counter % 3 == 0)
                {
                    fire();
                }
                if (aKeyDown == true && ships[0].x > 0)
                {
                    ships[0].heroMove("left");
                }
                if (wKeyDown == true && ships[0].y > ships[1].height)
                {
                    ships[0].heroMove("forward");
                }
                if (sKeyDown == true && ships[0].y < this.Height - ships[0].height)
                {
                    ships[0].heroMove("backward");
                }
                if (dKeyDown == true && ships[0].x < this.Width - ships[0].width)
                {
                    ships[0].heroMove("right");
                }
                if (QDown == true)
                {
                    dodging = true;
                }
            }
            else if (dodging == true)
            {
                ships[0].dodge(direction);

                if (aKeyDown == true)
                {
                    direction = "left";
                }
                else if (wKeyDown == true)
                {
                    direction = "forward";
                }
                else if (sKeyDown == true)
                {
                    direction = "backward";
                }
                else if (dKeyDown == true)
                {
                    direction = "right";
                }

                if (dodgeCounter > 10)
                {
                    invincible = true;
                }
                else
                {
                    invincible = false;
                }

                if (dodgeCounter == 0)
                {
                    dodging = false;
                    dodgeCounter = 25;
                    ships[0].image = Resources.HeroShip_fw1_;
                }

                dodgeCounter--;
            }

            int index = HeroBullets.FindIndex(b => b.y <= 0 - b.size);
            if (index >= 0)
            {
                HeroBullets.RemoveAt(index);
            }

            foreach (Bullet b in HeroBullets)
            {
                Rectangle newRec = new Rectangle(b.x, b.y, b.size, b.size);
                if (newRec.IntersectsWith(bossRec))
                {
                    BossHealth--;
                    b.y = -50;
                }
            }
            if (BossHealth == 0)
            {
                win();
            }
            counter++;

            Refresh();

        }
        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            foreach (Bullet b in HeroBullets)
            {
                e.Graphics.DrawImage(b.image, b.x, b.y);
            }

            foreach (Ship s in ships)
            {
                e.Graphics.DrawImage(s.image, s.x, s.y, s.width, s.height);
            }
            e.Graphics.FillRectangle(healthBrush, this.Width / 2 - 250, 20, BossHealth / 4, 30);

        }
        private void fire()
        {
            x = ships[0].x + 3;
            y = ships[0].y;
            image = Properties.Resources.HeroBullet;
            Bullet newBullet = new Bullet(x, y, size, image);
            HeroBullets.Add(newBullet);
        }
        private void win()
        {

        }
    }
}

