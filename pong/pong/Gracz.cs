using System;
using System.Collections.Generic;
using System.Text;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace pong
{
    public class Gracz : RectangleShape
    {
        
        public bool freeze_state = false;
        
        public Gracz() : base(new Vector2f(200,30))
        {

            Position = new Vector2f(200,500);
            FillColor = Color.White;

        }
        public void freeze(Window window)
        {
            if (freeze_state == false)
            {
                this.Position = new Vector2f(Mouse.GetPosition(window).X - 100, this.Position.Y);
            }

        }

    }
}
