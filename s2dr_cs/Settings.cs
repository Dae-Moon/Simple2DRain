using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace s2dr_cs
{
    public struct Settings
    {
        public Settings()
        {
            color = Color.FromArgb(255, 255, 255, 255);
            amount = 100;
            speed = 3;
            size = 50;
            angle = 90;
            thickness = 1;
        }

        public Color color;
        public int amount;

        public float speed;
        public float size;
        public float angle;
        public float thickness;
    }
}
