using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Проект_к_школе
{
    public partial class Balls : Form
    {
        public Balls()
        {
            InitializeComponent();
        }
        List<Ball> ListOfBalls = new List<Ball>();
        Graphics g;
        SolidBrush Brush;

        private void timer1_Tick(object sender, EventArgs e)
        {

            g = Graphics.FromImage(Field.Image);
            Brush = new SolidBrush(Color.Black);

            g.Clear(Color.AntiqueWhite);

            foreach (var i in ListOfBalls)
            {
                Brush.Color = i.BallColor;
                i.Tick(Field.DisplayRectangle);
                g.FillEllipse(Brush, (float)i.X, (float)i.Y, i.Size * 2, i.Size * 2);
            }
            Field.Refresh();
        }

        private void Field_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && ListOfBalls.Count != 0)
            {
                ListOfBalls.RemoveRange(0, ListOfBalls.Count > 0 ? 1 : ListOfBalls.Count);
                return;
            }
            Random r = new Random();
            Color C = Color.Black;

            switch (r.Next(0, 10))
            {
                case 1:
                    C = Color.Green;
                    break;
                case 2:
                    C = Color.Green;
                    break;
                case 3:
                    C = Color.Gold;
                    break;
                case 4:
                    C = Color.Goldenrod;
                    break;
                case 5:
                    C = Color.Khaki;
                    break;
                case 6:
                    C = Color.LightBlue;
                    break;
                case 7:
                    C = Color.LawnGreen;
                    break;
                case 8:
                    C = Color.MediumSpringGreen;
                    break;
                case 9:
                    C = Color.DarkMagenta;
                    break;
                case 10:
                    C = Color.Navy;
                    break;
            }
            ListOfBalls.Add(new Ball()
            {
                Curner = r.Next(0, 360),
                Speed = r.Next(1, 10),
                Size = r.Next(10, 30),
                X = PointToClient(MousePosition).X,
                Y = PointToClient(MousePosition).Y,
                BallColor = C
            });

            if (ListOfBalls[ListOfBalls.Count - 1].X + ListOfBalls[ListOfBalls.Count - 1].Size * 2 > Field.Right
                || ListOfBalls[ListOfBalls.Count - 1].Y + ListOfBalls[ListOfBalls.Count - 1].Size * 2 > Field.Bottom
                || ListOfBalls[ListOfBalls.Count - 1].X < Field.Left
                || ListOfBalls[ListOfBalls.Count - 1].Y < Field.Top)
                ListOfBalls.RemoveAt(ListOfBalls.Count - 1);

        }

        private void Balls_Resize(object sender, EventArgs e)
        {
            foreach (var i in ListOfBalls)
            {
                i.X = Size.Width / 2;
                i.Y = Size.Height / 2;
            }
        }
    }

    class Ball
    {
        internal int Curner, Size, Speed;
        internal double X, Y;
        internal Color BallColor = Color.Black;

        void CountCoordinats(out double NextX, out double NextY)
        {
            if (Curner < 90)
            {
                NextX = X + Math.Sin(Curner) * Speed;
                NextY = Y - Math.Cos(Curner) * Speed;
            }
            else if (Curner > 90 && Curner < 180)
            {
                NextX = X + Math.Cos(Curner - 90) * Speed;
                NextY = Y + Math.Sin(Curner - 90) * Speed;
            }
            else if (Curner > 180 && Curner < 270)
            {
                NextX = X - Math.Sin(Curner - 180) * Speed;
                NextY = Y + Math.Cos(Curner - 180) * Speed;
            }
            else if (Curner > 270)
            {
                NextX = X - Math.Cos(Curner - 270) * Speed;
                NextY = Y - Math.Sin(Curner - 270) * Speed;
            }
            else if (Curner == 0)
            {
                NextX = X;
                NextY = Y - Speed;
            }
            else if (Curner == 90)
            {
                NextX = X + Speed;
                NextY = Y;
            }
            else if (Curner == 180)
            {
                NextX = X;
                NextY = Y + Speed;
            }
            else if (Curner == 270)
            {
                NextX = X - Speed;
                NextY = Y;
            }
            else
            {
                NextX = 0;
                NextY = 0;
            }
        }

        public void Tick(Rectangle Border)
        {
            double NextX = 0, NextY = 0;
            Random r = new Random();
            CountCoordinats(out NextX, out NextY);

            while (NextX + Size * 2> Border.Right || NextY + Size * 2 > Border.Bottom
                || NextX < Border.Left || NextY < Border.Top)
            {
                int k = r.Next(-360, 360);
                Curner = (Curner + k) % 360;
                CountCoordinats(out NextX, out NextY);
            }

            X = NextX;
            Y = NextY;

        }
    }
}
