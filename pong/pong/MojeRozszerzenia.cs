using System;
using System.Collections.Generic;
using System.Text;
using SFML.System;

namespace Rozszerzenia
{
    public static class MojeRozszerzenia
    {
        public static Vector2f Normalize(this Vector2f vector2F)
        {
            return vector2F * 2f;
        }

        public static void Wypisz(this string s)
        {
           // Console.WriteLine($"Wypisuje napis: {s}");
        }
    }


}
