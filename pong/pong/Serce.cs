using System;
using System.Collections.Generic;
using System.Text;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace pong
{
    class Serce : RectangleShape
    {
        static Texture obrazek_serca = new Texture("serce.png");
        public Serce(int posx,int posy) : base(new Vector2f(35,35))
        {
            Position = new Vector2f(posx,posy);
            Texture = obrazek_serca;
        }

    }
}
