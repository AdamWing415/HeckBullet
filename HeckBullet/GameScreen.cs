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
using System.Threading;

namespace HeckBullet
{
    public partial class GameScreen : UserControl

    {
        List<Bullet> HeroBullets = new List<Bullet>();
        List<Bullet> enemyBullet = new List<Bullet>();
        List<Ship> ships = new List<Ship>();

        SolidBrush healthBrush = new SolidBrush(Color.OrangeRed);

        bool wKeyDown, aKeyDown, sKeyDown, dKeyDown, spaceDown, mDown, dodging, invincible, hit;

        int x, y, size, heroHealth, BossHealth, bulletSpeed;

        int counter, dodgeCounter;

        int i = 0;
        int hero = 0;
        int boss = 1;

        String direction;

        Image image;

        Random randGen = new Random();

        public GameScreen()
        {
            InitializeComponent();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            pictureBox1.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);

            this.Focus();
            Ship hero = new Ship(this.Width / 2 - 25, this.Height / 2 + 200, 50, 50, Resources.HeroShip_fw1_);
            ships.Add(hero);
            Ship boss = new Ship(this.Width / 2 - 300, 0, 600, 200, Resources.boss);
            ships.Add(boss);


            x = 200;
            heroHealth = 2;
            BossHealth = 2000;
            size = 15;
            dodgeCounter = 30;
            dodging = false;
            bulletSpeed = 4;
        }
        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    spaceDown = true;
                    break;
                case Keys.M:
                    mDown = true;
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
                case Keys.M:
                    mDown = false;
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
            Rectangle heroRec = new Rectangle(ships[hero].x, ships[hero].y, ships[hero].width - ships[hero].width / 2, ships[hero].height);
            Rectangle bossRec = new Rectangle(ships[boss].x, ships[boss].y, ships[boss].width, ships[boss].height - 100);

            if (BossHealth == 1000)
            {
                bulletSpeed = 6;
                Lines();
                y = 200;
            }

            foreach (Bullet b in HeroBullets)
            {
                b.HeroBulletMove(5);
            }

            //ADD RANDOM ATTACKS!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            waves();
            //randomPattern(bulletSpeed);


            if (dodging == false)
            {
                if (spaceDown == true && counter % 3 == 0)
                {
                    fire();
                }
                if (aKeyDown == true && ships[hero].x > 0)
                {
                    ships[hero].heroMove("left");
                }
                if (wKeyDown == true && ships[hero].y > ships[1].height)
                {
                    ships[hero].heroMove("forward");
                }
                if (sKeyDown == true && ships[hero].y < this.Height - ships[0].height)
                {
                    ships[hero].heroMove("backward");
                }
                if (dKeyDown == true && ships[hero].x < this.Width - ships[0].width)
                {
                    ships[hero].heroMove("right");
                }
                if (mDown == true)
                {
                    dodging = true;
                }
            }

            else if (dodging == true)
            {
                ships[hero].image = Properties.Resources.HeroShip_upside_down_;
                ships[hero].dodge(direction);

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

                if (dodgeCounter > 8)
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
                    dodgeCounter = 30;
                    ships[hero].image = Resources.HeroShip_fw1_;
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
                    b.y = 0;
                    b.x = -50;
                }
            }
            foreach (Bullet b in enemyBullet)
            {
                Rectangle newRec = new Rectangle(b.x, b.y, b.size, b.size);
                if (newRec.IntersectsWith(heroRec) && invincible == false)
                {
                    heroHealth--;
                    b.y = 0;
                    b.x = -50;
                    hit = true;
                    dodgeCounter = 50;
                }
            }

            if (hit == true && dodgeCounter > 0)
            {
                invincible = true;
                dodgeCounter--;
                ships[hero].image = Resources.HeroShip_upside_down_;
            }
            else if (hit == true && dodgeCounter == 0)
            {
                invincible = false;
                hit = false;
                dodgeCounter = 25;
                ships[hero].image = Resources.HeroShip_fw1_;
            }

            if (BossHealth <= 0)
            {
                win();
            }
            if (heroHealth <= 0)
            {
                lose();
            }
            counter++;
            i++;
            Refresh();

        }
        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            foreach (Bullet b in HeroBullets)
            {
                e.Graphics.DrawImage(b.image, b.x, b.y);
            }

            foreach (Bullet b in enemyBullet)
            {
                e.Graphics.DrawImage(b.image, b.x, b.y);
            }

            foreach (Ship s in ships)
            {
                e.Graphics.DrawImage(s.image, s.x, s.y, s.width, s.height);
            }
            e.Graphics.FillRectangle(healthBrush, 20, 20, 30, BossHealth /4);

            if (heroHealth == 2)
            {
                e.Graphics.FillRectangle(healthBrush, 25, this.Height - 25, 50, 15);
                e.Graphics.FillRectangle(healthBrush, 100, this.Height - 25, 50, 15);
            }
            else
            {
                e.Graphics.FillRectangle(healthBrush, 25, this.Height - 25, 50, 15);
            }


        }
        private void fire()
        {
            x = ships[hero].x + 3;
            y = ships[hero].y;
            image = Properties.Resources.HeroBullet;
            Bullet newBullet = new Bullet(x, y, size, image);
            HeroBullets.Add(newBullet);
        }
        private void win()
        {
            gameTimer.Stop();
            endlabel.Show();
            endlabel.Text = "VICTORY ACHIEVED";
            Refresh();
            Thread.Sleep(2500);

            Form Form1 = this.FindForm();
            Form1.Controls.Remove(this);
            MainMenu mm = new MainMenu();
            Form1.Controls.Add(mm);

            mm.Location = new Point(Form1.Width / 2 - mm.Width / 2, Form1.Height / 2 - mm.Height / 2);
        }
        private void lose()
        {
            gameTimer.Stop();
            endlabel.Show();
            endlabel.Text = "YOU DIED";
            Refresh();
            Thread.Sleep(2500);

            Form Form1 = this.FindForm();
            Form1.Controls.Remove(this);
            MainMenu mm = new MainMenu();
            Form1.Controls.Add(mm);

            mm.Location = new Point(Form1.Width / 2 - mm.Width / 2, Form1.Height / 2 - mm.Height / 2);
        }
        private void randomPattern(int speed)
        {
            if (enemyBullet.Count() < 50 && counter % 4 == 0)
            {
                size = 25;
                y = 0;

                x = randGen.Next(1, this.Width - size);

                Bullet newBullet = new Bullet(x, y, size, Properties.Resources.bullet);
                enemyBullet.Add(newBullet);
            }
            foreach (Bullet b in enemyBullet)
            {
                b.randomMove(speed);
            }
            if (enemyBullet[0].y > this.Height)
            {
                enemyBullet.RemoveAt(0);
            }
        }

        private void Lines()
        {
            if (i < 48)
            {

                x = 200;
                Bullet newBullet = new Bullet(x, y, size, Properties.Resources.bullet);
                enemyBullet.Add(newBullet);
                x = this.Width - 200;
                Bullet newBullet2 = new Bullet(x, y, size, Properties.Resources.bullet);
                enemyBullet.Add(newBullet2);

                y += 10;

            }

        }

        private void waves()
        {
            if (enemyBullet.Count() > 4)
            {
                x = enemyBullet[enemyBullet.Count() - 5].x;
            }

            if (x <= randGen.Next(2, 200) && counter %4 ==0)
            {

                x += randGen.Next(10,16);
                y = 0;
                for (int i = 0; i < 5; i++)
                {
                    Bullet newBullet = new Bullet(x, y, size, Properties.Resources.bullet);
                    enemyBullet.Add(newBullet);
                    x += 150;
                }
            }
            else if (x < randGen.Next(this.Width - 200, this.Width- 1) && counter % 4 == 0)
            {
                
                x -= randGen.Next(10, 16);
                y = 0;
                for (int i = 0; i < 5; i++)
                {
                    Bullet newBullet = new Bullet(x, y, size, Properties.Resources.bullet);
                    enemyBullet.Add(newBullet);
                    x += 150;
                }
            }


            foreach (Bullet b in enemyBullet)
            {
                b.randomMove(bulletSpeed);
            }
            if (enemyBullet[0].y > this.Height)
            {
                enemyBullet.RemoveAt(0);
            }
        }
    }
}

