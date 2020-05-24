using Godot;
using System;
using System.Collections.Generic;

namespace Test.Scripts.Shared
{
    public class Compass
    {
        private static Random random = new Random();
        public static List<Vector2> directions = new List<Vector2>
        {
            new Vector2(-0f, -1f),
            new Vector2(0.707f, -0.707f),
            new Vector2(1f, 0f),
            new Vector2(0.707f, 0.707f),
            new Vector2(0f, 1f),
            new Vector2(-0.707f, 0.707f),
            new Vector2(-1f, 0f),
            new Vector2(-0.707f, -0.707f)
        };
        /*
        public Dictionary<string, Vector2> directions = new Dictionary<string, Vector2>
        {
            { "N",  new Vector2(-0f, -1f) },
            { "NE",  new Vector2(0.707f, -0.707f) },
            { "E",  new Vector2(1f, 0f) },
            { "SE",  new Vector2(0.707f, 0.707f) },
            { "S",  new Vector2(0f, 1f) },
            { "SW",  new Vector2(-0.707f, 0.707f) },
            { "W",  new Vector2(-1f, 0f) },
            { "NW",  new Vector2(-0.707f, -0.707f) }
        };
        */

        public static Vector2 GetRandomDirection()
        {
            int index = random.Next(0, directions.Count);
            return directions[index];
        }
    }
}
