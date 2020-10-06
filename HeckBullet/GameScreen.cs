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
using System.Media;

namespace HeckBullet
{

    /// <summary>
    /// ADAM WINGERT 
    /// 5/10/2020
    /// BULLET
    /// </summary>
    public partial class GameScreen : UserControl

    {
        // lists for bullets and ships
        List<Bullet> HeroBullets = new List<Bullet>();
        List<Bullet> enemyBullet = new List<Bullet>();
        List<Bullet> specialBullets = new List<Bullet>();
        List<Bullet> leftEnemyBullet = new List<Bullet>();
        List<Bullet> rightEnemyBullet = new List<Bullet>();
        List<Ship> ships = new List<Ship>();

        //brush for drawing and sounds for playing
        SolidBrush healthBrush = new SolidBrush(Color.OrangeRed);
        SoundPlayer explode = new SoundPlayer(Resources.explode);
        SoundPlayer shooting = new SoundPlayer(Resources.shoot);

        //bools for keydown and other gaem checks
        bool wKeyDown, aKeyDown, sKeyDown, dKeyDown, spaceDown, mDown, dodging, invincible, hit;

        //ints & variables for various froperties and functions
        int x, y, size, heroHealth, BossHealth, bulletSpeed, xBulletSpeed;

        int counter, dodgeCounter;

        int attackType = 0;
        int previousAttack = 0;
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
            //runs all setupp code when the screen loads
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
            bulletSpeed = 5;
            xBulletSpeed = 1;
        }
        //all key down events for the program
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

        //all key up events for the program
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

        //runs every timer tick to update the screen
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //creates rectangles for the ships
            Rectangle heroRec = new Rectangle(ships[hero].x, ships[hero].y, ships[hero].width - ships[hero].width / 2, ships[hero].height);
            Rectangle bossRec = new Rectangle(ships[boss].x, ships[boss].y, ships[boss].width, ships[boss].height - 100);

            //checks if teh boss is at half health
            if (BossHealth == 1000)
            {
                ships[boss].image = Resources.boss_damaged;
                bulletSpeed = 7;
                Lines();
                y = 150;
            }

            //moves hero bullets
            foreach (Bullet b in HeroBullets)
            {
                b.HeroBulletMove(5);
            }

            // randomizes attacks and ensures attacks dont repeat twice in a row
            if (counter < 1)
            {
                previousAttack = attackType;
                attackType = randGen.Next(1, 6);
            }
            else if (counter % 800 == 0)
            {
                previousAttack = attackType;
                attackType = randGen.Next(1, 6);
            }

            if (attackType == 1 && previousAttack != attackType)
            {
                waves();
            }
            else if (attackType == 2 && previousAttack != attackType)
            {
                randomPattern();
            }
            else if (attackType == 3 && previousAttack != attackType)
            {
                blast();
                previousAttack = attackType;
                attackType = randGen.Next(1, 6);
            }
            else if (attackType == 4 && previousAttack != attackType)
            {
                lasers();
            }
            else if (attackType == 5 && previousAttack != attackType)
            {
                dodgeLines();
            }
            else
            {
                attackType = randGen.Next(1, 6);
            }

            //checks for dodgung
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

            //removes herobullets
            int index = HeroBullets.FindIndex(b => b.y <= 0 - b.size);
            if (index >= 0)
            {
                HeroBullets.RemoveAt(index);
            }

            //checks collision
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
                    explode.Play();
                    heroHealth--;
                    b.y = 0;
                    b.x = -50;
                    hit = true;
                    invincible = true;
                    dodgeCounter = 50;
                }
            }
            foreach (Bullet b in specialBullets)
            {
                Rectangle newRec = new Rectangle(b.x, b.y, b.size, b.size);
                if (newRec.IntersectsWith(heroRec) && invincible == false && BossHealth < 950)
                {
                    explode.Play();

                    heroHealth--;
                    b.y = 0;
                    b.x = -50;
                    hit = true;
                    invincible = true;
                    dodgeCounter = 50;
                }
            }
            foreach (Bullet b in leftEnemyBullet)
            {
                Rectangle newRec = new Rectangle(b.x, b.y, b.size, b.size);
                if (newRec.IntersectsWith(heroRec) && invincible == false)
                {
                    explode.Play();

                    heroHealth--;
                    b.y = 0;
                    b.x = -50;
                    hit = true;
                    invincible = true;
                    dodgeCounter = 50;
                }
            }
            foreach (Bullet b in rightEnemyBullet)
            {
                Rectangle newRec = new Rectangle(b.x, b.y, b.size, b.size);
                if (newRec.IntersectsWith(heroRec) && invincible == false)
                {
                    explode.Play();

                    heroHealth--;
                    b.y = 0;
                    b.x = -50;
                    hit = true;
                    invincible = true;
                    dodgeCounter = 50;
                }
            }

            //checks for hit and enables invincibility
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

            //checks for game ending values
            if (BossHealth <= 0)
            {
                win();
            }
            if (heroHealth <= 0)
            {
                lose();
            }

            //moves enemy bullets
            bulletMoves();
            counter++;

            Refresh();

        }
        //draws images and bullets to the creen
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
            foreach (Bullet b in specialBullets)
            {
                e.Graphics.DrawImage(b.image, b.x, b.y);
            }
            foreach (Bullet b in leftEnemyBullet)
            {
                e.Graphics.DrawImage(b.image, b.x, b.y);
            }
            foreach (Bullet b in rightEnemyBullet)
            {
                e.Graphics.DrawImage(b.image, b.x, b.y);
            }

            foreach (Ship s in ships)
            {
                e.Graphics.DrawImage(s.image, s.x, s.y, s.width, s.height);
            }
            e.Graphics.FillRectangle(healthBrush, 20, 20, 30, BossHealth / 4);

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
        //firing function
        private void fire()
        {
            //this sound lags my game so its commented out
            //if (counter % 35 == 0)
            //{
            //    shooting.Play();
            //}
            x = ships[hero].x + 3;
            y = ships[hero].y;
            image = Properties.Resources.HeroBullet;
            Bullet newBullet = new Bullet(x, y, size, image);
            HeroBullets.Add(newBullet);
        }
        //ends game on a win
        private void win()
        {
            explode.Play();
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
        //ends game on a loss
        private void lose()
        {
            explode.Play();
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
        //random attack pattern
        private void randomPattern()
        {
            if (enemyBullet.Count() < 50 && counter % 4 == 0)
            {
                size = 25;
                y = 0;

                x = randGen.Next(1, this.Width - size);

                Bullet newBullet = new Bullet(x, y, size, Properties.Resources.bullet);
                enemyBullet.Add(newBullet);
            }

        }
        //lines to be summoned on half boss health
        private void Lines()
        {
            for (int i = 0; i < 55; i++)
            {

                x = 200;
                Bullet newBullet = new Bullet(x, y, size, Properties.Resources.bullet);
                specialBullets.Add(newBullet);
                x = this.Width - 200;
                Bullet newBullet2 = new Bullet(x, y, size, Properties.Resources.bullet);
                specialBullets.Add(newBullet2);
                y += 10;

            }
            x = 0;
            for (int i = 0; i < 75; i++)
            {

                y = 250;
                Bullet newBullet = new Bullet(x, y, size, Properties.Resources.bullet);
                specialBullets.Add(newBullet);
                y = this.Height - 150;
                Bullet newBullet2 = new Bullet(x, y, size, Properties.Resources.bullet);
                specialBullets.Add(newBullet2);
                x += 15;

            }

        }
        //wave/zigzag attack pattern
        private void waves()
        {
            if (enemyBullet.Count() > 4)
            {
                x = enemyBullet[enemyBullet.Count() - 5].x;
            }

            if (x <= randGen.Next(2, 200) && counter % 4 == 0)
            {

                x += randGen.Next(10, 16);
                y = 0;
                for (int i = 0; i < 5; i++)
                {
                    Bullet newBullet = new Bullet(x, y, size, Properties.Resources.bullet);
                    enemyBullet.Add(newBullet);
                    x += 150;
                }
            }
            else if (x < randGen.Next(this.Width - 200, this.Width - 1) && counter % 4 == 0)
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
        }
        //blast attack pattern
        private void blast()
        {
            x = 0;
            if (counter % 90 == 0)
            {
                y = 0;
                for (int c = 0; c < 4; c++)
                {
                    for (int i = 0; i < 20; i++)
                    {
                        Bullet leftBullet = new Bullet(x, y, size, Properties.Resources.bullet);
                        leftEnemyBullet.Add(leftBullet);
                        Bullet midBullet = new Bullet(x + 300, y, size, Properties.Resources.bullet);
                        enemyBullet.Add(midBullet);
                        Bullet rightBullet = new Bullet(x + 600, y, size, Properties.Resources.bullet);
                        rightEnemyBullet.Add(rightBullet);
                        x += 15;
                    }
                    x = 0;
                    y -= 15;
                }

            }

        }
        //moving lines attack pattern
        private void dodgeLines()
        {
            x = 0;
            y = 0;
            if (counter % 80 == 0)
            {
                for (int i = 0; i < 75; i++)
                {
                    Bullet newBullet = new Bullet(x, y, size, Properties.Resources.bullet);
                    enemyBullet.Add(newBullet);

                    x += 15;

                }
            }
        }
        //laser line attack pattern
        private void lasers()
        {

            if (counter % 10 == 0)
            {
                y = 0;
                x = randGen.Next(20, this.Width - 20);
                for (int i = 0; i < 7; i++)
                {
                    Bullet newBullet = new Bullet(x, y, size, Resources.bullet);
                    enemyBullet.Add(newBullet);
                    y -= 15;
                }
            }
            else if (counter % 5 == 0)
            {
                y = 0;
                x = randGen.Next(20, this.Width - 20);
                Bullet newBullet = new Bullet(x, y, size, Resources.bullet);
                enemyBullet.Add(newBullet);
            }
        }

        //moves all bullets and check if they've left the screen
        private void bulletMoves()
        {
            foreach (Bullet b in enemyBullet)
            {
                b.randomMove(bulletSpeed);
            }
            foreach (Bullet b in leftEnemyBullet)
            {
                b.BmoveLeft(xBulletSpeed);
                b.randomMove(bulletSpeed);
            }
            foreach (Bullet b in rightEnemyBullet)
            {
                b.BMoveRight(xBulletSpeed);
                b.randomMove(bulletSpeed);
            }

            if (enemyBullet.Count() > 0)
            {
                if (enemyBullet[0].y > this.Height)
                {
                    enemyBullet.RemoveAt(0);
                }
            }

            if (leftEnemyBullet.Count() > 0)
            {
                if (leftEnemyBullet[0].y > this.Height)
                {
                    leftEnemyBullet.RemoveAt(0);
                }
            }

            if (rightEnemyBullet.Count() > 0)
            {
                if (rightEnemyBullet[0].y > this.Height)
                {
                    rightEnemyBullet.RemoveAt(0);
                }
            }
        }
    }
}

