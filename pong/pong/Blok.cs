using System;
using System.Collections.Generic;
using System.Text;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace pong
{
    class Blok : RectangleShape
    {
        public Blok(int posx,int posy) : base(new Vector2f(98, 98))
        {
            
            Position = new Vector2f(posx, posy);
            FillColor = Color.White;
            OutlineColor = Color.Red;
            OutlineThickness = 1;
        }

        public Blok(int posx,int posy,int sizex,int sizey) : this(posx,posy)
        {
            Size = new Vector2f(sizex, sizey);
        }
   }
}
