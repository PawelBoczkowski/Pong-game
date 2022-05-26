using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.Threading;
using System.Collections.Generic;
using System.Diagnostics;

namespace pong
{
    class Program
    {
        public static List<Blok> block_list = new List<Blok>();
        public static List<Serce> heart_list = new List<Serce>();
        public static RenderWindow window;
        static int heart_points = 3;

        Stopwatch sw = new Stopwatch();
        float speed = 0.8f;

        public Program()
        {
            window = new RenderWindow(new VideoMode(800, 600), "Pong!");
            window.KeyPressed += KeyHandler;
            window.Closed += (_, __) => Environment.Exit(0);

        }

        void KeyHandler(object soucre, KeyEventArgs args)
        {
            if (args.Code == Keyboard.Key.Escape)
            {
                window.SetMouseCursorGrabbed(false);
            }
        }

        void RunProgram()
        {

            Pilka ball = new Pilka();
            Gracz player = new Gracz();

            int hearts = 3;
            int heart_shift = 35;


            //napisy na ekranie
            Text score = new Text("", new Font("C:\\Windows\\Fonts\\Arial.ttf"), 20);
            score.FillColor = Color.White;
            score.Position = new Vector2f(0, 0);
            int score_points = 0;

            Text serca = new Text("", new Font("C:\\Windows\\Fonts\\Arial.ttf"), 20);
            serca.FillColor = Color.White;
            serca.Position = new Vector2f(730, 0);

            //pozycja myszki
            Mouse.SetPosition(new Vector2i((int)player.Position.X, (int)player.Position.Y));
            ball.shape.Position = new Vector2f(400, 300);

            for (int i = 1; i <= hearts; i += 1)
            {
                heart_list.Add(new Serce((int)window.Size.X - heart_shift, 40));
                heart_shift += 35;
            }


            window.SetMouseCursorGrabbed(true);
            window.SetMouseCursorVisible(false);
            while (window.IsOpen)
            {
                score.DisplayedString = $"Score:{score_points}";
                serca.DisplayedString = $"Lifes:{heart_points}";
                ball.shape.Position += ball.velocity * speed;

                bool lose_point = false;

                CalculateWall(ball);
                if (ball.shape.Position.Y + ball.shape.Radius * 2 >= player.Position.Y && ball.shape.Position.X >= player.Position.X && ball.shape.Position.X <= player.Position.X + player.Size.X)
                {
                    score_points += 1;
                    ball.velocity = new Vector2f(ball.velocity.X, -ball.velocity.Y);
                }


                if (ball.shape.Position.Y > player.Position.Y)
                {

                    if (heart_points <= 0)
                    {
                        ball.velocity = new Vector2f(0, 0);
                        player.freeze_state = true;
                        heart_points = 0;

                    }
                    heart_points -= 1;
                    lose_point = true;
                    ball.velocity = new Vector2f(-10, -5);

                    ball.shape.Position = new Vector2f(400, 300);

                }
                window.Clear(Color.Black);
                window.Draw(player);
                window.Draw(ball.shape);
                window.Draw(score);
                draw_blocks(block_list);
                draw_hearts(heart_list);


                player.freeze(window);

                
                if (heart_points == 0)
                {
                    window.Close();
                }


                window.DispatchEvents();
                window.Display();

                //fps settings (60fps now)
                Thread.Sleep(16);

                if (lose_point)
                {
                    sw.Start();
                    lose_point = false;
                    ball.velocity = new Vector2f(0, 0);
                    destroy_hearts(heart_list);
                }

                if (sw.ElapsedMilliseconds > 2000)
                {
                    sw.Stop();
                    sw.Reset();
                    ball.velocity = new Vector2f(-10, -5);
                }

            }
        }
        public void draw_blocks(List<Blok> lista)
        {
            foreach (Blok bloki in lista)
            {
                window.Draw(bloki);
            }
        }

        static void draw_hearts(List<Serce> lista_serc)
        {
            foreach (Serce serce in lista_serc)
            {
                window.Draw(serce);
               
            }
        }

        static void destroy_hearts(List<Serce> lista_serc) 
        {
            lista_serc.Remove(lista_serc[heart_points]);
           
        }
        static void CalculateWall(Pilka ball)
        {
            if (ball.shape.Position.X <= 0)
            {
                ball.velocity = new Vector2f(-ball.velocity.X, ball.velocity.Y);
            }

            if (ball.shape.Position.Y <= 0)
            {
                ball.velocity = new Vector2f(ball.velocity.X, -ball.velocity.Y);
            }

            if (ball.shape.Position.X >= (800 - 2 * (ball.shape.Radius)))
            {
                ball.velocity = new Vector2f(-ball.velocity.X, ball.velocity.Y);
            }

            if (ball.shape.Position.Y >= (600 - 2 * (ball.shape.Radius)))
            {

                ball.velocity = new Vector2f(ball.velocity.X, -ball.velocity.Y);
            }
        }


        static void Main(string[] args)
        {
            Program p = new Program();
            p.RunProgram();
        }
    }
}




















//for (int i = 0; i < 3; i += 1)
//{
//    for (int j = 0; j < 8; j += 1)
//    {
//        lista_blokow.Add(new Blok(pozycjaX, pozycjaY));
//        pozycjaX += 100;
//        if (pozycjaX == 802)
//        {
//            pozycjaX = 2;
//            pozycjaY += 100;
//        }

//    }
//}