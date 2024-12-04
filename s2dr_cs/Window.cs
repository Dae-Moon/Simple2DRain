using System.ComponentModel;
using System.Numerics;

namespace s2dr_cs
{
    public partial class Window : Form
    {
        readonly Random rnd = new();
        DateTime lastTime = DateTime.Now;
        float frameTime, frameTimeAmount;
        Settings settings = new();
        List<Vector2> data = new();
        Task currentColorDialog = null;

        public Window()
        {
            InitializeComponent();

            SetDoubleBuffered(pb_display);
        }



        public static void SetDoubleBuffered(Control c)
        {
            //Taxes: Remote Desktop Connection and painting
            //http://blogs.msdn.com/oldnewthing/archive/2006/01/03/508694.aspx
            if (SystemInformation.TerminalServerSession)
                return;

            System.Reflection.PropertyInfo aProp =
                  typeof(Control).GetProperty(
                        "DoubleBuffered",
                        System.Reflection.BindingFlags.NonPublic |
                        System.Reflection.BindingFlags.Instance);
            aProp.SetValue(c, true, null);
        }

        Vector2 RandomVector(Vector2 min, Vector2 max)
        {
            float x = rnd.NextSingle(min.X, max.X);
            float y = rnd.NextSingle(min.Y, max.Y);
            return new(x, y);
        }

        KeyValuePair<Side, Side> DetermineTwoSides(float angle)
        {
            KeyValuePair<Side, Side> v = new(Side.Left, Side.Left);

            if (angle == 90.0f)
                v = new(Side.Top, Side.Top);
            else if (angle == 180.0f)
                v = new(Side.Right, Side.Right);
            else if (angle == 270.0f)
                v = new(Side.Bottom, Side.Bottom);
            else
            {
                if (angle > 0.0f && angle < 90.0f)
                    v = new(Side.Left, Side.Top);
                else if (angle > 90.0f && angle < 180.0f)
                    v = new(Side.Top, Side.Right);
                else if (angle > 180.0f && angle < 270.0f)
                    v = new(Side.Right, Side.Bottom);
                else if (angle > 270.0f && angle < 360.0f)
                    v = new(Side.Bottom, Side.Left);
            }

            return v;
        }

        KeyValuePair<Vector4, Vector4> GetArea(KeyValuePair<Side, Side> twoSides, float offset)
        {
            Vector4 first = new(-offset, -offset, -offset, Size.Height + offset);
            Vector4 second = first;

            switch (twoSides.Key)
            {
                case Side.Top:
                    first.X = -offset;
                    first.Y = -offset;
                    first.Z = Size.Width + offset;
                    first.W = -offset;
                    break;
                case Side.Right:
                    first.X = Size.Width + offset;
                    first.Y = -offset;
                    first.Z = Size.Width + offset;
                    first.W = Size.Height + offset;
                    break;
                case Side.Bottom:
                    first.X = -offset;
                    first.Y = Size.Height + offset;
                    first.Z = Size.Width + offset;
                    first.W = Size.Height + offset;
                    break;
            }

            switch (twoSides.Value)
            {
                case Side.Top:
                    second.X = -offset;
                    second.Y = -offset;
                    second.Z = Size.Width + offset;
                    second.W = -offset;
                    break;
                case Side.Right:
                    second.X = Size.Width + offset;
                    second.Y = -offset;
                    second.Z = Size.Width + offset;
                    second.W = Size.Height + offset;
                    break;
                case Side.Bottom:
                    second.X = -offset;
                    second.Y = Size.Height + offset;
                    second.Z = Size.Width + offset;
                    second.W = Size.Height + offset;
                    break;
            }

            return new(first, second);
        }



        void Generate()
        {
            frameTimeAmount += frameTime;

            int amount = (int)(settings.amount * (settings.speed * frameTimeAmount));
            if (amount > 0)
                frameTimeAmount = 0;

            for (int i = 0; i < amount; i++)
            {
                var twoSides = DetermineTwoSides(settings.angle.Normalized());
                var area = GetArea(twoSides, settings.size);
                var r1 = RandomVector(new(area.Key.X, area.Key.Y), new(area.Key.Z, area.Key.W));
                var r2 = RandomVector(new(area.Value.X, area.Value.Y), new(area.Value.Z, area.Value.W));
                data.Add(r1);
                data.Add(r2);
            }
        }

        void Update(Action<Vector2, Vector2> rain)
        {
            for (int i = 0; i < data.Count; i++)
            {
                var dir = settings.angle.ToDirection();

                rain?.Invoke(data[i], data[i] + dir * settings.size);

                Vector2 min = new(-settings.size - 1, -settings.size - 1);
                Vector2 max = new(Size.Width + settings.size + 1, Size.Height + settings.size + 1);

                var end = data[i] + dir * (settings.speed * 10 * (100 * frameTime));
                if (end.X < min.X || end.Y < min.Y || end.X > max.X || end.Y > max.Y)
                    data.RemoveAt(i);
                else
                    data[i] = end;
            }
        }



        private void pb_display_Paint(object sender, PaintEventArgs e)
        {
            {
                var currentTime = DateTime.Now;
                frameTime = (float)(currentTime - lastTime).TotalSeconds;
                lastTime = currentTime;
            }

            var g = e.Graphics;
            {
                g.Clear(Color.Black);

                Generate();
                Update((first, second) => { g.DrawLine(new Pen(settings.color, settings.thickness), first.ToPointF(), second.ToPointF()); });

                g.DrawString($"{(int)(1 / frameTime)} FPS", Font, Brushes.White, 10, 10);
            }

            panel_settings.Update();
            pb_display.Invalidate();
        }
       
        private void btn_color_picker_Click(object sender, EventArgs e)
        {
            if (currentColorDialog != null)
                return;

            ColorDialog MyDialog = new();
            MyDialog.AllowFullOpen = true;
            MyDialog.ShowHelp = false;
            MyDialog.AnyColor = true;
            MyDialog.SolidColorOnly = false;
            MyDialog.Color = settings.color;

            currentColorDialog = Task.Run(() =>
            {
                // Update the text box color if the user clicks OK 
                if (MyDialog.ShowDialog(Owner) == DialogResult.OK)
                    settings.color = MyDialog.Color;

                currentColorDialog = null;
            });
        }

        private void tb_color_alpha_TextChanged(object sender, EventArgs e)
        {   
            if (int.TryParse(tb_color_alpha.Text, out int alpha))
                settings.color = Color.FromArgb(Math.Clamp(alpha, 0, 255), settings.color);
        }

        private void tb_amount_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(tb_amount.Text, out int amount))
                settings.amount = amount;
        }

        private void tb_speed_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(tb_speed.Text, out float speed))
                settings.speed = speed;
        }

        private void tb_size_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(tb_size.Text, out float size))
                settings.size = size;
        }

        private void tb_angle_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(tb_angle.Text, out float angle))
                settings.angle = angle;
        }

        private void tb_thickness_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(tb_thickness.Text, out float thickness))
                settings.thickness = thickness;
        }
    }

    public enum Side
    {
        Left,
        Top,
        Right,
        Bottom,
    }

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
