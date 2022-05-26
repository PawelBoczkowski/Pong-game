using System;
using System.Collections.Generic;
using System.Text;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace pong
{
     public class Pilka
    {
        public Vector2f velocity = new Vector2f(-10,-5);
        public int mass = 10;
        public CircleShape shape;
       
        public Pilka() {
             shape = new CircleShape(30);
            


        }
    }
}
