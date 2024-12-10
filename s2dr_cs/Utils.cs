using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace s2dr_cs
{
    public static class Utils
    {
        public static float NextSingle(this Random rnd, float min, float max)
        {
            double range = (double)max - (double)min;
            double sample = rnd.NextDouble();
            double scaled = min + sample * range;
            return (float)scaled;
        }

        public static float Normalized(this float angle)
        {
            if (angle < 0)
            {
                angle = angle + 360 * ((int)(angle / 360) + 1);
            }
            else if (angle >= 360)
            {
                angle = angle - 360 * ((int)(angle / 360));
            }
            // a = (360.0/65536) * ((int)(a*(65536/360.0)) & 65535);
            return angle;
        }

        public static Vector2 ToDirection(this float angle)
        {
            angle = angle.Normalized() * ((float)MathF.PI / 180f);
            var cos = MathF.Cos(angle);
            var sin = MathF.Sin(angle);
            return new(cos, sin);
        }

        public static Point ToPoint(this Vector2 vector2) => new((int)vector2.X, (int)vector2.Y);
        public static PointF ToPointF(this Vector2 vector2) => new(vector2.X, vector2.Y);
    }
}
