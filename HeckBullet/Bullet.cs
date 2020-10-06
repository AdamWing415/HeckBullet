using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeckBullet
{
    class Bullet
        //class for every bullet object
    {
        public int size, x, y;
        public Image image;

        public Bullet(int _x, int _y, int _size, Image _image)
        {
            x = _x;
            y = _y;
            size = _size;
            image = _image;

           
        }
        //functions for moving tgeh bullets in different directions
        public void HeroBulletMove(int speed)
        {
            y -= speed;
        }
        public void randomMove (int speed)
        {
            y += speed;
        }
        public void BMoveRight(int speed)
        {
            x += speed;
        }
        public void BmoveLeft(int speed)
        {
            x -= speed;
        }
    }
}
