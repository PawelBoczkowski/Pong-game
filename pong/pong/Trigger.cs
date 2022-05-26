using System;
using System.Collections.Generic;
using System.Text;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;



namespace pong
{
    class Trigger : CircleShape
    {
        public Pilka p = new Pilka();
        public int PositionX = 0;
        public int PositionY = 0;

        public static void UpdateTrigger()
        { 
        
        }
    }
}
