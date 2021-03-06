﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeckBullet
{
    class Ship
        //class to contain both the hero ship and the boss
    {
        public int x, y, height, width;
        public Image image;

       
        public Ship(int _x, int _y, int _width, int _height, Image _image)
        {
            x = _x;
            y = _y;
            width = _width;
            height = _height;
            image = _image;
        }
        
        //function for the hero to move
        public void heroMove(string direction)
        {
            switch (direction)
            {
                case "left":
                    x -= 3;
                    break;
                case "right":
                    x += 3;
                    break;
                case "forward":
                    y -= 3;
                    break;
                case "backward":
                    y += 3;
                    break;
            }
        }
        //dodge function for the hero
        public void dodge(string direction)
        {
            switch (direction)
            {
                case "left":
                    if (x > 5)
                    {
                        x -= 5;
                    }
               

                    break;
                case "right":
                    if (x < 700 - width*2)
                    {
                        x += 5;
                        
                    }
                    
                    break;
                case "forward":
                    if (y > 155)
                    {
                        y -= 5;
                        
                    }
                    
                    break;
                case "backward":
                    if (y <= 500)
                    {
                        y += 5;
                        
                    }
                    
                    break;

            
            }
        }
    }
}
